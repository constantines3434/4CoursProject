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
    // Класс AnswerViewModel для хранения ответов
    public class AnswerViewModel : INotifyPropertyChanged
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        private string _answerText;
        public string AnswerText
        {
            get { return _answerText; }
            set
            {
                if (_answerText != value)
                {
                    _answerText = value;
                    OnPropertyChanged("AnswerText");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class QuestionsAfterLessons : Page
    {
        public ObservableCollection<AnswerViewModel> Answers { get; set; }
        public ObservableCollection<AnswerViewModel> CorrectAnswers { get; set; } = new ObservableCollection<AnswerViewModel>();
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
            new AnswerViewModel { AnswerText = "Нет такого понятия" },
        };

            currentQ = 0;
            QuestionList = EnigmaBase.GetContext().Questions.ToList();
            CurrentQuestion.Add(QuestionList[currentQ]);
            controlText.ItemsSource = CurrentQuestion;
            control.ItemsSource = Answers;
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in control.Items)
            {
                if (item is RadioButton radioButton && radioButton.IsChecked == true)
                {
                    var selectedAnswer = radioButton.DataContext as AnswerViewModel;
                    if (selectedAnswer != null)
                    {
                        CorrectAnswers.Add(selectedAnswer);
                        selectedAnswer.IsSelected = true;
                    }
                }
            }

            currentQ++;
            if (currentQ < QuestionList.Count && QuestionList.Count != 0)
            {
                CurrentQuestion.Clear();
                CurrentQuestion.Add(QuestionList[currentQ]);
                controlText.ItemsSource = CurrentQuestion;
            }
            else
            {
                if (CorrectAnswers.Count == 0)
                {
                    MessageBox.Show("Переход к Энигме");
                    Commands.Manager.MainFrame.Navigate(new EnigmaAPI());
                }
                else
                {
                    MessageBox.Show("Ответьте на все вопросы перед переходом");
                }
            }
        }
    }
}