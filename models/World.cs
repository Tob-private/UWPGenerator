namespace UWPGenerator.models
{
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