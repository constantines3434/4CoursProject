using EnigmaProject.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace EnigmaProject.View
{
    public partial class QuizeAfterLessons : Page
    {
        private ObservableCollection<string> QuestionForAnswers;
        private List<string> CorrectAnswers; // Список для хранения правильных ответов
        private int currentQuestionIndex = 0;
        private string selectedAnswer = "";

        public QuizeAfterLessons()
        {
            InitializeComponent();
            QuestionForAnswers = new ObservableCollection<string>()
            {
                "Ответ1",
                "Ответ2",
                "Ответ3"
            };

            // Инициализация списка правильных ответов
            CorrectAnswers = new List<string>()
            {
                "Правильный ответ на вопрос 1",
                "Правильный ответ на вопрос 2",
                "Правильный ответ на вопрос 3"
            };

            DataContext = QuestionForAnswers;
            control.ItemsSource = EnigmaBase.GetContext().Questions.Select(q => q.Content).ToList();
            ShowCurrentQuestion();
        }

        private string GetCurrentQuestion()
        {
            if (currentQuestionIndex >= 0 && currentQuestionIndex < QuestionForAnswers.Count)
                return QuestionForAnswers[currentQuestionIndex];
            return null;
        }

        private void ShowCurrentQuestion()
        {
            if (QuestionForAnswers.Count > 0 && currentQuestionIndex < QuestionForAnswers.Count)
                QuestionTextBlock.Text = QuestionForAnswers[currentQuestionIndex];
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
                selectedAnswer = radioButton.Content.ToString();
        }

        private void CheckAnswer()
        {
            var currentQuestion = GetCurrentQuestion();
            if (currentQuestion != null)
            {
                var correctAnswer = CorrectAnswers[currentQuestionIndex];
                if (selectedAnswer == correctAnswer)
                {
                    MessageBox.Show("Правильный ответ!");
                }
                else
                {
                    MessageBox.Show("Неправильный ответ. Попробуйте еще раз.");
                }

                currentQuestionIndex++;
                if (currentQuestionIndex >= QuestionForAnswers.Count)
                    currentQuestionIndex = 0; // Если дошли до конца списка вопросов, начинаем сначала

                ShowCurrentQuestion();
            }
            else
            {
                MessageBox.Show("Некорректный вопрос или ответ не найден.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
        }
    }
}

