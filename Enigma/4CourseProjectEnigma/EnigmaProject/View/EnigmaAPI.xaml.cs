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

using EnigmaProject.Components;
namespace EnigmaProject.View
{
    public partial class EnigmaAPI : Page
    {
        string result = "Ошибка";
        string data = "THE"; //QUICK BROWN FOX JUMPS OVER THE LAZY DOG";//= "The quick brown fox jumps over the lazy dog";

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
            //var selectedReflector = Reflector.SelectedValue;
            //if (selectedReflector == null)
            //    return;

            //var selectedValueReflector = selectedReflector.ToString();


            string data = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG";//= "The quick brown fox jumps over the lazy dog";

            // Rotors for encryption
            //1
            MyRotor rotor1 = new MyRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ")
            {
                //сделать окно
                Notch = 'Y',
                Turnover = 'Q',
            };
            //
            MyRotor rotor2 = new MyRotor("AJDKSIRUXBLHWTMCQGZNPYFVOE")
            {
                Notch = 'M',
                Turnover = 'E',
            };
            //3
            MyRotor rotor3 = new MyRotor("BDFHJLCPRTXVZNYEIWGAKMUSQO")
            {
                Notch = 'D',
                Turnover = 'V',
            };
            //A EJMZALYXVBWFCRQUONTSPIKHGD
            //B YRUHQSLDPXNGOKMIEBFZCWVJAT
            //C FVPJIAOYEDRZXWGCTKUQSBNMHL 
            MyRotor ReflectorB = new MyRotor("YRUHQSLDPXNGOKMIEBFZCWVJAT");

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

             result = e.Encrypt(data);

            //MessageBox.Show($"{result}");
            //получить роттеры, которые соответствуют выбранному набору
            //получть рефлектор
            //шифрование сообщения
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
         //   MessageBox.Show($"{result}");
            Encryption();
            Answer.Text = result;
        }
    }
}
