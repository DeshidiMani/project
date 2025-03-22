import React, { useState } from 'react';
import axios from '../../services/api';

const CourseEditor = () => {
  const [form, setForm] = useState({
    title: '',
    description: '',
    category: '',
    difficulty: ''
  });
  const [message, setMessage] = useState(null);
  const [error, setError] = useState(null);

  const handleChange = (e) => {
    setForm({...form, [e.target.name]: e.target.value});
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await axios.post('/courses', form);
      setMessage('Course created successfully!');
    } catch (err) {
      setError('Error creating course.');
    }
  };

  return (
    <div className="card p-4">
      <h2 className="mb-4">Create Course</h2>
      {message && <div className="alert alert-success">{message}</div>}
      {error && <div className="alert alert-danger">{error}</div>}
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <input type="text" name="title" className="form-control" placeholder="Course Title" value={form.title} onChange={handleChange} required />
        </div>
        <div className="mb-3">
          <textarea name="description" className="form-control" placeholder="Description" value={form.description} onChange={handleChange} required />
        </div>
        <div className="mb-3">
          <input type="text" name="category" className="form-control" placeholder="Category" value={form.category} onChange={handleChange} required />
        </div>
        <div className="mb-3">
          <input type="text" name="difficulty" className="form-control" placeholder="Difficulty" value={form.difficulty} onChange={handleChange} required />
        </div>
        <button type="submit" className="btn btn-primary">Create Course</button>
      </form>
    </div>
  );
};

export default CourseEditor;
