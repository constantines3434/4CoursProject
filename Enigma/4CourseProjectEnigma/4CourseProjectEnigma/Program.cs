using System;
using System.Collections.Generic;

public class EnigmaMachine
{
    private List<char> rotor1;
    private List<char> rotor2;
    private List<char> rotor3;
    private List<char> reflector;

    public EnigmaMachine()
    {
        // Инициализация роторов и рефлектора (можно использовать другие настройки)
        rotor1 = new List<char>("EKMFLGDQVZNTOWYHXUSPAIBRCJ".ToCharArray());
        rotor2 = new List<char>("AJDKSIRUXBLHWTMCQGZNPYFVOE".ToCharArray());
        rotor3 = new List<char>("BDFHJLCPRTXVZNYEIWGAKMUSQO".ToCharArray());
        reflector = new List<char>("YRUHQSLDPXNGOKMIEBFZCWVJAT".ToCharArray());
    }

    private char Substitute(char input, List<char> rotor)
    {
        int index = input - 'A';
        return rotor[index];
    }

    public char Encrypt(char letter)
    {
        if (!char.IsLetter(letter))
            return letter;

        letter = char.ToUpper(letter);

        // Прохождение через роторы
        letter = Substitute(letter, rotor1);
        letter = Substitute(letter, rotor2);
        letter = Substitute(letter, rotor3);

        // Прохождение через рефлектор
        int index = letter - 'A';
        letter = reflector[index];

        // Обратный проход через роторы
        for (int i = rotor3.Count - 1; i >= 0; i--)
        {
            if (rotor3[i] == letter)
            {
                index = i;
                break;
            }
        }
        letter = (char)('A' + index);

        for (int i = rotor2.Count - 1; i >= 0; i--)
        {
            if (rotor2[i] == letter)
            {
                index = i;
                break;
            }
        }
        letter = (char)('A' + index);

        for (int i = rotor1.Count - 1; i >= 0; i--)
        {
            if (rotor1[i] == letter)
            {
                index = i;
                break;
            }
        }
        letter = (char)('A' + index);

        return letter;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        EnigmaMachine enigma = new EnigmaMachine();
        string message = "HELLO";

        Console.WriteLine("Original message: " + message);

        // Шифрование сообщения
        string encryptedMessage = "";
        foreach (char letter in message)
        {
            encryptedMessage += enigma.Encrypt(letter);
        }

        Console.WriteLine("Encrypted message: " + encryptedMessage);
    }
}
