import React from 'react';
import ReactDOM from 'react-dom/client'; 
import App from './App';
import 'bootstrap/dist/css/bootstrap.min.css';
import './assets/styles/global.css';
import 'alertifyjs/build/css/alertify.min.css';
import 'alertifyjs/build/css/themes/bootstrap.min.css';


const root = ReactDOM.createRoot(document.getElementById('root')); // Yeni createRoot
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
