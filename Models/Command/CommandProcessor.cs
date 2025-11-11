using System;
using System.Collections.Generic;

namespace APS.Models.Command
{
    /// <summary>
    /// 3. The Invoker
    /// Holds commands and triggers their execution. It is decoupled
    /// from the ConcreteCommand and Receiver, only knowing about the ICommand interface.
    /// This implementation uses a queue to process commands sequentially.
    /// </summary>
    public class CommandProcessor
    {
        private readonly Queue<ICommand> _commandQueue = new Queue<ICommand>();
        private readonly List<ICommand> _commandHistory = new List<ICommand>();

        public void AddCommandToQueue(ICommand command)
        {
            _commandQueue.Enqueue(command);
            Console.WriteLine($"[Invoker] Added {command.GetType().Name} to the queue.");
        }

        public void ProcessCommands()
        {
            Console.WriteLine("\n[Invoker] === Processing Command Queue ===");
            while (_commandQueue.Count > 0)
            {
                ICommand command = _commandQueue.Dequeue();
                
                Console.WriteLine($"[Invoker] Executing {command.GetType().Name}...");
                command.Execute();
                
                _commandHistory.Add(command);
            }
            Console.WriteLine("[Invoker] === Command Queue Empty ===\n");
        }

        public void ShowHistory()
        {
            Console.WriteLine("[Invoker] --- Command History ---");
            foreach(var cmd in _commandHistory)
            {
                Console.WriteLine($" - {cmd.GetType().Name}");
            }
            Console.WriteLine("[Invoker] -----------------------");
        }
    }
}