using System.Collections.Generic;
using System.Linq;

namespace ConsultantApp
{
    public class KnowledgeBase
    {
        private readonly Dictionary<Diagnosis, HashSet<Question>> _knowledge;

        public KnowledgeBase(Dictionary<Diagnosis, HashSet<Question>> knowledge)
        {
            _knowledge = knowledge;
        }

        public Diagnosis GetDiagnose(Questionnaire questionnaire, byte threshold = 90)
        {
            var diagnose = Diagnosis.Healthy;
            var max = threshold;
            foreach (var knowledge in _knowledge)
            {
                var matchesCount = knowledge.Value.Count(question => questionnaire[question]);
                var matchesPercentage = (byte) (100 * matchesCount / knowledge.Value.Count);
                if (matchesPercentage >= max)
                {
                    diagnose = knowledge.Key;
                    max = matchesPercentage;
                }
            }
            return diagnose;
        }
    }
}