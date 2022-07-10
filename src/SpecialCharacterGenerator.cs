
public class SpecialCharacterGenerator : AbstractCharacterGenerator, ICharacterGenerator
{
    private string specialCharacters = "öäü,.-;:_#'+*-/?ß=}])[({&%$§!°^<>|´`~";
    public char Generate()
    {
        int randomNumber = base.random.Next(specialCharacters.Length);
        return specialCharacters[randomNumber];
    }
}

