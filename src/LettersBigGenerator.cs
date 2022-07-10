
public class LettersBigGenerator : AbstractCharacterGenerator, ICharacterGenerator
{
    private string lettersBig = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public char Generate()
    {
        int randomNumber = base.random.Next(lettersBig.Length);
        return lettersBig[randomNumber];
    }
}

