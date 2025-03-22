import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5130/api',
  headers: {
    Authorization: `Bearer ${localStorage.getItem('authToken')}`, // Replace with your token logic
  },
});

export default api;