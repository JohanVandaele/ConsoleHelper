namespace UIConsole;

public static partial class Program
{
    // ----
    // Menu
    // ----
    public static SubMenu Menu = new(
        01, null, " Hoofdmenu ", MenuItemActive.Enabled, MenuItemVisible.Visible,
        [
            new SubMenu(01, "<I>nput", "Input", MenuItemActive.Enabled, MenuItemVisible.Visible,
                [
                    new MenuAction (03,"<1> Lees String","Lees String",MenuItemActive.Enabled, MenuItemVisible.Visible,Item01),
                    new MenuAction (03,"<2> Lees DatumTijd","Lees DatumTijd",MenuItemActive.Enabled, MenuItemVisible.Visible,Item02),
                    new MenuAction (03,"<3> Lees Datum","Lees Datum",MenuItemActive.Enabled, MenuItemVisible.Visible,Item03),
                    new MenuAction (03,"<4> Lees Tijd","Lees Tijd",MenuItemActive.Enabled, MenuItemVisible.Visible,Item04),
                    new MenuAction (03,"<5> Lees Getal","Lees Getal",MenuItemActive.Enabled, MenuItemVisible.Visible,Item05),
                    new MenuAction (03,"<6> Lees Integer","Lees Integer",MenuItemActive.Enabled, MenuItemVisible.Visible,Item06),
                    new MenuAction (03,"<7> Lees Decimal","Lees Decimal",MenuItemActive.Enabled, MenuItemVisible.Visible,Item07),
                    new MenuAction (03,"<8> Lees Float","Lees Float",MenuItemActive.Enabled, MenuItemVisible.Visible,Item08),
                    new MenuAction (03,"<9> Lees Boolean","Lees Boolean",MenuItemActive.Enabled, MenuItemVisible.Visible,Item09),
                    new MenuLijn(),
                    new MenuAction (03,"L i j s t e n","",MenuItemActive.Disabled, MenuItemVisible.Visible,null!),
                    new MenuAction (03,"<A> Lees Enum","Lees Enum",MenuItemActive.Enabled, MenuItemVisible.Visible,Item18),
                    new MenuAction (03,"<B> Maak een keuze uit een lijst","Lees String",MenuItemActive.Enabled, MenuItemVisible.Visible,Item10),
                    new MenuAction (03,"<C> Maak een keuze uit een simpele lijst","Lees Simpele Lijst",MenuItemActive.Enabled, MenuItemVisible.Visible,Item11),
                    new MenuLijn(),
                    new MenuAction (03,"R e g E x","",MenuItemActive.Disabled, MenuItemVisible.Visible,null!),
                    new MenuAction (03,"<D> Lees Telefoon nummer","Lees Telefoonnummer",MenuItemActive.Enabled, MenuItemVisible.Visible,Item12),
                    new MenuAction (03,"<E> Lees E-mail adres","Lees E-mail-adres",MenuItemActive.Enabled, MenuItemVisible.Visible,Item13),
                    new MenuAction (03,"<E> Lees Website URL","Lees Website URL",MenuItemActive.Enabled, MenuItemVisible.Visible,Item14),
                    new MenuAction (03,"<F> Lees Paswoord","Lees Paswoord",MenuItemActive.Enabled, MenuItemVisible.Visible,Item15),
                ]),
            new SubMenu(02, "<O>utput", "Output", MenuItemActive.Enabled, MenuItemVisible.Visible,
                [
                    new MenuAction (03,"<1> Toon Boodschappen","Toon Boodschappen",MenuItemActive.Enabled, MenuItemVisible.Visible,Item16),
                    new MenuAction (03,"<2> Toon met kleur in tekst","Toon met kleur",MenuItemActive.Enabled, MenuItemVisible.Visible,Item17),
                ]),
            new MenuAction (03,"Voorbeeld werken met <l>ijsten","Voorbeeld lijst",MenuItemActive.Enabled, MenuItemVisible.Visible,Item19),
            new MenuAction (03,"<T>erminal Escape Codes","Escapecodes",MenuItemActive.Enabled, MenuItemVisible.Visible,Ansi.AnsiCodeTest),
        ]
    );

    public static void Main(string[] args)
    {
        MenuGegevens = $"Demo toepassing voor het testen van de ConsoleHelper methods";

        // - - - 
        // Menu
        // - - - 
        //PrintMenu("UI Demo", Menu);		// Toon menustructuur
        ToonMenu("UI Demo", Menu);          // Start het programma
    }

