import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Button } from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTimesCircle } from '@fortawesome/free-solid-svg-icons';

function NotFound() {
  const navigate = useNavigate();

  return (
    <div
      className="d-flex flex-column justify-content-center align-items-center"
      style={{ height: '100vh', backgroundColor: '#f8d7da' }}
    >
      <FontAwesomeIcon
        icon={faTimesCircle}
        style={{ color: 'red', fontSize: '120px', marginBottom: '20px' }}
      />
      <h1 style={{ color: '#842029', fontWeight: 'bold', marginBottom: '20px' }}>
        Aradığınız Sayfa Bulunamadı :(
      </h1>
      <Button
        color="danger"
        size="lg"
        onClick={() => navigate('/')}
        style={{ borderRadius: '20px' }}
      >
        Ana Sayfaya Dön
      </Button>
    </div>
  );
}

export default NotFound;
