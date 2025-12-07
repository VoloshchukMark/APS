using System;
using APS.Models; // For User, Course, EnrollmentManager

namespace APS.Models.Mediator
{
    /// <summary>
    /// The Concrete Mediator
    /// Encapsulates relations between colleagues (User, Course, EnrollmentManager).
    /// 
    /// Pure Fabrication implementation (GRASP)
    /// Class that's not real in real world, design to perform technical tasks
    /// </summary>
    public class CourseEnrollmentMediator : IMediator
    {
        // It knows about the sub-systems it coordinates
        private readonly IEnrollmentManager _enrollmentManager;

        public CourseEnrollmentMediator(IEnrollmentManager enrollmentManager)
        {
            _enrollmentManager = enrollmentManager;
        }

        // The core logic. It reacts to notifications from components.
        public void Notify(object sender, string eventType, object data)
        {
            // A User is attempting to enroll
            if (eventType == "User.Enroll" && sender is IUser enrollingUser && data is ICourse targetCourse)
            {
                Console.WriteLine($"[Mediator] Received enrollment request from '{enrollingUser.GetName()}' for '{targetCourse.Name}'.");

                // 1. Coordinate with the EnrollmentManager
                _enrollmentManager.ProcessEnrollment(enrollingUser, targetCourse);

                // 2. Coordinate with the Course
                targetCourse.HandleEnrollmentRequest(enrollingUser);
            }

            // The Course has confirmed the enrollment
            else if (eventType == "Course.Enrolled" && sender is ICourse enrolledCourse && data is IUser confirmedUser)
            {
                Console.WriteLine($"[Mediator] Course '{enrolledCourse.Name}' confirms enrollment for '{confirmedUser.GetName()}'.");

                // 3. Notify the User
                confirmedUser.ReceiveEnrollmentConfirmation(enrolledCourse.Name);
            }
        }
    }
}