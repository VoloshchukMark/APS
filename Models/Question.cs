using APS.Models.Visitor; // Import the Visitor namespace

namespace APS.Models
{
    public abstract class Question
    {
        private string Text;
        public Question(string text)
        {
            Text = text;
        }

        // Public getter for the Visitor
        public string GetText() { return Text; }
        
        public void displayQuestion()
        {
            Console.WriteLine(Text);
        }

        // 3. Add the 'Accept' method to the Element interface
        public abstract void Accept(IQuestionVisitor visitor);
    }

    public class MultipleChoiceQuestion : Question
    {
        private List<string> Choices { get; set; }
        
        public MultipleChoiceQuestion(string text): base(text) { 
            Choices = [];
        }

        public MultipleChoiceQuestion(string text, List<string> choices): base(text) { 
            Choices = choices;
        }

        // Public getter for the Visitor
        public List<string> GetChoices() { return Choices; }
        
        public void addChoice(string choice)
        {
            Choices.Add(choice);
        }

        // 4. Implemented 'Accept' in the Concrete Element
        public override void Accept(IQuestionVisitor visitor)
        {
            // Calls the correct 'Visit' method on the visitor
            visitor.Visit(this);
        }
    }
}