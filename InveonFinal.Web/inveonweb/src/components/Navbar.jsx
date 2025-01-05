import React from 'react';
import { NavLink } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser, faShoppingCart, faSignOutAlt, faSignInAlt, faUserPlus, faHome } from '@fortawesome/free-solid-svg-icons';

function Navbar({ isAuthenticated, onLogout, cart }) {
  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <div className="container">
        <NavLink className="navbar-brand" to="/">
          <FontAwesomeIcon icon={faHome} className="me-2" />
          Bookify
        </NavLink>
        <div className="collapse navbar-collapse">
          <ul className="navbar-nav ms-auto">
            {isAuthenticated ? (
              <>
                <li className="nav-item">
                  <NavLink className="nav-link" to="/profile">
                    <FontAwesomeIcon icon={faUser} className="me-2" />
                    Profil
                  </NavLink>
                </li>
                <li className="nav-item">
                  <NavLink className="nav-link" to="/basket">
                    <FontAwesomeIcon icon={faShoppingCart} className="me-2" />
                    Sepet ({cart.length})
                  </NavLink>
                </li>
                <li className="nav-item">
                  <button className="btn btn-danger nav-link" onClick={onLogout}>
                    <FontAwesomeIcon icon={faSignOutAlt} className="me-2" />
                    Çıkış Yap
                  </button>
                </li>
              </>
            ) : (
              <>
                <li className="nav-item">
                  <NavLink className="nav-link" to="/register">
                    <FontAwesomeIcon icon={faUserPlus} className="me-2" />
                    Kayıt Ol
                  </NavLink>
                </li>
                <li className="nav-item">
                  <NavLink className="nav-link" to="/login">
                    <FontAwesomeIcon icon={faSignInAlt} className="me-2" />
                    Giriş Yap
                  </NavLink>
                </li>
              </>
            )}
          </ul>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;
