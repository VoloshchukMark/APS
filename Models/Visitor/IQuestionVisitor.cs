using APS.Models;

namespace APS.Models.Visitor
{
    /// <summary>
    /// 1. The Visitor Interface
    /// Declares a Visit method for each concrete Element (Question) type.
    /// </summary>
    public interface IQuestionVisitor
    {
        void Visit(MultipleChoiceQuestion question);
        // If you later add 'OpenEndedQuestion', you would add:
        // void Visit(OpenEndedQuestion question);
    }
}