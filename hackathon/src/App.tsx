import React from 'react';
import './App.css';
import Login from './Components/Login';
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Search from './Components/Search';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <div>
          <header className="App-header">
            <Routes>
              <Route path="/" element={<Navigate replace to="/login" />} />             
              <Route path="/login" element={<Login/>} />
              <Route path="/search" element={<Search/>} />
            </Routes>
          </header>
        </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
