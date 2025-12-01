using System;
using APS.Models;

namespace APS.Models.Visitor
{
    /// <summary>
    /// 2. The Concrete Visitor
    /// Implements the operations to be performed on each concrete element.
    /// </summary>
    public class TestDisplayVisitor : IQuestionVisitor
    {
        public void Visit(MultipleChoiceQuestion question)
        {
            // Access public properties of the question
            Console.WriteLine($"  [MCQ] {question.GetText()}");
            
            var choices = question.GetChoices();
            if (choices.Count > 0)
            {
                char choiceLetter = 'a';
                foreach (var choice in choices)
                {
                    Console.WriteLine($"    ({choiceLetter++}) {choice}");
                }
            }
        }
    }
}