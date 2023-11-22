using EducationalPracticePavilions.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace EducationalPracticePavilions.View
{
    /// <summary>
    /// Логика взаимодействия для InterfaceAddEditEmployee.xaml
    /// </summary>
    public partial class InterfaceAddEditEmployee : Page
    {
        public event EventHandler DataUpdated;

        private User _currentUser = new Employee();
        
        public InterfaceAddEditEmployee(Employee selectedEmployee)
        {
            InitializeComponent();
            if (selectedEmployee != null)
                _currentUser = selectedEmployee;

            DataContext = _currentUser;
        }
        private void OnDataUpdated()
        {
            DataUpdated?.Invoke(this, EventArgs.Empty);
        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            // Присвоение значения Роли
            _currentUser.Role = ComboRole.SelectedItem as Role;
            // Присвоение значения статуса
            _currentUser.Gender = ComboSex.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(_currentUser.Surname))
                errors.AppendLine("Укажите корректное Фамилию");
            if (string.IsNullOrWhiteSpace(_currentUser.NameEmployee))
                errors.AppendLine("Укажите корректное Имя");
            if (string.IsNullOrWhiteSpace(_currentUser.Patronimic))
                errors.AppendLine("Укажите корректное Отчество");
            if (string.IsNullOrWhiteSpace(_currentUser.PasswordEmployee))
                errors.AppendLine("Укажите корректное Пароль");
            if (string.IsNullOrWhiteSpace(_currentUser.PhoneNumber))
                errors.AppendLine("Укажите корректное Номер телефона");
            if (_currentUser.Role == null)
                errors.AppendLine("Корректно выберите роль сотрудника");
            if (_currentUser.Gender == null)
                errors.AppendLine("Корректно выберите пол сотрудника");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //добавление
            if (_currentUser.IdEmployee == 0)
                PavilionsBase.GetContext().Employees.Add(_currentUser);
            try
            {
                // Попробуйте сохранить изменения
                PavilionsBase.GetContext().SaveChanges();
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
        private byte[] ConvertBitmapImageToByteArray(BitmapImage bitmapImage)
        {
            byte[] byteArray;

            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

            using (MemoryStream stream = new MemoryStream())
            {
                encoder.Save(stream);
                byteArray = stream.ToArray();
            }

            return byteArray;
        }
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(openFileDialog.FileName);
                bitmap.EndInit();

                Image1.Source = bitmap;
                byte[] imageBytes = ConvertBitmapImageToByteArray(bitmap);
                _currentUser.Photo = imageBytes;
                imageBytes = null;
                openFileDialog = null;
            }
        }
        private void TransitionToTheAllRentsOfTenantButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new InterfaceAllRentsOfTenant());
        }
    }
}
