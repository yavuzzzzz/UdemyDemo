import React from 'react';
import { Modal, ModalHeader, ModalBody, ModalFooter, Button } from 'reactstrap';

function PaymentModal({ isOpen, toggle }) {
  const handlePayment = () => {
    alertify.success('Ödeme işlemi başarılı!');
    toggle();
  };

  return (
    <Modal isOpen={isOpen} toggle={toggle}>
      <ModalHeader>Ödeme Bilgileri</ModalHeader>
      <ModalBody>
        <p>Kredi Kartı Bilgileri Giriniz:</p>
        <input placeholder="Kart Numarası" />
      </ModalBody>
      <ModalFooter>
        <Button color="success" onClick={handlePayment}>Ödemeyi Tamamla</Button>
        <Button onClick={toggle}>İptal</Button>
      </ModalFooter>
    </Modal>
  );
}

export default PaymentModal;
