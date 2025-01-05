import React from 'react';
import { Navbar, NavbarBrand, Nav, NavItem, NavLink, Button, Badge } from 'reactstrap';
import { useNavigate } from 'react-router-dom';

function AppNavbar({ isAuthenticated, onLogout, cart }) {
  const navigate = useNavigate();
  const totalQuantity = cart.reduce((total, item) => total + item.quantity, 0); // Toplam miktar

  const handleLogoClick = () => {
    navigate(isAuthenticated ? '/' : '/login');
  };

  return (
    <Navbar color="primary" dark expand="md" className="px-4">
      <NavbarBrand onClick={handleLogoClick} style={{ cursor: 'pointer', fontWeight: 'bold' }}>
        Bookify
      </NavbarBrand>
      <Nav className="ms-auto" navbar>
        {isAuthenticated ? (
          <>
            <NavItem>
              <NavLink onClick={() => navigate('/profile')} style={{ cursor: 'pointer', color: 'white' }}>
                Profile
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink onClick={() => navigate('/basket')} style={{ cursor: 'pointer', color: 'white' }}>
                Sepet <Badge color="warning">{totalQuantity}</Badge>
              </NavLink>
            </NavItem>
            <NavItem>
              <Button color="light" size="sm" onClick={onLogout}>
                Log Out
              </Button>
            </NavItem>
          </>
        ) : (
          <>
            <NavItem>
              <NavLink onClick={() => navigate('/register')} style={{ cursor: 'pointer', color: 'white' }}>
                Register
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink onClick={() => navigate('/login')} style={{ cursor: 'pointer', color: 'white' }}>
                Log In
              </NavLink>
            </NavItem>
          </>
        )}
      </Nav>
    </Navbar>
  );
}

export default AppNavbar;
