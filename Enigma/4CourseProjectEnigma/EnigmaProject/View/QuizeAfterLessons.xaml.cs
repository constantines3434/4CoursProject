using EnigmaProject.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EnigmaProject.View
{
    public partial class QuizeAfterLessons : Page
    {
        string selectedAnswer = "\0";
        private ObservableCollection<string> QuestionForAnswers { get; set; }
        private int currentQuestionIndex = 0;

        public QuizeAfterLessons()
        {
            InitializeComponent();
            QuestionForAnswers = new ObservableCollection<string>()
            {
                "Ответ1",
                "Ответ2",
                "Ответ3"
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
            // Получить текущий вопрос
            var currentQuestion = GetCurrentQuestion(); 
            if (GetCurrentQuestion() != null && GetCurrentQuestion() == selectedAnswer)
            {
                MessageBox.Show("Правильный ответ!");
                currentQuestionIndex++;
                if (currentQuestionIndex >= QuestionForAnswers.Count)
                    currentQuestionIndex = 0; // Если дошли до конца списка вопросов, начинаем сначала
                ShowCurrentQuestion();
            }
            else
                MessageBox.Show("Неправильный ответ. Попробуйте еще раз.");    
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
        }
    }
}
