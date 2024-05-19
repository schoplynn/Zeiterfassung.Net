//using CommandLineParser.Arguments;
//using CommandLineParser.Exceptions;

//CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser();
////switch argument is meant for true/false logic
//SwitchArgument showArgument = new SwitchArgument('s', "show", "Set whether show or not", true);
//ValueArgument<decimal> version = new ValueArgument<decimal>('v', "version", "Set desired version");
//EnumeratedValueArgument<string> color = new EnumeratedValueArgument<string>('c', "color", new string[] { "red", "green", "blue" });

//parser.Arguments.Add(showArgument);
//parser.Arguments.Add(version);
//parser.Arguments.Add(color);

//try
//{
//    parser.ParseCommandLine(args);
//    //parser.ShowParsedArguments();

//    if (showArgument.Parsed)
//    {
//        Console.WriteLine("Show wurde angegeben");
//    }

//    // now you can work with the arguments ... 

//    // if (color.Parsed) ... test, whether the argument appeared on the command line
//    // {
//    //     color.Value ... contains value of the level argument
//    // } 
//    // if (showArgument.Value) ... test the switch argument value 
//    //     ... 
//}
//catch (CommandLineException e)
//{
//    Console.WriteLine(e.Message);
//}

//#region Interactive Interface
//using System;
//using System.Collections.Generic;

//// Command dictionary to store available commands and their actions
//Dictionary<string, Action> commands = new Dictionary<string, Action>
//    {
//        { "help", ShowHelp },
//        { "exit", ExitShell },
//        { "greet", GreetUser }
//    };

//Console.WriteLine("Welcome to the ShellApp! Type 'help' for a list of commands.");

//bool running = true;
//while (running)
//{
//    Console.Write("ShellApp> ");
//    string input = Console.ReadLine();
//    if (string.IsNullOrWhiteSpace(input))
//    {
//        continue;
//    }

//    string command = input.Trim().ToLower();
//    if (commands.ContainsKey(command))
//    {
//        commands[command].Invoke();
//    }
//    else
//    {
//        Console.WriteLine($"Unknown command: {command}");
//    }
//}

//static void ShowHelp()
//{
//    Console.WriteLine("Available commands:");
//    Console.WriteLine("  help  - Show this help message");
//    Console.WriteLine("  exit  - Exit the shell");
//    Console.WriteLine("  greet - Greets the user");
//}

//static void ExitShell()
//{
//    Console.WriteLine("Exiting the shell...");
//    Environment.Exit(0);
//}

//static void GreetUser()
//{
//    Console.Write("Enter your name: ");
//    string name = Console.ReadLine();
//    Console.WriteLine($"Hello, {name}!");
//}
//#endregion

//string[] options = { "Option 1", "Option 2", "Option 3", "Exit" };
//int currentSelection = 0;

//ConsoleKeyInfo keyInfo;
//do
//{
//    Console.Clear();
//    for (int i = 0; i < options.Length; i++)
//    {
//        if (i == currentSelection)
//        {
//            Console.BackgroundColor = ConsoleColor.Gray;
//            Console.ForegroundColor = ConsoleColor.Black;
//        }

//        Console.WriteLine(options[i]);

//        Console.ResetColor();
//    }

//    keyInfo = Console.ReadKey();

//    if (keyInfo.Key == ConsoleKey.DownArrow)
//    {
//        currentSelection++;
//        if (currentSelection >= options.Length)
//        {
//            currentSelection = 0;
//        }
//    }
//    else if (keyInfo.Key == ConsoleKey.UpArrow)
//    {
//        currentSelection--;
//        if (currentSelection < 0)
//        {
//            currentSelection = options.Length - 1;
//        }
//    }
//} while (keyInfo.Key != ConsoleKey.Enter);

//Console.Clear();
//Console.WriteLine($"You selected: {options[currentSelection]}");

//if (currentSelection != options.Length - 1)
//{
//    // Handle other options here
//    Console.WriteLine($"Handling {options[currentSelection]}...");
//}
//else
//{
//    Console.WriteLine("Exiting...");
//}


using Com.ChristianBier.Zeiterfassung.Data.Models;
using Com.ChristianBier.Zeiterfassung.Data.Services;

var entries = SqliteDataAccessService.LoadEintraege();
TimeSpan timetotal = new TimeSpan();
foreach (var e in entries)
{
    Console.WriteLine($"Eintrag Nr. {e.Id}");
    Console.WriteLine($"Am {e.Date}");
    Console.WriteLine($"wurde von {e.TimeStart.ToString("HH:mm")} Uhr");
    Console.WriteLine($"bis {e.TimeEnd.ToString("HH:mm")} Uhr gearbeitet.");
    Console.WriteLine($"Gesamtzeit: {e.Dauer.Hours}:{e.Dauer.Minutes}");
    Console.WriteLine($"Und folgendes getan:\r\n{e.Text}");
    Console.WriteLine($"-----------------");
    timetotal += e.Dauer;
    e.Text = String.Concat(e.Text, " ", "Dieser Text wurde hinzugefügt");
    SqliteDataAccessService.SaveEintag(e);
}

Eintrag newE = new Eintrag();
newE.Date = DateTime.Now;
newE.TimeStart = DateTime.Now;
newE.TimeEnd = DateTime.Now.AddMinutes(67);
newE.Text = "Habe TV geschaut";
SqliteDataAccessService.SaveEintag(newE);

Console.WriteLine("====================");
Console.WriteLine($"Gesamtzeit: {timetotal.Hours} Stunden und {timetotal.Minutes} Minuten");
Console.ReadLine();