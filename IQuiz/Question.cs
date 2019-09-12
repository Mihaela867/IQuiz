using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQuiz
{
    class Question
    {
        public string description;
        public string[] answers = new string[4];
        public int category;
        public Question(string Description, string ans1, string ans2, string ans3, string ans4,string Category)
        {
            description = Description;
            answers[0] = ans1;
            answers[1] = ans2;
            answers[2] = ans3;
            answers[3] = ans4;
            Int32.TryParse(Category, out category);
        }
    }
}
