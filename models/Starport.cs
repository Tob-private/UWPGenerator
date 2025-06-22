namespace UWPGenerator.models
{
    public class StarportModel
    {
        public required string Class { get; set; }
        public required int Number { get; set; }
        public required string Quality { get; set; }
        public required string BerthingCost { get; set; }
        public required string Fuel { get; set; }
        public required List<string> Facilities { get; set; }
        public required List<string> Bases { get; set; }

        public override string ToString()
        {
            return $@"- Class: {Class}, Quality: {Quality}, Berthing Cost: {BerthingCost}, Fuel: {Fuel}
Facilities: {string.Join("; ", Facilities.Select(f => f.ToString()))}";
        }
    }
}