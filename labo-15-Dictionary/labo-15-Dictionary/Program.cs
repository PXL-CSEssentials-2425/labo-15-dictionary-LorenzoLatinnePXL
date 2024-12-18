using System.Runtime.Intrinsics.Arm;

public class Program
{

    static string userInput = "0";
    static Dictionary<string, int> klassement = new Dictionary<string, int>()
    {
            { "Emma", 18 },
            { "Liam", 19 },
            { "Noah", 17 },
            { "Olivia", 20 }
    };

    public static void Main(string[] args)
    {

        do
        {
            Console.Write(@"Welkom bij het Klassement Beheer Systeem!
Kies een optie uit het menu:

1. Toon het klassement
2. Zoek de score van een deelnemer
3. Pas de score van een deelnemer aan of voeg een nieuwe deelnemer toe
4. Toon de gemiddelde score
5. Toon de deelnemer met de hoogste score
6. Stop het programma

Maak uw keuze: ");
            Console.WriteLine();

            userInput = Console.ReadLine();
            Console.WriteLine();

            switch (userInput)
            {
                case "1":
                    ToonKlassement();
                    break;
                case "2":
                    ZoekScoreVanDeelnemer();
                    break;
                case "3":
                    WriteDeelnemer();
                    break;
                case "4":
                    ToonGemiddelde();
                    break;
                case "5":
                    ToonHoogsteScore();
                    break;
            }
        } while (!userInput.Equals("6") || userInput == null);
    }

    private static void ToonHoogsteScore()
    {
        int hoogsteScore = 0;
        string besteStudent = "";

        foreach (string key in klassement.Keys)
        {
            if (klassement[key] > hoogsteScore)
            {
                hoogsteScore = klassement[key];
                besteStudent = key;
            }
        }

        Console.WriteLine($"De deelnemer met de hoogste score is {besteStudent} met {hoogsteScore} punten.");
        Console.WriteLine();
    }

    private static void ToonGemiddelde()
    {
        double aantalStudenten = klassement.Count;
        double totaalScore = 0;

        foreach (int value in klassement.Values)
        {
            totaalScore += value;
        }

        double gemiddelde = totaalScore / aantalStudenten;

        Console.WriteLine($"De gemiddelde score van alle deelnemers is: {gemiddelde} punten.");
        Console.WriteLine();
    }

    private static void WriteDeelnemer()
    {
        bool isEenGetal;
        string ingegevenNaam;
        int ingegevenPunten;

        Console.Write("Geef de naam van een deelnemer: ");
        ingegevenNaam = Console.ReadLine();

        do
        {
            Console.Write("Geef de nieuwe score: ");
            isEenGetal = int.TryParse(Console.ReadLine(), out ingegevenPunten);

            if (!isEenGetal)
            {
                Console.WriteLine("Geef een getal.");
            }
        } while (!isEenGetal);

        if (klassement.ContainsKey(ingegevenNaam))
        {
            klassement[ingegevenNaam] = ingegevenPunten;
            Console.WriteLine($"De score van {ingegevenNaam} is bijgewerkt naar {ingegevenPunten} punten.");
        } 
        else
        {
            klassement.Add(ingegevenNaam , ingegevenPunten);
            Console.WriteLine($"{ingegevenNaam} is toegevoegd aan het klassement met {ingegevenPunten} punten.");
        }

        Console.WriteLine();


    }

    private static void ZoekScoreVanDeelnemer()
    {
        Console.Write("Geef de naam van een deelnemer: ");

        string gezochteNaam = Console.ReadLine();
        int puntenVanGezochteNaam = 0;

        if (klassement.TryGetValue(gezochteNaam, out puntenVanGezochteNaam))
        {
            Console.WriteLine($"{gezochteNaam} heeft {puntenVanGezochteNaam} punten");
        }
        else
        {
            Console.WriteLine($"{gezochteNaam} staat niet in het klassement.");
        }
        Console.WriteLine();
    }

    private static void ToonKlassement()
    {
        Console.WriteLine("Klassement: ");
        foreach (string key in klassement.Keys)
        {
            Console.WriteLine($"- {key}: {klassement[key]} punten");
        }
        Console.WriteLine();
    }
}