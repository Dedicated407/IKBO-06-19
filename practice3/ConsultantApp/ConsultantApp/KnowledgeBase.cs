using System.Collections.Generic;
using System.Linq;

namespace ConsultantApp
{
    public class KnowledgeBase
    {
        private readonly Dictionary<Diagnosis, HashSet<Question>> _knowledge;
        private readonly HashSet<Question> _dangerMarkers;

        public KnowledgeBase(Dictionary<Diagnosis, HashSet<Question>> knowledge, HashSet<Question> dangerMarkers)
        {
            _knowledge = knowledge;
            _dangerMarkers = dangerMarkers;
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
            if (diagnose == Diagnosis.Healthy)
            {
                if (_dangerMarkers.Any(question => questionnaire[question]))
                {
                    return Diagnosis.Unknown;
                }
            }
            return diagnose;
        }
    }
}