    // -----------
    // Lees String
    // -----------
    private static void Item01()
    {
        string? input;

        // Input zonder parameters
        ToonInfoBoodschap($"Input zonder parameters");
        input = LeesString();
        ToonSuccessBoodschap($"String = '{input ?? "NULL"}'");

        Console.WriteLine();

        // Input met enkel label
        ToonInfoBoodschap($"Input met enkel Label");
        input = LeesString("Geef een tekst in");
        ToonSuccessBoodschap($"String = '{input ?? "NULL"}'");

        Console.WriteLine();

        // Input met label en negatieve minLength en maxLength
        ToonInfoBoodschap($"Input met label en negatieve minLength en maxLength");
        input = LeesString("Geef een tekst in", -5, -6);
        ToonSuccessBoodschap($"String = '{input ?? "NULL"}'");

        Console.WriteLine();

        // Input verplicht
        ToonInfoBoodschap($"Input verplicht");
        input = LeesString("Geef een tekst in", 0, 5, OptionMode.Mandatory);
        ToonSuccessBoodschap($"String = '{input ?? "NULL"}'");

        Console.WriteLine();

        // Input met teruggave van string.Empty indien geen ingave
        ToonInfoBoodschap($"Input met teruggave van string.Empty indien geen ingave");
        input = LeesString("Geef een tekst in", 0, 5, OptionMode.Optional, ReturnNullOrEmpty.Empty);
        ToonSuccessBoodschap($"String = '{input ?? "NULL"}'");

        Console.WriteLine();

        // Input met teruggave van NULL indien geen ingave
        ToonInfoBoodschap($"Input met teruggave van NULL indien geen ingave");
        input = LeesString("Geef een tekst in", 0, 5, OptionMode.Optional, ReturnNullOrEmpty.Null);
        ToonSuccessBoodschap($"String = '{input ?? "NULL"}'");
    }

    // -------------
    // Lees DateTime
    // -------------
    private static void Item02()
    {
        DateTime? input;

        // Optionele input
        ToonInfoBoodschap($"Optionele input met minDateTime en maxDateTime");
        input = LeesDatumTijd("Geef DatumTijd in", new DateTime(2024, 10, 31, 4, 10, 10), new DateTime(2025, 10, 31, 4, 10, 10));
        ToonSuccessBoodschap($"DateTime = '{(input == null ? "NULL" : input.ToString())}'");

        Console.WriteLine();

        // Verplichte input
        ToonInfoBoodschap($"Verplichte input met minDateTime en maxDateTime");
        input = LeesDatumTijd("Geef DatumTijd in", new DateTime(2024, 10, 31, 4, 10, 10), new DateTime(2025, 10, 31, 4, 10, 10), OptionMode.Mandatory);
        ToonSuccessBoodschap($"DateTime = '{(input == null ? "NULL" : input.ToString())}'");

        Console.WriteLine();

        // Optionele input met minDateTime > maxDateTime
        try
        {
            ToonInfoBoodschap($"Optionele input met minDateTime > maxDateTime");
            input = LeesDatumTijd("Geef DatumTijd in", new DateTime(2025, 10, 31, 4, 10, 10), new DateTime(2024, 10, 31, 4, 10, 10));
            ToonSuccessBoodschap($"DateTime = '{(input == null ? "NULL" : input.ToString())}'");
        }
        catch (Exception ex)
        {
            ToonFoutBoodschap(ex.Message);
        }
    }

    // ---------
    // Lees Date
    // ---------
    private static void Item03()
    {
        DateOnly? input;

        // Optionele input
        ToonInfoBoodschap($"Optionele input met minDate en maxDate");
        input = LeesDatum("Geef Datum in", new DateOnly(2024, 10, 31), new DateOnly(2025, 10, 31));
        ToonSuccessBoodschap($"Datum = '{(input == null ? "NULL" : input.ToString())}'");

        Console.WriteLine();

        // Verplichte input
        ToonInfoBoodschap($"Verplichte input met minDate en maxDate");
        input = LeesDatum("Geef Datum in", new DateOnly(2024, 10, 31), new DateOnly(2025, 10, 31), OptionMode.Mandatory);
        ToonSuccessBoodschap($"Datum = '{(input == null ? "NULL" : input.ToString())}'");

        Console.WriteLine();

        // Optionele input met minDate > maxDate
        try
        {
            ToonInfoBoodschap($"Optionele input met minDate > maxDate");
            input = LeesDatum("Geef Datum in", new DateOnly(2025, 10, 31), new DateOnly(2024, 10, 31));
            ToonSuccessBoodschap($"Datum= '{(input == null ? "NULL" : input.ToString())}'");
        }
        catch (Exception ex)
        {
            ToonFoutBoodschap(ex.Message);
        }
    }

    // ---------
    // Lees Time
    // ---------
    private static void Item04()
    {
        TimeOnly? input;

        // Optionele input
        ToonInfoBoodschap($"Optionele input met minTime en maxTime");
        input = LeesTijd("Geef Tijd in", new TimeOnly(11, 12, 13), new TimeOnly(14, 15, 16));
        ToonSuccessBoodschap($"Tijd = '{(input == null ? "NULL" : input.Value.FormatTime())}'");

        Console.WriteLine();

        // Verplichte input
        ToonInfoBoodschap($"Optionele input met minTime en maxTime");
        input = LeesTijd("Geef Tijd in", new TimeOnly(11, 12, 13), new TimeOnly(14, 15, 16), OptionMode.Mandatory);
        ToonSuccessBoodschap($"Tijd = '{(input == null ? "NULL" : input.Value.FormatTime())}'");

        Console.WriteLine();

        // Optionele input zonder minTime/maxTime
        ToonInfoBoodschap($"Optionele input zonder minTime/maxTime");
        input = LeesTijd("Geef Tijd in", null, null);
        ToonSuccessBoodschap($"Tijd = '{(input == null ? "NULL" : input.Value.FormatTime())}'");

        Console.WriteLine();

        // Optionele input met minTime of maxTime niet ingevuld
        try
        {
            ToonInfoBoodschap($"Optionele input met minTime of maxTime niet ingevuld");
            input = LeesTijd("Geef Tijd in", new TimeOnly(14, 15, 16), null, OptionMode.Mandatory);
            ToonSuccessBoodschap($"Tijd = '{(input == null ? "NULL" : input.Value.FormatTime())}'");
        }
        catch (Exception ex)
        {
            ToonFoutBoodschap(ex.Message);
        }

        Console.WriteLine();

        // Optionele input met minTime > maxTime
        try
        {
            ToonInfoBoodschap($"Optionele input met minTime > maxTime");
            input = LeesTijd("Geef Tijd in", new TimeOnly(14, 15, 16), new TimeOnly(13, 14, 15), OptionMode.Mandatory);
            ToonSuccessBoodschap($"Tijd = '{(input == null ? "NULL" : input.Value.FormatTime())}'");
        }
        catch (Exception ex)
        {
            ToonFoutBoodschap(ex.Message);
        }
    }

