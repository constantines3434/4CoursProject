using EnigmaProject.Model;
using EnigmaProject.UserControlls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EnigmaProject.ViewModel;

namespace EnigmaProject.View
{
    public partial class QuestionsAfterLessons : Page
    {
        public ObservableCollection<AnswerViewModel> Answers { get; set; }
        public ObservableCollection<AnswerViewModel> MyAnswers { get; set; }
            = new ObservableCollection<AnswerViewModel>();
        public ObservableCollection<AnswerViewModel> CorrectAnswers
            = new ObservableCollection<AnswerViewModel>();

        private int currentQ { get; set; }
        private List<Question> QuestionList = new List<Question>();
        private List<Question> CurrentQuestion = new List<Question>();

        public QuestionsAfterLessons()
        {
            InitializeComponent();
            Answers = new ObservableCollection<AnswerViewModel>
            {
                new AnswerViewModel { AnswerText = "Обратимое преобразование информации \n в целях её сокрытия" },
                new AnswerViewModel { AnswerText = "необратимое сообщение" },
                new AnswerViewModel { AnswerText = "Набор символов" },
                new AnswerViewModel { AnswerText = "Нет такого понятия"},
            };
            CorrectAnswers.Add(Answers[0]);

            //вопросы
            currentQ = 0;
            QuestionList = EnigmaBase.GetContext().Questions.ToList();
            CurrentQuestion.Add(QuestionList[currentQ]);
            controlText.ItemsSource = CurrentQuestion;
            
            control.ItemsSource = Answers;
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var answer in Answers)
            {
                if (answer.IsSelected)
                {
                    string selectedAnswerText = answer.AnswerText;
                    if (!string.IsNullOrEmpty(selectedAnswerText))
                    {
                        // Проверяем, есть ли такой ответ уже в MyAnswers
                        bool answerExists = MyAnswers.Any(ans => ans.AnswerText == selectedAnswerText);

                        if (!answerExists)
                        {
                            MessageBox.Show("Ответ добавлен");
                            // Если ответа еще нет в MyAnswers, добавляем его
                            MyAnswers.Add(new AnswerViewModel { AnswerText = selectedAnswerText });
                        }
                    }
                }
            }

            if (MyAnswers.Count == CorrectAnswers.Count)
            {
                for (int i = 0; i < MyAnswers.Count; i++)
                {
                    // Проверяем, правильно ли ответил пользователь на все вопросы
                    if (MyAnswers[i].AnswerText != CorrectAnswers[i].AnswerText)
                    {
                        MessageBox.Show("Ответ не правильный");
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Переход к Энигме");
                        Commands.Manager.MainFrame.Navigate(new EnigmaAPI());
                    }
                }
            }
        }
    }
}