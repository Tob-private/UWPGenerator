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
            PopulationModel population = Characteristics.Population();

            // Calculate planet government
            GovernmentModel government = Characteristics.Government(population.Number);


            // Calculate law level
           int lawLevel = Characteristics.LawLevel(government.Number);


            // Calculate starport
            StarportModel starport = Characteristics.Starport(population.Number);

            // Calculate tech level
            int techLevel = Characteristics.TechLevel(starport.Number, size.Number, atmosphere.Number, hydrographics.Number, population.Number, government.Number);

            // Calculate travel codes
            string travelCode = "", travelCodesPrompt = "";

            if (atmosphere.Number >= 10 && (government.Number == 0 || government.Number == 7 || government.Number == 10) && (lawLevel == 0 || lawLevel >= 9))
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

            if (atmosphere.Number >= 4 && atmosphere.Number <= 9 && hydrographics.Number >= 4 && hydrographics.Number <= 8 && population.Number >= 5 && population.Number <= 7) // Agricultural
            {
                tradeCodes.Add("Ag");
            }
            if (size.Number == 0 && atmosphere.Number == 0 && hydrographics.Number == 0) // Asteroid
            {
                tradeCodes.Add("As");
            }
            if (population.Number == 0 && government.Number == 0 && lawLevel == 0) // Barren
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
            if (population.Number >= 9) // High Population
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
            if ((size.Number >= 0 && size.Number <= 2 || size.Number == 4 || size.Number == 7 || size.Number == 9) && population.Number >= 9) // Industrial
            {
                tradeCodes.Add("In");
            }
            if (population.Number <= 3) // Low Population
            {
                tradeCodes.Add("Lo");
            }
            if (techLevel <= 5) // Low Tech
            {
                tradeCodes.Add("Lt");
            }
            if (atmosphere.Number >= 0 && atmosphere.Number <= 3 && hydrographics.Number >= 0 && hydrographics.Number <= 3 && population.Number >= 6) // Non-Agricultural
            {
                tradeCodes.Add("Na");
            }
            if (population.Number >= 0 && population.Number <= 6 && government.Number >= 0 && government.Number <= 6) // Non-Industrial
            {
                tradeCodes.Add("NI");
            }
            if (size.Number >= 2 && size.Number <= 5 && atmosphere.Number >= 0 && atmosphere.Number <= 3 && hydrographics.Number >= 0 && hydrographics.Number <= 3) // Poor
            {
                tradeCodes.Add("Po");
            }
            if ((atmosphere.Number == 6 || atmosphere.Number == 8) && population.Number >= 6 && population.Number <= 8 && government.Number >= 4 && government.Number <= 9) // Rich
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

            // Get first letter of each base (e.g., "N A R")
            string UWPBases = string.Join(" ", starport.Bases.Select(f => f.ToString()[..1]));

            // Join trade codes with semicolons (e.g., "Ag; Ri; Hi")
            string UWPTradeCodes = string.Join(" ", tradeCodes.Select(f => f.ToString()));

            // Capitalize first letter of travelCode (e.g., "A")
            string UWPTravelCode = !string.IsNullOrEmpty(travelCode)
                ? char.ToUpper(travelCode[0]).ToString()
                : "";


            string UWPString = $"{planetName}   0101    {starport.Class}{size.Class}{atmosphere.Class}{hydrographics.Class}{population.Class}{government.Class}{lawLevel:X}-{techLevel:X} {UWPBases}  {UWPTradeCodes}  {UWPTravelCode}";

            World world = new()
            {
                UWPString = UWPString,
                Size = size,
                Atmosphere = atmosphere,
                Hydrographics = hydrographics,
                Population = population,
                Government = government,
                Culture = government.Culture,
                LawLevel = lawLevel,
                Starport = starport,
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