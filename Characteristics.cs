

using UWPGenerator.models;

namespace UWPGenerator
{
    public class Characteristics
    {
        private static Random random = new Random();

        // Calculate planet size
        public static SizeModel Size()
        {
            int sizeNumber = Math.Min(10, Math.Max(0, Services.RollDice(6, 2) - 2));
            string diameter = "", gravity = "", sizeClass = "";

            switch (sizeNumber)
            {
                case 0:
                    diameter = "Less than 1000 km";
                    gravity = "Negligible";
                    sizeClass = "0";
                    break;
                case 1:
                    diameter = "1600 km";
                    gravity = "0.05 Gs";
                    sizeClass = "1";
                    break;
                case 2:
                    diameter = "3200 km";
                    gravity = "0.15 Gs";
                    sizeClass = "2";
                    break;
                case 3:
                    diameter = "4800 km";
                    gravity = "0.25 Gs";
                    sizeClass = "3";
                    break;
                case 4:
                    diameter = "6400 km";
                    gravity = "0.35 Gs";
                    sizeClass = "4";
                    break;
                case 5:
                    diameter = "8000 km";
                    gravity = "0.45 Gs";
                    sizeClass = "5";
                    break;
                case 6:
                    diameter = "9600 km";
                    gravity = "0.7 Gs";
                    sizeClass = "6";
                    break;
                case 7:
                    diameter = "11200 km";
                    gravity = "0.9 Gs";
                    sizeClass = "7";
                    break;
                case 8:
                    diameter = "12800 km";
                    gravity = "1.0 Gs";
                    sizeClass = "8";
                    break;
                case 9:
                    diameter = "14400 km";
                    gravity = "1.25 Gs";
                    sizeClass = "9";
                    break;
                case 10:
                    diameter = "16000 km";
                    gravity = "1.4 Gs";
                    sizeClass = "A";
                    break;
                default:
                    throw new Exception("Couldnt set size" + sizeNumber);
            }

            SizeModel size = new()
            {
                SizeClass = sizeClass,
                SizeNumber = sizeNumber,
                Diameter = diameter,
                Gravity = gravity,
            };

            return size;
        }
        public static AtmosphereModel Atmosphere(int size)
        {
            int atmosphereNumber = Math.Max(0, Math.Min(Services.RollDice(6, 2) - 7 + size, 15));

            string? unusualAtmosphereType = null;
            string atmosphereComposition;
            string atmospherePressure;
            string atmosphereClass;
            string gearRequired;

            switch (atmosphereNumber)
            {
                case 0:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "None";
                    atmospherePressure = "0.00";
                    gearRequired = "Vacc Suit";
                    break;
                case 1:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Trace";
                    atmospherePressure = $"{Math.Round(0.001 + (random.NextDouble() * (0.09 - 0.001)), 2)}";
                    gearRequired = "Vacc Suit";
                    break;
                case 2:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Very Thin, Tainted";
                    atmospherePressure = $"{Math.Round(0.1 + (random.NextDouble() * (0.42 - 0.1)), 2)}";
                    gearRequired = "Respirator, Filter";
                    break;
                case 3:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Very Thin";
                    atmospherePressure = $"{Math.Round(0.1 + (random.NextDouble() * (0.42 - 0.1)), 2)}";
                    gearRequired = "Respirator";
                    break;
                case 4:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Thin, Tainted";
                    atmospherePressure = $"{Math.Round(0.43 + (random.NextDouble() * (0.7 - 0.43)), 2)}";
                    gearRequired = "Filter";
                    break;
                case 5:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Thin";
                    atmospherePressure = $"{Math.Round(0.43 + (random.NextDouble() * (0.7 - 0.43)), 2)}";
                    gearRequired = "";
                    break;
                case 6:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Standard";
                    atmospherePressure = $"{Math.Round(0.71 + (random.NextDouble() * (1.49 - 0.71)), 2)}";
                    gearRequired = "";
                    break;
                case 7:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Standard, Tainted";
                    atmospherePressure = $"{Math.Round(0.71 + (random.NextDouble() * (1.49 - 0.71)), 2)}";
                    gearRequired = "Filter";
                    break;
                case 8:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Dense";
                    atmospherePressure = $"{Math.Round(1.5 + (random.NextDouble() * (1.5 - 2.49)), 2)}";
                    gearRequired = "";
                    break;
                case 9:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Dense, Tainted";
                    atmospherePressure = $"{Math.Round(1.5 + (random.NextDouble() * (1.5 - 2.49)), 2)}";
                    gearRequired = "Filter";
                    break;
                case 10:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Exotic";
                    atmospherePressure = "Varies";
                    gearRequired = "Air Supply";
                    break;
                case 11:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Corrosive";
                    atmospherePressure = "Varies";
                    gearRequired = "Vacc Suit";
                    break;
                case 12:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Insidious";
                    atmospherePressure = "Varies";
                    gearRequired = "Vacc Suit";
                    break;
                case 13:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Dense, Tainted";
                    atmospherePressure = $"{Math.Round(2.5 + (random.NextDouble() * (2.5 - 10.0)), 2)}";
                    gearRequired = "";
                    break;
                case 14:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Low";
                    atmospherePressure = $"{Math.Round(0 + (random.NextDouble() * (.5 - 0)), 2)}";
                    gearRequired = "";
                    break;
                case 15:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Unusual";
                    atmospherePressure = "Varies";
                    gearRequired = "Varies";

                    Console.WriteLine("Your planet has an unusual atmosphere, which kind is it?");
                    unusualAtmosphereType = Console.ReadLine();
                    if (unusualAtmosphereType != null)
                    {
                        unusualAtmosphereType = unusualAtmosphereType.ToUpper();
                    }
                    break;
                default:
                    throw new Exception("Couldn't set Atmosphere" + atmosphereNumber);
            }


            AtmosphereModel atmosphere = new()
            {
                Class = atmosphereClass,
                Number = atmosphereNumber,
                Composition = atmosphereComposition,
                UnusualAtmosphereType = unusualAtmosphereType,
                PressureATM = atmospherePressure,
                GearRequired = gearRequired,
            };

            return atmosphere;
        }
    }

}