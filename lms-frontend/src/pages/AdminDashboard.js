import React, { useEffect } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';
import AdminUserManagement from '../components/Admin/AdminUserManagement';
import NotificationPanel from '../components/Notifications/NotificationPanel';

const AdminDashboard = () => {
  const demoUserId = 1; // Replace with actual admin user id from auth state

  useEffect(() => {
    // Initialize SignalR connection
    const connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5130/notificationHub") // Replace with your SignalR hub URL
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
      <AdminUserManagement />
      <NotificationPanel userId={demoUserId} />
    </div>
  );
};

export default AdminDashboard;