
public class LettersSmallGenerator : AbstractCharacterGenerator, ICharacterGenerator
{
    private string lettersSmall = "abcdefghijklmnopqrstuvwxyz";
    public char Generate()
    {
        int randomNumber = base.random.Next(lettersSmall.Length);
        return lettersSmall[randomNumber];
    }
}

