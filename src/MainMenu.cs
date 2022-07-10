using System;
using System.Collections.Generic;
using System.Windows;

public class MainMenu
{
    public static List<ICharacterGenerator> generators = new List<ICharacterGenerator>();

    public static int currentPasswordLength = 8;
    public static char charForHidePassword = '*';
    public static string currentPassword;
    public static string passwordHide;

    public static Boolean isPasswordVisible = false;
    public static Boolean isSpecialCharacterSelected = true;
    public static Boolean isNumberSelected = true;
    public static Boolean isLettersBigSelected = true;
    public static Boolean isLettersSmallSelected = true;

    private static SpecialCharacterGenerator specialCharacterGenerator = new SpecialCharacterGenerator();
    private static LettersSmallGenerator lettersSmallGenerator = new LettersSmallGenerator();
    private static LettersBigGenerator lettersBigGenerator = new LettersBigGenerator();
    private static NumberGenerator numberGenerator = new NumberGenerator();


    [STAThread]
    static void Main(string[] args)
    {
        generators.Add(lettersSmallGenerator);
        generators.Add(lettersBigGenerator);
        generators.Add(numberGenerator);
        generators.Add(specialCharacterGenerator);

        currentPassword = PasswordUtilities.GeneratePassword(currentPasswordLength, generators);
        passwordHide = PasswordUtilities.CreateHiddenPassword(currentPassword, charForHidePassword);

        MainMenu.MainMenuSelection();
    }

