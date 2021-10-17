using System;
using System.Linq;
using Xunit;

namespace ConsultantApp.Tests
{
    public class QuestionnaireTests
    {
        [Fact]
        public void CanGetNextQuestion()
        {
            var values = Enum.GetValues(typeof(Question)).Cast<Question>().ToArray();
            var questionnaire = new Questionnaire();
            var questions = questionnaire.GetQuestions().ToArray();

            bool canReceiveAllQuestions = values.All(x => questions.Contains(x));

            Assert.True(canReceiveAllQuestions);
        }

        [Fact]
        public void AllQuestionsAreUnique()
        {
            var questionnaire = new Questionnaire();
            
            bool isQuestionUnique = questionnaire
                .GetQuestions()
                .GroupBy(x => x)
                .All(x => x.Count() == 1);
            
            Assert.True(isQuestionUnique);
        }
    }
}