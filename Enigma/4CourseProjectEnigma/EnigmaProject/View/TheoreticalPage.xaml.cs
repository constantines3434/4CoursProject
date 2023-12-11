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
        public TheoreticalPage()
        {
            InitializeComponent();
            currentL= 0;
            LessonList = EnigmaBase.GetContext().Lessons.ToList();
            CurrentLesson.Add(LessonList[currentL]);
            control.ItemsSource = CurrentLesson;
            UpdateProgressBar();



            


        }

        private void UpdateProgressBar()
        {
            progressBar.Minimum = 0;
            //progressBar.Maximum = lessonCounts[(int)currentTheme] - 1;
            //progressBar.Value = currentLessonIndex;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            currentL++;

            using (EnigmaBase context = EnigmaBase.GetContext())
            {
            
                if (currentL == LessonList.Count() + 1)
                {
                    var lessonToUpdate = context.Lessons.FirstOrDefault(lesson => lesson.IdLesson == currentL);

                    if (lessonToUpdate != null)
                    {
                        // Изменение нужных свойств выбранной записи
                        lessonToUpdate.IsCompleted = false;

                        // Сохранение изменений в базе данных
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
            }
        }
    }
}
