﻿using NetFoundy.Concepts;

var topic = args[0];
switch (topic)
{
    case "reftypes":
        ReferenceTypes.Run();
        break;
    default:
        Console.WriteLine("Unknown topic");
        break;
}