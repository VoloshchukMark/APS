using APS.Models.Mediator;

namespace APS.Models
{
    public interface IUser : IMediatorComponent
    {
        string GetName();
        bool IsAdmin { get; }
        void EnrollInCourse(ICourse course);
        void ReceiveEnrollmentConfirmation(string courseName);
        void Update(string subjectName, string message);
    }
}