    // ----------
    // Lees Getal
    // ----------
    private static void Item05()
    {
        // Int, Int32
        ToonInfoBoodschap($"Integer met min en max waarde, verplicht");
        int inputInt = LeesGetal<int>("\nGeef Getal in (int)", int.MinValue, int.MaxValue, OptionMode.Mandatory);
        ToonSuccessBoodschap($"Getal = '{inputInt}' - Type = {inputInt.GetType()}");

        Console.WriteLine();

        // Met minValue en MaxValue van het datatype
        ToonInfoBoodschap($"Met minValue en MaxValue van het datatype\n");

        Console.WriteLine();

        // Int; Int32
        ToonInfoBoodschap($"Int");
        inputInt = LeesGetal<int>("\nGeef Getal in (int)", int.MinValue, int.MaxValue);
        ToonSuccessBoodschap($"Getal = '{inputInt}' - Type = {inputInt.GetType()}");

        Console.WriteLine();

        ToonInfoBoodschap($"Int");
        inputInt = LeesGetal("\nGeef Getal in (int)", int.MinValue, int.MaxValue);
        ToonSuccessBoodschap($"Getal = '{inputInt}' - Type = {inputInt.GetType()}");

        ResetConsole();

        // Decimal
        ToonInfoBoodschap($"Decimal");
        decimal inputDecimal = LeesGetal<decimal>("\nGeef Getal in (decimal)", decimal.MinValue, decimal.MaxValue);
        ToonSuccessBoodschap($"Getal = '{inputDecimal}' - Type = {inputDecimal.GetType()}");

        Console.WriteLine();

        ToonInfoBoodschap($"Decimal");
        inputDecimal = LeesGetal("\nGeef Getal in (decimal)", decimal.MinValue, decimal.MaxValue);
        ToonSuccessBoodschap($"Getal = '{inputDecimal}' - Type = {inputDecimal.GetType()}");

        ResetConsole();

        // Float, Single
        ToonInfoBoodschap($"Float");
        float inputFloat = LeesGetal<float>("\nGeef Getal in (float)", float.MinValue, float.MaxValue);
        ToonSuccessBoodschap($"Getal = '{inputFloat}' - Type =  {inputFloat.GetType()}");

        Console.WriteLine();

        ToonInfoBoodschap($"Float");
        inputFloat = LeesGetal("\nGeef Getal in (float)", float.MinValue, float.MaxValue);
        ToonSuccessBoodschap($"Getal = '{inputFloat}' - Type =  {inputFloat.GetType()}");

        ResetConsole();

        // Double
        ToonInfoBoodschap($"Double");
        double inputDouble = LeesGetal<double>("\nGeef Getal in (double)", double.MinValue, double.MaxValue);
        ToonSuccessBoodschap($"Getal = '{inputDouble}' - Type =  {inputDouble.GetType()}");

        Console.WriteLine();

        ToonInfoBoodschap($"Double");
        inputDouble = LeesGetal("\nGeef Getal in (double)", double.MinValue, double.MaxValue);
        ToonSuccessBoodschap($"Getal = '{inputDouble}' - Type =  {inputDouble.GetType()}");

        ResetConsole();

        // Met minValue en MaxValue van de parameters
        ToonInfoBoodschap($"Met minValue en MaxValue van de parameters\n");

        ToonInfoBoodschap($"Int");
        inputInt = LeesGetal<int>("\nGeef Getal in (int)", 10, 20);
        ToonSuccessBoodschap($"Getal = '{inputInt}' - Type = {inputInt.GetType()}");

        Console.WriteLine();

        ToonInfoBoodschap($"Decimal");
        inputDecimal = LeesGetal<decimal>("\nGeef Getal in (decimal)", 10, 20);
        ToonSuccessBoodschap($"Getal = '{inputDecimal}' - Type = {inputDecimal.GetType()}");

        Console.WriteLine();

        ToonInfoBoodschap($"Float");
        inputFloat = LeesGetal<float>("\nGeef Getal in (float)", 10, 20);
        ToonSuccessBoodschap($"Getal = '{inputFloat}' - Type =  {inputFloat.GetType()}");

        Console.WriteLine();

        ToonInfoBoodschap($"Double");
        inputDouble = LeesGetal<double>("\nGeef Getal in (double)", 10, 20);
        ToonSuccessBoodschap($"Getal = '{inputDouble}' - Type =  {inputDouble.GetType()}");

        Console.WriteLine();

        // Optionele input met minimum > maximum
        try
        {
            ToonInfoBoodschap($"  - Optionele input met minimum > maximumDecimal");
            inputDecimal = LeesGetal<decimal>("\nGeef Getal in (decimal)", 20.20m, 10.10m);
            ToonSuccessBoodschap($"Getal = '{inputDecimal}' - Type = {inputDecimal.GetType()}");
        }
        catch (Exception ex)
        {
            ToonFoutBoodschap(ex.Message);
        }
    }

