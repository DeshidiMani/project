import React from 'react';
import { Link } from 'react-router-dom';

const Home = () => {
  return (
    <div className="text-center mt-4">
      <h1>Welcome to LMS Portal</h1>
      <p>Please login or register to get started.</p>
      <div className="d-flex justify-content-center gap-3">
        <Link to="/login" className="btn btn-primary">Login</Link>
        <Link to="/register" className="btn btn-secondary">Register</Link>
      </div>
    </div>
  );
};

export default Home;
