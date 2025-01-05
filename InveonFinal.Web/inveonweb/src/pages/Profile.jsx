import React, { useState } from 'react';
import { Card, CardBody, CardTitle, CardText, Input, Button } from 'reactstrap';
import { FaEdit } from 'react-icons/fa';
import alertify from 'alertifyjs';
import { GoHome } from 'react-icons/go';
import GoHomeButton from '../components/GoHomeButton';

function Profile({ userInfo, setUserInfo }) {
  const [editableField, setEditableField] = useState(null); // Düzenlenmekte olan alan
  const [editedValue, setEditedValue] = useState(''); // Yeni değer

  const handleEditClick = (field) => {
    setEditableField(field); // Düzenlenebilir alanı belirle
    setEditedValue(userInfo[field]); // Mevcut değeri input'a yükle
  };

  const handleSaveClick = () => {
    if (editedValue.trim() === '') {
      alertify.error('Değer boş olamaz!');
      return;
    }
  
    const fieldLabels = {
      name: 'Ad',
      email: 'Email',
      password: 'Şifre',
    };
  
    // Kullanıcı bilgilerini güncelle
    setUserInfo({ ...userInfo, [editableField]: editedValue });
    alertify.success(`${fieldLabels[editableField]} başarıyla güncellendi!`);
    setEditableField(null); // Düzenleme modunu kapat
  };
  

  return (
    <div className="container py-5">
      <h2 className="text-center mb-5">Profil Bilgileriniz</h2>
      <Card className="mb-4 shadow">
        <CardBody>
          {/* Ad */}
          <div className="d-flex justify-content-between align-items-center mb-3">
            <span>Ad:</span>
            {editableField === 'name' ? (
              <>
                <Input
                  type="text"
                  value={editedValue}
                  onChange={(e) => setEditedValue(e.target.value)}
                  style={{ width: '60%' }}
                />
                <Button color="success" onClick={handleSaveClick} className="ms-2">
                  Kaydet
                </Button>
              </>
            ) : (
              <span>{userInfo.name}</span>
            )}
            <Button color="warning" size="sm" onClick={() => handleEditClick('name')}>
              <FaEdit />
            </Button>
          </div>

          {/* Email */}
          <div className="d-flex justify-content-between align-items-center mb-3">
            <span>Email:</span>
            {editableField === 'email' ? (
              <>
                <Input
                  type="email"
                  value={editedValue}
                  onChange={(e) => setEditedValue(e.target.value)}
                  style={{ width: '60%' }}
                />
                <Button color="success" onClick={handleSaveClick} className="ms-2">
                  Kaydet
                </Button>
              </>
            ) : (
              <span>{userInfo.email}</span>
            )}
            <Button color="warning" size="sm" onClick={() => handleEditClick('email')}>
              <FaEdit />
            </Button>
          </div>

          {/* Şifre */}
          <div className="d-flex justify-content-between align-items-center mb-3">
            <span>Şifre:</span>
            {editableField === 'password' ? (
              <>
                <Input
                  type="password"
                  value={editedValue}
                  onChange={(e) => setEditedValue(e.target.value)}
                  style={{ width: '60%' }}
                />
                <Button color="success" onClick={handleSaveClick} className="ms-2">
                  Kaydet
                </Button>
              </>
            ) : (
              <span>****</span>
            )}
            <Button color="warning" size="sm" onClick={() => handleEditClick('password')}>
              <FaEdit />
            </Button>
          </div>
        </CardBody>
      </Card>

      <h3 className="text-center mb-4">Satın Alınan Kurslar</h3>
      {userInfo.purchasedCourses && userInfo.purchasedCourses.length > 0 ? (
        userInfo.purchasedCourses.map((course) => (
          <Card key={course.id} className="mb-3">
            <CardBody>
              <CardTitle tag="h5">{course.name}</CardTitle>
              <CardText>{course.description}</CardText>
              <CardText className="fw-bold">Fiyat: {course.price}₺</CardText>
            </CardBody>
          </Card>
        ))
      ) : (
        <p className="text-center">Henüz bir kurs satın almadınız.</p>
      )}  
      <GoHomeButton />
    </div>
  );

}

export default Profile;
