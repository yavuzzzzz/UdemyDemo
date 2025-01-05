import React from 'react';
import { useForm } from 'react-hook-form';
import { useNavigate } from 'react-router-dom';
import alertify from 'alertifyjs';

function Login({ setAuth, userInfo, setCart }) {
  const { register, handleSubmit } = useForm();
  const navigate = useNavigate();

  const onSubmit = (data) => {
    // Kullanıcı bilgileri kontrolü
    if (!userInfo || !userInfo.email || !userInfo.password) {
      alertify.error('Kayıtlı kullanıcı bilgisi bulunamadı!');
      return;
    }

    if (!data.email.trim() || !data.password.trim()) {
      alertify.error('Email ve şifre boş bırakılamaz!');
      return;
    }

    if (data.email.trim() === userInfo.email && data.password.trim() === userInfo.password) {
      alertify.success('Giriş başarılı!');
      setAuth(true);

      // LocalStorage'dan sepet bilgilerini yükleme
      const savedCart = localStorage.getItem('redirectedCart');
      if (savedCart) {
        setCart(JSON.parse(savedCart)); // LocalStorage'dan alınan sepeti state'e yükle
        alertify.success('Sepetiniz geri yüklendi.');
        localStorage.removeItem('redirectedCart'); // Yükledikten sonra localStorage'dan temizle
      }

      navigate('/');
    } else {
      alertify.error('Geçersiz email veya şifre.');
    }
  };

  return (
    <div className="d-flex justify-content-center align-items-center" style={{ height: '100vh' }}>
      <form onSubmit={handleSubmit(onSubmit)} style={{ width: '300px' }}>
        <h3 className="text-center mb-4">Giriş Yap</h3>
        <div className="mb-3">
          <input
            className="form-control"
            {...register('email')}
            placeholder="Email"
            type="email"
            required
          />
        </div>
        <div className="mb-3">
          <input
            className="form-control"
            {...register('password')}
            placeholder="Şifre"
            type="password"
            required
          />
        </div>
        <button className="btn btn-primary w-100" type="submit">
          Giriş Yap
        </button>
      </form>
    </div>
  );
}

export default Login;
