using EnigmaProject.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EnigmaProject.View
{
    public partial class QuizeAfterLessons : Page
    {
        private ObservableCollection<string> QuestionForAnswers { get; set; }
        private int currentQuestionIndex = 0;

        public QuizeAfterLessons()
        {
            InitializeComponent();
            QuestionForAnswers = new ObservableCollection<string>()
            {
                "Вопрос1",
                "Вопрос2",
                "Вопрос3"
            };

            DataContext = QuestionForAnswers;
            control.ItemsSource = EnigmaBase.GetContext().Questions.Select(q => q.Content).ToList();
            ShowCurrentQuestion();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            currentQuestionIndex++;
            if (currentQuestionIndex >= QuestionForAnswers.Count)
            {
                currentQuestionIndex = 0; // Если дошли до конца списка вопросов, начинаем сначала
            }

            ShowCurrentQuestion();
        }

        private void ShowCurrentQuestion()
        {
            if (QuestionForAnswers.Count > 0 && currentQuestionIndex < QuestionForAnswers.Count)
            {
                QuestionTextBlock.Text = QuestionForAnswers[currentQuestionIndex];
            }
        }
    }
}
