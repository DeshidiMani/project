import api from './api';

const authService = {
  login: async (credentials) => {
    const response = await api.post('/auth/login', credentials);
    // Ensure the backend returns a plain JSON object: { user, token }
    return response;
  },
  register: async (formData) => {
    const response = await api.post('/auth/register', formData);
    return response;
  }
};

export default authService;
