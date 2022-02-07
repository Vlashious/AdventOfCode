var allInputs = await File.ReadAllLinesAsync("input");
var oxygenLines = await File.ReadAllLinesAsync("input");
var scrubberLines = await File.ReadAllLinesAsync("input");
var lineLength = allInputs.FirstOrDefault()!.Length;
var gamma = "";
var epsilon = "";

for (var i = 0; i < lineLength; i++)
{
    var iColumn = allInputs.Select(line => line[i]);
    var oneCount = iColumn.Count(ch => ch == '1');
    var zeroCount = iColumn.Count(ch => ch == '0');
    var isOneMostCommon = oneCount >= zeroCount;

    (gamma, epsilon) = isOneMostCommon switch
    {
        true => (gamma + "1", epsilon + "0"),
        false => (gamma + "0", epsilon + "1")
    };
}

for (var i = 0; i < lineLength; i++)
{
    var iOxygenColumn = oxygenLines.Select(line => line[i]);
    var oxygenOneCount = iOxygenColumn.Count(ch => ch == '1');
    var oxygenZeroCount = iOxygenColumn.Count(ch => ch == '0');

    var iScrubbleColumn = scrubberLines.Select(line => line[i]);
    var scrubbleOneCount = iScrubbleColumn.Count(ch => ch == '1');
    var scrubbleZeroCount = iScrubbleColumn.Count(ch => ch == '0');

    Func<string, bool> oxygenSelector = line =>
    {
        return line[i] == (oxygenOneCount >= oxygenZeroCount) switch
        {
            true => '1',
            false => '0'
        };
    };

    Func<string, bool> scrubberSelector = line =>
    {
        return line[i] == (scrubbleOneCount >= scrubbleZeroCount) switch
        {
            true => '0',
            false => '1'
        };
    };

    if (oxygenLines.Count() != 1)
    {
        oxygenLines = oxygenLines.Where(oxygenSelector).ToArray();
    }

    if (scrubberLines.Count() != 1)
    {
        scrubberLines = scrubberLines.Where(scrubberSelector).ToArray();
    }
}

var gammaNum = Convert.ToInt64(gamma, 2);
var epsilonNum = Convert.ToInt64(epsilon, 2);

var oxygenNum = Convert.ToInt64(oxygenLines.FirstOrDefault()!, 2);
var scrubberNum = Convert.ToInt64(scrubberLines.FirstOrDefault()!, 2);

Console.WriteLine(gammaNum * epsilonNum);
Console.WriteLine(oxygenNum * scrubberNum);