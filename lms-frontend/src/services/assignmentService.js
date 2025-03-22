import api from './api';

const assignmentService = {
  fetchAssignmentsByCourse: async (courseId) => {
    return await api.get(`/assignments/bycourse?courseId=${courseId}`);
  },
  submitAssignment: async (assignmentId, submission) => {
    return await api.post(`/assignments/${assignmentId}/submit`, submission);
  }
};

export default assignmentService;
