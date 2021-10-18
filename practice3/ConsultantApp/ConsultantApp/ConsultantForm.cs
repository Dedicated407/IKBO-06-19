using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConsultantApp.Properties;
using static ConsultantApp.Diagnosis;
using static ConsultantApp.Question;

namespace ConsultantApp
{
    public partial class ConsultantForm : Form
    {
        private readonly Dictionary<Question, string> _dictionaryQuestions = new()
        {
            {AgeOver50, "Вам больше 50ти лет?"},
            {IsMale, "Ваш пол мужской?"},
            {Overheat , "У вас есть повышенная температура? (>36.6)"},
            {RunnyNose , "Есть ли у вас насморк?"},
            {Cough, "У вас есть кашель?"},
            {ChronicDiseases, "У вас или у вашей семье были хронические заболевания?"},
            {Pressure, "Ваше текущее давление в пределах нормы? (120/79 - 127/84)"},
            {StomachPain, "Испытываете ли вы боль в области живота?"},
            {NoSmell, "Отсутствует ли у вас запах?"},
            {Headache, "Испытываете ли вы головную боль?"},
            {Weak, "Чувствуете ли вы слабость?"},
            {ShortnessOfBreath, "Испытываете ли вы затруднения с дыханием при физической нагрузке или в покое?"},
            {IsSweating, "Есть ли у вас потливость при малой физической нагрузке?"},
            {Alcoholism, "Часто ли вы употребляете алкогольные напитки?"},
            {IsSmoke, "Употребляете вы никотиновые средства?"},
            {FattyFood, "Часто ли вы едите жирную еду?"},
            {PhysicalActivity, "Мало ли в вашей жизни физической активности?"}
        };

        private readonly Dictionary<Diagnosis, string> _dictionaryDiagnosis = new()
        {
            {Healthy, "Вы здоровы!"},
            {Unknown, "Нужно обязательно сходить к врачу, сложно найти конкретный диагноз."},
            {Cold, "простуда!"},
            {Sars, "ОРВИ, скорее обратитесь в поликлинику!"},
            {HeartFailure, "сердечная недостаточность"},
            {MetabolicDisorders, "нарушение обмена веществ"},
            {CoronaVirus, "короновирус...."},
        };

        private readonly Questionnaire _questionnaire = new();
        private readonly IEnumerator<Question> _questionEnumerator;
        
        private static readonly KnowledgeBase Knowledge = new 
        (
            new Dictionary<Diagnosis, HashSet<Question>>
            {
                [Cold] = new () 
                {
                    Cough,
                    RunnyNose
                },
                [Sars] = new () 
                {
                    Cough,
                    Overheat,
                    RunnyNose,
                    Weak
                },
                [HeartFailure] = new()
                {
                    Pressure,
                    Weak,
                    ShortnessOfBreath,
                    IsSweating,
                    FattyFood,
                    PhysicalActivity
                },
                [MetabolicDisorders] = new()
                {
                    ShortnessOfBreath,
                    Alcoholism,
                    FattyFood,
                    PhysicalActivity
                },
                [CoronaVirus] = new()
                {
                    Overheat,
                    NoSmell,
                    Weak,
                    Headache,
                    ShortnessOfBreath               
                }
            }, new HashSet<Question> 
            {
                Cough,
                Overheat,
                RunnyNose,
                ShortnessOfBreath
            }
        );
        
        public ConsultantForm(Control mainForm)
        {
            InitializeComponent();
            Closing += (_, _) => mainForm.Show();
            _questionEnumerator = _questionnaire.GetQuestions().GetEnumerator();
            if (!_questionEnumerator.MoveNext())
            {
                return;
            }
            labelQuestion.Text = _dictionaryQuestions[_questionEnumerator.Current];
        }

        private void SetAnswer(bool isAnswerPositive)
        {
            _questionnaire[_questionEnumerator.Current] = isAnswerPositive;
            if (!_questionEnumerator.MoveNext())
            {
                labelQuestion.Text = Resources.Diagnosis + _dictionaryDiagnosis[Knowledge.GetDiagnose(_questionnaire)];
                return;
            }

            if (!_dictionaryQuestions.ContainsKey(_questionEnumerator.Current))
            {
                labelQuestion.Text = Resources.QustionsAreOver;
                return;
            }

            labelQuestion.Text = _dictionaryQuestions[_questionEnumerator.Current];
        }
        
        private void ClickButtonYes(object sender, EventArgs e) => SetAnswer(true);

        private void ClickButtonNo(object sender, EventArgs e) => SetAnswer(false);
    }
}
