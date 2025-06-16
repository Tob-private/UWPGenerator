namespace UWPGenerator
{

    public class Faction
    {
        public int Government { get; set; }
        public int StrengthNumber { get; set; }
        public string StrengthDesc { get; set; } = "";

        public override string ToString()
        {
            return $"- Government: {Government}, Strength: {StrengthNumber} ({StrengthDesc})";
        }

    }

    public class World
    {
        public required string UWPString { get; set; } = "";
        public required int Size { get; set; }
        public required int Atmosphere { get; set; }
        public required int Hydrographics { get; set; }
        public required int Population { get; set; }
        public required int Government { get; set; }
        public required List<Faction> Factions { get; set; }
        public required int Culture { get; set; }
        public required int LawLevel { get; set; }
        public required int Starport { get; set; }
        public required List<string> StarportBases { get; set; }
        public required int TechLevel { get; set; }

        public override string ToString()
        {
            return $@"
UWP String: {UWPString}
Size: {Size}
Atmosphere: {Atmosphere}
Hydrographics: {Hydrographics}
Population: {Population}
Government: {Government}
Culture: {Culture}
Law Level: {LawLevel}
Starport: {Starport}
Starport Bases: {string.Join("; ", StarportBases.Select(f => f.ToString()))}
Tech Level: {TechLevel}
Factions: 
{string.Join(Environment.NewLine, Factions.Select(f => f.ToString()))}
";
        }

    }

    class GenerateUWP
    {

        private static Random random = new Random();

        private static int RollDice(int sides = 6, int times = 1)
        {
            int total = 0;
            for (int i = 0; i < times; i++)
            {
                total += random.Next(1, sides + 1);
            }
            return total;
        }

        // Define return value
        public static World GenerateWorld()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("=====================================================");
            Console.WriteLine("======  Welcome to the MgT 2e world generator  ======");
            Console.WriteLine("=====================================================");
            Console.WriteLine("=====================================================");
            // Calculate planet size
            int size = RollDice(6, 2) - 2;
            size = Math.Min(10, Math.Max(0, size));


            // Calculate planet atmosphere
            int atmosphere = RollDice(6, 2) - 7 + size;
            atmosphere = Math.Min(10, Math.Max(0, atmosphere));
            string unusualAtmosphereType = "";
            if (atmosphere == 15)
            {
                Console.WriteLine("Your planet has an unusual atmosphere, which kind is it?");
                unusualAtmosphereType = Console.ReadLine() ?? ""; // fallback to empty string if null
                unusualAtmosphereType = unusualAtmosphereType.ToUpper();
            }



            // Calculate planet hydrographics
            int hydrographicsMod = 0, hydrographics = 0;

            // If it DOESN'T have a D-type, or F-type "Panthalassic", consider temperature for the modifier
            int temperatureMod = -1, temperature = -1;

            if (atmosphere != 13 || unusualAtmosphereType != "PANTHALASSIC")
            {
                switch (atmosphere)
                {
                    case 0:
                    case 1:
                        temperature = 0;
                        break;
                    case 2:
                    case 3:
                        temperatureMod = -2;
                        break;
                    case 4:
                    case 5:
                    case 14:
                        temperatureMod = -1;
                        break;
                    case 6:
                    case 7:
                        temperatureMod = 0;
                        break;
                    case 8:
                    case 9:
                        temperatureMod = 1;
                        break;
                    case 10:
                    case 13:
                    case 15:
                        temperatureMod = 2;
                        break;
                    case 11:
                    case 12:
                        temperatureMod = 6;
                        break;
                    default:
                        throw new Exception("Couldn't set temperature modifier");
                }

                // Generate temperature, then apply corresponding DM to hydrographics roll 
                if (temperature != -1)
                {
                    if (temperatureMod == -1)
                    {
                        temperatureMod = 0;
                    }
                    temperature = RollDice(6, 2) + temperatureMod;

                    if (temperature == 10 || temperature == 11)
                    {
                        hydrographicsMod += -2;
                    }
                    else if (temperature >= 12)
                    {
                        hydrographicsMod += -6;
                    }
                }
            }
            if (size < 2)
            {
                hydrographics = 0;
            }
            else if (atmosphere < 2 || (atmosphere > 9 && atmosphere < 13))
            {
                hydrographicsMod += -4;
                hydrographics = RollDice(6, 2) - 7 + hydrographicsMod;
                hydrographics = Math.Min(10, Math.Max(0, hydrographics));
            }
            else
            {
                hydrographics = RollDice(6, 2) - 7 + atmosphere;
                hydrographics = Math.Min(10, Math.Max(0, hydrographics));

            }

            // Calculate planet population
            int population = RollDice(6, 2) - 2;

            // Calculate planet government
            int government = RollDice(6, 2) - 7 + population;

            // Generate factions
            List<Faction> factions = new List<Faction>();
            int factionsAmountMod = 0;

            if (government == 0 || government == 7)
            {

                factionsAmountMod = 1;
            }
            else if (government >= 10)
            {
                factionsAmountMod = -1;
            }
            else
            {
                factionsAmountMod = 0;
            }

            int factionsAmount = RollDice(3) - factionsAmountMod;

            for (int i = 0; i < factionsAmount; i++)
            {
                int factionGovernment = RollDice(6, 2);
                int factionStrengthNumber = RollDice(6, 2);
                string factionStrengthDesc = "";

                factionStrengthDesc = factionStrengthNumber switch
                {
                    2 or 3 => "Obscure group - few have heard of them, no popular support",
                    4 or 5 => "Fringe group - few supporters",
                    6 or 7 => "Minor group - some supporters",
                    8 or 9 => "Notable group - significant support, well known",
                    10 or 11 => "Significant - nearly as powerful as the government",
                    12 => "Overwhelming popular support - more powerful than the government",
                    _ => throw new Exception("Couldnt set factionStrengthDesc"),
                };
                Faction faction = new()
                {
                    Government = factionGovernment,
                    StrengthNumber = factionStrengthNumber,
                    StrengthDesc = factionStrengthDesc
                };


                factions.Add(faction);
            }
            // Generate culture differences
            int culture = RollDice(6) + RollDice(10);

            // Calculate law level
            int lawLevel = RollDice(6, 2) - 7 + government;

            // Calculate starport
            int starportMod = 0, starport = 0;
            List<string> starportBases = new List<string>();

            if (population >= 10)
            {
                starportMod = 2;
            }
            else if (population >= 8)
            {
                starportMod = 1;
            }
            else if (population <= 2)
            {
                starportMod = -1;
            }
            else if (population <= 4)
            {
                starportMod = -2;
            }

            starport = RollDice(6, 2) + starportMod;

            // Add starport bases
            int rollForNavalBase = 0, rollForResearchBase = 0, rollForScoutBase = 0, rollForTASBase = 0;
            switch (starport)
            {
                case 5:
                case 6:
                    rollForScoutBase = RollDice(6, 2);
                    if (rollForScoutBase >= 7)
                    {
                        starportBases.Add("Scout");
                    }
                    break;
                case 7:
                case 8:
                    rollForScoutBase = RollDice(6, 2);
                    if (rollForScoutBase >= 8)
                    {
                        starportBases.Add("Scout");
                    }
                    rollForResearchBase = RollDice(6, 2);
                    if (rollForResearchBase >= 10)
                    {
                        starportBases.Add("Research");
                    }
                    rollForTASBase = RollDice(6, 2);
                    if (rollForTASBase >= 10)
                    {
                        starportBases.Add("TAS");
                    }
                    break;
                case 9:
                case 10:
                    rollForNavalBase = RollDice(6, 2);
                    if (rollForNavalBase >= 8)
                    {
                        starportBases.Add("Naval");
                    }
                    rollForScoutBase = RollDice(6, 2);
                    if (rollForScoutBase >= 8)
                    {
                        starportBases.Add("Scout");
                    }
                    rollForResearchBase = RollDice(6, 2);
                    if (rollForResearchBase >= 10)
                    {
                        starportBases.Add("Research");
                    }
                    starportBases.Add("TAS");
                    break;
                case 11:
                case 12:
                case 13:
                case 14:
                    rollForNavalBase = RollDice(6, 2);
                    if (rollForNavalBase >= 8)
                    {
                        starportBases.Add("Naval");
                    }
                    rollForScoutBase = RollDice(6, 2);
                    if (rollForScoutBase >= 10)
                    {
                        starportBases.Add("Scout");
                    }
                    rollForResearchBase = RollDice(6, 2);
                    if (rollForResearchBase >= 8)
                    {
                        starportBases.Add("Research");
                    }
                    starportBases.Add("TAS");
                    break;
                default:
                    break;
            }
            if (starportBases.Count == 0)
            {
                starportBases.Add("No bases");
            }

            // Calculate tech level
            int techLevel = 0, techLevelMod = 0;

            // Add tech level mods based on all previous characteristics
            switch (starport)
            {
                case 10:
                    techLevelMod += 6;
                    break;
                case 11:
                    techLevelMod += 4;
                    break;
                case 12:
                    techLevelMod += 2;
                    break;
                case 0:
                case 1:
                case 2:
                    techLevelMod += -4;
                    break;
                default:
                    break;
            }

            switch (size)
            {
                case 0:
                case 1:
                    techLevelMod += 2;
                    break;
                case 2:
                case 3:
                case 4:
                    techLevelMod += 1;
                    break;
                default:
                    break;
            }

            switch (atmosphere)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    techLevelMod += 1;
                    break;
                default:
                    break;
            }

            switch (hydrographics)
            {
                case 0:
                case 9:
                    techLevelMod += 1;
                    break;
                case 10:
                    techLevelMod += 2;
                    break;
                default:
                    break;
            }

            switch (population)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 8:
                    techLevelMod += 1;
                    break;
                case 9:
                    techLevelMod += 2;
                    break;
                case 10:
                    techLevelMod += 4;
                    break;
                default:
                    break;
            }

            switch (population)
            {
                case 0:
                case 5:
                    techLevelMod += 1;
                    break;
                case 7:
                    techLevelMod += 2;
                    break;
                case 13:
                case 14:
                    techLevelMod += -2;
                    break;
                default:
                    break;
            }

            techLevel = RollDice() + techLevelMod;

            // Calculate travel codes
            string travelCode = "", travelCodesPrompt = "";

            do
            {
                Console.Write("Would you like there do be a travel code? (y/n) --- ");
                travelCodesPrompt = Console.ReadLine()?.Trim().ToLower() ?? "";
                Console.WriteLine("");
            } while (travelCodesPrompt != "y" && travelCodesPrompt != "n");

            if (travelCodesPrompt == "y")
            {
                //Ask user for which travel code they want (amber/red)
                do
                {
                    Console.Write("Which travel code should it be? (amber/red) --- ");
                    travelCode = Console.ReadLine()?.Trim().ToLower() ?? "";
                    Console.WriteLine("");
                } while (travelCode != "amber" && travelCode != "red");
            }










            string UWPString = "";

            World world = new()
            {
                UWPString = UWPString,
                Size = size,
                Atmosphere = atmosphere,
                Hydrographics = hydrographics,
                Population = population,
                Government = government,
                Factions = factions,
                Culture = culture,
                LawLevel = lawLevel,
                Starport = starport,
                StarportBases = starportBases,
                TechLevel = techLevel,
            };

            return world;

        }

        static void Main()
        {
            var world = GenerateWorld();

            Console.WriteLine("This is you newly created world:");
            Console.WriteLine(world);
        }
    }

}