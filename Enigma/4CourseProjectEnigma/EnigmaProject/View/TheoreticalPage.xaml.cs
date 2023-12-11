using EnigmaProject.Model;
using EnigmaProject.ViewModel;
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

namespace EnigmaProject.View
{
    /// <summary>
    /// Логика взаимодействия для TheoreticalPage.xaml
    /// </summary>
    enum CountLessonsInTheme
    {
        First = 2,
        Second = 1,
        Third = 2
    };
    public partial class TheoreticalPage : Page
    {
        private LessonVM lessonViewModel;
        
        //var selectedFruits = from fruit in fruits
        //                     where fruit.StartsWith("А", StringComparison.CurrentCultureIgnoreCase)
        //                     select fruit;


        public TheoreticalPage()
        {
            InitializeComponent();
            lessonViewModel = new LessonVM();
            DataContext = lessonViewModel;

            // Заполнение уроков для каждой темы в соответствии с их количеством
            int lessonIndex = 0;
            foreach (var count in lessonCounts)
            {
                var lessons = new List<Lesson>();
                for (int i = 0; i < count; i++)
                {
                    if (lessonIndex < lessonViewModel.Lessons.Count)
                    {
                        lessons.Add(lessonViewModel.Lessons[lessonIndex]);
                        lessonIndex++;
                    }
                }
                lessonsByTheme.Add(lessons);
            }

            // Показываем уроки первой темы
            ShowLesson(currentLessonIndex);
            UpdateProgressBar();
        }

        private void ShowLesson(int lessonIndex)
        {

            //var query = 

            int themeIndex = (int)currentTheme;
            if (themeIndex < lessonsByTheme.Count && lessonIndex >= 0 && lessonIndex < lessonsByTheme[themeIndex].Count)
            {
                lessonViewModel.SelectedLesson = lessonsByTheme[themeIndex][lessonIndex];
            }
            else
            {
                // Обработка случая, когда lessonIndex выходит за пределы доступных уроков для текущей темы
                // Можно показать сообщение об ошибке или выполнить другие действия
            }
        }

        private void UpdateProgressBar()
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = lessonCounts[(int)currentTheme] - 1;
            progressBar.Value = currentLessonIndex;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentLessonIndex < lessonCounts[(int)currentTheme] - 1)
            {
                currentLessonIndex++;
                ShowLesson(currentLessonIndex);
                progressBar.Value = currentLessonIndex;
            }
            else
            {
                MessageBox.Show("Опрос");
                if (currentTheme < CountLessonsInTheme.Third)
                {
                    currentTheme++; // Переходим к следующей теме
                    currentLessonIndex = 0;
                    ShowLesson(currentLessonIndex);
                    UpdateProgressBar();
                }
                else
                {
                    MessageBox.Show("Это был последний опрос");
                }
            }
        }
    }
}
