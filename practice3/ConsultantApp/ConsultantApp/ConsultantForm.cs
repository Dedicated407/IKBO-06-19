﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConsultantApp.Properties;
using static ConsultantApp.Diagnosis;
using static ConsultantApp.Question;

namespace ConsultantApp
{
    public partial class ConsultantForm : Form
    {
        private readonly Dictionary<Question, string> _dictionary = new()
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
            }, new HashSet<Question> 
            {
                Cough,
                Overheat,
                RunnyNose,
                Weak
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
            labelQuestion.Text = _dictionary[_questionEnumerator.Current];
        }

        private void SetAnswer(bool isAnswerPositive)
        {
            _questionnaire[_questionEnumerator.Current] = isAnswerPositive;
            if (!_questionEnumerator.MoveNext())
            {
                labelQuestion.Text = Resources.Diagnosis + Knowledge.GetDiagnose(_questionnaire);
                return;
            }

            if (!_dictionary.ContainsKey(_questionEnumerator.Current))
            {
                labelQuestion.Text = Resources.QustionsAreOver;
                return;
            }

            labelQuestion.Text = _dictionary[_questionEnumerator.Current];
        }
        
        private void ClickButtonYes(object sender, EventArgs e) => SetAnswer(true);

        private void ClickButtonNo(object sender, EventArgs e) => SetAnswer(false);
    }
}
