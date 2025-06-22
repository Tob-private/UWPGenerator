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
            string travelCode = Characteristics.TravelCode(atmosphere.Number, government.Number, lawLevel);

            // Calculate trade codes
            List<string> tradeCodes = Characteristics.TradeCodes(size.Number, atmosphere.Number, hydrographics.Number, population.Number, government.Number, lawLevel, techLevel);

            // Get first letter of each base (e.g., "N A R")
            string UWPBases = string.Join(" ", starport.Bases.Select(f => f.ToString()[..1]));

            // Join trade codes (e.g., "Ag Ri Hi")
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