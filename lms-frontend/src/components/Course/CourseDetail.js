import React, { useEffect, useState } from 'react';
import axios from '../../services/api';

const CourseDetail = ({ courseId }) => {
  const [course, setCourse] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchCourse = async () => {
      try {
        const response = await axios.get(`/courses/${courseId}`);
        setCourse(response.data.data);
      } catch (err) {
        setError('Error fetching course details.');
      }
    };
    fetchCourse();
  }, [courseId]);

  if (error) return <div className="alert alert-danger">{error}</div>;
  if (!course) return <div>Loading...</div>;

  return (
    <div className="card p-4">
      <h2>{course.title}</h2>
      <p>{course.description}</p>
      <p>Category: {course.category}</p>
      <p>Difficulty: {course.difficulty}</p>
    </div>
  );
};

export default CourseDetail;
