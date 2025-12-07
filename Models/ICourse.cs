using APS.Models.Mediator;

namespace APS.Models
{
    public interface ICourse : IMediatorComponent
    {
        string Name { get; }
        void HandleEnrollmentRequest(IUser user);
    }
}
