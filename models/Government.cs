namespace UWPGenerator.models
{
    public class GovernmentModel
    {
        public required string Class { get; set; }
        public required int Number { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
        public required string Culture { get; set; }
        public required List<string> Contraband { get; set; }
        public required List<Faction> Factions { get; set; }

        public override string ToString()
        {
            return $@"- Class: {Class}, Type: {Type}, Description: {Description}
Contraband: 
{string.Join("; ", Contraband.Select(f => f.ToString()))}
Factions:
{string.Join(Environment.NewLine, Factions.Select(f => f.ToString()))}
Culture: {Culture}";
        }
    }
}