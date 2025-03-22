import api from './api';

const progressService = {
  fetchProgress: async (userId, courseId) => {
    return await api.get(`/progress/${userId}/${courseId}`);
  }
};

export default progressService;
