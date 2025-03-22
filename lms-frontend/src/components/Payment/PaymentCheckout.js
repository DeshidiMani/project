import React, { useState } from 'react';
import paymentService from '../../services/paymentService';

const PaymentCheckout = ({ courseId, amount }) => {
  const [paymentLink, setPaymentLink] = useState(null);
  const [message, setMessage] = useState(null);
  const [error, setError] = useState(null);

  const handleCheckout = async () => {
    try {
      const response = await paymentService.processPayment({ courseId, amount });
      setPaymentLink(response.data.PaymentLink);
      setMessage('Payment link generated successfully. Please complete your payment.');
    } catch (err) {
      setError('Error processing payment.');
    }
  };

  return (
    <div className="card p-4">
      <h2 className="mb-3">Course Payment</h2>
      <p>Amount: ${amount}</p>
      {paymentLink ? (
        <a href={paymentLink} target="_blank" rel="noopener noreferrer" className="btn btn-warning">
          Complete Payment
        </a>
      ) : (
        <button onClick={handleCheckout} className="btn btn-primary">Checkout</button>
      )}
      {message && <div className="alert alert-success mt-2">{message}</div>}
      {error && <div className="alert alert-danger mt-2">{error}</div>}
    </div>
  );
};

export default PaymentCheckout;
