import React, { useEffect, useState } from 'react';
import axios from '../../services/api';

const AssignmentList = ({ courseId }) => {
  const [assignments, setAssignments] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchAssignments = async () => {
      try {
        const response = await axios.get(`/assignments/bycourse?courseId=${courseId}`);
        setAssignments(response.data.data);
      } catch (err) {
        setError('Error fetching assignments.');
      }
    };
    fetchAssignments();
  }, [courseId]);

  return (
    <div className="card p-4">
      <h2 className="mb-3">Assignments</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      <ul className="list-group">
        {assignments.map((assignment) => (
          <li key={assignment.id} className="list-group-item">
            <h5>{assignment.title} {assignment.isQuiz && <span className="badge bg-info">Quiz</span>}</h5>
            <p>{assignment.description}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default AssignmentList;
