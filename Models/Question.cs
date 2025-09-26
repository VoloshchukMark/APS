using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APS.Models
{
    public abstract class Question
    {
        private string Text;
        public Question(string text)
        {
            Text = text;
        }
        
        public void displayQuestion()
        {
            Console.WriteLine(Text);
        }
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
        
        public void addChoice(string choice)
        {
            Choices.Add(choice);
        }
        
    }
}