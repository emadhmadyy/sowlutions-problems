using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\Administrator\Desktop\prediction.csv";

        var playerDataList = ReadDataFromCsv(filePath);

        Console.WriteLine("Enter the Card Suit:");
        string cardSuit = Console.ReadLine();
        Console.WriteLine("Enter the Animal Name:");
        string animalName = Console.ReadLine();
        Console.WriteLine("Enter the Fruit:");
        string fruit = Console.ReadLine();

        double suitProbability = CalculateCategoryProbability(playerDataList, "CardSuit", cardSuit);
        double animalProbability = CalculateCategoryProbability(playerDataList, "AnimalName", animalName);
        double fruitProbability = CalculateCategoryProbability(playerDataList, "Fruit", fruit);

        double averageProbability = (suitProbability + animalProbability + fruitProbability) / 3;

        Console.WriteLine($"The average probability of getting True for {cardSuit}, {animalName}, {fruit} is: {averageProbability * 100:F2}%");
    }

    static List<PlayerData> ReadDataFromCsv(string filePath)
    {
        var records = new List<PlayerData>();

        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (values.Length == 4 && bool.TryParse(values[3].Trim(), out bool result))
                {
                    records.Add(new PlayerData(values[0].Trim(), values[1].Trim(), values[2].Trim(), result));
                }
            }
        }

        return records;
    }

    static double CalculateCategoryProbability(List<PlayerData> playerDataList, string categoryType, string categoryValue)
    {
        int totalCount = 0;
        int trueCount = 0;

        foreach (var record in playerDataList)
        {
            if ((categoryType == "CardSuit" && record.CardSuit.Equals(categoryValue, StringComparison.OrdinalIgnoreCase)) ||
                (categoryType == "AnimalName" && record.AnimalName.Equals(categoryValue, StringComparison.OrdinalIgnoreCase)) ||
                (categoryType == "Fruit" && record.Fruit.Equals(categoryValue, StringComparison.OrdinalIgnoreCase)))
            {
                totalCount++;
                if (record.Result) trueCount++;
            }
        }

        return totalCount > 0 ? (trueCount / (double)totalCount) : 0;
    }
}

class PlayerData
{
    public string CardSuit { get; }
    public string AnimalName { get; }
    public string Fruit { get; }
    public bool Result { get; }

    public PlayerData(string cardSuit, string animalName, string fruit, bool result)
    {
        CardSuit = cardSuit;
        AnimalName = animalName;
        Fruit = fruit;
        Result = result;
    }
}
