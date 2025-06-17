using UWPGenerator.models;

namespace UWPGenerator
{
    class GenerateUWP
    {
        public static World GenerateWorld()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("=====================================================");
            Console.WriteLine("======  Welcome to the MgT 2e world generator  ======");
            Console.WriteLine("=====================================================");
            Console.WriteLine("=====================================================");

            // Give planet a name
            string planetName = Services.RandomizePlanetName();

            // Calculate planet size
            SizeModel size = Characteristics.Size();

            // Calculate planet atmosphere
            AtmosphereModel atmosphere = Characteristics.Atmosphere(size.Number);

            // Calculate planet hydrographics
            // If it DOESN'T have a D-type, or F-type "Panthalassic", consider temperature for the modifier
            TemperatureModel temperature = Characteristics.Temperature(atmosphere.Number);

            HydroGraphicsModel hydrographics = Characteristics.HydroGraphics(size.Number, atmosphere.Number, atmosphere.UnusualAtmosphereType, temperature.Number);

            // Calculate planet population
            int population = Services.RollDice(6, 2) - 2;

            // Calculate planet government
            int government = Services.RollDice(6, 2) - 7 + population;
            government = Math.Min(10, Math.Max(0, government));

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

            int factionsAmount = Services.RollDice(3) - factionsAmountMod;

