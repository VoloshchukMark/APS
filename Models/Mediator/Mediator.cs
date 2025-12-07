using System;

namespace APS.Models.Mediator
{
    /// <summary>
    /// The Mediator Interface
    /// Declares a method used by components to notify the mediator about events.
    /// 
    /// Low Coupling implementation (GRASP)
    /// Hepls User class to access EnrollmentManager class' functionality
    /// </summary>
    public interface IMediator
    {
        // A flexible notification method
        void Notify(object sender, string eventType, object data);
    }

    /// <summary>
    /// 2. The Base Component (Abstract Colleague)
    /// Provides basic functionality for storing a mediator's instance.
    /// </summary>
    public interface IMediatorComponent 
    {
        public void SetMediator(IMediator mediator);
    }
}