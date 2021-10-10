using System.Collections.Generic;
using Xunit;
using static ConsultantApp.Diagnosis;
using static ConsultantApp.Question;

namespace ConsultantApp.Tests
{
    public class KnowledgeBaseTest
    {
        private readonly KnowledgeBase _knowledge = new KnowledgeBase(
            new Dictionary<Diagnosis, HashSet<Question>>{
                [Cold] = new HashSet<Question> {
                    Cough,
                },
                [SARS] = new HashSet<Question> {
                    Cough,
                    Overheat
                },
            }
        );
        
        [Fact]
        public void GetDiagnoseTestCold()
        {
            var questionnaire = new Questionnaire
            {
                [Cough] = true,
                [IsMale] = true,
            };
            
            var result = _knowledge.GetDiagnose(questionnaire);
            var expect = Cold;
            Assert.Equal(result, expect);
        }
        
        [Fact]
        public void GetDiagnoseTestSars()
        {
            var questionnaire = new Questionnaire
            {
                [Cough] = true,
                [Overheat] = true,
            };
            
            var result = _knowledge.GetDiagnose(questionnaire);
            var expect = SARS;
            Assert.Equal(result, expect);
        }
        
        [Fact]
        public void GetDiagnoseTestHealthy()
        {
            var questionnaire = new Questionnaire
            {
                [IsMale] = true,
                [AgeOver50] = true,
            };
            
            var result = _knowledge.GetDiagnose(questionnaire);
            var expect = Healthy;
            Assert.Equal(result, expect);
        }
        
        [Fact]
        public void GetDiagnoseTestSimple()
        {
            var tests = new Dictionary<Diagnosis, HashSet<Question>>
            {
                [Cold] = new HashSet<Question>
                {
                    Cough,
                },
                [SARS] = new HashSet<Question>
                {
                    Cough,
                    Overheat
                },
            };
            var knowledge = new KnowledgeBase(tests);
            foreach (var testcase in tests)
            {
                var questionnaire = new Questionnaire();
                foreach (var question in testcase.Value)
                {
                    questionnaire[question] = true;
                }
                var result = knowledge.GetDiagnose(questionnaire);
                var expect = testcase.Key;
                Assert.Equal(result, expect);    
            }
        }
        
        [Fact]
        public void GetDiagnoseTestUnknown()
        {
            var questionnaire = new Questionnaire
            {
                [Overheat] = true,
                [AgeOver50] = true,
            };
            
            var result = _knowledge.GetDiagnose(questionnaire);
            var expect = Healthy; // TODO: Handle Unknown symptoms
            Assert.Equal(result, expect);
        }
    }
}