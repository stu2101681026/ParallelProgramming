using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    
    public static void WordsCount(List<string> words)
    {
        
        int count = 0;
        foreach (string word in words) 
        { 
            count++;
        }
        Console.WriteLine( "The total amount of words is " + count);

    }
    public static void GetShortestWord(List<string> words)
    {
        string shortestWord = words[0];
        foreach (string word in words)
        {
            if (word.Length < shortestWord.Length)
            {
                shortestWord = word;
            }
        }
        Console.WriteLine("Shortest word is " + shortestWord);
    }
    public static void GetLongestWord(List<string> words)
    {
        string longestWord = words[0];
        foreach (string word in words)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
            }
        }
        Console.WriteLine("Longest word is " + longestWord);
    }
    

    public static void GetAverageLength(List<string> words)
    {
        double sum = 0;
        foreach(string word in words)
        {
            sum += word.Length;
        }
        Console.WriteLine("Average length of words is " + sum / words.Count + " symbols");
    }

    static Dictionary<string, int> CountWordFrequency(List<string> words)
    {
        Dictionary<string, int> frequency = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (frequency.ContainsKey(word))
            {
                frequency[word]++;
            }
            else
            {
                frequency[word] = 1;
            }
        }
        return frequency;
    }

    static List<string> FindMostCommonWords(Dictionary<string, int> wordFrequency, int count)
    {
        
        List<string> mostCommonWords = new List<string>();
        foreach (var pair in wordFrequency.OrderByDescending(pair => pair.Value).Take(count))
        {
            mostCommonWords.Add(pair.Key);
        }
        return mostCommonWords;
    }

    static List<string> FindLeastCommonWords(Dictionary<string, int> wordFrequency, int count)
    {
        List<string> leastCommonWords = new List<string>();
        foreach (var pair in wordFrequency.OrderBy(pair => pair.Value).Take(count))
        {
            leastCommonWords.Add(pair.Key);
        }
        return leastCommonWords;
    }

    private static void Main(string[] args)
    {
        string text = File.ReadAllText("frina.txt");
        char[] delimiterChars = { ' ', ',', '.', ';', '/', '"', '(', ')', '?', '!', '-', '\t' };

        string[] fakewords = text.Split(delimiterChars);
        List<string> words = new List<string>();

        foreach (string word in fakewords)
        {
            if (word.Length >= 3)
            {
                words.Add(word.ToLower());
            }
        }

        Dictionary<string, int> wordFrequency = CountWordFrequency(words);

        List<string> mostCommonWords = FindMostCommonWords(wordFrequency, 5);
        List<string> leastCommonWords = FindLeastCommonWords(wordFrequency, 5);

        WordsCount(words);
        GetShortestWord(words);
        GetLongestWord(words);
        GetAverageLength(words);

        Console.WriteLine($"Five most common words: {string.Join(", ", mostCommonWords)}");
        Console.WriteLine($"Five least common words: {string.Join(", ", leastCommonWords)}");


    }
}