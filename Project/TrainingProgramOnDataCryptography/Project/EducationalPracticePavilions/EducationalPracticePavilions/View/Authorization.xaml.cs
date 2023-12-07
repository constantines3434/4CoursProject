using 
    
    
    
    .Model;
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

namespace EnigmaApi.View
{
    public partial class Authorization : Page
    {
        public static Captcha captcha;
        List<string> Roles = new List<string>
        {
            "Пользователь",
            "Администратор",
        };
        public Authorization()
        {
            InitializeComponent();
            ComboRole.ItemsSource = Roles;
            ComboRole.SelectedIndex = 0;
        }
        private int countOfAttempt = 0; //Счетчик попыток
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            string role = ComboRole.SelectedItem.ToString().ToLower();
            string login = LoginBox.Text.ToLower();
            string password = PasswordBox.Password;
            
            if ((login != "") && (password != ""))
            {
                User authorizationUser = null;
                UserAuthorization(authorizationUser, role, login, password, ref countOfAttempt);
            }
            else
                GoToCaptcha(ref countOfAttempt);
        }
        private void GoToCaptcha(ref int countOfAttempt)
        {
            MessageBox.Show("Ошибка входа. Пожалуйста, проверьте свои учетные данные.");
            countOfAttempt++;
            if (countOfAttempt >= 3)
            {
                //переход на капчу
                if (captcha == null)
                {
                    captcha = new Captcha();
                    captcha.Show();
                    countOfAttempt = 0;
                    MainWindow.GetWindow(this)?.Close();
                }
                else
                    captcha.Activate();
                countOfAttempt = 0;
            }
        }
        private void UserAuthorization(User authorizationUser, string role,
                                          string login, string password, ref int countOfAttempt)
        {
        authorizationUser = EnigmaBase.GetContext().Users.Where(p => p.LoginOfUser.ToLower() == login
                                                       && p.PasswordOfUser == password).FirstOrDefault();
            if (authorizationUser != null) //сделать зависимость от роли пользователя
            {
                MessageBox.Show("Вход выполнен успешно!");
                if (authorizationUser.RoleOfUser == "Пользователь")
                    Manager.MainFrame.Navigate(new TheoreticalPage());
                    //MessageBox.Show("Окна теории");
                else if (authorizationUser.RoleOfUser == "Администратор")
                    Manager.MainFrame.Navigate(new InterfaceAdministrator());//переход на view соответствующей роли
            }
            else
            {
                GoToCaptcha(ref countOfAttempt);
            }
        }
    }
}