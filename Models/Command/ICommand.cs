using System;

namespace APS.Models.Command
{
    /// <summary>
    /// 1. The Command Interface
    /// Declares the primary execution method.
    /// </summary>
    public interface ICommand
    {
        void Execute();
        // You could also add a void Undo() method here to support undo operations.
    }
}