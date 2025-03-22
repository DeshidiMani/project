import React, { useState } from 'react';
import axios from '../../services/api';

const AssignmentSubmit = ({ assignmentId }) => {
  const [submissionText, setSubmissionText] = useState('');
  const [message, setMessage] = useState(null);
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await axios.post(`/assignments/${assignmentId}/submit`, { submissionText });
      setMessage('Assignment submitted successfully!');
      setSubmissionText('');
    } catch (err) {
      setError('Error submitting assignment.');
    }
  };

  return (
    <div className="card p-4">
      <h2 className="mb-3">Submit Assignment/Quiz</h2>
      {message && <div className="alert alert-success">{message}</div>}
      {error && <div className="alert alert-danger">{error}</div>}
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <textarea 
            className="form-control"
            placeholder="Enter your answer here..."
            value={submissionText}
            onChange={(e) => setSubmissionText(e.target.value)}
            required 
          />
        </div>
        <button type="submit" className="btn btn-primary">Submit</button>
      </form>
    </div>
  );
};

export default AssignmentSubmit;
