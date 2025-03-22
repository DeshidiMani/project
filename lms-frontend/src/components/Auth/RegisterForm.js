import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { register } from '../../redux/slices/authSlice';

const RegisterForm = () => {
  const dispatch = useDispatch();
  const [form, setForm] = useState({
    name: '', email: '', password: '', role: 'Student'
  });
  const [message, setMessage] = useState(null);
  const [error, setError] = useState(null);

  const handleChange = (e) => {
    setForm({...form, [e.target.name]: e.target.value});
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const responseMessage = await dispatch(register(form)).unwrap();
      setMessage(responseMessage);
    } catch (err) {
      setError(err || 'Registration failed. Please try again.');
    }
  };

  return (
    <div className="card p-4">
      <h2 className="mb-4">Register</h2>
      {message && <div className="alert alert-success">{message}</div>}
      {error && <div className="alert alert-danger">{error}</div>}
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label>Name</label>
          <input 
            type="text" 
            className="form-control" 
            name="name" placeholder="Name" 
            value={form.name} onChange={handleChange} required />
        </div>
        <div className="mb-3">
          <label>Email</label>
          <input 
            type="email" 
            className="form-control" 
            name="email" placeholder="Email" 
            value={form.email} onChange={handleChange} required />
        </div>
        <div className="mb-3">
          <label>Password</label>
          <input 
            type="password" 
            className="form-control" 
            name="password" placeholder="Password" 
            value={form.password} onChange={handleChange} required />
        </div>
        <div className="mb-3">
          <label>Role</label>
          <select 
            className="form-select" 
            name="role"
            value={form.role} onChange={handleChange}>
            <option value="Student">Student</option>
            <option value="Instructor">Instructor</option>
          </select>
        </div>
        <button type="submit" className="btn btn-primary">Register</button>
      </form>
    </div>
  );
};

export default RegisterForm;
