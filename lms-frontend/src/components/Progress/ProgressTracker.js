import React, { useEffect, useState } from 'react';
import axios from '../../services/api';

const ProgressTracker = ({ courseId }) => {
  const [progress, setProgress] = useState(null);
  const [error, setError] = useState(null);

  // Hardcoded userId = 1 for demo; replace with dynamic value from auth state.
  useEffect(() => {
    const fetchProgress = async () => {
      try {
        const response = await axios.get(`/progress/1/${courseId}`);
        setProgress(response.data.data);
      } catch (err) {
        setError('Error fetching progress.');
      }
    };
    fetchProgress();
  }, [courseId]);

  return (
    <div className="card p-4">
      <h2 className="mb-3">Progress Tracker</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      {progress ? (
        <p>Completion: {progress.completionPercentage}%</p>
      ) : (
        <p>Loading progress...</p>
      )}
    </div>
  );
};

export default ProgressTracker;
