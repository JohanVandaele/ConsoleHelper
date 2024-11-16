using System.Reflection;
using UIConsole;

namespace VoorbeeldenCursus;

public class Program
{
    private static readonly List<string> Menu =     // Spread operator
    [
        "Menu Item 0",																				// 00
		"Menu Item 1",																				// 01
		"Menu Item 2",																				// 02
		// "Menu Item n",	/																		// 0n
		// . . . .
		// P l a a t s   h i e r   d e   v e r s c h i l l e n d e   m e n u   i t e m s
		// . . . .
	];

    private static string Titel(string t) => $"{Ansi.CURSORHOME}{Ansi.EraseScreen}{new string('=', t.Length)}\n{t}\n{new string('=', t.Length)}\n";

    private static void Main(string[] args)
    {
        UIConsole.Program.StartConsole();

        Console.Title = "EFCoreStart";

        var keuze = string.Empty;

        while (keuze != "X")
        {
            //ResetConsole();	// Problem when using Terminal !!!
            Console.Write($"{UIConsole.Program.ConsBGC}{UIConsole.Program.ConsFGC}{Ansi.EraseScreen}{Ansi.CURSORHOME}");
            Console.WriteLine($"{Ansi.UnderlineOn}MENU{Ansi.UnderlineOf}");

            var item = 0;
            foreach (var m in Menu) Console.WriteLine($"{item++}. {m}");

            keuze = UIConsole.Program.LeesString("Keuze ('X' om te stoppen):", 1, 2, OptionMode.Mandatory)!.ToUpper();

            if (keuze != "X")
            {
                Seperator = true;

                // Reflection
                try
                {
                    //ResetConsole();	// Problem when using Terminal !!!
                    //Console.Write($"{ConsBGC}{ConsFGC}{Ansi.EraseScreen}{Ansi.CURSORHOME}");

                    if (keuze.All(char.IsNumber) && int.Parse(keuze) < Menu.Count) Console.WriteLine(Titel($"{"00"[..(-keuze.Length + 2)] + keuze}" + ". " + Menu.ElementAt(int.Parse(keuze))));

                    //typeof(Program).InvokeMember($"Item{("00".Substring(0, -keuze.Length + 2)) + keuze}"
                    typeof(Program).InvokeMember
                    (
                          $"Item{"00"[..(-keuze.Length + 2)] + keuze}"
                        , BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.NonPublic
                        , null
                        , null
                        , new object[] { new object[] { Titel($"{"00"[..(-keuze.Length + 2)] + keuze}" + ". " + Menu.ElementAt(int.Parse(keuze))), 123 } }
                    );
                }
                catch (Exception)
                {
                    UIConsole.Program.ToonFoutBoodschap("Ongeldige keuze");
                }
            }

            // ===
            // End
            // ===
            if (keuze == "X") break;

            UIConsole.Program.DrukToets();
        }
    }

    // ---------

    private static bool Seperator = false;

    private static void SeperateLog()
    {
        if (!Seperator) return;

        Thread.Sleep(2000); // Wait to Finish logging threat
        if (Seperator) Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - -\n");
        Seperator = false;
    }

    // ---------

    private static void ProcessException(Exception e)
    {
        Console.WriteLine($"\n{Ansi.UnderlineOn}Exception{Ansi.UnderlineOf}\n\n{e.Message}{(e.InnerException != null ? "\n\n" + e.InnerException.Message : "")}");
        Thread.Sleep(2000); // Wait to Finish logging threat
    }

    // ----------
    // Menu-items
    // ----------
    // 00. Menu Item 0
    private static void Item00(object[] args)
    {
        try
        {
            UIConsole.Program.ToonTekst("Kiekeboe", Ansi.FDMAGENTA);
            UIConsole.Program.ToonTekst("Kiekeboe");
            UIConsole.Program.ToonInfoBoodschap("InfoTekst");
            UIConsole.Program.ToonFoutBoodschap("FoutTekst");
        }
        catch (Exception e)
        {
            ProcessException(e);
        }
    }

    // ---------

    // 01. Menu Item 1
    private static void Item01(object[] args)
    {
        try
        {
            UIConsole.Program.ToonInfoBoodschap("Hello World");
        }
        catch (Exception e)
        {
            ProcessException(e);
        }
    }

    // ---------

    // 02. Menu Item 2
    private static void Item02(object[] args)
    {
        try
        {
            UIConsole.Program.ToonInfoBoodschap("Hello Johan");
        }
        catch (Exception e)
        {
            ProcessException(e);
        }
    }
}
