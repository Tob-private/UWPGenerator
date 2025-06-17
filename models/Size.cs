namespace UWPGenerator.models
{
    public class SizeModel
    {
        public required string SizeClass { get; set; }
        public required int SizeNumber { get; set; }
        public required string Diameter { get; set; }
        public required string Gravity { get; set; }

        public override string ToString()
        {
            return $"- Size Class: {SizeClass}, Diameter: {Diameter}, Gravity: {Gravity}";
        }
    }
}