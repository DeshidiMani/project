import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchAllCourses } from '../../redux/slices/courseSlice';

const CourseList = () => {
  const dispatch = useDispatch();
  const { courses, error } = useSelector((state) => state.courses);

  useEffect(() => {
    dispatch(fetchAllCourses());
  }, [dispatch]);

  return (
    <div className="card p-4">
      <h2 className="mb-4">Available Courses</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      <ul className="list-group">
        {courses.map(course => (
          <li key={course.id} className="list-group-item">
            <h5>{course.title}</h5>
            <p>{course.description}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default CourseList;
