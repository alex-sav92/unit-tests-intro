// See https://aka.ms/new-console-template for more information
using PlateReader;

Console.WriteLine("Introdu un nr. de inmatriculare din Romania:");

string plate;
PlateValidator validator = new PlateValidator();
do
{
    plate = Console.ReadLine()!;
    if (validator.IsValid(plate)) 
    {
        Console.WriteLine("Numar valid");
    }
    else
    {
        Console.WriteLine("Numar INVALID");
    }

} while (plate != "q");