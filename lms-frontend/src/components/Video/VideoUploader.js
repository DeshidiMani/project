import React, { useState } from 'react';
import axios from '../../services/api';

const VideoUploader = ({ courseId }) => {
  const [videoFile, setVideoFile] = useState(null);
  const [message, setMessage] = useState(null);
  const [error, setError] = useState(null);

  const handleFileChange = (e) => {
    setVideoFile(e.target.files[0]);
  };

  const handleUpload = async () => {
    const formData = new FormData();
    formData.append('video', videoFile);
    formData.append('courseId', courseId);
    try {
      await axios.post('/videos/upload', formData, { headers: { 'Content-Type': 'multipart/form-data' } });
      setMessage('Video uploaded successfully!');
    } catch (err) {
      setError('Error uploading video.');
    }
  };

  return (
    <div className="card p-4">
      <h2 className="mb-3">Upload Video Lesson</h2>
      {message && <div className="alert alert-success">{message}</div>}
      {error && <div className="alert alert-danger">{error}</div>}
      <input type="file" className="form-control mb-2" onChange={handleFileChange} />
      <button onClick={handleUpload} className="btn btn-primary">Upload Video</button>
    </div>
  );
};

export default VideoUploader;
