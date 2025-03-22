import api from './api';

const paymentService = {
  processPayment: async (paymentData) => {
    return await api.post('/payments/checkout', paymentData);
  }
};

export default paymentService;
