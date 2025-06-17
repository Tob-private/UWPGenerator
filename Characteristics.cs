

using UWPGenerator.models;

namespace UWPGenerator
{
    public class Characteristics
    {

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
                    throw new Exception("Couldnt set size");
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
    }

}