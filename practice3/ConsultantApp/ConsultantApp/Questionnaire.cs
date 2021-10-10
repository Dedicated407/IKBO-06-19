using System;
using System.Collections.Generic;

namespace ConsultantApp
{
    public class Questionnaire
    {
        private readonly Dictionary<Question, bool> _answers = new Dictionary<Question, bool>();

        public Questionnaire()
        {
            var questions = Enum.GetValues(typeof(Question));
            foreach (var question in questions)
            {
                _answers.Add((Question)question, false);
            }
        }

        public bool this[Question question]
        {
            get => _answers[question];
            set => _answers[question] = value;
        }
    }
}