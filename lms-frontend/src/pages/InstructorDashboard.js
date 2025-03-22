import React from 'react';
import CourseEditor from '../components/Course/CourseEditor';
import VideoUploader from '../components/Video/VideoUploader';
import NotificationPanel from '../components/Notifications/NotificationPanel';
import StudentProgressTracker from '../components/Instructor/StudentProgressTracker';
import AssignmentGradePanel from '../components/Instructor/AssignmentGradePanel';

const InstructorDashboard = () => {
  const demoUserId = 1;       // Replace with actual instructor user id from auth state
  const demoCourseId = 1;     // Replace with instructor's course id
  const demoAssignmentId = 1; // Replace with assignment id for grading

  return (
    <div>
      <h1 className="my-4">Instructor Dashboard</h1>
      <CourseEditor />
      <VideoUploader courseId={demoCourseId} />
      <StudentProgressTracker courseId={demoCourseId} />
      <AssignmentGradePanel assignmentId={demoAssignmentId} />
      <NotificationPanel userId={demoUserId} />
    </div>
  );
};

export default InstructorDashboard;
