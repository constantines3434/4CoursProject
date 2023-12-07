using 
    
    .Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
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
    /// <summary>
    /// Логика взаимодействия для InterfaceAddEditUser.xaml
    /// </summary>
    public partial class InterfaceAddEditUser : Page
    {
        public event EventHandler DataUpdated;

        private User _currentUser = new User();
        List<string> Roles = new List<string>
        {
            "Пользователь",
            "Администратор",
            "Удалён"
        };
        public InterfaceAddEditUser(User selectedUser)
        {
            InitializeComponent();
            if (selectedUser != null)
                _currentUser = selectedUser;
            ComboRole.ItemsSource = Roles;
            DataContext = _currentUser;
        }
        private void OnDataUpdated()
        {
            DataUpdated?.Invoke(this, EventArgs.Empty);
        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            _currentUser.RoleOfUser = ComboRole.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(_currentUser.LoginOfUser))
                errors.AppendLine("Укажите корректно Логин");
            if (_currentUser.RoleOfUser == null)
                errors.AppendLine("Корректно выберите роль");
            if (string.IsNullOrWhiteSpace(_currentUser.PasswordOfUser))
                errors.AppendLine("Укажите корректное Пароль");
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //добавление
            if (_currentUser.IdUser == 0)
                EnigmaBase.GetContext().Users.Add(_currentUser);
            try
            {
                // Попробуйте сохранить изменения
                EnigmaBase.GetContext().SaveChanges();
                OnDataUpdated(); // Сигнализируйте об обновлении данных 
                MessageBox.Show("Информация сохранена");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }
    }
}
