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
        public EnigmaAPI()
        {
            InitializeComponent();
            Rotor1.ItemsSource = EnigmaBase.GetContext().Rotors.ToList();
            Rotor1.SelectedIndex = 0;
            Rotor2.ItemsSource = EnigmaBase.GetContext().Rotors.ToList();
            Rotor2.SelectedIndex = 1;
            Rotor3.ItemsSource = EnigmaBase.GetContext().Rotors.ToList();
            Rotor3.SelectedIndex = 2;
            Reflector.ItemsSource = EnigmaBase.GetContext().Reflectors.ToList();
            Reflector.SelectedIndex = 1;
            DataTextBox.Text = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG";
        }

        public string Encryption()
        {
            var selectedRotor1 = (Rotor)Rotor1.SelectedItem;
            if (selectedRotor1 == null)
                return "Ошибка";
            
            var selectedRotor2 = (Rotor)Rotor2.SelectedItem;
            if (selectedRotor2 == null)
                return "Ошибка";
            
            var selectedRotor3 = (Rotor)Rotor3.SelectedItem;
            if (selectedRotor3 == null)
                return "Ошибка";    

            var selectedReflector = (Reflector)Reflector.SelectedItem;
            if (selectedRotor3 == null)
                return "Ошибка";

            // Rotors for encryption
            //1
            MyRotor rotor1 = new MyRotor($"{selectedRotor1.Dictionary}")
            {
                //сделать окно
                Notch = NotchRotor1.Text[0],//'Y',
                Turnover = NotchRotor1.Text[0]//'Q',
            };
            //
            MyRotor rotor2 = new MyRotor($"{selectedRotor2.Dictionary}")
            {
                Notch = NotchRotor2.Text[0],//'M',
                Turnover = NotchRotor2.Text[0]//'E',
            };
            //3
            MyRotor rotor3 = new MyRotor($"{selectedRotor3.Dictionary}")
            {
                Notch = NotchRotor3.Text[0],//'D',
                Turnover = NotchRotor3.Text[0]//'V',
            };
            //A EJMZALYXVBWFCRQUONTSPIKHGD
            //B YRUHQSLDPXNGOKMIEBFZCWVJAT
            //C FVPJIAOYEDRZXWGCTKUQSBNMHL
            MyRotor ReflectorB = new MyRotor($"{selectedReflector.Dictionary}");

            Enigma e = new Enigma();

            // Plugboard
            //сделать отдельное окно
            e.Plugboard.Add('X', 'D');
            e.Plugboard.Add('A', 'V');

            e.Rotors.Add(rotor1, HeadRotor1.Text[0]); //A
            e.Rotors.Add(rotor2, HeadRotor2.Text[0]); //B
            e.Rotors.Add(rotor3, HeadRotor3.Text[0]); //C

            // Reflector
            e.Rotors.SetReflector(ReflectorB);

            return e.Encrypt(DataTextBox.Text);
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e) =>
            Answer.Text = Encryption();
        

    }
}
