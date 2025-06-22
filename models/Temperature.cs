namespace UWPGenerator.models
{
    public class TemperatureModel
    {
        public required int Number { get; set; }
        public required string Type { get; set; }
        public required string AvgTemp { get; set; }
        public required string Description { get; set; }

        public override string ToString()
        {
            return $@"- Number: {Number}
-- Type: { Type}
-- Average Temperature: {AvgTemp}
-- Description: {Description}";
        }
    }
}