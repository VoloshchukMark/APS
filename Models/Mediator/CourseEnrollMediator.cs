using System;
using APS.Models; // For User, Course, EnrollmentManager

namespace APS.Models.Mediator
{
    /// <summary>
    /// 3. The Concrete Mediator
    /// Encapsulates relations between colleagues (User, Course, EnrollmentManager).
    /// </summary>
    public class CourseEnrollmentMediator : IMediator
    {
        // It knows about the sub-systems it coordinates
        private readonly EnrollmentManager _enrollmentManager;

        public CourseEnrollmentMediator()
        {
            _enrollmentManager = EnrollmentManager.GetInstance();
        }
        
        // The core logic. It reacts to notifications from components.
        public void Notify(object sender, string eventType, object data)
        {
            // A User is attempting to enroll
            if (eventType == "User.Enroll" && sender is User enrollingUser && data is Course targetCourse)
            {
                Console.WriteLine($"[Mediator] Received enrollment request from '{enrollingUser.GetName()}' for '{targetCourse.Name}'.");
                
                // 1. Coordinate with the EnrollmentManager
                _enrollmentManager.ProcessEnrollment(enrollingUser, targetCourse);
                
                // 2. Coordinate with the Course
                targetCourse.HandleEnrollmentRequest(enrollingUser);
            }
            
            // The Course has confirmed the enrollment
            else if (eventType == "Course.Enrolled" && sender is Course enrolledCourse && data is User confirmedUser)
            {
                Console.WriteLine($"[Mediator] Course '{enrolledCourse.Name}' confirms enrollment for '{confirmedUser.GetName()}'.");
                
                // 3. Notify the User
                confirmedUser.ReceiveEnrollmentConfirmation(enrolledCourse.Name);
            }
        }
    }
}