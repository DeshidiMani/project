import React, { useEffect } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';
import NotificationPanel from '../Notifications/NotificationPanel';

const AdminUserManagement = () => {
  useEffect(() => {
    // Initialize SignalR connection
    const connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5130/notificationHub", {
        accessTokenFactory: () => localStorage.getItem('authToken'), // Replace with your token logic
      })
      .build();

    // Set up event listener for notifications
    connection.on("ReceiveNotification", (message) => {
      console.log("Notification received:", message);
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
  }, []);

  return (
    <div>
      <h1 className="my-4">Admin Dashboard</h1>
      <NotificationPanel userId={1} />
    </div>
  );
};

export default AdminUserManagement;