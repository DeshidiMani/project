import api from './api';

const videoService = {
  uploadVideo: async (formData) => {
    return await api.post('/videos/upload', formData, {
      headers: { 'Content-Type': 'multipart/form-data' }
    });
  },
  getVideoStream: async (id) => {
    return await api.get(`/videos/${id}`, { responseType: 'blob' });
  }
};

export default videoService;
