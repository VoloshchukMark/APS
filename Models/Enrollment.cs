using System;
using System.Collections.Generic;

namespace APS.Models
{

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
    }
}