import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import AuthComponent from './components/AuthComponent';
import './index.css';

ReactDOM.render(
    <BrowserRouter>
        <AuthComponent/>
    </BrowserRouter>,
    document.getElementById('root')
);
