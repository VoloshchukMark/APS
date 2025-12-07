using System;
using System.Collections.Generic;

namespace APS.Models
{
    /// <summary>
    /// Controller implementation (GRASP)
    /// It's not part of the UI, but it manages checks and payment functions
    /// </summary>
    public sealed class EnrollmentManager
    {
        private static EnrollmentManager? _instance;            //it could be nullable, right?

        private EnrollmentManager() { }

        public static EnrollmentManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EnrollmentManager();
            }
            return _instance;
        }
        
        public void ProcessEnrollment(User user, Course course)
        {
            // Simulate processing payment, checking prerequisites, etc.
            Console.WriteLine($"[EnrollmentManager] Processing enrollment for {user.GetName()} in {course.Name}...");
            Console.WriteLine($"[EnrollmentManager] ...Success. Payment processed.");
        }
    }
}