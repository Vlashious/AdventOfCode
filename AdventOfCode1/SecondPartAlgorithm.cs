class SecondPartAlgorithm : IAlgorithm
{
    public async Task<int> Execute()
    {
        var allWindows = new List<List<int>>();
        var allLines = await File.ReadAllLinesAsync("input.txt");
        var allNumbers = allLines.Select(line => int.Parse(line)).ToArray();

        for (var i = 0; i < allNumbers.Length; i++)
        {
            if (i == allNumbers.Length - 2)
            {
                break;
            }

            allWindows.Add(new() { allNumbers[i], allNumbers[i + 1], allNumbers[i + 2] });
        }

        var allSums = allWindows.Select(window => window.Sum()).ToArray();
        var previousNumber = int.MaxValue;
        var increasesCount = 0;

        foreach (var sum in allSums)
        {
            var delta = sum - previousNumber;

            if (delta > 0)
            {
                increasesCount++;
            }

            previousNumber = sum;
        }

        return increasesCount;
    }
}