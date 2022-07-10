using System;
using System.Collections.Generic;

public static class PasswordScore
{
    public const string
        VeryWeak = "very weak",
        Weak = "weak",
        Medium = "medium",
        Strong = "strong",
        VeryStrong = "very strong";
}

public class PasswordUtilities { 
    public static string GeneratePassword(int passwordLength, List<ICharacterGenerator> generators)
    {
        string password = "";
        var random = new Random();

        for (int i = 0; i < passwordLength; i++)
        {
            int randomNumber = random.Next(generators.Count);
            password += generators[randomNumber].Generate();
        }

        return password;    
    }

    public static string CreateHiddenPassword(string password, char charForHide)
    {
        string passwordHidden = "";

        for (int i = 0; i < password.Length; i++)
        {
            passwordHidden += charForHide;
        }

        return passwordHidden;
    }

    public static string CheckPasswordStrength(string password, List<ICharacterGenerator> generators)
    {
        int passwordLength = password.Length;

        if (generators.Count == 1)
        {
            if (passwordLength <= 5)
                return PasswordScore.VeryWeak;
            else if (passwordLength <= 7)
                return PasswordScore.Weak;
            else if (passwordLength <= 9)
                return PasswordScore.Medium;
            else if (passwordLength <= 14)
                return PasswordScore.Strong;
            else if (passwordLength <= 18)
                return PasswordScore.VeryStrong;
            else
                return PasswordScore.VeryStrong;

        }

        else if (generators.Count == 2)
        {
            if (passwordLength <= 4)
                return PasswordScore.VeryWeak;
            else if (passwordLength <= 6)
                return PasswordScore.Weak;
            else if (passwordLength <= 8)
                return PasswordScore.Medium;
            else if (passwordLength <= 12)
                return PasswordScore.Strong;
            else if (passwordLength <= 16)
                return PasswordScore.VeryStrong;
            else
                return PasswordScore.VeryStrong;
        }

        else if (generators.Count == 3)
        {
            if (passwordLength <= 4)
                return PasswordScore.VeryWeak;
            else if (passwordLength <= 5)
                return PasswordScore.Weak;
            else if (passwordLength <= 7)
                return PasswordScore.Medium;
            else if (passwordLength <= 11)
                return PasswordScore.Strong;
            else if (passwordLength <= 15)
                return PasswordScore.VeryStrong;
            else
                return PasswordScore.VeryStrong;
        }

        else 
        {
            if (passwordLength <= 3)
                return PasswordScore.VeryWeak;
            else if (passwordLength <= 4)
                return PasswordScore.Weak;
            else if (passwordLength <= 6)
                return PasswordScore.Medium;
            else if (passwordLength <= 10)
                return PasswordScore.Strong;
            else if (passwordLength <= 14)
                return PasswordScore.VeryStrong;
            else
                return PasswordScore.VeryStrong;
        }
    }
}
