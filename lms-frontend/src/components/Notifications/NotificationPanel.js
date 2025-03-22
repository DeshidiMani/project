import React, { useEffect } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';

const NotificationPanel = ({ userId }) => {
  useEffect(() => {
    // Initialize SignalR connection
    const connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5130/notificationHub", {
        accessTokenFactory: () => localStorage.getItem('authToken'), // Replace with your token logic
      })// Replace with your SignalR hub URL
      .build();

    // Set up event listener for notifications
    connection.on("ReceiveNotification", (message) => {
      console.log("Notification received for user:", userId, message);
    });

    // Start the connection
    connection
      .start()
      .then(() => console.log("Connected to SignalR hub"))
      .catch((err) => console.error("Error connecting to SignalR hub:", err));

    // Cleanup the connection when the component unmounts
    return () => {
      connection.stop().then(() => console.log("Disconnected from SignalR hub"));
    };
  }, [userId]);

  return (
    <div>
      <h2>Notifications</h2>
      {/* Render notifications here */}
    </div>
  );
};

export default NotificationPanel;