    // ------------
    // Lees integer
    // ------------
    private static void Item06()
    {
        int? input;

        ToonInfoBoodschap($"");
        input = LeesInt("\nGeef Getal in (int)");
        ToonSuccessBoodschap($"Getal = '{(input == null ? "NULL" : input)}'");

        Console.WriteLine();

        ToonInfoBoodschap($"");
        input = LeesInt("\nGeef Getal in (int)", int.MinValue, int.MaxValue, OptionMode.Mandatory);
        ToonSuccessBoodschap($"Getal = '{(input == null ? "NULL" : input)}'");

        Console.WriteLine();

        ToonInfoBoodschap($"");
        input = LeesInt("\nGeef Getal in (int)", 100, 200);
        ToonSuccessBoodschap($"Getal = '{(input == null ? "NULL" : input)}'");

        Console.WriteLine();

        // Optionele input met minimum > maximum
        try
        {
            ToonInfoBoodschap($"");
            input = LeesInt("\nGeef Getal in (int)", 200, 100);
            ToonSuccessBoodschap($"Getal = '{(input == null ? "NULL" : input)}'");
        }
        catch (Exception ex)
        {
            ToonFoutBoodschap(ex.Message);
        }
    }

    // ------------
    // Lees decimal
    // ------------
    private static void Item07()
    {
        decimal? input;

        ToonInfoBoodschap($"");
        input = LeesDecimal("\nGeef Getal in (decimal)", 100, 200);
        ToonSuccessBoodschap($"Getal = '{(input == null ? "NULL" : input)}'");

        Console.WriteLine();

        // Optionele input met minimum > maximum
        try
        {
            ToonInfoBoodschap($"Optionele input met minimum > maximum");
            input = LeesDecimal("\nGeef Getal in (decimal)", 200, 100);
            ToonSuccessBoodschap($"Getal = '{(input == null ? "NULL" : input)}'");
        }
        catch (Exception ex)
        {
            ToonFoutBoodschap(ex.Message);
        }
    }

    // ----------
    // Lees float
    // ----------
    private static void Item08()
    {
        float? input;

        ToonInfoBoodschap($"");
        input = LeesFloat("\nGeef Getal in (float)", 100, 200);
        ToonSuccessBoodschap($"Getal = '{(input == null ? "NULL" : input)}'");

        Console.WriteLine();

        // Optionele input met minimum > maximum
        try
        {
            ToonInfoBoodschap($"Optionele input met minimum > maximum");
            input = LeesFloat("\nGeef Getal in (float)", 200, 100);
            ToonSuccessBoodschap($"Getal = '{(input == null ? "NULL" : input)}'");
        }
        catch (Exception ex)
        {
            ToonFoutBoodschap(ex.Message);
        }
    }

    // ------------
    // Lees boolean
    // ------------
    private static void Item09()
    {
        bool? input;

        ToonInfoBoodschap($"Optional");
        input = LeesBool("", OptionMode.Optional);
        ToonSuccessBoodschap($"Bool = '{(input == null ? "NULL" : input)}'");

        Console.WriteLine();

        ToonInfoBoodschap($"Mandatory");
        input = LeesBool("", OptionMode.Mandatory);
        ToonSuccessBoodschap($"Bool = '{(input == null ? "NULL" : input)}'");
    }

    // ----------
    // Lees lijst
    // ----------
    private class MuziekInstrument
    {
        public int Id { get; set; }
        public string NaamNL { get; set; } = null!;
        public string NaamEN { get; set; } = null!;
        public string Categorie { get; set; } = null!;
    }

