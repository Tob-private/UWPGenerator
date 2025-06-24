namespace UWPGenerator.models
{
    public class World
    {
        public required string WorldName { get; set; } = "";
        public required string UWPString { get; set; } = "";
        public required SizeModel Size { get; set; }
        public required AtmosphereModel Atmosphere { get; set; }
        public required HydroGraphicsModel Hydrographics { get; set; }
        public required PopulationModel Population { get; set; }
        public required GovernmentModel Government { get; set; }
        public required string Culture { get; set; }
        public required int LawLevel { get; set; }
        public required StarportModel Starport { get; set; }
        public required int TechLevel { get; set; }
        public required string TravelCode { get; set; }
        public required List<string> TradeCodes { get; set; }

        public override string ToString()
        {
            return $@"
-------------------------------------------------------------
UWP String: {UWPString}
-------------------------------------------------------------
= Size:
-{Size}

= Atmosphere: 
-{Atmosphere}

= Hydrographics: 
-{Hydrographics}

= Population: 
-{Population}

= Government: 
-{Government}

= Law Level: {LawLevel}

= Starport: 
-{Starport}

= Starport Bases: {string.Join("; ", Starport.Bases.Select(f => f.ToString()))}

= Tech Level: {TechLevel}
= Travel Code: {TravelCode}
= Trade Codes: {string.Join("; ", TradeCodes.Select(f => f.ToString()))}

";
        }
        public string ToMarkdown()
        {
            return $@"# 🌍 {WorldName}
**UWP String:** `{UWPString}`

---

## 🪐 Planetary Profile

### 🧱 Size
- **Class:** {Size.Class}
- **Diameter:** {Size.Diameter}
- **Gravity:** {Size.Gravity}

### 🌬️ Atmosphere
- **Class:** {Atmosphere.Class}
- **Composition:** {Atmosphere.Composition}
- **Pressure:** {Atmosphere.PressureATM}
- **Gear Required:** {Atmosphere.GearRequired}

### 🌊 Hydrographics
- **Class:** {Hydrographics.Class}
- **Hydrographic Percentage:** {Hydrographics.Percentage}
- **Description:** {Hydrographics.Description}

### 👥 Population
- **Class:** {Population.Class}
- **Population Range:** {Population.InhabitantsAmount}
- **Total Population:** {Population.TotalPopulation}
- **Description:** {Population.Description}

### 🏛️ Government
- **Class:** {Government.Class}
- **Type:** {Government.Type}
  > {Government.Description}
- **Contraband:** {string.Join("; ", Government.Contraband.Select(f => f.ToString()))}
- **Culture:** {Government.Culture}
#### 🛡️ Factions
{string.Join(Environment.NewLine, Government.Factions.Select(f => f.ToMarkdown()))}

### ⚖️ Law Level
- **Law Level:** {LawLevel}

---

## 🛸 Starport Information

### ✈️ Starport
- **Class:** {Starport.Class}
- **Quality:** {Starport.Quality}
- **Berthing Cost:** {Starport.BerthingCost}
- **Fuel:** {Starport.Fuel}
- **Facilities:** {string.Join("; ", Starport.Facilities.Select(f => f.ToString()))}

### 🛰️ Starport Bases
{string.Join("\n", Starport.Bases.Select(b => $"- {b}"))}

---

## ⚙️ Tech & Trade
- **Tech Level:** {TechLevel}
- **Travel Code:** {TravelCode.ToUpper()}
- **Trade Codes:** {string.Join(", ", TradeCodes.Select(t => t.ToString()))}
";
        }
    }
}