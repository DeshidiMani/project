import React, { useState, useEffect } from 'react';
import axios from '../../services/api';

const AssignmentGradePanel = ({ assignmentId }) => {
  const [submissions, setSubmissions] = useState([]);
  const [grade, setGrade] = useState('');
  const [message, setMessage] = useState(null);
  const [error, setError] = useState(null);

  // This endpoint is assumed to be available –
  // if not, please implement GET /assignments/{assignmentId}/submissions in your backend.
  useEffect(() => {
    const fetchSubmissions = async () => {
      try {
        const response = await axios.get(`/assignments/${assignmentId}/submissions`);
        setSubmissions(response.data.data);
      } catch (err) {
        setError('Error fetching submissions.');
      }
    };
    fetchSubmissions();
  }, [assignmentId]);

  const handleGradeSubmit = async (submissionId) => {
    try {
      await axios.put('/instructor/grade-assignment', { submissionId, grade });
      setMessage('Grade submitted successfully!');
    } catch (err) {
      setError('Error submitting grade.');
    }
  };

  return (
    <div className="card p-4 mt-4">
      <h2 className="mb-3">Grade Assignment Submissions</h2>
      {message && <div className="alert alert-success">{message}</div>}
      {error && <div className="alert alert-danger">{error}</div>}
      <table className="table">
        <thead>
          <tr>
            <th>Submission ID</th>
            <th>Student ID</th>
            <th>Submission Text</th>
            <th>Current Grade</th>
            <th>New Grade</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {submissions.map(sub => (
            <tr key={sub.id}>
              <td>{sub.id}</td>
              <td>{sub.studentId}</td>
              <td>{sub.submissionText}</td>
              <td>{sub.grade !== null ? sub.grade : 'Not graded'}</td>
              <td>
                <input
                  type="number"
                  className="form-control"
                  placeholder="Enter grade"
                  value={grade}
                  onChange={(e) => setGrade(e.target.value)}
                />
              </td>
              <td>
                <button className="btn btn-sm btn-primary" onClick={() => handleGradeSubmit(sub.id)}>Submit Grade</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default AssignmentGradePanel;
