import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from '../pages/Home';
import Login from '../pages/Login';
import Register from '../pages/Register';
import Profile from '../pages/Profile';
import Navbar from '../components/Navbar';
import Basket from '../pages/Basket';
import { useState, useEffect } from 'react';
import Checkout from '../pages/Checkout';
import CourseDetail from '../pages/CourseDetail';
import alertify from 'alertifyjs';
import NotFound from '../pages/NotFound';

function AppRouter() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [cart, setCart] = useState([]);
  const [redirectedCart, setRedirectedCart] = useState([]); // Yönlendirme sonrası sepeti tutmak için
  const [userInfo, setUserInfo] = useState({
    name: '',
    email: '',
    password: '',
    purchasedCourses: [],
  });

  useEffect(() => {
    const savedUser = localStorage.getItem('userInfo');
    if (savedUser) {
      setUserInfo(JSON.parse(savedUser));
    }

    const authStatus = localStorage.getItem('isAuthenticated');
    if (authStatus === 'true') {
      setIsAuthenticated(true);
    }

    const savedRedirectedCart = localStorage.getItem('redirectedCart');
    if (savedRedirectedCart) {
      setRedirectedCart(JSON.parse(savedRedirectedCart));
    }
  }, []);

  const handleLogout = () => {
    setIsAuthenticated(false);
    localStorage.removeItem('isAuthenticated'); 
    alertify.success('Çıkış Yapıldı!'); 
    setCart([]); 
  };

  return (
    <Router>
      <Navbar isAuthenticated={isAuthenticated} onLogout={handleLogout} cart={cart} />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/home" element={<Home />} />
        <Route
          path="/login"
          element={
            <Login
              setAuth={setIsAuthenticated}
              userInfo={userInfo}
              setCart={setCart}
              redirectedCart={redirectedCart}
              setRedirectedCart={setRedirectedCart}
            />
          }
        />
        <Route path="/register" element={<Register setUserInfo={setUserInfo} />} />
        <Route
          path="/profile"
          element={isAuthenticated ? <Profile userInfo={userInfo} setUserInfo={setUserInfo} /> : <Login />}
        />
        <Route
          path="/course/:id"
          element={<CourseDetail isAuthenticated={isAuthenticated} setCart={setCart} cart={cart} />}
        />
        <Route
          path="/basket"
          element={<Basket cart={cart} setCart={setCart} isAuthenticated={isAuthenticated} setRedirectedCart={setRedirectedCart} />}
        />
        <Route path="/checkout" element={<Checkout cart={cart} />} />

        <Route path="*" element={<NotFound />} />
      </Routes>
    </Router>
  );
}

export default AppRouter;
