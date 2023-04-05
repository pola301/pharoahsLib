import React from 'react';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import Login from './Login';
import Registeration from './registeration';
import Dashboard from './users/Dashboard';
import Orders from './users/Orders';
import Profile from './users/Profile';
import Cart from './users/Cart';
import BooksDisplay from './users/BooksDisplay';
import AdminDashboard from './Admin/AdminDashboard';
import AdminOrders from './Admin/AdminOrders';
import Books from './Admin/Books';
import UserList from './admin/UsersList';

export default function RouterPage(){
    return(
        <Router>
            <Routes>
                <Route path = '/' element = {<Login />}/>
                <Route path = '/registeration' element = {<Registeration />}/>
                <Route path = '/dashboard' element = {<Dashboard />}/>
                <Route path = '/myorders' element = {<Orders />}/>
                <Route path = '/profile' element = {<Profile />}/>
                <Route path = '/cart' element = {<Cart />}/>
                <Route path = '/products' element = {<BooksDisplay />}/>
                <Route path = '/admindashboard' element = {<AdminDashboard />}/>
                <Route path = '/adminorders' element = {<AdminOrders />}/>
                <Route path = '/books' element = {<Books />}/>
                <Route path = '/users' element = {<UserList />}/>


            </Routes>
        </Router>
        )
}