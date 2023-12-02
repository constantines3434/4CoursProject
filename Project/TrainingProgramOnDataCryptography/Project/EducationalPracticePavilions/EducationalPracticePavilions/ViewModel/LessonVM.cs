using EducationalPracticePavilions.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPracticePavilions.ViewModel
{
    public class LessonVM : INotifyPropertyChanged
    {
        private Lesson selectedLesson;

        public ObservableCollection<Lesson> Lessons { get; set; }
        public Lesson SelectedLesson
        {
            get { return selectedLesson; }
            set
            {
                selectedLesson = value;
                OnPropertyChanged("SelectedLesson");
            }
        }

        public LessonVM()
        {
            // Инициализация Lessons из контекста данных
            Lessons = new ObservableCollection<Lesson>(EnigmaBase.GetContext().Lessons);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
