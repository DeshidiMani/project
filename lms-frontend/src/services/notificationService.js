import api from './api';

const notificationService = {
  fetchNotifications: async (userId) => {
    return await api.get(`/notifications/${userId}`);
  }
};

export default notificationService;