    private static void Item10()
    {
        var muziekinstrumenten = new List<MuziekInstrument>
        {
            new() { Id = 01, NaamNL = "Trompet",NaamEN = "Trumpet", Categorie = "Koperblazer" },
            new() { Id = 02, NaamNL = "Elektrische Gitaar",NaamEN = "Electric Guitar", Categorie = "Tokkelinstrument" },
            new() { Id = 03, NaamNL = "Clarinet",NaamEN = "Clarinet", Categorie = "Houtblazer" },
            new() { Id = 04, NaamNL = "Hoorn",NaamEN = "Horn", Categorie = "Koperblazer" },
            new() { Id = 05, NaamNL = "Saxofoon",NaamEN = "Saxophone", Categorie = "Houtblazer" },
            new() { Id = 06, NaamNL = "Harp",NaamEN = "Harp", Categorie = "Tokkelinstrument" },
            new() { Id = 07, NaamNL = "Bel",NaamEN = "Bell", Categorie = "Slaginstrument" },
            new() { Id = 08, NaamNL = "Klassieke Gitaar",NaamEN = "Classical Guitar", Categorie = "Tokkelinstrument" },
            new() { Id = 09, NaamNL = "Cornet",NaamEN = "Cornet", Categorie = "Koperblazer" },
            new() { Id = 10, NaamNL = "Cymbalen",NaamEN = "Cymbals", Categorie = "Slaginstrument" },
            new() { Id = 11, NaamNL = "Drum Stel",NaamEN = "Drum Kit", Categorie = "Slaginstrument" },
            new() { Id = 12, NaamNL = "Fluit",NaamEN = "Fluit", Categorie = "Houtblazer" },
            new() { Id = 13, NaamNL = "Franse Hoorn",NaamEN = "French Horn", Categorie = "Koperblazer" },
            new() { Id = 14, NaamNL = "Xylofoon",NaamEN = "Xylophone", Categorie = "Slaginstrument" },
            new() { Id = 15, NaamNL = "Lier",NaamEN = "Lyre", Categorie = "Tokkelinstrument" },
            new() { Id = 16, NaamNL = "Hobo",NaamEN = "Oboe", Categorie = "Houtblazer" },
            new() { Id = 17, NaamNL = "Orgel",NaamEN = "Organ", Categorie = "Tokkelinstrument" },
            new() { Id = 18, NaamNL = "Panfluit",NaamEN = "Pan Pipes", Categorie = "Houtblazer" },
            new() { Id = 19, NaamNL = "Portugese Gitaar",NaamEN = "Portuguese Guitar", Categorie = "Tokkelinstrument" },
            new() { Id = 20, NaamNL = "Blokfluit",NaamEN = "Recorder", Categorie = "Houtblazer" },
            new() { Id = 21, NaamNL = "Sousafoon",NaamEN = "Sousaphone", Categorie = "Koperblazer" },
            new() { Id = 22, NaamNL = "Viool",NaamEN = "Viola", Categorie = "Strijkinstrument" },
        };

        // --- SelectionMode.Single

        // SelectionMode.Single - Lege lijst
        ResetConsole();
        ToonInfoBoodschap("1. SelectionMode.Single - Lege lijst");

        var selectieLijst = muziekinstrumenten.Where(m => m.Categorie == "Toetsinstrument").ToList();   // Filter (eventueel) de lijst

        var muziekinstrument = (MuziekInstrument?)LeesLijst(                              // Cast van object naar MuziekInstrument
              $"Lijst van Muziekinstrumenten" +                                     // Titel
                $"\n{"",8}{"----------------",-20}{"---------",-15}" +
                $"\n{"",8}{"Nederlandse Naam",-20}{"Categorie",-15}" +
                $"\n{"",8}{"----------------",-20}{"---------",-15}"
            , selectieLijst                                                               // Lijst van de objecten
            , selectieLijst.Select(m => $"{m.NaamNL,-20}{m.Categorie,-15}").ToList()     // Display lijst : wordt op het scherm getoond
            , SelectionMode.Single                                                        // SelectionMode : je kan hier slechts 1 keuze maken
            , OptionMode.Optional)                                                        // OptionMode    : je bent hier niet verplicht om een keuze te maken
            .FirstOrDefault();                                                            // Neem het eerste object uit de lijst

        ToonSuccessBoodschap(muziekinstrument == null ? "U hebt geen keuze gemaakt" : $"U koos voor '{muziekinstrument.NaamNL}'");

        DrukToets();

        // SelectionMode.Single - Niet Lege lijst
        ResetConsole();
        ToonInfoBoodschap("2. SelectionMode.Single - Niet Lege lijst");

        selectieLijst = muziekinstrumenten.Where(m => m.Categorie == "Koperblazer").ToList();

        AlternateRows = false;
        muziekinstrument = (MuziekInstrument?)LeesLijst(
             $"Lijst van Muziekinstrumenten" +
               $"\n{"",8}{"----------------",-20}{"---------",-15}" +
               $"\n{"",8}{"Nederlandse Naam",-20}{"Categorie",-15}" +
               $"\n{"",8}{"----------------",-20}{"---------",-15}"
           , selectieLijst
           , selectieLijst.Select(m => $"{m.NaamNL,-20}{m.Categorie,-15}").ToList()
           , SelectionMode.Single)
           .FirstOrDefault();
        AlternateRows = AlternateRowsOrig;

        ToonSuccessBoodschap(muziekinstrument == null ? "U hebt geen keuze gemaakt" : $"U koos voor '{muziekinstrument.NaamNL}'");

        DrukToets();

        // SelectionMode.Single - Niet Lege lijst - Verplicht

        ResetConsole();
        ToonInfoBoodschap("3. SelectionMode.Single - Niet Lege lijst - Verplicht");

        selectieLijst = muziekinstrumenten.Where(m => m.Categorie == "Koperblazer").ToList();

        AlternateRows = false;
        muziekinstrument = (MuziekInstrument?)LeesLijst(
             $"Lijst van Muziekinstrumenten" +
               $"\n{"",8}{"----------------",-20}{"---------",-15}" +
               $"\n{"",8}{"Nederlandse Naam",-20}{"Categorie",-15}" +
               $"\n{"",8}{"----------------",-20}{"---------",-15}"
           , selectieLijst
           , selectieLijst.Select(m => $"{m.NaamNL,-20}{m.Categorie,-15}").ToList()
           , SelectionMode.Single
           , OptionMode.Mandatory)
           .FirstOrDefault();
        AlternateRows = AlternateRowsOrig;

        ToonSuccessBoodschap(muziekinstrument == null ? "U hebt geen keuze gemaakt" : $"U koos voor '{muziekinstrument.NaamNL}'");

        // --- SelectionMode.Multiple

        DrukToets();

        // SelectionMode.Multiple - Lege lijst
        ResetConsole();
        ToonInfoBoodschap("4. SelectionMode.Multiple - Lege lijst");

        selectieLijst = muziekinstrumenten.Where(m => m.Categorie == "Toetsinstrument").ToList();

        var gekozenLijst = LeesLijst(
              $"Lijst van Muziekinstrumenten" +
                $"\n{"",8}{"----------------",-20}{"---------",-15}" +
                $"\n{"",8}{"Nederlandse Naam",-20}{"Categorie",-15}" +
                $"\n{"",8}{"----------------",-20}{"---------",-15}"
            , selectieLijst
            , selectieLijst.Select(m => $"{m.NaamNL,-20}{m.Categorie,-15}").ToList()
            , SelectionMode.Multiple);

        if (gekozenLijst.Any()) ToonSuccessBoodschap("U hebt geen keuze gemaakt");
        else foreach (MuziekInstrument mi in gekozenLijst) ToonSuccessBoodschap($"U koos voor '{mi.NaamNL}'");

        DrukToets();

        // SelectionMode.Multiple - Niet Lege lijst
        ResetConsole();
        ToonInfoBoodschap("5. SelectionMode.Multiple - Niet Lege lijst");

        gekozenLijst = LeesLijst(
             $"Lijst van Muziekinstrumenten" +
               $"\n{"",8}{"----------------",-20}{"---------",-15}" +
               $"\n{"",8}{"Nederlandse Naam",-20}{"Categorie",-15}" +
               $"\n{"",8}{"----------------",-20}{"---------",-15}"
           , muziekinstrumenten
           , muziekinstrumenten.Select(m => $"{m.NaamNL,-20}{m.Categorie,-15}").ToList()
           , SelectionMode.Multiple);

        if (!gekozenLijst.Any()) ToonSuccessBoodschap("U hebt geen keuze gemaakt");
        else foreach (MuziekInstrument mi in gekozenLijst) ToonSuccessBoodschap($"U koos voor '{mi.NaamNL}'");

        DrukToets();

        // SelectionMode.Multiple - Niet Lege lijst - Verplicht
        ResetConsole();
        ToonInfoBoodschap("6. SelectionMode.Multiple - Niet Lege lijst - Verplicht");

        gekozenLijst = LeesLijst(
             $"Lijst van Muziekinstrumenten" +
               $"\n{"",8}{"----------------",-20}{"---------",-15}" +
               $"\n{"",8}{"Nederlandse Naam",-20}{"Categorie",-15}" +
               $"\n{"",8}{"----------------",-20}{"---------",-15}"
           , muziekinstrumenten
           , muziekinstrumenten.Select(m => $"{m.NaamNL,-20}{m.Categorie,-15}").ToList()
           , SelectionMode.Multiple
           , OptionMode.Mandatory);

        if (!gekozenLijst.Any()) ToonSuccessBoodschap("U hebt geen keuze gemaakt");
        else foreach (MuziekInstrument mi in gekozenLijst) ToonSuccessBoodschap($"U koos voor '{mi.NaamNL}'");

        // --- SelectionMode.None

        DrukToets();

        // SelectionMode.None - Lege Lijst
        ResetConsole();
        ToonInfoBoodschap("7. SelectionMode.None - Lege lijst");

        selectieLijst = muziekinstrumenten.Where(m => m.Categorie == "Toetsinstrument").ToList();

        LeesLijst(
              $"Lijst van Muziekinstrumenten" +
                $"\n{"----------------",-20}{"---------",-15}" +
                $"\n{"Nederlandse Naam",-20}{"Categorie",-15}" +
                $"\n{"----------------",-20}{"---------",-15}"
            , selectieLijst
            , selectieLijst.Select(m => $"{m.NaamNL,-20}{m.Categorie,-15}").ToList());

        DrukToets();

        // SelectionMode.None - Niet Lege lijst
        ResetConsole();
        ToonInfoBoodschap("8. SelectionMode.None - Niet Lege lijst");

        AlternateRows = false;
        LeesLijst(
             $"Lijst van Muziekinstrumenten" +
               $"\n{"------------",-18}{"---------",-15}" +
               $"\n{"Engelse Naam",-18}{"Categorie",-15}" +
               $"\n{"------------",-18}{"---------",-15}"
           , muziekinstrumenten
           , muziekinstrumenten.Select(m => $"{m.NaamEN,-18}{m.Categorie,-15}").ToList());
        AlternateRows = AlternateRowsOrig;

        //DrukToets();
    }

