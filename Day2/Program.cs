using System.Drawing;

string input = File.ReadAllText("../../../Data.txt");
string[] inputs = input.Split("\n");

int sum = 0;

foreach (string data in inputs)
{
    sum += GetPower(data);
}

Console.WriteLine(sum);

int GetPower(string data)
{
    string[] colors = ["red", "green", "blue"];
    string[] turns = data.Split(';');
    int redMin = 0;
    int greenMin = 0;
    int blueMin = 0;

    int index = 0;
    foreach (string turn in turns)
    {
        foreach (string color in colors)
        {
            index = turn.IndexOf(color);
            if (index != -1)
            {
                int cubes = GetNumberOfCubes(color, turn);
                switch (color)
                {
                    case "red":
                        redMin = Math.Max(redMin, cubes);
                        break;
                    case "green":
                        greenMin = Math.Max(greenMin, cubes);
                        break;
                    case "blue":
                        blueMin = Math.Max(blueMin, cubes);
                        break;
                }
            }
        }
    }
    return redMin * greenMin * blueMin;
}

int GetNumberOfCubes(string color, string data)
{
    data = " " + data;
    int index = data.IndexOf(color);
    return Int32.Parse(data[(index - 3)..(index - 1)]);
}

// Part one stuff
//bool CheckValidGame(string data)
//{
//    string[] colors = ["red", "green", "blue"];
//    string[] turns = data.Split(';');

//    int index = -1;
//    foreach (string turn in turns)
//    {
//        foreach (string color in colors)
//        {
//            index = turn.IndexOf(color);
//            if (index != -1)
//            {
//                if (CheckToManyCubes(color, turn)){
//                    return false;
//                }
//            }
//        }
//    }
//    return true;
//}

//bool CheckToManyCubes(string color, string data)
//{
//    int maxRed = 12;
//    int maxGreen = 13;
//    int maxBlue = 14;
//    int numberOfCubes = GetNumberOfCubes(color, data);

//    return color switch
//    {
//        "red" => numberOfCubes > maxRed,
//        "green" => numberOfCubes > maxGreen,
//        "blue" => numberOfCubes > maxBlue,
//        _ => false,
//    };
//}

//int GetGameId(string game)
//{
//    int index = game.IndexOf(':');
//    return Int32.Parse(game[4..index]);
//}