    public static void MainMenuSelection()
    {
        Console.Clear();
        Console.WriteLine("Password Generator v. 1.0.0");
        Console.WriteLine("");
        Console.WriteLine("");

        if (isPasswordVisible == true)
            Console.WriteLine(currentPassword);
        else
            Console.WriteLine(passwordHide);

        Console.WriteLine("");
        Console.WriteLine("password score: " + PasswordUtilities.CheckPasswordStrength(currentPassword, generators));
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("password visible   password length");

        Console.Write("    [" + isPasswordVisible + "]");

        string blankCharacters = "              ";

        if (isPasswordVisible == true)
            blankCharacters += " ";

        if (currentPasswordLength > 9 && currentPasswordLength < 100)
            blankCharacters = blankCharacters.Substring(1);
        if (currentPasswordLength > 99 && currentPasswordLength < 1000)
            blankCharacters = blankCharacters.Substring(1);

        Console.Write(blankCharacters + "[" + currentPasswordLength + "]");

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("(a) a-z   (A) A-Z   (1) 0-9   (.) ./*+ü ...");

        string blankCharactersAfterLettersSmall = "    ";
        string blankCharactersAfterLettersBig = "    ";
        string blankCharactersAfterNumber = "    ";

        if (isLettersSmallSelected == false)
            blankCharactersAfterLettersSmall = blankCharactersAfterLettersSmall.Remove(1, 1);
        if (isLettersBigSelected == false)
            blankCharactersAfterLettersBig = blankCharactersAfterLettersBig.Remove(1, 1);
        if (isNumberSelected == false)
            blankCharactersAfterNumber = blankCharactersAfterNumber.Remove(1, 1);

        string generatorSelections = "[" + isLettersSmallSelected + "]" + blankCharactersAfterLettersSmall + 
                                     "[" + isLettersBigSelected + "]" + blankCharactersAfterLettersBig +
                                     "[" + isNumberSelected + "]" + blankCharactersAfterNumber +
                                     "[" + isSpecialCharacterSelected + "]";

        Console.WriteLine(generatorSelections);
        Console.WriteLine("");

        if (isPasswordVisible)
            Console.WriteLine("(g) generate  (l) change length  (c) copy  (h) hide (e) exit");
        else
            Console.WriteLine("(g) generate  (l) change length  (c) copy  (s) show (e) exit");

        Console.WriteLine("");

        Boolean isValidInput = false;

        do
        {
            char input = ' ';

            try
            {
                input = Console.ReadKey().KeyChar;
            }
            
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }   

            Console.WriteLine("");

            if (input == 'g' || input == 'G')
            {
                isValidInput = true;
                currentPassword = PasswordUtilities.GeneratePassword(currentPasswordLength, generators);
                MainMenuSelection();
            }

            else if (input == 'l' || input == 'L')
            {
                isValidInput = true;
                Console.WriteLine("");
                Console.WriteLine("new password length: ");
                bool isValidLenthInput = false;

                do
                {      
                    int passwordLengthInput;
                    bool res = int.TryParse(Console.ReadLine(), out passwordLengthInput);

                    if (res == false)
                    {
                        Console.WriteLine("Please enter a number");
                    }

                    else if (passwordLengthInput > 0 && passwordLengthInput < 1000)
                    {
                        isValidLenthInput = true;
                        currentPasswordLength = passwordLengthInput;
                        currentPassword = PasswordUtilities.GeneratePassword(currentPasswordLength, generators);
                        MainMenuSelection();

                    }
                    else
                        Console.WriteLine("Please enter a number between 1 and 999");            

                } while (isValidLenthInput == false);
            }

            else if (input == 'c' || input == 'C')
            {
                isValidInput = true;
                Clipboard.SetText(currentPassword);
                MainMenuSelection();
            }

            else if ((input == 'h' || input == 'H') && isPasswordVisible == true)
            {
                isValidInput = true;
                isPasswordVisible = false;
                passwordHide = PasswordUtilities.CreateHiddenPassword(currentPassword, charForHidePassword);
                MainMenuSelection();
            }

            else if ((input == 's' || input == 'S') && isPasswordVisible == false)
            {
                isValidInput = true;
                isPasswordVisible = true;
                MainMenuSelection();
            }

            else if (input == 'a')
            {
                isValidInput = true;
                if (isLettersSmallSelected)
                {
                    if (generators.Count != 1)
                    {
                        isLettersSmallSelected = false;
                        generators.Remove(lettersSmallGenerator);
                    }
                }

                else
                {
                    isLettersSmallSelected = true;
                    generators.Add(lettersSmallGenerator);
                }

                currentPassword = PasswordUtilities.GeneratePassword(currentPasswordLength, generators);
                MainMenuSelection();
            }

            else if (input == 'A')
            {
                isValidInput = true;
                if (isLettersBigSelected)
                {
                    if (generators.Count != 1)
                    {
                        isLettersBigSelected = false;
                        generators.Remove(lettersBigGenerator);
                    }
                }

                else
                {
                    isLettersBigSelected = true;
                    generators.Add(lettersBigGenerator);
                    generators.Add(lettersBigGenerator);
                }

                currentPassword = PasswordUtilities.GeneratePassword(currentPasswordLength, generators);
                MainMenuSelection();
            }

            else if (input == '1')
            {
                isValidInput = true;
                if (isNumberSelected)
                {
                    if (generators.Count != 1)
                    {
                        isNumberSelected = false;
                        generators.Remove(numberGenerator);
                    }
                }

                else
                {
                    isNumberSelected = true;
                    generators.Add(numberGenerator);
                }

                currentPassword = PasswordUtilities.GeneratePassword(currentPasswordLength, generators);
                MainMenuSelection();
            }

            else if (input == '.')
            {
                isValidInput = true;
                if (isSpecialCharacterSelected)
                {
                    if (generators.Count != 1)
                    {
                        isSpecialCharacterSelected = false;
                        generators.Remove(specialCharacterGenerator);
                    }
                }

                else
                {
                    isSpecialCharacterSelected = true;
                    generators.Add(specialCharacterGenerator);
                }

                currentPassword = PasswordUtilities.GeneratePassword(currentPasswordLength, generators);
                MainMenuSelection();
            }

            else if (input == 'e')
                Environment.Exit(0);

            else
            {
                Console.WriteLine("");
                Console.WriteLine("Please select an option");
                Console.WriteLine("Type in the character in the brackets ()");
            }
                      
        } while (isValidInput == false);
    }
}
