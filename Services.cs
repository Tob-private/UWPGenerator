using System.Text.Json;
namespace UWPGenerator
{
    class Services
    {
        public static Random random = new Random();

        public static int RollDice(int sides = 6, int times = 1)
        {
            int total = 0;
            for (int i = 0; i < times; i++)
            {
                total += random.Next(1, sides + 1);
            }
            return total;
        }

        public static string RandomizePlanetName()
        {
            {
                // Read JSON file content
                string json = File.ReadAllText("./assets/planet-names.json");

                // Deserialize JSON array into a List<string>
                List<string>? planets = JsonSerializer.Deserialize<List<string>>(json);

                if (planets == null || planets.Count == 0)
                {
                    Console.WriteLine("No planets loaded.");
                    return "no planet names available";
                }

                // Initialize Random
                Random random = new Random();

                // Pick a random planet
                string randomPlanet = planets[random.Next(planets.Count)];

                // Output the result
                return randomPlanet;
            }

        }
        public static long NextLong(Random rng, long min, long max)
        {
            if (min > max)
                throw new ArgumentOutOfRangeException("min", "min should be less than or equal to max");

            // Generate a random double between 0.0 and 1.0
            double range = max - min;
            double sample = rng.NextDouble();
            return (long)(min + (sample * range));
        }
    }
}