import React from 'react';
import { useForm } from 'react-hook-form';
import { useNavigate } from 'react-router-dom';
import alertify from 'alertifyjs';

function Register({ setUserInfo }) {
  const { register, handleSubmit } = useForm();
  const navigate = useNavigate();

  const onSubmit = (data) => {
    setUserInfo(data);
    localStorage.setItem('userInfo', JSON.stringify(data)); 
    alertify.success('Kayıt başarılı!');
    navigate('/login');
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
          <h3 className="text-center mb-4">Kayıt Ol</h3>
          <div className="mb-3">
            <input
              className="form-control"
              {...register('name')}
              placeholder="Ad Soyad"
              type="text"
              required
            />
          </div>
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
            Kayıt Ol
          </button>
        </form>
      </div>
    </div>
  );
}

export default Register;
