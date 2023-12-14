using EnigmaProject.Model;
using EnigmaProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    public partial class TheoreticalPage : Page
    {
        private int currentL { get; set; }
        private List<Lesson> LessonList = new List<Lesson>();
        private List<Lesson> CurrentLesson = new List<Lesson>();
        private int lastLessonIndex;

        public TheoreticalPage()
        {
            InitializeComponent();
            currentL = 0;
            LessonList = EnigmaBase.GetContext().Lessons.ToList();
            lastLessonIndex = LessonList.Count - 1;
            CurrentLesson.Add(LessonList[currentL]);
            control.ItemsSource = CurrentLesson;
            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = lastLessonIndex;
            progressBar.Value = currentL; // Устанавливаем текущее значение ProgressBar
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            currentL++;
            if (currentL == LessonList.Count)
            {
                using (EnigmaBase context = EnigmaBase.GetContext())
                {
                    var lessonToUpdate = context.Lessons.FirstOrDefault(lesson => lesson.IdLesson == currentL);

                    if (lessonToUpdate != null)
                    {
                        lessonToUpdate.IsCompleted = false;
                        context.SaveChanges();
                    }
                }
            }

            if (currentL < LessonList.Count() && LessonList.Count != 0)
            {
                CurrentLesson.Clear();
                CurrentLesson.Add(LessonList[currentL]);
                control.ItemsSource = null;
                control.ItemsSource = CurrentLesson;

                UpdateProgressBar(); // Обновляем значение ProgressBar после добавления нового урока
            }
            else
            {
                // Если все уроки пройдены, переходим на другую страницу
                MessageBox.Show("Страница опросов");
                //NavigationService.Navigate(new AnotherPage());
            }
        }
    }


}
