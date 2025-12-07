namespace APS.Models
{
    public interface IEnrollmentManager
    {
        void ProcessEnrollment(IUser user, ICourse course);
    }
}
