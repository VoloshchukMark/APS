using System;
using System.Collections.Generic;

namespace APS.Models
{

    public sealed class EnrollmentManager : IEnrollmentManager
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

        public void ProcessEnrollment(IUser user, ICourse course)
        {
            // Simulate processing payment, checking prerequisites, etc.
            Console.WriteLine($"[EnrollmentManager] Processing enrollment for {user.GetName()} in {course.Name}...");
            Console.WriteLine($"[EnrollmentManager] ...Success. Payment processed.");
        }
    }
}