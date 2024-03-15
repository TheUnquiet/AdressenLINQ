using BL.interfaces;
using BL.managers;
using BL.models;
using DL;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        // Test
        Console.WriteLine("Hello World");
        string filename = @"C:\Users\Gebruiker\Documents\Hogent\pro-gev\Adressen\ClassLibrary1\DL\tesxtFiles\adresinfo.txt";
        IFileProcessor fp = new FileProcessor();
        AdresManager am = new AdresManager(fp);
        List<string> adresses = fp.ReadAdresses(filename);
        List<Adres> list = am.MakeAdresses(adresses); // final list of adres objects
        LogFinsihed("Reading and writing adresses");

        // LINQ Query 1
        var provinceNamesAlphabetical = list.OrderBy(a => a.Provincie).Select(a => a.Provincie).Distinct();
        foreach (var r in provinceNamesAlphabetical) { Console.WriteLine(r); }
        LogFinsihed();

        // LINQ Query 2
        //StraatNamenGemeente("Aartselaar", list);
        LogFinsihed();

        // LINQ Query 3
        var straatNaamMeesteVooromt = list.GroupBy(a => a.StraatNaam) // group streets 
            .OrderByDescending(a => a.Count()) // order by biggest count
            .First() // get first group
            .OrderBy(a => a.Provincie)
            .ThenBy(a => a.Gemeente);
        foreach (var s in straatNaamMeesteVooromt) { Console.WriteLine($"{s.Provincie}, {s.Gemeente}, {s.StraatNaam}"); }

        LogFinsihed();

        // LINQ Query 8
        var langsteStraatNaam = list.OrderByDescending(a => a.StraatNaam.Length).Distinct().First();
        Console.Write(langsteStraatNaam.StraatNaam);

        // LINQ Query 9
        Console.Write($", {langsteStraatNaam.Gemeente}, {langsteStraatNaam.Provincie}");

        LogFinsihed();

        // LINQ Query 10
        var UniekeStraatNamen = list.Select(a => (a.StraatNaam, a.Gemeente, a.Provincie) ).Distinct(); // return a tuple
        foreach (var s in  UniekeStraatNamen) { Console.WriteLine(s); }

        LogFinsihed();

        // LINQ Query 11
        StraatNamenGemeenteUniek("Ham", list);
    }

    static void StraatNamenGemeente(string gemeente, List<Adres> list)
    {
        // LINQ Query 2
        var res = list.Where(a => a.Gemeente == gemeente).Select(a => a.StraatNaam);
        foreach (var r in res) { Console.WriteLine(r); }
    }

    static void StraatNamenGemeenteUniek(string gemeente, List<Adres> list)
    {
        var res = list.Where(a => a.Gemeente == gemeente).Select(a => a.StraatNaam).Distinct();
        foreach (var r in res) { Console.WriteLine(r); }
    }

    static void LogFinsihed(string? message = "")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Finshed! " + message + "\n");
        Console.ForegroundColor = ConsoleColor.White;
    }
}