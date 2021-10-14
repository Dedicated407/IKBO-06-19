using System;
using System.Collections.Generic;

namespace ConsultantApp
{
    public class Questionnaire
    {
        private readonly HashSet<Question> _answers = new ();

        public bool this[Question question]
        {
            get => _answers.Contains(question);
            set
            {
                if (value)
                {
                    _answers.Add(question);
                }
            }
        }
    }
}