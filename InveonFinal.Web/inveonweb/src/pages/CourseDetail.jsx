import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Card, CardBody, CardTitle, CardText, Button, Spinner } from 'reactstrap';
import alertify from 'alertifyjs';
import seedData from '../data/SeedData';
import GoHomeButton from '../components/GoHomeButton';

function CourseDetail({ cart, setCart }) {
  const { id } = useParams(); // URL'den kurs ID'sini alıyoruz
  const navigate = useNavigate();
  const [course, setCourse] = useState(null);
  const [quantity, setQuantity] = useState(1); // Başlangıç miktarı
  const [loading, setLoading] = useState(true);
  const [showGoToCart, setShowGoToCart] = useState(false); // Sepete Git butonunu gösterme durumu

  useEffect(() => {
    setLoading(true);
    setTimeout(() => {
      const selectedCourse = seedData.find((c) => c.id === id);
      setCourse(selectedCourse);
      setLoading(false);
    }, 1000);
  }, [id]);

  const handleIncrease = () => {
    setQuantity(quantity + 1);
    alertify.success('Seçilen üründen 1 adet daha satın aldınız!');
    setShowGoToCart(true); // "+" butonuna basılınca "Sepete Git" butonunu göster
  };

  const handleDecrease = () => {
    if (quantity > 1) {
      setQuantity(quantity - 1);
      alertify.warning('Seçilen üründen bir adet bıraktınız!');
    } else {
      const updatedCart = cart.filter((item) => item.id !== course.id);
      setCart(updatedCart); // Ürünü sepetten çıkar
      alertify.error('Ürün sepetten çıkarıldı!');

      // Eğer sepet boşsa yönlendirme
      if (updatedCart.length === 0) {
        alertify.warning('Sepetinizde ürün bulunmamaktadır.');
        navigate('/'); // Ana sayfaya yönlendir
      }
    }
  };

  const handleAddToCart = () => {
    const existingItem = cart.find((item) => item.id === course.id);
    if (existingItem) {
      setCart(cart.map((item) => (item.id === course.id ? { ...item, quantity: item.quantity + quantity } : item)));
    } else {
      setCart([...cart, { ...course, quantity }]);
    }
    alertify.success('Ürün sepete eklendi.');
    setShowGoToCart(true); // Sepete ekle ile "Sepete Git" butonunu göster
  };

  return (
    <div className="container py-5">
      {loading ? (
        <div className="d-flex justify-content-center align-items-center" style={{ height: '50vh' }}>
          <Spinner color="primary" style={{ width: '3rem', height: '3rem' }} />
        </div>
      ) : course ? (
        <Card className="shadow-lg p-4" style={{ maxWidth: '600px', margin: 'auto' }}>
          <CardBody className="text-center">
            <CardTitle tag="h3">{course.name}</CardTitle>
            <CardText>{course.description}</CardText>
            <CardText className="fw-bold">Kategori: {course.category}</CardText>
            <CardText className="fw-bold text-success">Fiyat: {course.price}₺</CardText>

            <div className="d-flex justify-content-center align-items-center mb-4">
              <Button color="success" onClick={handleIncrease} className="me-2">
                +
              </Button>
              <span className="fw-bold">{quantity}</span>
              <Button color="danger" onClick={handleDecrease} className="ms-2">
                -
              </Button>
            </div>

            {/* Sepete Ekle Butonu - Küçük ve Sol Hizalanmış */}
            <div className="d-flex justify-content-between align-items-center">
              <Button
                color="primary"
                onClick={handleAddToCart}
                className="me-auto"
                style={{ width: '150px', fontSize: '14px' }}
              >
                Sepete Ekle
              </Button>

              {/* Sepete Git Butonu */}
              {showGoToCart && (
                <Button
                  color="warning"
                  className="ms-3"
                  style={{ fontSize: '14px' }}
                  onClick={() => navigate('/basket')}
                >
                  Sepete Git
                </Button>
              )}
            </div>
          </CardBody>
        </Card>
      ) : (
        <p>Kurs bulunamadı.</p>
      )}
      <GoHomeButton></GoHomeButton>
    </div>
  );
}

export default CourseDetail;
