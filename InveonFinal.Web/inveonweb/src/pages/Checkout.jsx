import React from 'react';
import { useForm } from 'react-hook-form';
import { Button } from 'reactstrap';
import axios from 'axios';

function Checkout({ cart }) {
  const { register, handleSubmit } = useForm();
  const totalAmount = cart.reduce((total, item) => total + item.price * item.quantity, 0);

  const onSubmit = async (data) => {
    try {
      const response = await axios.post('http://localhost:4000/api/payment', {
        name: data.name,
        cardNumber: data.cardNumber,
        expiryDate: data.expiryDate,
        cvc: data.cvc,
        amount: totalAmount,
        cartItems: cart,
      });
      if (response.data.status === 'success') {
        alert('Ödeme başarılı! Teşekkürler.');
      } else {
        alert('Ödeme başarısız. Lütfen bilgilerinizi kontrol edin.');
      }
    } catch (error) {
      alert('Bir hata oluştu: ' + error.message);
    }
  };

  return (
    <div className="container py-5">
      <h2 className="text-center mb-4">Ödeme Formu</h2>
      <form onSubmit={handleSubmit(onSubmit)} style={{ maxWidth: '400px', margin: '0 auto' }}>
        <div className="mb-3">
          <label>Ad Soyad</label>
          <input className="form-control" {...register('name')} placeholder="Ad Soyad" required />
        </div>
        <div className="mb-3">
          <label>Kredi Kartı Numarası</label>
          <input
            className="form-control"
            {...register('cardNumber')}
            placeholder="**** **** **** ****"
            type="text"
            maxLength="16"
            required
          />
        </div>
        <div className="mb-3 d-flex justify-content-between">
          <div>
            <label>Son Kullanma Tarihi (AA/YY)</label>
            <input
              className="form-control"
              {...register('expiryDate')}
              placeholder="AA/YY"
              type="text"
              maxLength="5"
              required
            />
          </div>
          <div>
            <label>CVC</label>
            <input className="form-control" {...register('cvc')} placeholder="CVC" type="text" maxLength="3" required />
          </div>
        </div>
        <h5 className="mt-4">Toplam Tutar: {totalAmount}₺</h5>
        <Button type="submit" color="primary" className="w-100 mt-3">
          Ödeme Yap
        </Button>
      </form>
    </div>
  );
}

export default Checkout;
