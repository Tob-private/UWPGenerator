namespace UWPGenerator.models
{
    public class HydroGraphicsModel
    {
        public required string Class { get; set; }
        public required int Number { get; set; }
        public required string Percentage { get; set; }
        public required string Description { get; set; }

        public override string ToString()
        {
            return $"- Class: {Class}, Hydrographic Percentage: {Percentage}, Description: {Description}";
        }
    }
}