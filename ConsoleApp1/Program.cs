// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

Console.WriteLine("No Transform: Select 1");
Console.WriteLine("Transform: Select 2");
int selection = int.Parse(Console.ReadLine()!);
switch (selection)
{
    case 1:
        RepositoryNoTransform.ProcessFluent();
        Console.WriteLine();
        RepositoryNoTransform.ProcessAnnotations();
        break;
    case 2:
        RepositoryTransform.ProcessFluent();
        Console.WriteLine();
        RepositoryTransform.ProcessAnnotations();
        break;
}