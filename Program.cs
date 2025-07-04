using System;
using System.Linq;
class Program
{
    static void Main()
    {
        string text = "In those days, I didn’t understand anything. I should have judged her according to her actions, not her words. She perfumed my planet and lit up my life. " +
            "I should never have run away! I ought to have realized the tenderness " +
            "underlying her silly pretensions. Flowers are so contradictory! But I was too young to know how to love her.";

        Func<string, int> countWord = word =>
            text.Split(new[] { ' ', '.', ',', '—', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Count(w => w.Equals(word, StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("Count 'her': " + countWord("her"));
        Console.WriteLine("Count 'my': " + countWord("my"));
    }
}
