import React from 'react';
import { Button } from 'reactstrap';
import { useNavigate } from 'react-router-dom';
import { FaHome } from 'react-icons/fa';

function GoHomeButton() {
  const navigate = useNavigate();

  return (
    <div style={{ position: 'fixed', bottom: '20px', left: '20px', zIndex: '1000' }}>
      <Button color="primary" onClick={() => navigate('/')} className="d-flex align-items-center gap-2">
        <FaHome /> Ana Sayfaya Dön
      </Button>
    </div>
  );
}

export default GoHomeButton;
