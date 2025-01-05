import React from 'react';
import { Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';

function CourseCard({ course, onDetail }) {
  return (
    <Card>
      <img alt={course.name} src={course.image} style={{ width: '100%', height: '200px', objectFit: 'cover' }} />
      <CardBody>
        <CardTitle tag="h5">{course.name}</CardTitle>
        <CardText>{course.description}</CardText>
        <CardText className="fw-bold">Fiyat: {course.price}₺</CardText>
        <Button color="primary" onClick={onDetail}>
          Detaylara Git
        </Button>
      </CardBody>
    </Card>
  );
}

export default CourseCard;
