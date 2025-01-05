import React, { useEffect } from 'react';
import { Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';
import { useNavigate } from 'react-router-dom';
import alertify from 'alertifyjs';
import { GoHome } from 'react-icons/go';
import GoHomeButton from '../components/GoHomeButton';

function Basket({ cart, setCart, isAuthenticated, setRedirectedCart }) {
  const navigate = useNavigate();

  useEffect(() => {
    // Kullanıcı giriş yapmadan sepette işlem yaparsa login sayfasına yönlendir
    if (!isAuthenticated && cart.length > 0) {
      alertify.warning('Sepette işlem yapmak için giriş yapmalısınız!');
      localStorage.setItem('redirectedCart', JSON.stringify(cart)); // Sepeti localStorage'a kaydet
      setRedirectedCart(cart);
      navigate('/login');
    }
  }, [isAuthenticated, cart, navigate, setRedirectedCart]);
  

  const handleIncreaseQuantity = (id) => {
    setCart(
      cart.map((item) =>
        item.id === id ? { ...item, quantity: item.quantity + 1 } : item
      )
    );
    alertify.success('Seçilen üründen 1 adet daha satın aldınız!');
  };

  const handleDecreaseQuantity = (id) => {
    const selectedItem = cart.find((item) => item.id === id);
    if (selectedItem.quantity === 1) {
      setCart(cart.filter((item) => item.id !== id));
      alertify.error('Ürün sepetten çıkarıldı!');
    } else {
      setCart(
        cart.map((item) =>
          item.id === id ? { ...item, quantity: item.quantity - 1 } : item
        )
      );
      alertify.warning('Seçilen üründen bir adet bıraktınız!');
    }
  };

  const totalAmount = cart.reduce((total, item) => total + item.price * item.quantity, 0);

  return (
    <div className="container py-5">
      <h2 className="text-center mb-5">Sepetiniz</h2>
      {cart.length > 0 ? (
        cart.map((course) => (
          <Card className="mb-4" key={course.id}>
            <CardBody className="d-flex justify-content-between align-items-center">
              <div>
                <CardTitle tag="h5">{course.name}</CardTitle>
                <CardText>
                  Fiyat: {course.price}₺ x {course.quantity} = {course.price * course.quantity}₺
                </CardText>
              </div>
              <div>
                <Button
                  color="success"
                  onClick={() => handleIncreaseQuantity(course.id)}
                  className="me-2"
                >
                  +
                </Button>
                <Button
                  color="danger"
                  onClick={() => handleDecreaseQuantity(course.id)}
                >
                  -
                </Button>
              </div>
            </CardBody>
          </Card>
        ))
      ) : (
        <div className="text-center py-5">
          <h4>Sepetiniz Boş</h4>
        </div>
      )}

      {/* Sepet toplam tutar ve ödeme butonu */}
      {cart.length > 0 && (
        <div style={{ position: 'fixed', bottom: '20px', right: '20px' }}>
          <Button color="success" size="lg" onClick={() => navigate('/checkout')}>
            Ödeme Yap ({totalAmount}₺)
          </Button>
        </div>
      )}

      <GoHomeButton></GoHomeButton>
    </div>
  );
}

export default Basket;