    // ------------------
    // Lees Simpele lijst
    // ------------------
    private static void Item11()
    {
        string? geslacht;

        ToonInfoBoodschap($"");
        //geslacht = ((string?)LeesKeuzeUitLijst("Geslacht", new List<object>() { "M", "V", "X", "Y", "Z" }));
        geslacht = (string?)LeesKeuzeUitLijst("Geslacht", ["M", "V", "X", "Y", "Z"]);

        ToonSuccessBoodschap(geslacht == null ? "U hebt geen keuze gemaakt" : $"U koos voor '{geslacht}'");

        Console.WriteLine();

        ToonInfoBoodschap($"");
        geslacht = (string?)LeesKeuzeUitLijst("Geslacht", ["M", "V", "X", "Y", "Z"], OptionMode.Mandatory);

        ToonSuccessBoodschap(geslacht == null ? "U hebt geen keuze gemaakt" : $"U koos voor '{geslacht}'");
    }

    // -------------------
    // Lees Telefoonnummer
    // -------------------
    private static void Item12()
    {
        string? telefoonnummer;

        // Optional
        ToonInfoBoodschap($"Optional");
        telefoonnummer = LeesTelefoonNummer();

        ToonSuccessBoodschap(telefoonnummer == null ? "U maakte geen keuze" : $"Telefoonnummer is '{telefoonnummer}'");

        Console.WriteLine();

        // Mandatory
        ToonInfoBoodschap($"Mandatory");
        telefoonnummer = LeesTelefoonNummer("TelefoonNr", OptionMode.Mandatory);

        ToonSuccessBoodschap(telefoonnummer == null ? "U maakte geen keuze" : $"Telefoonnummer is '{telefoonnummer}'");
    }

