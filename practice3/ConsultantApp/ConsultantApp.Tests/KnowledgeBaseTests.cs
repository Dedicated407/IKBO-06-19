using System.Collections.Generic;
using Xunit;
using static ConsultantApp.Diagnosis;
using static ConsultantApp.Question;

namespace ConsultantApp.Tests
{
    public class KnowledgeBaseTests
    {
        private static readonly HashSet<Question> DangerMarkers = new HashSet<Question> { Cough, Overheat, RunnyNose };

        private static readonly KnowledgeBase Knowledge = new KnowledgeBase(
            new Dictionary<Diagnosis, HashSet<Question>>
            {
                [Cold] = new HashSet<Question> { Cough },
                [Sars] = new HashSet<Question> { Cough, Overheat }
            },
            DangerMarkers
        );

        [Fact]
        public void GetDiagnoseTestCold()
        {
            var questionnaire = new Questionnaire { [Cough] = true, [IsMale] = true };

            var result = Knowledge.GetDiagnose(questionnaire);
            var expected = Cold;

            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetDiagnoseTestSars()
        {
            var questionnaire = new Questionnaire { [Cough] = true, [Overheat] = true };

            var result = Knowledge.GetDiagnose(questionnaire);
            var expected = Sars;

            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetDiagnoseTestHealthy()
        {
            var questionnaire = new Questionnaire { [IsMale] = true, [AgeOver50] = true };

            var result = Knowledge.GetDiagnose(questionnaire);
            var expected = Healthy;

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(Cold, new[] { Cough })]
        [InlineData(Sars, new[] { Cough, Overheat })]
        public void GetDiagnoseTestSimple(Diagnosis diagnosis, Question[] questions)
        {
            var knowledge = new Dictionary<Diagnosis, HashSet<Question>>
            {
                [diagnosis] = new HashSet<Question>(questions)
            };
            var knowledgeBase = new KnowledgeBase(knowledge, DangerMarkers);
            var questionnaire = new Questionnaire();
            foreach (var question in questions)
            {
                questionnaire[question] = true;
            }

            var result = knowledgeBase.GetDiagnose(questionnaire);
            var expected = diagnosis;

            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetDiagnoseTestUnknown()
        {
            var questionnaire = new Questionnaire { [Overheat] = true, [AgeOver50] = true };

            var result = Knowledge.GetDiagnose(questionnaire);
            var expected = Unknown;

            Assert.Equal(result, expected);
        }
    }
}
