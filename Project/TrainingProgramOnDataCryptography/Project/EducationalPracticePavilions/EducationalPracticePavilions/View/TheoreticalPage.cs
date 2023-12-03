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
    //число уроков в теме
    enum CountLessonsInTheme
    {
        First = 2,
        Second = 1,
        Third = 2
    };
    public partial class TheoreticalPage : Page
    {
        private List<UserProgress> userProgresses;
        private LessonVM lessonViewModel;
        public static QuestionsAfterLessons quize;
        private int curentLesson = 0;
        private int currentThemeLessonsCount = (int)CountLessonsInTheme.First; 
        // Устанавливаем начальное количество уроков для первой темы
        public TheoreticalPage()
        {
            InitializeComponent();
            lessonViewModel = new LessonVM();
            DataContext = lessonViewModel;

            // Получение данных о прогрессе пользователя из базы данных
            userProgresses = EnigmaBase.GetContext().UserProgresses.ToList();

            // Определение прогресса пользователя для каждой темы
            int completedLessonsFirstTheme = userProgresses.Count(up => up.IdLesson <= (int)CountLessonsInTheme.First && up.Completed.GetValueOrDefault());
            //int completedLessonsSecondTheme = userProgresses.Count(up => up.IdLesson > (int)CountLessonsInTheme.First && up.IdLesson <= ((int)CountLessonsInTheme.First + (int)CountLessonsInTheme.Second) && up.Completed.GetValueOrDefault());
            //int completedLessonsThirdTheme = userProgresses.Count(up => up.IdLesson > ((int)CountLessonsInTheme.First + (int)CountLessonsInTheme.Second) && up.Completed.GetValueOrDefault());

            // Обновление переменных в соответствии с прогрессом пользователя
            currentThemeLessonsCount = completedLessonsFirstTheme;// + completedLessonsSecondTheme + completedLessonsThirdTheme;
            progressBar.Maximum = currentThemeLessonsCount - 1;

            // Найти урок, который пользователь еще не прошел
            Lesson nextLesson = lessonViewModel.Lessons.FirstOrDefault(l => userProgresses.All(up => up.IdLesson != l.IdLesson));

            // Если есть еще не завершенные уроки, выбрать первый из них
            lessonViewModel.SelectedLesson = nextLesson ?? lessonViewModel.Lessons.FirstOrDefault();

            progressBar.Minimum = 0;
            progressBar.Value = 0;
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
                //переход на опрос
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
