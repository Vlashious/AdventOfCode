class FirstPartAlgorithm : IAlgorithm
{
    public Task<int> Execute()
    {
        var previousNumber = int.MaxValue;
        var increasesCount = 0;
        foreach (var line in File.ReadLines("input.txt"))
        {
            var currentNumber = int.Parse(line);
            var delta = currentNumber - previousNumber;

            if (delta > 0)
            {
                increasesCount++;
            }

            previousNumber = currentNumber;
        }

        return Task.FromResult(increasesCount);
    }
}