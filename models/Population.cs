namespace UWPGenerator.models
{
    public class PopulationModel
    {
        public required string Class { get; set; }
        public required int Number { get; set; }
        public required string InhabitantsAmount { get; set; }
        public required long TotalPopulation { get; set; }
        public required string Description { get; set; }

        public override string ToString()
        {
            return $@"- Class: {Class}
-- Inhabitants: { InhabitantsAmount}
-- Total Population: {TotalPopulation}
-- Description: {Description}";
        }
    }
}