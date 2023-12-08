using EnigmaProject.Model;
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
        string data = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG";//= "The quick brown fox jumps over the lazy dog";

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
            MessageTextBox.Text = data;
        }

        public void Encryption()
        {
            var selectedReflector = Reflector.SelectedValue;
            if (selectedReflector == null)
                return;
            var selectedRotor1 = Rotor1.SelectedValue;
            if (selectedRotor1 == null)
                return;

            var selectedValueReflector = selectedReflector.ToString();

            // Rotors for encryption
            //1
            //сделать окно
            RotorVM rotor1 = new RotorVM("EKMFLGDQVZNTOWYHXUSPAIBRCJ")
            {
                
                Notch = 'Y',
                Turnover = 'Q',
            };
            RotorVM rotor2 = new RotorVM("AJDKSIRUXBLHWTMCQGZNPYFVOE")
            {
                Notch = 'M',
                Turnover = 'E',
            };
            //3
            RotorVM rotor3 = new RotorVM("BDFHJLCPRTXVZNYEIWGAKMUSQO")
            {
                Notch = 'D',
                Turnover = 'V',
            };

            RotorVM ReflectorB = new RotorVM("YRUHQSLDPXNGOKMIEBFZCWVJAT");

            Enigma e = new Enigma();

            // Plugboard
            //сделать отдельное окно
            e.Plugboard.Add('X', 'D');
            e.Plugboard.Add('A', 'V');

            
            e.Rotors.Add(rotor1, 'A');
            e.Rotors.Add(rotor2, 'B');
            e.Rotors.Add(rotor3, 'C');

            // Reflector
            e.Rotors.SetReflector(ReflectorB);

            string result = e.Encrypt(data);

        }
    }
}
