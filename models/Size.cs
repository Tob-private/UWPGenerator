namespace UWPGenerator.models
{
    public class SizeModel
    {
        public required string Class { get; set; }
        public required int Number { get; set; }
        public required string Diameter { get; set; }
        public required string Gravity { get; set; }

        public override string ToString()
        {
            return $@"- Class: {Class}
-- Diameter: {Diameter}
-- Gravity: {Gravity}";
        }
    }
}