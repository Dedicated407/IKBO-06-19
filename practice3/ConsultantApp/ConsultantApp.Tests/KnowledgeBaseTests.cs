using System.Collections.Generic;
using Xunit;
using static ConsultantApp.Diagnosis;
using static ConsultantApp.Question;

namespace ConsultantApp.Tests
{
    public class KnowledgeBaseTests
    {
        private static readonly HashSet<Question> DangerMarkers = new HashSet<Question> {Cough, Overheat, RunnyNose};

        private static readonly KnowledgeBase Knowledge = new KnowledgeBase(
            new Dictionary<Diagnosis, HashSet<Question>>
            {
                [Cold] = new HashSet<Question> {Cough}, 
                [Sars] = new HashSet<Question> {Cough, Overheat}
            }, 
            DangerMarkers
        );

        [Fact]
        public void GetDiagnoseTestCold()
        {
            var questionnaire = new Questionnaire {[Cough] = true, [IsMale] = true};

            var result = Knowledge.GetDiagnose(questionnaire);
            var expected = Cold;
            
            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetDiagnoseTestSars()
        {
            var questionnaire = new Questionnaire {[Cough] = true, [Overheat] = true};

            var result = Knowledge.GetDiagnose(questionnaire);
            var expected = Sars;
            
            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetDiagnoseTestHealthy()
        {
            var questionnaire = new Questionnaire {[IsMale] = true, [AgeOver50] = true};

            var result = Knowledge.GetDiagnose(questionnaire);
            var expected = Healthy;
            
            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetDiagnoseTestSimple()
        {
            var tests = new Dictionary<Diagnosis, HashSet<Question>>
            {
                [Cold] = new HashSet<Question> {Cough}, [Sars] = new HashSet<Question> {Cough, Overheat}
            };
            var knowledge = new KnowledgeBase(tests, DangerMarkers);
            foreach (var testcase in tests)
            {
                var questionnaire = new Questionnaire();
                foreach (var question in testcase.Value)
                {
                    questionnaire[question] = true;
                }

                var result = knowledge.GetDiagnose(questionnaire);
                var expected = testcase.Key;
                
                Assert.Equal(result, expected);
            }
        }

        [Fact]
        public void GetDiagnoseTestUnknown()
        {
            var questionnaire = new Questionnaire {[Overheat] = true, [AgeOver50] = true};

            var result = Knowledge.GetDiagnose(questionnaire);
            var expected = Unknown;
            
            Assert.Equal(result, expected);
        }
    }
}