    // ----------------
    // Lees email adres
    // ----------------
    private static void Item13()
    {
        string? email;

        // Optional
        ToonInfoBoodschap($"Optional");
        email = LeesEmailAdres();

        ToonSuccessBoodschap(email == null ? "U maakte geen keuze" : $"Email is '{email}'");

        Console.WriteLine();

        // Mandatory
        ToonInfoBoodschap($"Mandatory");
        email = LeesEmailAdres("email", OptionMode.Mandatory);

        ToonSuccessBoodschap(email == null ? "U maakte geen keuze" : $"Email is '{email}'");
    }

    // ----------------
    // Lees website URL
    // ----------------
    private static void Item14()
    {
        string? website;

        // Optional
        ToonInfoBoodschap($"Optional");
        website = LeesWebsiteUrl();

        ToonSuccessBoodschap(website == null ? "U maakte geen keuze" : $"Website is '{website}'");

        Console.WriteLine();

        // Mandatory
        ToonInfoBoodschap($"Mandatory");
        website = LeesWebsiteUrl("Website", OptionMode.Mandatory);

        ToonSuccessBoodschap(website == null ? "U maakte geen keuze" : $"Website is '{website}'");
    }

    // -------------
    // Lees Paswoord
    // -------------
    private static void Item15()
    {
        string? paswoord;

        // Optional
        ToonInfoBoodschap($"Optional");
        paswoord = LeesPaswoord();

        ToonSuccessBoodschap(paswoord == null ? "U maakte geen keuze" : $"Paswoord is '{paswoord}'");

        Console.WriteLine();

        // Mandatory
        ToonInfoBoodschap($"Mandatory");
        paswoord = LeesPaswoord("Paswoord", 8, 64, OptionMode.Mandatory);

        ToonSuccessBoodschap(paswoord == null ? "U maakte geen keuze" : $"Paswoord is '{paswoord}'");
    }

    // -----------------
    // Toon boodschappen
    // -----------------
    private static void Item16()
    {
        ToonFoutBoodschap("Foutboodschap");
        ToonInfoBoodschap("Infoboodschap");
        ToonWarningBoodschap("Warningboodschap");
        ToonSuccessBoodschap("Successboodschap");
    }

    // ------------------
    // WriteLineWithColor
    // ------------------
    private static void Item17()
    {
        //WriteLineWithColor($"Ik zal je iets van [green]de kleine Johannes[/green] vertellen.  Het heeft veel van een sprookje, mijn verhaal, maar het is toch allemaal echt gebeurd.\n\n[Red]De kleine Johannes[/Red] is een uniek hoogtepunt in de Nederlandse literatuur.\nVertaald in tientallen talen, onderwerp van talloze studies en boekverslagen van scholieren heeft het zichzelf bewezen als een klassiek werk dat met het verstrijken van de tijd zijn glans heeft behouden.\nDeze hertaling heeft de hindernissen die opgeworpen werden door het negentiende - eeuwse taalgebruik opgeheven. In sprankelende taal worden de ontwikkelingsfasen van [cyan]de kleine Johannes[/cyan] \nverbeeld door personages die de natuur, de liefde, het geluk, de kennis, het spirituele en de vluchtigheid van het leven vertegenwoordigen.\nDe herkenbaarheid en de diepte van dit klank-en kleurrijke sprookje is in al haar eenvoud zo schitterend dat het blijft fascineren.");
        //Console.WriteLine();

        Console.Write($"Ik zal je iets van {Ansi.FDGREEN}de kleine Johannes{ConsFGC} vertellen.  Het heeft veel van een sprookje, mijn verhaal, maar het is toch allemaal echt gebeurd.\n\n{Ansi.FDRED}De kleine Johannes{ConsFGC} is een uniek hoogtepunt in de Nederlandse literatuur.\nVertaald in tientallen talen, onderwerp van talloze studies en boekverslagen van scholieren heeft het zichzelf bewezen als een klassiek werk dat met het verstrijken van de tijd zijn glans heeft behouden.\nDeze hertaling heeft de hindernissen die opgeworpen werden door het negentiende - eeuwse taalgebruik opgeheven. In sprankelende taal worden de ontwikkelingsfasen van {Ansi.FDCYAN}de kleine Johannes{ConsFGC} \nverbeeld door personages die de natuur, de liefde, het geluk, de kennis, het spirituele en de vluchtigheid van het leven vertegenwoordigen.\nDe herkenbaarheid en de diepte van dit klank-en kleurrijke sprookje is in al haar eenvoud zo schitterend dat het blijft fascineren.");
        Console.WriteLine();
    }

