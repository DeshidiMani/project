import React, { useState, useEffect } from 'react';
import axios from '../../services/api';

const StudentProgressTracker = ({ courseId }) => {
  const [progressList, setProgressList] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchProgress = async () => {
      try {
        const response = await axios.get(`/instructor/progress/${courseId}`);
        setProgressList(response.data.data);
      } catch (err) {
        setError('Error fetching student progress.');
      }
    };
    fetchProgress();
  }, [courseId]);

  return (
    <div className="card p-4 mt-4">
      <h2 className="mb-3">Student Progress Tracker</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      <table className="table">
        <thead>
          <tr>
            <th>Student ID</th>
            <th>Completion (%)</th>
          </tr>
        </thead>
        <tbody>
          {progressList.map(p => (
            <tr key={p.userId}>
              <td>{p.userId}</td>
              <td>{p.completionPercentage}%</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default StudentProgressTracker;
