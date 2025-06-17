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
    public class AtmosphereModel
    {
        public required string Class { get; set; }
        public required int Number { get; set; }
        public required string Composition { get; set; }
        public required string PressureATM { get; set; }
        public required string GearRequired { get; set; }
        public required string? UnusualAtmosphereType { get; set; }

        public override string ToString()
        {
            return $"- Class: {Class}, Number: {Number}, Composition: {Composition}, Pressure: {PressureATM} atm, Gear Required: {GearRequired}"
                 + (string.IsNullOrWhiteSpace(UnusualAtmosphereType) ? "" : $", Unusual Atmosphere Type: {UnusualAtmosphereType}");
        }

    }
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

    public class World
    {
        public required string UWPString { get; set; } = "";
        public required SizeModel Size { get; set; }
        public required AtmosphereModel Atmosphere { get; set; }
        public required int Hydrographics { get; set; }
        public required int Population { get; set; }
        public required int Government { get; set; }
        public required List<Faction> Factions { get; set; }
        public required int Culture { get; set; }
        public required int LawLevel { get; set; }
        public required int Starport { get; set; }
        public required List<string> StarportBases { get; set; }
        public required int TechLevel { get; set; }
        public required string TravelCode { get; set; }
        public required List<string> TradeCodes { get; set; }

        public override string ToString()
        {
            return $@"
UWP String: {UWPString}
Size:
{Size}
Atmosphere: 
{Atmosphere}
Hydrographics: {Hydrographics}
Population: {Population}
Government: {Government}
Factions: 
{string.Join(Environment.NewLine, Factions.Select(f => f.ToString()))}
Culture: {Culture}
Law Level: {LawLevel}
Starport: {Starport}
Starport Bases: {string.Join("; ", StarportBases.Select(f => f.ToString()))}
Tech Level: {TechLevel}
Travel Code: {TravelCode}
Trade Codes: {string.Join("; ", TradeCodes.Select(f => f.ToString()))}

";
        }

    }
}