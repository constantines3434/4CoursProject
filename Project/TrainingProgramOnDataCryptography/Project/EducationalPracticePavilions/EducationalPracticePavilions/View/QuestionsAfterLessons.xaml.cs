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
using System.Windows.Shapes;

namespace EnigmaApi.View
{
    /// <summary>
    /// Логика взаимодействия для QuestionsAfterLessons.xaml
    /// </summary>
    public partial class QuestionsAfterLessons : Window
    {
        public static MainWindow mainWindow;
        public QuestionsAfterLessons()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ принят");
            if (QuizeFrame != null)
            {
                if (mainWindow == null)
                {
                    mainWindow = new MainWindow();
                    mainWindow.Show();
                    Manager.MainFrame.Navigate(new TheoreticalPage());
                    Captcha.GetWindow(this)?.Close();
                }
                else
                    mainWindow.Activate();
            }
        }
    }
}
