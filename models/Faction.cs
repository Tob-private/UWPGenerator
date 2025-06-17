namespace UWPGenerator.models
{
    public class Faction
    {
        public int Government { get; set; }
        public int StrengthNumber { get; set; }
        public string StrengthDesc { get; set; } = "";

        public override string ToString()
        {
            return $"- Government: {Government}, Strength: {StrengthNumber} ({StrengthDesc})";
        }
    }
}