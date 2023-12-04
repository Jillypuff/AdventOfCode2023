string input = File.ReadAllText("../../../Data.txt");
string[] inputs = input.Split("\r\n");

int totalWinnings = 0;

foreach (string data in inputs)
{
    totalWinnings += CalculateWinnings(data);
}

Console.WriteLine(totalWinnings);



int CalculateWinnings(string data)
{
    data = StripCardNumber(data);
    int[] winningNumbers = GetNumbers(data.Split('|').First());
    int[] playerNumbers = GetNumbers(data.Split('|').Last());
    int totalWinnings = 0;
    foreach (int winningNumber in winningNumbers)
    {
        if (playerNumbers.Contains(winningNumber))
        {
            totalWinnings = totalWinnings == 0 ? totalWinnings + 1 : totalWinnings * 2;
        }
    }

    return totalWinnings;
}

int[] GetNumbers(string data)
    => data.Split(' ')
           .Where(s => !string.IsNullOrWhiteSpace(s))
           .Select(x => int.Parse(x.Trim()))
           .ToArray();

string StripCardNumber(string data) 
    => data.Split(':').Last();


