
public class NumberGenerator : AbstractCharacterGenerator, ICharacterGenerator
{
    private string numbers = "0123456789";
    public char Generate()
    {
        int randomNumber = base.random.Next(numbers.Length);
        return numbers[randomNumber];
    }
}

