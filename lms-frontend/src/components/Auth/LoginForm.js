import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { login } from '../../redux/slices/authSlice';
import { useNavigate } from 'react-router-dom';

const LoginForm = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const result = await dispatch(login({ email, password })).unwrap();
      console.log("Login result:", result); // Debugging the payload

      const userRole = result?.data?.user?.role; // Accessing the role correctly
      if (userRole === "Student") {
        navigate('/dashboard/student');
      } else if (userRole === "Instructor") {
        navigate('/dashboard/instructor');
      } else if (userRole === "Admin") {
        navigate('/dashboard/admin');
      } else {
        setError('Unable to determine user role. Please contact support.');
      }
    } catch (err) {
      setError('Invalid credentials, please try again.');
      console.error("Login Error:", err);
    }
  };

  return (
    <div className="card p-4">
      <h2 className="mb-4">Login</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label>Email</label>
          <input
            type="email"
            className="form-control"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label>Password</label>
          <input
            type="password"
            className="form-control"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary">Login</button>
      </form>
    </div>
  );
};

export default LoginForm;