    // --------
    // LeesEnum
    // --------
    private static void Item18()
    {
        ToonInfoBoodschap($"");
        AlternateRows = false;
        var input = LeesEnum<SelectionMode>("Kies een SelectieMode", SelectionMode.Single, OptionMode.Optional).FirstOrDefault()!;
        AlternateRows = AlternateRowsOrig;
        ToonSuccessBoodschap($"Input = {input}");
    }

    // ----------
    // Char.Is...
    // ----------
    private class Chars
    {
        public int Number { get; init; }
        public char Ch { get; init; }
        public bool IsControl { get; init; }
        public bool IsDigit { get; init; }
        public bool IsLetter { get; init; }
        public bool IsLetterOrDigit { get; init; }
        public bool IsLower { get; init; }
        public bool IsNumber { get; init; }
        public bool IsPunctuation { get; init; }
        public bool IsSeparator { get; init; }
        public bool IsSymbol { get; init; }
        public bool IsWhiteSpace { get; init; }
    }

    private static void Item19()
    {
        var charProperties = new List<string>() { "IsControl", "IsDigit", "IsLetter", "IsLower", "IsNumber", "IsPunctuation", "IsSeparator", "IsSymbol", "IsWhiteSpace", "IsLetterOrDigit" };

        var title = string.Empty;
        title += $"{"Kies Char-Properties\n        ────────────────────\n        Char Property\n        ────────────────────",-20}";

        AlternateRows = false;
        var choices = LeesLijst(title, charProperties, charProperties.Select(i => i).ToList(), SelectionMode.Multiple, OptionMode.Optional);
        AlternateRows = AlternateRowsOrig;

        // 

        var chars = new List<Chars>();

        for (var c = 0; c < Math.Pow(2, 16); c++)
        {
            chars.Add(new Chars()
            {
                Number = c,
                Ch = !char.IsControl((char)c) ? (char)c : ' ',
                IsControl = char.IsControl((char)c),
                IsDigit = char.IsDigit((char)c),
                IsLetter = char.IsLetter((char)c),
                IsLower = char.IsLower((char)c),
                IsNumber = char.IsNumber((char)c),
                IsPunctuation = char.IsPunctuation((char)c),
                IsSeparator = char.IsSeparator((char)c),
                IsSymbol = char.IsSymbol((char)c),
                IsWhiteSpace = char.IsWhiteSpace((char)c),
                IsLetterOrDigit = char.IsLetterOrDigit((char)c)
            }); ;
        }

        title = string.Empty;
        title += "Selectie voor: " + string.Join(", ", choices) + "\n";
        title += $"{"─────",-6}{"────",-5}{"───────",-8}{"─────",-6}{"──────",-7}{"─────",-6}{"──────",-7}{"───────────",-12}{"─────────",-10}{"──────",-7}{"──────────",-11}{"─────────────",-14}\n";
        title += $"{"Code ",-6}{"char",-5}{"Control",-8}{"Digit",-6}{"Letter",-7}{"Lower",-6}{"Number",-7}{"Punctuation",-12}{"Separator",-10}{"Symbol",-7}{"WhiteSpace",-11}{"LetterOrDigit",-14}\n";
        title += $"{"─────",-6}{"────",-5}{"───────",-8}{"─────",-6}{"──────",-7}{"─────",-6}{"──────",-7}{"───────────",-12}{"─────────",-10}{"──────",-7}{"──────────",-11}{"─────────────",-14}";

        var displayValues = chars.Where(i => !choices.Any()
                                             || (i.IsControl && choices.Contains("IsControl"))
                                             || (i.IsDigit && choices.Contains("IsDigit"))
                                             || (i.IsLetter && choices.Contains("IsLetter"))
                                             || (i.IsLetterOrDigit && choices.Contains("IsLetterOrDigit"))
                                             || (i.IsLower && choices.Contains("IsLower"))
                                             || (i.IsNumber && choices.Contains("IsNumber"))
                                             || (i.IsPunctuation && choices.Contains("IsPunctuation"))
                                             || (i.IsSeparator && choices.Contains("IsSeparator"))
                                             || (i.IsSymbol && choices.Contains("IsSymbol"))
                                             || (i.IsWhiteSpace && choices.Contains("IsWhiteSpace"))
                                        )
                                .Select(i => $"{i.Number:D5} {(i.Number == 91 ? "[" : i.Number == 93 ? " " : i.Ch),-5}{Bool2Icon(i.IsControl),-8 + 1}{Bool2Color(i.IsDigit),-6}{new string(' ', 10).Substring(0, i.IsDigit ? 2 : 1)}{Bool2PlusMin(i.IsLetter),-7}{i.IsLower,-6}{i.IsNumber,-7}{i.IsPunctuation,-12}{i.IsSeparator,-10}{i.IsSymbol,-7}{i.IsWhiteSpace,-11}{i.IsLetterOrDigit,-14}").ToList();

        LeesLijst(title, null!, displayValues);
    }
}
