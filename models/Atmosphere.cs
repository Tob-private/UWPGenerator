namespace UWPGenerator.models
{
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

            string unusual = string.IsNullOrWhiteSpace(UnusualAtmosphereType)
                ? ""
                : $"--Unusual Atmosphere Type: {UnusualAtmosphereType}";

            return $@"- Class: {Class}
-- Number: {Number}
-- Composition: {Composition}
-- Pressure: {PressureATM} atm
-- Gear Required: {GearRequired}
{unusual}";
        }
    }
}