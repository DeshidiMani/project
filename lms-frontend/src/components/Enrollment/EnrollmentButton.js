import React, { useState } from 'react';
import axios from '../../services/api';

const EnrollmentButton = ({ courseId }) => {
  const [message, setMessage] = useState(null);
  const [error, setError] = useState(null);

  const handleEnrollment = async () => {
    try {
      await axios.post('/enrollments', { courseId });
      setMessage('Enrollment successful!');
    } catch (err) {
      setError('Error enrolling in course.');
    }
  };

  return (
    <div className="mb-3">
      <button onClick={handleEnrollment} className="btn btn-success">Enroll in Course</button>
      {message && <div className="alert alert-success mt-2">{message}</div>}
      {error && <div className="alert alert-danger mt-2">{error}</div>}
    </div>
  );
};

export default EnrollmentButton;
