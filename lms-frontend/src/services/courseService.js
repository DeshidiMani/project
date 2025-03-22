import api from './api';

const courseService = {
  fetchAllCourses: async () => {
    return await api.get('/courses');
  },
  fetchCourseById: async (id) => {
    return await api.get(`/courses/${id}`);
  },
  createCourse: async (courseData) => {
    return await api.post('/courses', courseData);
  },
  updateCourse: async (id, courseData) => {
    return await api.put(`/courses/${id}`, courseData);
  },
  deleteCourse: async (id) => {
    return await api.delete(`/courses/${id}`);
  }
};

export default courseService;
