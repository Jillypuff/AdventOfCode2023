string input = File.ReadAllText("../../../Data.txt");
string[] inputs = input.Split("\r\n");

int sum = 0;
foreach (string s in inputs)
{
    sum += GetBothNumbers(s);
}

Console.WriteLine(sum);

int GetBothNumbers(string s)
{
    string[] numbers = ["one","two","three","four","five","six","seven","eight","nine",
                        "1","2","3","4","5","6","7","8","9"];
    string firstNumber = "";
    string secondNumber = "";

    int firstIndex = Int32.MaxValue;
    int lastIndex = -1;
    int index;

    foreach (string number in numbers)
    {
        index = s.IndexOf(number);
        if (index != -1)
        {
            if (index < firstIndex)
            {
                firstIndex = index;
                firstNumber = number;
            }
        }
    }
    foreach (string number in numbers)
    {
        index = s.LastIndexOf(number);
        if (index != -1)
        {
            if (index > lastIndex)
            {
                lastIndex = index;
                secondNumber = number;
            }
        }
    }

    if (firstNumber.Length != 1)
    {
        firstNumber = ConvertNumber(firstNumber);
    }
    if (secondNumber.Length != 1)
    {
        secondNumber = ConvertNumber(secondNumber);
    }

    string returnValue = firstNumber + secondNumber;
    return Int32.Parse(returnValue);
}

string ConvertNumber(string s)
{
    s = s.ToLower();
    if (s.Equals("one"))
        return "1";
    else if (s.Equals("two"))
        return "2";
    else if (s.Equals("three"))
        return "3";
    else if (s.Equals("four"))
        return "4";
    else if (s.Equals("five"))
        return "5";
    else if (s.Equals("six"))
        return "6";
    else if (s.Equals("seven"))
        return "7";
    else if (s.Equals("eight"))
        return "8";

    return "9";
}