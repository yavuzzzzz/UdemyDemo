import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Spinner } from 'reactstrap';
import CourseCard from '../components/CourseCard';
import seedData from '../data/SeedData';
import { useNavigate } from 'react-router-dom';

function Home() {
  const [courses, setCourses] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  useEffect(() => {
    setLoading(true);
    setTimeout(() => {
      setCourses(seedData);
      setLoading(false);
    }, 1000);
  }, []);

  return (
    <Container className="py-5">
      <h2 className="text-center mb-5">Kurslar</h2>
      {loading ? (
        <div className="d-flex justify-content-center align-items-center" style={{ height: '50vh' }}>
          <Spinner color="primary" style={{ width: '3rem', height: '3rem' }} />
        </div>
      ) : (
        <Row>
          {courses.map((course) => (
            <Col key={course.id} sm="6" md="4" className="mb-4">
              <CourseCard course={course} onDetail={() => navigate(`/course/${course.id}`)} />
            </Col>
          ))}
        </Row>
      )}
    </Container>
  );
}

export default Home;
