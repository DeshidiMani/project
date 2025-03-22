import React from 'react';

const VideoPlayer = ({ videoUrl }) => {
  return (
    <div className="card p-4">
      <h2 className="mb-3">Video Lesson</h2>
      <video className="w-100" controls>
        <source src={videoUrl} type="video/mp4" />
        Your browser does not support the video tag.
      </video>
    </div>
  );
};

export default VideoPlayer;
