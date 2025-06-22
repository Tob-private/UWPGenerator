namespace UWPGenerator.models
{
    public class Faction
    {
        public required int Index { get; set; }
        public required string Type { get; set; }
        public required string TypeDesc { get; set; }
        public required List<string> Contraband { get; set; }
        public required int StrengthNumber { get; set; }
        public required string StrengthDesc { get; set; }

        public override string ToString()
        {
            return $@"
            
--- Faction #{Index}
---- Governing Type: {Type} ({TypeDesc})
---- Strength: {StrengthNumber} ({StrengthDesc})
---- Contraband: {string.Join("; ", Contraband.Select(f => f.ToString()))}";
        }
    }
}