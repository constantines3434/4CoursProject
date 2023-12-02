using EducationalPracticePavilions.Model;
using EducationalPracticePavilions.UserControlls;
using EducationalPracticePavilions.ViewModel;
using System;
using System.Collections.Generic;
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

namespace EducationalPracticePavilions.View
{
    //сделать словарь -> кинь в Model
    enum Themes
    {
        First = 2,
        Second = 1,
        Third = 2
    };
    public partial class TheoreticalPage : Page
    {
        public static QuestionsAfterLessons quize;
        private LessonVM lessonViewModel; // Объект класса LessonVM
        private int curentLesson = 0;
        private int currentThemeLessonsCount = (int)Themes.First; // Устанавливаем начальное количество уроков для первой темы
        public TheoreticalPage()
        {
            InitializeComponent();
            lessonViewModel = new LessonVM(); // Инициализация объекта LessonVM
            DataContext = lessonViewModel; // Устанавливаем LessonVM в качестве DataContext

            progressBar.Minimum = 0;
            progressBar.Maximum = (int)(Themes)(currentThemeLessonsCount)-1;
            progressBar.Value = curentLesson;
            // Установка изначально выбранного урока до первого клика
            lessonViewModel.SelectedLesson = lessonViewModel.Lessons[curentLesson];
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (curentLesson < currentThemeLessonsCount - 1)
            {
                lessonViewModel.SelectedLesson = lessonViewModel.Lessons[++curentLesson];
                progressBar.Value = curentLesson;
            }
            else
            {
                MessageBox.Show("Опрос");
                //переход на капчу
                if (quize == null)
                {
                    quize = new QuestionsAfterLessons();
                    quize.Show();
                    MainWindow.GetWindow(this)?.Close();
                }
                else
                    quize.Activate();
            }
        }
    }
}
