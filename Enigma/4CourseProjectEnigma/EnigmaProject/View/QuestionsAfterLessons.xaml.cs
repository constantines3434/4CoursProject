using EnigmaProject.Model;
using EnigmaProject.UserControlls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnigmaProject.View
{
    /// <summary>
    /// Логика взаимодействия для QuestionsAfterLessons.xaml
    /// </summary>
    public partial class QuestionsAfterLessons : Page
    {
        public ObservableCollection<string> Answers { get; set; }
        public ObservableCollection<string> CorrectAnswers { get; set; }
        private int answersCount = 0;
        //private int currentQuestionIndex = 0;

        private int currentQ { get; set; }
        private List<Question> QuestionList = new List<Question>();
        private List<Question> CurrentQuestion = new List<Question>();
        private int lastQuestionIndex;

        public QuestionsAfterLessons()
        {
            InitializeComponent();
            Answers = new ObservableCollection<string>
            {
                "Ответ 1",
                "Ответ 2",
                "Ответ 3",
                "Ответ 4",

                "Ответ 5",
                "Ответ 6",
                "Ответ 7",
                "Ответ 8",

                "Ответ 9",
                "Ответ 10",
                "Ответ 11",
                "Ответ 12"
            };
            
            currentQ = 0;
            QuestionList = EnigmaBase.GetContext().Questions.ToList();
            lastQuestionIndex = QuestionList.Count - 1;
            CurrentQuestion.Add(QuestionList[currentQ]);
            controlText.ItemsSource = CurrentQuestion;

            DataContext = this;//
        }

        /// <summary>
        /// ответ на вопрос
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //правильный ответ
            if (answersCount == 5)
            {
                MessageBox.Show("Переход к Энигме");
                Commands.Manager.MainFrame.Navigate(new EnigmaAPI());
            }
            string selectedText = "";
            foreach (var item in control.Items)
                if (item is RadioButton radioButton && radioButton.IsChecked == true)
                { 
                    selectedText = radioButton.Content.ToString();
                    CorrectAnswers.Add(selectedText);
                    answersCount++;

                    //обновления вопросов
                    currentQ++;

                    // bool isAnswerCorrect = userAnswer == correctAnswer;
                    if (currentQ < QuestionList.Count() && QuestionList.Count != 0)
                    {
                        CurrentQuestion.Clear();
                        CurrentQuestion.Add(QuestionList[currentQ]);
                        control.ItemsSource = null;
                        control.ItemsSource = CurrentQuestion;
                    }
                }

           
        }
    }
}