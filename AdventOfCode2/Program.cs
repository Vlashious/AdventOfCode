var allInputs = await File.ReadAllLinesAsync("input");
var position = new Position(0, 0, 0);

foreach (var input in allInputs)
{
    var arguments = input.Split(" ");
    var units = int.Parse(arguments[1]);
    position = arguments[0] switch
    {
        "forward" => position with { horizontal = position.horizontal + units, depth = position.depth + position.aim * units },
        "down" => position with { aim = position.aim + units },
        "up" => position with { aim = position.aim - units },
        _ => position
    };
}

Console.WriteLine(position.depth * position.horizontal);

record Position(int horizontal, int depth, int aim);