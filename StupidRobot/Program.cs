using StupidRobot;

Console.WriteLine("Welcome to FRIDAY world, kindly set her place and let her know her instruction :D");
Console.WriteLine("Or you can use EXIT command to shut her down :)");
var FRIDAY = new Robot();
var shouldContinue = true;
var hasPlacedFRIDAY = false;

while (shouldContinue)
{
    var action = Console.ReadLine();

    if (string.IsNullOrEmpty(action))
    {
        continue;
    }

    action = action.ToUpper().Trim();

    if (action == "EXIT")
    {
        Console.WriteLine("FRIDAY is going to be turn off.");
        break;
    }

    if (!action.Contains("PLACE") && !hasPlacedFRIDAY)
    {
        Console.WriteLine("FRIDAY doesn't know where she is located :(");
        continue;
    }

    if (action.Contains("PLACE"))
    {
        var placeArr = action.Split(" ");
        if (placeArr.Length != 2)
        {
            Console.WriteLine("Invalid Instruction");
            continue;
        }

        var positionInformation = placeArr[1];
        var positionInformationArr = positionInformation.Split(",");
        if (positionInformationArr.Length != 3)
        {
            Console.WriteLine("Invalid Instruction");
            continue;
        }

        try
        {
            var x = Convert.ToInt16(positionInformationArr[0]);
            var y = Convert.ToInt16(positionInformationArr[1]);
            var f = Enum.Parse<DirectionEnum>(positionInformationArr[2]);
            FRIDAY.SetPosition(x, y, f);
            hasPlacedFRIDAY = true;
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid Instruction");
        }

        continue;
    }

    switch (action)
    {
        case "MOVE":
            FRIDAY.MoveForward();
            break;
        case "LEFT":
            FRIDAY.TurnLeft();
            break;
        case "RIGHT":
            FRIDAY.TurnRight();
            break;
        case "REPORT":
            Console.WriteLine(FRIDAY.ToString());
            break;
        default:
            Console.WriteLine("Invalid instruction");
            break;
    }
}

Thread.Sleep(1500);