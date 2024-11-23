using System;

class CricketTeam
{
    public void PointsCalculation(int noOfMatches)
    {
        int[] scores = new int[noOfMatches];
        int sum = 0;

        Console.WriteLine($"Enter the scores for {noOfMatches} matches:");

        for (int i = 0; i < noOfMatches; i++)
        {
            Console.Write($"Match {i + 1}: ");
            scores[i] = int.Parse(Console.ReadLine());
            sum += scores[i];
        }

        double average = (double)sum / noOfMatches;

        Console.WriteLine("\n--- Results ---");
        Console.WriteLine($"Number of Matches: {noOfMatches}");
        Console.WriteLine($"Total Score: {sum}");
        Console.WriteLine($"Average Score: {average}");
        Console.ReadLine();
    }

    static void Main()
    {
        Console.WriteLine("Enter the number of matches played:");
        int noOfMatches = int.Parse(Console.ReadLine());

        CricketTeam team = new CricketTeam();
        team.PointsCalculation(noOfMatches);
    }
}