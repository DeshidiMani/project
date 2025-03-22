import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import Home from './pages/Home';
import LoginForm from './components/Auth/LoginForm';
import RegisterForm from './components/Auth/RegisterForm';
import AdminDashboard from './pages/AdminDashboard';
import InstructorDashboard from './pages/InstructorDashboard';
import StudentDashboard from './pages/StudentDashboard';
import { useSelector } from 'react-redux';

const App = () => {
  const { user } = useSelector((state) => state.auth); // Access user details from Redux state

  const RoleBasedDashboard = () => {
    if (!user) return <Navigate to="/login" />;
    switch (user.role) {
      case 'Admin':
        return <AdminDashboard />;
      case 'Instructor':
        return <InstructorDashboard />;
      case 'Student':
        return <StudentDashboard />;
      default:
        return <Navigate to="/login" />;
    }
  };

  return (
    <Router>
      <div className="container mt-4">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<LoginForm />} />
          <Route path="/register" element={<RegisterForm />} />
          <Route path="/dashboard/*" element={<RoleBasedDashboard />} />
          <Route path="/dashboard/student" element={<StudentDashboard />} />
          <Route path="/dashboard/instructor" element={<InstructorDashboard />} />
          <Route path="/dashboard/admin" element={<AdminDashboard />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;
