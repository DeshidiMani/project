import React from 'react';
import CourseList from '../components/Course/CourseList';
import VideoPlayer from '../components/Video/VideoPlayer';
import AssignmentList from '../components/Assignment/AssignmentList';
import AssignmentSubmit from '../components/Assignment/AssignmentSubmit';
import ProgressTracker from '../components/Progress/ProgressTracker';
import EnrollmentButton from '../components/Enrollment/EnrollmentButton';
import PaymentCheckout from '../components/Payment/PaymentCheckout';
import NotificationPanel from '../components/Notifications/NotificationPanel';

const StudentDashboard = () => {
  const demoCourseId = 1;      // Replace dynamically with enrolled course id
  const demoCourseAmount = 99.99; // Replace with actual course payment amount
  const demoUserId = 1;        // Replace with logged in student id
  // Dummy video URL; in production replace with dynamic URL retrieved from backend
  const demoVideoUrl = 'https://www.w3schools.com/html/mov_bbb.mp4';
  // Dummy assignment id for submission; replace with dynamic assignment id
  const demoAssignmentId = 1;

  return (
    <div>
      <h1 className="my-4">Student Dashboard</h1>
      <CourseList />
      <VideoPlayer videoUrl={demoVideoUrl} />
      <AssignmentList courseId={demoCourseId} />
      <AssignmentSubmit assignmentId={demoAssignmentId} />
      <ProgressTracker courseId={demoCourseId} />
      <EnrollmentButton courseId={demoCourseId} />
      <PaymentCheckout courseId={demoCourseId} amount={demoCourseAmount} />
      <NotificationPanel userId={demoUserId} />
    </div>
  );
};

export default StudentDashboard;
