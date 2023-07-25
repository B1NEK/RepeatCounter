
class Program
{
    static void Main(string[] args)
    {
        string filePath = "/Users/petrbinek/Desktop/Povtoreniya.txt";

        string text = File.ReadAllText(filePath);

        // Удаление знаков пунктуации
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        // Разделение текста на слова
        string[] words = noPunctuationText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Счетчик слов
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        // Подсчет частоты появления каждого слова
        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
            else
            {
                wordCount[word] = 1;
            }
        }

        // Сортировка по убыванию частоты
        var sortedWords = wordCount.OrderByDescending(pair => pair.Value);

        // Вывод 10 наиболее часто встречающихся слов
        int count = 0;
        foreach (var pair in sortedWords)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
            count++;
            if (count >= 10)
            {
                break;
            }
        }
    }
}
