import api from './api';

const enrollmentService = {
  enroll: async (courseId) => {
    return await api.post('/enrollments', { courseId });
  }
};

export default enrollmentService;