            for (int i = 0; i < factionsAmount; i++)
            {
                int factionGovernment = Services.RollDice(6, 2);
                int factionStrengthNumber = Services.RollDice(6, 2);
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
            int culture = Services.RollDice(6) + (Services.RollDice(6) * 10);

            // Calculate law level
            int lawLevel = Services.RollDice(6, 2) - 7 + government;
            lawLevel = Math.Min(20, Math.Max(0, lawLevel));


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

            starport = Services.RollDice(6, 2) + starportMod;
            starport = Math.Min(14, Math.Max(0, starport));

            // Add starport bases
            int rollForNavalBase = 0, rollForResearchBase = 0, rollForScoutBase = 0, rollForTASBase = 0;
            switch (starport)
            {
                case 5:
                case 6:
                    rollForScoutBase = Services.RollDice(6, 2);
                    if (rollForScoutBase >= 7)
                    {
                        starportBases.Add("Scout");
                    }
                    break;
                case 7:
                case 8:
                    rollForScoutBase = Services.RollDice(6, 2);
                    if (rollForScoutBase >= 8)
                    {
                        starportBases.Add("Scout");
                    }
                    rollForResearchBase = Services.RollDice(6, 2);
                    if (rollForResearchBase >= 10)
                    {
                        starportBases.Add("Research");
                    }
                    rollForTASBase = Services.RollDice(6, 2);
                    if (rollForTASBase >= 10)
                    {
                        starportBases.Add("TAS");
                    }
                    break;
                case 9:
                case 10:
                    rollForNavalBase = Services.RollDice(6, 2);
                    if (rollForNavalBase >= 8)
                    {
                        starportBases.Add("Naval");
                    }
                    rollForScoutBase = Services.RollDice(6, 2);
                    if (rollForScoutBase >= 8)
                    {
                        starportBases.Add("Scout");
                    }
                    rollForResearchBase = Services.RollDice(6, 2);
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
                    rollForNavalBase = Services.RollDice(6, 2);
                    if (rollForNavalBase >= 8)
                    {
                        starportBases.Add("Naval");
                    }
                    rollForScoutBase = Services.RollDice(6, 2);
                    if (rollForScoutBase >= 10)
                    {
                        starportBases.Add("Scout");
                    }
                    rollForResearchBase = Services.RollDice(6, 2);
                    if (rollForResearchBase >= 8)
                    {
                        starportBases.Add("Research");
                    }
                    starportBases.Add("TAS");
                    break;
                default:
                    break;
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

            switch (size.Number)
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

            switch (atmosphere.Number)
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

            switch (hydrographics.Number)
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

            techLevel = Services.RollDice() + techLevelMod;
            techLevel = Math.Min(30, Math.Max(0, techLevel));

            // Calculate travel codes
            string travelCode = "", travelCodesPrompt = "";

            if (atmosphere.Number >= 10 && (government == 0 || government == 7 || government == 10) && (lawLevel == 0 || lawLevel >= 9))
            {
                Console.WriteLine("Your world has relatively extreme characteristics. Consider it for Amber travel code status");
            }
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

            // Calculate trade codes
            List<string> tradeCodes = new List<string>();

            if (atmosphere.Number >= 4 && atmosphere.Number <= 9 && hydrographics.Number >= 4 && hydrographics.Number <= 8 && population >= 5 && population <= 7) // Agricultural
            {
                tradeCodes.Add("Ag");
            }
            if (size.Number == 0 && atmosphere.Number == 0 && hydrographics.Number == 0) // Asteroid
            {
                tradeCodes.Add("As");
            }
            if (population == 0 && government == 0 && lawLevel == 0) // Barren
            {
                tradeCodes.Add("Ba");
            }
            if (atmosphere.Number >= 2 && hydrographics.Number == 0) // Desert
            {
                tradeCodes.Add("De");
            }
            if (size.Number >= 10 && hydrographics.Number >= 1) // Fluid Oceans
            {
                tradeCodes.Add("Fl");
            }
            if (size.Number >= 6 && size.Number <= 8 && (atmosphere.Number == 5 || atmosphere.Number == 6 || atmosphere.Number == 8) && (hydrographics.Number == 5 || hydrographics.Number == 6 || hydrographics.Number == 7)) // Garden
            {
                tradeCodes.Add("Ga");
            }
            if (population >= 9) // High Population
            {
                tradeCodes.Add("Hi");
            }
            if (techLevel >= 12) // High Tech
            {
                tradeCodes.Add("Ht");
            }
            if ((atmosphere.Number == 0 || atmosphere.Number == 1) && hydrographics.Number >= 1) // Ice-Capped
            {
                tradeCodes.Add("Ic");
            }
            if ((size.Number >= 0 && size.Number <= 2 || size.Number == 4 || size.Number == 7 || size.Number == 9) && population >= 9) // Industrial
            {
                tradeCodes.Add("In");
            }
            if (population <= 3) // Low Population
            {
                tradeCodes.Add("Lo");
            }
            if (techLevel <= 5) // Low Tech
            {
                tradeCodes.Add("Lt");
            }
            if (atmosphere.Number >= 0 && atmosphere.Number <= 3 && hydrographics.Number >= 0 && hydrographics.Number <= 3 && population >= 6) // Non-Agricultural
            {
                tradeCodes.Add("Na");
            }
            if (population >= 0 && population <= 6 && government >= 0 && government <= 6) // Non-Industrial
            {
                tradeCodes.Add("NI");
            }
            if (size.Number >= 2 && size.Number <= 5 && atmosphere.Number >= 0 && atmosphere.Number <= 3 && hydrographics.Number >= 0 && hydrographics.Number <= 3) // Poor
            {
                tradeCodes.Add("Po");
            }
            if ((atmosphere.Number == 6 || atmosphere.Number == 8) && population >= 6 && population <= 8 && government >= 4 && government <= 9) // Rich
            {
                tradeCodes.Add("Ri");
            }
            if (atmosphere.Number == 0) // Vacuum
            {
                tradeCodes.Add("Va");
            }
            if (hydrographics.Number >= 10) // Water World
            {
                tradeCodes.Add("Wa");
            }

            string starportClass = "";
            if (starport <= 2)
            {
                starportClass = "X";
            }
            else if (starport <= 4)
            {
                starportClass = "E";
            }
            else if (starport <= 6)
            {
                starportClass = "D";
            }
            else if (starport <= 8)
            {
                starportClass = "C";
            }
            else if (starport <= 10)
            {
                starportClass = "B";
            }
            else if (starport >= 11)
            {
                starportClass = "A";
            }

            // Get first letter of each base (e.g., "N A R")
            string UWPBases = string.Join(" ", starportBases.Select(f => f.ToString()[..1]));

            // Join trade codes with semicolons (e.g., "Ag; Ri; Hi")
            string UWPTradeCodes = string.Join(" ", tradeCodes.Select(f => f.ToString()));

            // Capitalize first letter of travelCode (e.g., "A")
            string UWPTravelCode = !string.IsNullOrEmpty(travelCode)
                ? char.ToUpper(travelCode[0]).ToString()
                : "";


            string UWPString = $"{planetName}   0101    {starportClass}{size.Class}{atmosphere.Class}{hydrographics.Class}{population:X}{government:X}{lawLevel:X}-{techLevel:X} {UWPBases}  {UWPTradeCodes}  {UWPTravelCode}";

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
                TravelCode = travelCode,
                TradeCodes = tradeCodes,
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