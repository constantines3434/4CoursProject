﻿using EnigmaProject.Model;
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

using EnigmaProject.ViewModel;

namespace EnigmaProject.View
{
    /// <summary>
    /// Логика взаимодействия для EnigmaAPI.xaml
    /// </summary>
    public partial class EnigmaAPI : Page
    {
        public EnigmaAPI()
        {
            InitializeComponent();
            Rotor1.ItemsSource = EnigmaBase.GetContext().Rotors.ToList();
            Rotor1.SelectedIndex = 0;
            Rotor2.ItemsSource = EnigmaBase.GetContext().Rotors.ToList();
            Rotor2.SelectedIndex = 0;
            Rotor3.ItemsSource = EnigmaBase.GetContext().Rotors.ToList();
            Rotor3.SelectedIndex = 0;
            Reflector.ItemsSource = EnigmaBase.GetContext().Reflectors.ToList();
            Reflector.SelectedIndex = 0;
        }

        public void Encryption()
        {
            var selectedReflector = Reflector.SelectedValue;
            if (selectedReflector == null)
                return;

            var selectedValueReflector = selectedReflector.ToString();

            string data = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG";//= "The quick brown fox jumps over the lazy dog";

            // Rotors for encryption
            //1
            //RotorVM rotor1 = new RotorVM("EKMFLGDQVZNTOWYHXUSPAIBRCJ")
            //{
            //    //сделать окно
               
            //    rotor1.RotorDataHandler.Notch = 'Y',
            //    Turnover = 'Q',
            //};
            //получить роттеры, которые соответствуют выбранному набору
            //получть рефлектор
            //шифрование сообщения
        }
    }
}
