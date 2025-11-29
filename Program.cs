using System;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace passwordGenerator;

class Program
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#$%&*+-?@";
    const int default_length = 16;

    static void Main(string[] args)
    {
        System.Console.WriteLine("Please enter your password");
        string userPassword = Console.ReadLine();

        if (userPassword.Length < 12)
        {
            System.Console.WriteLine("Password too short! Generating password...");
            System.Console.WriteLine(GeneratePassword(default_length));
        }

    }

    public static string GeneratePassword(int length)
    {
        StringBuilder password = new StringBuilder();
        var rng = RandomNumberGenerator.Create();

        byte[] randomByte = new byte[1];

        for (int i = 0; i < length; i++)
        {
            rng.GetBytes(randomByte);
            int index = randomByte[0] % chars.Length;

            password.Append(chars[index]);
        }

        return password.ToString();
    }

}


