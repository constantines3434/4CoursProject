using 
    
    
    .Model;
using System;
using System.Collections.Generic;
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

namespace EnigmaApi.View
{
    public partial class InterfaceAdministrator : Page
    {
        public InterfaceAdministrator()
        {
            InitializeComponent();
            ListViewEmployees.ItemsSource = EnigmaBase.GetContext().Users.ToList();
        }
        private void UpdateUsers()
        {
            var currentUser = EnigmaBase.GetContext().Users.ToList();
            // Поиск по логину
            if (!string.IsNullOrEmpty(TBoxSearch.Text))
            {
                // Отфильтровать список сотрудников по логину
                currentUser = currentUser
                    .Where(p => p.LoginOfUser == TBoxSearch.Text)
                    .ToList();
            }

            ListViewEmployees.ItemsSource = currentUser;
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUsers();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)ListViewEmployees.SelectedItem;

            if (selectedUser != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить выбранного сотрудника?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        User UserToDelete = EnigmaBase.GetContext().Users.Find(selectedUser.IdUser);

                        if (UserToDelete != null)
                        {
                            UserToDelete.RoleOfUser = "Удалён";
                            EnigmaBase.GetContext().SaveChanges();
                            UpdateUsers();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message.ToString()}");
                    }
                }
            }
        }
        private void HandleDataUpdated(object sender, EventArgs e)
        {
            UpdateUsers();
        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            InterfaceAddEditUser addEditUser = new InterfaceAddEditUser(null);
            addEditUser.DataUpdated += HandleDataUpdated; // Подпишитесь на событие
            Manager.MainFrame.Navigate(addEditUser);
        }
        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)(sender as Button).DataContext;
            InterfaceAddEditUser addEditUser = new InterfaceAddEditUser(selectedUser);
            addEditUser.DataUpdated += HandleDataUpdated; // Подпишитесь на событие
            Manager.MainFrame.Navigate(addEditUser);
        }
    }
}

