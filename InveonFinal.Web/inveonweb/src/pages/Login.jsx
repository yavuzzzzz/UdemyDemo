import React from 'react';
import { useForm } from 'react-hook-form';
import { useNavigate } from 'react-router-dom';
import alertify from 'alertifyjs';

function Login({ setAuth, userInfo, setCart }) {
  const { register, handleSubmit } = useForm();
  const navigate = useNavigate();
  const redirectedCart = JSON.parse(localStorage.getItem('redirectedCart')) || [];
  const setRedirectedCart = (cart) => localStorage.setItem('redirectedCart', JSON.stringify(cart));

  const onSubmit = (data) => {
    if (data.email.trim() === userInfo.email && data.password.trim() === userInfo.password) {
      alertify.success('Giriş başarılı!');
      setAuth(true);
      localStorage.setItem('isAuthenticated', 'true');
  
      if (redirectedCart.length > 0) {
        setCart(redirectedCart); // `redirectedCart` bilgilerini yükle
        alertify.success('Sepetiniz geri yüklendi.');
        setRedirectedCart([]); // Yükleme sonrası temizle
        localStorage.removeItem('redirectedCart');
      }
  
      navigate('/');
    } else {
      alertify.error('Geçersiz email veya şifre.');
    }
  };
  

  return (
    <div className="d-flex justify-content-center align-items-center" style={{ height: '100vh' }}>
      <div
        className="p-4 shadow"
        style={{
          border: '2px solid #6c757d', // İnce çerçeve
          borderRadius: '10px',
          maxWidth: '400px',
          width: '100%',
        }}
      >
        <h2 className="text-center mb-4" style={{ color: '#6c757d' }}>Bookify'a Hoş Geldiniz!</h2>
        <form onSubmit={handleSubmit(onSubmit)} style={{ width: '100%' }}>
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
    </div>
  );
}

export default Login;
