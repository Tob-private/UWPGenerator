

using UWPGenerator.models;

namespace UWPGenerator
{
    public class Characteristics
    {
        private static Random random = new Random();

        // Calculate planet size
        public static SizeModel Size()
        {
            int sizeNumber = Math.Min(10, Math.Max(0, Services.RollDice(6, 2) - 2));
            string diameter = "", gravity = "", sizeClass = "";

            switch (sizeNumber)
            {
                case 0:
                    diameter = "Less than 1000 km";
                    gravity = "Negligible";
                    sizeClass = "0";
                    break;
                case 1:
                    diameter = "1600 km";
                    gravity = "0.05 Gs";
                    sizeClass = "1";
                    break;
                case 2:
                    diameter = "3200 km";
                    gravity = "0.15 Gs";
                    sizeClass = "2";
                    break;
                case 3:
                    diameter = "4800 km";
                    gravity = "0.25 Gs";
                    sizeClass = "3";
                    break;
                case 4:
                    diameter = "6400 km";
                    gravity = "0.35 Gs";
                    sizeClass = "4";
                    break;
                case 5:
                    diameter = "8000 km";
                    gravity = "0.45 Gs";
                    sizeClass = "5";
                    break;
                case 6:
                    diameter = "9600 km";
                    gravity = "0.7 Gs";
                    sizeClass = "6";
                    break;
                case 7:
                    diameter = "11200 km";
                    gravity = "0.9 Gs";
                    sizeClass = "7";
                    break;
                case 8:
                    diameter = "12800 km";
                    gravity = "1.0 Gs";
                    sizeClass = "8";
                    break;
                case 9:
                    diameter = "14400 km";
                    gravity = "1.25 Gs";
                    sizeClass = "9";
                    break;
                case 10:
                    diameter = "16000 km";
                    gravity = "1.4 Gs";
                    sizeClass = "A";
                    break;
                default:
                    throw new Exception("Couldnt set size" + sizeNumber);
            }

            SizeModel size = new()
            {
                Class = sizeClass,
                Number = sizeNumber,
                Diameter = diameter,
                Gravity = gravity,
            };

            return size;
        }
        public static AtmosphereModel Atmosphere(int size)
        {
            int atmosphereNumber = Math.Max(0, Math.Min(Services.RollDice(6, 2) - 7 + size, 15));

            string? unusualAtmosphereType = null;
            string atmosphereComposition;
            string atmospherePressure;
            string atmosphereClass;
            string gearRequired;

            switch (atmosphereNumber)
            {
                case 0:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "None";
                    atmospherePressure = "0.00";
                    gearRequired = "Vacc Suit";
                    break;
                case 1:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Trace";
                    atmospherePressure = $"{Math.Round(0.001 + (random.NextDouble() * (0.09 - 0.001)), 2)}";
                    gearRequired = "Vacc Suit";
                    break;
                case 2:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Very Thin, Tainted";
                    atmospherePressure = $"{Math.Round(0.1 + (random.NextDouble() * (0.42 - 0.1)), 2)}";
                    gearRequired = "Respirator, Filter";
                    break;
                case 3:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Very Thin";
                    atmospherePressure = $"{Math.Round(0.1 + (random.NextDouble() * (0.42 - 0.1)), 2)}";
                    gearRequired = "Respirator";
                    break;
                case 4:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Thin, Tainted";
                    atmospherePressure = $"{Math.Round(0.43 + (random.NextDouble() * (0.7 - 0.43)), 2)}";
                    gearRequired = "Filter";
                    break;
                case 5:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Thin";
                    atmospherePressure = $"{Math.Round(0.43 + (random.NextDouble() * (0.7 - 0.43)), 2)}";
                    gearRequired = "";
                    break;
                case 6:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Standard";
                    atmospherePressure = $"{Math.Round(0.71 + (random.NextDouble() * (1.49 - 0.71)), 2)}";
                    gearRequired = "";
                    break;
                case 7:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Standard, Tainted";
                    atmospherePressure = $"{Math.Round(0.71 + (random.NextDouble() * (1.49 - 0.71)), 2)}";
                    gearRequired = "Filter";
                    break;
                case 8:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Dense";
                    atmospherePressure = $"{Math.Round(1.5 + (random.NextDouble() * (1.5 - 2.49)), 2)}";
                    gearRequired = "";
                    break;
                case 9:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Dense, Tainted";
                    atmospherePressure = $"{Math.Round(1.5 + (random.NextDouble() * (1.5 - 2.49)), 2)}";
                    gearRequired = "Filter";
                    break;
                case 10:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Exotic";
                    atmospherePressure = "Varies";
                    gearRequired = "Air Supply";
                    break;
                case 11:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Corrosive";
                    atmospherePressure = "Varies";
                    gearRequired = "Vacc Suit";
                    break;
                case 12:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Insidious";
                    atmospherePressure = "Varies";
                    gearRequired = "Vacc Suit";
                    break;
                case 13:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Dense, Tainted";
                    atmospherePressure = $"{Math.Round(2.5 + (random.NextDouble() * (2.5 - 10.0)), 2)}";
                    gearRequired = "";
                    break;
                case 14:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Low";
                    atmospherePressure = $"{Math.Round(0 + (random.NextDouble() * (.5 - 0)), 2)}";
                    gearRequired = "";
                    break;
                case 15:
                    atmosphereClass = $"{atmosphereNumber:x}";
                    atmosphereComposition = "Unusual";
                    atmospherePressure = "Varies";
                    gearRequired = "Varies";

                    Console.WriteLine("Your planet has an unusual atmosphere, which kind is it?");
                    unusualAtmosphereType = Console.ReadLine();
                    if (unusualAtmosphereType != null)
                    {
                        unusualAtmosphereType = unusualAtmosphereType.ToUpper();
                    }
                    break;
                default:
                    throw new Exception("Couldn't set Atmosphere" + atmosphereNumber);
            }


            AtmosphereModel atmosphere = new()
            {
                Class = atmosphereClass,
                Number = atmosphereNumber,
                Composition = atmosphereComposition,
                UnusualAtmosphereType = unusualAtmosphereType,
                PressureATM = atmospherePressure,
                GearRequired = gearRequired,
            };

            return atmosphere;
        }
        public static TemperatureModel Temperature(int atmosphere)
        {
            if (atmosphere >= 15)
            {
                Console.WriteLine("⚠️ WARNING: Unusual atmosphere detected.");
            }
            int temperatureMod = -1, temperatureNumber = -1;
            string type = "", avgTemp = "", description = "";

            switch (atmosphere)
            {
                case 0:
                case 1:
                    temperatureNumber = 0;
                    break;
                case 2:
                case 3:
                    temperatureMod = -2;
                    break;
                case 4:
                case 5:
                case 14:
                    temperatureMod = -1;
                    break;
                case 6:
                case 7:
                    temperatureMod = 0;
                    break;
                case 8:
                case 9:
                    temperatureMod = 1;
                    break;
                case 10:
                case 13:
                case 15:
                    temperatureMod = 2;
                    break;
                case 11:
                case 12:
                    temperatureMod = 6;
                    break;
                default:
                    throw new Exception("Couldn't set temperature modifier");
            }

            // Generate temperature, then apply corresponding DM to hydrographicsNumber roll 
            if (temperatureNumber == -1)
            {
                if (temperatureMod == -1)
                {
                    temperatureMod = 0;
                }
                temperatureNumber = Services.RollDice(6, 2) + temperatureMod;
                temperatureNumber = Math.Min(20, Math.Max(0, temperatureNumber));
            }

            switch (temperatureNumber)
            {
                case 0:
                case 1:
                case 2:
                    type = "Frozen";
                    avgTemp = "-51° or less";
                    description = "Frozen world. No liquid water, very dry atmosphere";
                    break;
                case 3:
                case 4:
                    type = "Cold";
                    avgTemp = "-51° to 0°";
                    description = "Icy world. Little liquid water, extensive ice caps, few clouds";
                    break;
                case int t when t >= 5 && t <= 9:
                    type = "Temperate";
                    avgTemp = "0° to 30°";
                    description = "Temperate world. Earth-like. Liquid & vaporised water are common, moderate ice caps.";
                    break;
                case 10:
                case 11:
                    type = "Hot";
                    avgTemp = "31° to 80°";
                    description = "Hot world. Small or no ice caps, little liquid water. Most water in the form of clouds";
                    break;
                case >= 12:
                    type = "Hot";
                    avgTemp = "31° to 80°";
                    description = "Hot world. Small or no ice caps, little liquid water. Most water in the form of clouds";
                    break;
                default:
                    throw new Exception("Couldn't set temperature");
            }

            TemperatureModel temperature = new()
            {
                Number = temperatureNumber,
                Type = type,
                AvgTemp = avgTemp,
                Description = description,
            };

            return temperature;
        }
        public static HydroGraphicsModel HydroGraphics(int size, int atmosphere, string? atmosphereType, int temperature)
        {
            int hydrographicsMod = 0, hydrographicsNumber;
            string percentage, description;

            if (atmosphere != 13 || atmosphereType != "PANTHALASSIC")
            {
                if (temperature == 10 || temperature == 11)
                {
                    hydrographicsMod += -2;
                }
                else if (temperature >= 12)
                {
                    hydrographicsMod += -6;
                }
            }
            if (size < 2)
            {
                hydrographicsNumber = 0;
            }
            else if (atmosphere < 2 || (atmosphere > 9 && atmosphere < 13))
            {
                hydrographicsMod += -4;
                hydrographicsNumber = Services.RollDice(6, 2) - 7 + hydrographicsMod + atmosphere;
            }
            else
            {
                hydrographicsNumber = Services.RollDice(6, 2) - 7 + hydrographicsMod + atmosphere;
            }
            hydrographicsNumber = Math.Min(10, Math.Max(0, hydrographicsNumber));

            switch (hydrographicsNumber)
            {
                case 0:
                    percentage = $"{random.Next(0, 5)}%";
                    description = "Desert world";
                    break;
                case 1:
                    percentage = $"{random.Next(6, 15)}%";
                    description = "Dry world";
                    break;
                case 2:
                    percentage = $"{random.Next(16, 25)}%";
                    description = "A few small seas.";
                    break;
                case 3:
                    percentage = $"{random.Next(26, 35)}%";
                    description = "Small seas and oceans";
                    break;
                case 4:
                    percentage = $"{random.Next(36, 45)}%";
                    description = "Wet world";
                    break;
                case 5:
                    percentage = $"{random.Next(46, 55)}%";
                    description = "Large oceans";
                    break;
                case 6:
                    percentage = $"{random.Next(56, 65)}%";
                    description = "";
                    break;
                case 7:
                    percentage = $"{random.Next(66, 75)}%";
                    description = "Earth-like world";
                    break;
                case 8:
                    percentage = $"{random.Next(76, 85)}%";
                    description = "Water world";
                    break;
                case 9:
                    percentage = $"{random.Next(86, 95)}%";
                    description = "Only a few small islands and archipelagos";
                    break;
                case 10:
                    percentage = $"{random.Next(96, 100)}%";
                    description = "Almost entirely water";
                    break;
                default:
                    throw new Exception("Couldn't set hydrographics");
            }

            HydroGraphicsModel hydrographics = new()
            {
                Class = $"{hydrographicsNumber:x}",
                Number = hydrographicsNumber,
                Percentage = percentage,
                Description = description,
            };

            return hydrographics;
        }
        public static PopulationModel Population()
        {
            int populationNumber = Math.Max(0, Math.Min(Services.RollDice(6, 2) - 2, 12));

            string inhabitantsAmount = "", description = "";
            long totalPopulation;

            switch (populationNumber)
            {
                case 0:
                    inhabitantsAmount = "None";
                    description = "";
                    totalPopulation = 0;
                    break;
                case 1:
                    inhabitantsAmount = "1+";
                    description = "A tiny farmstead or a single family";
                    totalPopulation = random.Next(1, 100);
                    break;
                case 2:
                    inhabitantsAmount = "100+";
                    description = "A village";
                    totalPopulation = random.Next(100, 1000);
                    break;
                case 3:
                    inhabitantsAmount = "1 000+";
                    description = "";
                    totalPopulation = random.Next(1000, 10000);
                    break;
                case 4:
                    inhabitantsAmount = "10 000+";
                    description = "Small town";
                    totalPopulation = random.Next(10000, 100000);
                    break;
                case 5:
                    inhabitantsAmount = "100 000+";
                    description = "Average city";
                    totalPopulation = random.Next(100000, 1000000);
                    break;
                case 6:
                    inhabitantsAmount = "1 000 000+";
                    description = "";
                    totalPopulation = random.Next(1000000, 10000000);
                    break;
                case 7:
                    inhabitantsAmount = "10 000 000+";
                    description = "Large city";
                    totalPopulation = random.Next(10000000, 100000000);
                    break;
                case 8:
                    inhabitantsAmount = "100 000 000+";
                    description = "";
                    totalPopulation = random.Next(100000000, 1000000000);
                    break;
                case 9:
                    inhabitantsAmount = "1 000 000 000+";
                    description = "";
                    totalPopulation = Services.NextLong(random, 1000000000, 10000000000);
                    break;
                case 10:
                    inhabitantsAmount = "10 000 000 000+";
                    description = "";
                    totalPopulation = Services.NextLong(random, 10000000000, 100000000000);
                    break;
                case 11:
                    inhabitantsAmount = "100 000 000 000+";
                    description = "Incredibly crowded world";
                    totalPopulation = Services.NextLong(random, 100000000000, 1000000000000);
                    break;
                case >= 12:
                    inhabitantsAmount = "1 000 000 000 000+";
                    description = "World-city";
                    totalPopulation = Services.NextLong(random, 1000000000000, 10000000000000);
                    break;

                default:
                    throw new Exception("Couldn't set population" + populationNumber);
            }


            PopulationModel population = new()
            {
                Class = $"{populationNumber:x}",
                Number = populationNumber,
                InhabitantsAmount = inhabitantsAmount,
                TotalPopulation = totalPopulation,
                Description = description,
            };

            return population;
        }
        public static GovernmentModel Government(int population)
        {
            int governmentNumber = Services.RollDice(6, 2) - 7 + population;
            governmentNumber = Math.Min(15, Math.Max(0, governmentNumber));

            string type = "", description = "";
            List<string> contraband = [];

            switch (governmentNumber)
            {
                case 0:
                    type = "None";
                    description = "No government structure. In many cases, family bonds predominate";
                    contraband.Add("None");
                    break;
                case 1:
                    type = "Company/Corporation";
                    description = "Ruling functions are assumed by a company managerial elite, and most citizenry are company employees or dependants";
                    contraband.AddRange(new[] { "Weapons", "Drugs", "Travellers" });
                    break;
                case 2:
                    type = "Participating Democracy";
                    description = "Ruling functions are reached by the advice and consent of the citizenry directly";
                    contraband.Add("Drugs");
                    break;
                case 3:
                    type = "Self-Perpetuating Oligarchy";
                    description = "Ruling functions are performed by a restricted minority, with little or no input from the mass of citizenry";
                    contraband.AddRange(new[] { "Technology", "Weapons", "Travellers" });
                    break;
                case 4:
                    type = "Representative Democracy";
                    description = "Ruling functions are performed by elected representatives";
                    contraband.AddRange(new[] { "Drugs", "Weapons", "Psionics" });
                    break;
                case 5:
                    type = "Feudal Technocracy";
                    description = "Ruling functions are performed by specific individuals for persons who agree to be ruled by them. Relationships are based on the performance of technical activities which are mutually beneficial";
                    contraband.AddRange(new[] { "Technology", "Weapons", "Computers" });
                    break;
                case 6:
                    type = "Captive Government";
                    description = "Ruling functions are performed by an imposed leadership answerable to an outside group";
                    contraband.AddRange(new[] { "Weapons", "Technology", "Travellers" });
                    break;
                case 7:
                    type = "Balkanisation";
                    description = "No central authority exists; rival governments compete for control. Law level refers to the government nearest the starport";
                    contraband.Add("Varies");
                    break;
                case 8:
                    type = "Civil Service Bureaucracy";
                    description = "Ruling functions are performed by government agencies employing individuals selected for their expertise";
                    contraband.AddRange(new[] { "Drugs", "Weapons", "Technology" });
                    break;
                case 9:
                    type = "Impersonal Bureaucracy";
                    description = "Ruling functions are performed by agencies which have become insulated from the governed citizens";
                    contraband.AddRange(new[] { "Technology", "Weapons", "Drugs", "Travellers", "Psionics" });
                    break;
                case 10:
                    type = "Charismatic Dictator";
                    description = "Ruling functions are performed by agencies directed by a single leader who enjoys the overwhelming confidence of the citizens";
                    contraband.Add("None");
                    break;
                case 11:
                    type = "Non-Charismatic Leader";
                    description = "A previous charismatic dictator has been replaced by a leader through normal channels";
                    contraband.AddRange(new[] { "Weapons", "Technology", "Computers" });
                    break;
                case 12:
                    type = "Charismatic Oligarchy";
                    description = "Ruling functions are performed by a select group of members of an organisation or class which enjoys the overwhelming confidence of the citizenry";
                    contraband.Add("Weapons");
                    break;
                case 13:
                    type = "Religious Dictatorship";
                    description = "Ruling functions are performed by a religious organisation without regard to specific individual needs of the citizenry";
                    contraband.Add("Varies");
                    break;
                case 14:
                    type = "Religious Autocracy";
                    description = "Government by a single religious leader having absolute power over the citizenry";
                    contraband.Add("Varies");
                    break;
                case 15:
                    type = "Totalitarian Oligarchy";
                    description = "Government by an all-powerful minority which maintains absolute control through widespread coercion and oppression";
                    contraband.Add("Varies");
                    break;
                default:
                    throw new Exception("Could not set government with the following number: " + governmentNumber);
            }


            // Generate factions
            List<Faction> factions = [];
            int factionsAmountMod = 0;

            if (governmentNumber == 0 || governmentNumber == 7)
            {

                factionsAmountMod = 1;
            }
            else if (governmentNumber >= 10)
            {
                factionsAmountMod = -1;
            }

            int factionsAmount = Services.RollDice(3) - factionsAmountMod;

            for (int i = 0; i < factionsAmount; i++)
            {
                int factionGovernmentNumber = Services.RollDice(6, 2);
                string factionGovType, factionGovDesc;
                List<string> factionContraband = [];
                switch (factionGovernmentNumber)
                {
                    case 2:
                        factionGovType = "Participating Democracy";
                        factionGovDesc = "Ruling functions are reached by the advice and consent of the citizenry directly";
                        factionContraband.Add("Drugs");
                        break;
                    case 3:
                        factionGovType = "Self-Perpetuating Oligarchy";
                        factionGovDesc = "Ruling functions are performed by a restricted minority, with little or no input from the mass of citizenry";
                        factionContraband.AddRange(new[] { "Technology", "Weapons", "Travellers" });
                        break;
                    case 4:
                        factionGovType = "Representative Democracy";
                        factionGovDesc = "Ruling functions are performed by elected representatives";
                        factionContraband.AddRange(new[] { "Drugs", "Weapons", "Psionics" });
                        break;
                    case 5:
                        factionGovType = "Feudal Technocracy";
                        factionGovDesc = "Ruling functions are performed by specific individuals for persons who agree to be ruled by them. Relationships are based on the performance of technical activities which are mutually beneficial";
                        factionContraband.AddRange(new[] { "Technology", "Weapons", "Computers" });
                        break;
                    case 6:
                        factionGovType = "Captive Government";
                        factionGovDesc = "Ruling functions are performed by an imposed leadership answerable to an outside group";
                        factionContraband.AddRange(new[] { "Weapons", "Technology", "Travellers" });
                        break;
                    case 7:
                        factionGovType = "Balkanisation";
                        factionGovDesc = "No central authority exists; rival governments compete for control. Law level refers to the government nearest the starport";
                        factionContraband.Add("Varies");
                        break;
                    case 8:
                        factionGovType = "Civil Service Bureaucracy";
                        factionGovDesc = "Ruling functions are performed by government agencies employing individuals selected for their expertise";
                        factionContraband.AddRange(new[] { "Drugs", "Weapons", "Technology" });
                        break;
                    case 9:
                        factionGovType = "Impersonal Bureaucracy";
                        factionGovDesc = "Ruling functions are performed by agencies which have become insulated from the governed citizens";
                        factionContraband.AddRange(new[] { "Technology", "Weapons", "Drugs", "Travellers", "Psionics" });
                        break;
                    case 10:
                        factionGovType = "Charismatic Dictator";
                        factionGovDesc = "Ruling functions are performed by agencies directed by a single leader who enjoys the overwhelming confidence of the citizens";
                        factionContraband.Add("None");
                        break;
                    case 11:
                        factionGovType = "Non-Charismatic Leader";
                        factionGovDesc = "A previous charismatic dictator has been replaced by a leader through normal channels";
                        factionContraband.AddRange(new[] { "Weapons", "Technology", "Computers" });
                        break;
                    case 12:
                        factionGovType = "Charismatic Oligarchy";
                        factionGovDesc = "Ruling functions are performed by a select group of members of an organisation or class which enjoys the overwhelming confidence of the citizenry";
                        factionContraband.Add("Weapons");
                        break;
                    default:
                        throw new Exception("Could not set faction with the following number: " + factionGovernmentNumber);
                }

                int factionStrengthNumber = Services.RollDice(6, 2);
                string factionStrengthDesc = factionStrengthNumber switch
                {
                    2 or 3 => "Obscure group - few have heard of them, no popular support",
                    4 or 5 => "Fringe group - few supporters",
                    6 or 7 => "Minor group - some supporters",
                    8 or 9 => "Notable group - significant support, well known",
                    10 or 11 => "Significant - nearly as powerful as the governmentNumber",
                    12 => "Overwhelming popular support - more powerful than the governmentNumber",
                    _ => throw new Exception("Couldnt set factionStrengthDesc" + factionStrengthNumber),
                };
                Faction faction = new()
                {
                    Type = factionGovType,
                    TypeDesc = factionGovDesc,
                    Contraband = factionContraband,
                    StrengthNumber = factionStrengthNumber,
                    StrengthDesc = factionStrengthDesc
                };


                factions.Add(faction);
            }
            // Generate culture differences
            int cultureNumber = Services.RollDice(6) + (Services.RollDice(6) * 10);
            string cultureDesc = cultureNumber switch
            {
                11 => "Sexist - one gender is considered subservient or inferior to the other.",
                12 => "Religious - culture is heavily influenced by a religion or belief systems, possibly one unique to this world.",
                13 => "Artistic - art and culture are highly prized. Aesthetic design is important in all artefacts produced on world.",
                14 => "Ritualised - social interaction and trade is highly formalised. Politeness and adherence to traditional forms is considered very important.",
                15 => "Conservative - the culture resists change and outside influences.",
                16 => "Xenophobic - the culture distrusts outsiders and alien influences. Offworlders will face considerable prejudice.",
                21 => "Taboo - a particular topic is forbidden and cannot be discussed. Travellers who unwittingly mention this topic will be ostracised.",
                22 => "Deceptive - trickery and equivocation are considered acceptable. Honesty is a sign of weakness.",
                23 => "Liberal - the culture welcomes change and offworld influence. Travellers who bring new and strange ideas will be welcomed.",
                24 => "Honourable - one's word is one's bond in the culture. Lying is both rare and despised.",
                25 => "Influenced - the culture is heavily influenced by another, neighbouring world. Roll again for a cultural quirk that has been inherited from the culture.",
                26 => "Fusion - the culture is a merger of two distinct cultures. Roll again twice to determine the quirks inherited from these cultures. If the quirks are incompatible, then the culture is likely divided.",
                31 => "Barbaric - physical strength and combat prowess are highly valued in the culture. Travellers may be challenged to a fight, or dismissed if they seem incapable of defending themselves. Sports tend towards the bloody and violent.",
                32 => "Remnant - the culture is a surviving remnant of a once-great and vibrant civilisation, clinging to its former glory. The world is filled with crumbling ruins, and every story revolves around the good old days.",
                33 => "Degenerate - the culture is falling apart and is on the brink of war or economic collapse. Violent protests are common, and the social order is decaying.",
                34 => "Progressive - the culture is expanding and vibrant. Fortunes are being made in trade; science is forging bravely ahead.",
                35 => "Recovering - a recent trauma, such as a plague, war, disaster or despotic regime has left scars on the culture.",
                36 => "Nexus - members of many different cultures and species visit here.",
                41 => "Tourist Attraction - some aspect of the culture or the planet draws visitors from all over charted space.",
                42 => "Violent - physical conflict is common, taking the form of duels, brawls or other contests. Trial by combat is a part of their judicial system.",
                43 => "Peaceful - physical conflict is almost unheard-of. The culture produces few soldiers, and diplomacy reigns supreme. Forceful Travellers will be ostracised.",
                44 => "Obsessed - everyone is obsessed with or addicted to a substance, personality, act or item. This monomania pervades every aspect of the culture.",
                45 => "Fashion - fine clothing and decoration are considered vitally important in the culture. Underdressed Travellers have no standing here.",
                46 => "At war - the culture is at war, either with another planet or polity, or is troubled by terrorists or rebels.",
                51 => "Unusual Custom: Offworlders - space travellers hold a unique position in the culture's mythology or beliefs, and travellers will be expected to live up to these myths.",
                52 => "Unusual Custom: Starport - the planet's starport is more than a commercial centre; it might be a religious temple, or be seen as highly controversial and surrounded by protestors.",
                53 => "Unusual Custom: Media - news agencies and telecommunications channels are especially strange here. Getting accurate information may be difficult.",
                54 => "Unusual Customs: Technology - the culture interacts with technology in an unusual way. Telecommunications might be banned, robots might have civil rights, or cyborgs might be property.",
                55 => "Unusual Customs: Lifecycle - there might be a mandatory age of termination, or anagathics might be widely used. Family units might be different, with children being raised by the state or banned in favour of cloning.",
                56 => "Unusual Customs: Social Standings - the culture has a distinct caste system. Travellers of a low social standing who do not behave appropriately will face punishment.",
                61 => "Unusual Customs: Trade - the culture has an odd attitude towards some aspect of commerce, which may interfere with trade at the spaceport. For example, merchants might expect a gift as part of a deal, or some goods may only be handled by certain families.",
                62 => "Unusual Customs: Nobility - those of high social standing have a strange custom associated with them; perhaps nobles are blinded, or must live in gilded cages, or only serve for a single year before being exiled.",
                63 => "Unusual Customs: Sex - the culture has an unusual attitude towards intercourse and reproduction. Perhaps cloning is used instead, or sex is used to seal commercial deals.",
                64 => "Unusual Customs: Eating - food and drink occupies an unusual place in the culture. Perhaps eating is a private affair, or banquets and formal dinners are seen as the highest form of politeness.",
                65 => "Unusual Customs: Travel - travellers may be distrusted or feted, or perhaps the culture frowns on those who leave their homes.",
                66 => "Unusual Customs: Conspiracy - something strange is going on. The government is being subverted by another group or agency.",
                _ => throw new Exception($"Could not set cultureDesc: {cultureNumber}"),
            };

            GovernmentModel government = new()
            {
                Class = $"{governmentNumber:x}",
                Number = governmentNumber,
                Type = type,
                Description = description,
                Culture = cultureDesc,
                Contraband = contraband,
                Factions = factions
            };

            return government;
        }
        public static int LawLevel(int government)
        {
            return Math.Min(9, Math.Max(0, Services.RollDice(6, 2) + government));
        }
        public static StarportModel Starport(int population)
        {
            int starportMod = 0;
            List<string> starportBases = [];

            if (population >= 10)
            {
                starportMod = 2;
            }
            else if (population >= 8)
            {
                starportMod = 1;
            }
            else if (population <= 2)
            {
                starportMod = -1;
            }
            else if (population <= 4)
            {
                starportMod = -2;
            }

            int starportNumber = Services.RollDice(6, 2) + starportMod;
            starportNumber = Math.Min(14, Math.Max(0, starportNumber));
            int rollForNavalBase;
            int rollForResearchBase;
            int rollForScoutBase;
            int rollForTASBase;

            string starportClass = "", starportQuality = "", berthingCost = "", starportFuel = "";
            List<string> starportFacilities = [];
            switch (starportNumber)
            {
                case 0:
                case 1:
                case 2:
                    starportClass = "X";
                    starportQuality = "No Starport";
                    berthingCost = "None";
                    starportFacilities.Add("None");
                    break;
                case 3:
                case 4:
                    starportClass = "E";
                    starportQuality = "Frontier";
                    berthingCost = "None";
                    starportFacilities.Add("None");
                    break;
                case 5:
                case 6:
                    starportClass = "D";
                    starportQuality = "Poor";
                    berthingCost = $"{Services.RollDice() * 10} Credits";
                    starportFuel = "Unrefined";
                    starportFacilities.Add("Limited Repair");

                    rollForScoutBase = Services.RollDice(6, 2);
                    if (rollForScoutBase >= 7)
                    {
                        starportBases.Add("Scout");
                    }
                    break;
                case 7:
                case 8:
                    starportClass = "C";
                    starportQuality = "Routine";
                    berthingCost = $"{Services.RollDice() * 100} Credits";
                    starportFuel = "Unrefined";
                    starportFacilities.Add("Shipyard (small craft)");
                    starportFacilities.Add("Repair");

                    rollForScoutBase = Services.RollDice(6, 2);
                    if (rollForScoutBase >= 8)
                    {
                        starportBases.Add("Scout");
                    }
                    rollForResearchBase = Services.RollDice(6, 2);
                    if (rollForResearchBase >= 10)
                    {
                        starportBases.Add("Research");
                    }
                    // Add starport bases
                    rollForTASBase = Services.RollDice(6, 2);
                    if (rollForTASBase >= 10)
                    {
                        starportBases.Add("TAS");
                    }
                    break;
                case 9:
                case 10:
                    starportClass = "B";
                    starportQuality = "Good";
                    berthingCost = $"{Services.RollDice() * 500} Credits";
                    starportFuel = "Refined";
                    starportFacilities.Add("Shipyard (space craft)");
                    starportFacilities.Add("Repair");

                    rollForNavalBase = Services.RollDice(6, 2);
                    if (rollForNavalBase >= 8)
                    {
                        starportBases.Add("Naval");
                    }
                    rollForScoutBase = Services.RollDice(6, 2);
                    if (rollForScoutBase >= 8)
                    {
                        starportBases.Add("Scout");
                    }
                    rollForResearchBase = Services.RollDice(6, 2);
                    if (rollForResearchBase >= 10)
                    {
                        starportBases.Add("Research");
                    }
                    starportBases.Add("TAS");
                    break;
                case 11:
                case 12:
                case 13:
                case 14:
                    starportClass = "A";
                    starportQuality = "Excellent";
                    berthingCost = $"{Services.RollDice() * 1000} Credits";
                    starportFuel = "Refined";
                    starportFacilities.Add("Shipyard (all)");
                    starportFacilities.Add("Repair");

                    rollForNavalBase = Services.RollDice(6, 2);
                    if (rollForNavalBase >= 8)
                    {
                        starportBases.Add("Naval");
                    }
                    rollForScoutBase = Services.RollDice(6, 2);
                    if (rollForScoutBase >= 10)
                    {
                        starportBases.Add("Scout");
                    }
                    rollForResearchBase = Services.RollDice(6, 2);
                    if (rollForResearchBase >= 8)
                    {
                        starportBases.Add("Research");
                    }
                    starportBases.Add("TAS");
                    break;
                default:
                    throw new Exception("Couldnt set starport" + starportNumber);
            }

            StarportModel starport = new()
            {
                Class = starportClass,
                Number = starportNumber,
                Quality = starportQuality,
                BerthingCost = berthingCost,
                Fuel = starportFuel,
                Facilities = starportFacilities,
                Bases = starportBases
            };

            return starport;
        }
        public static int TechLevel(int starport, int size, int atmosphere, int hydrographics, int population, int government)
        {
            int techLevel = 0, techLevelMod = 0;

            // Add tech level mods based on all previous characteristics
            switch (starport)
            {
                case 10:
                    techLevelMod += 6;
                    break;
                case 11:
                    techLevelMod += 4;
                    break;
                case 12:
                    techLevelMod += 2;
                    break;
                case 0:
                case 1:
                case 2:
                    techLevelMod += -4;
                    break;
                default:
                    break;
            }

            switch (size)
            {
                case 0:
                case 1:
                    techLevelMod += 2;
                    break;
                case 2:
                case 3:
                case 4:
                    techLevelMod += 1;
                    break;
                default:
                    break;
            }

            switch (atmosphere)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    techLevelMod += 1;
                    break;
                default:
                    break;
            }

            switch (hydrographics)
            {
                case 0:
                case 9:
                    techLevelMod += 1;
                    break;
                case 10:
                    techLevelMod += 2;
                    break;
                default:
                    break;
            }

            switch (population)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 8:
                    techLevelMod += 1;
                    break;
                case 9:
                    techLevelMod += 2;
                    break;
                case 10:
                    techLevelMod += 4;
                    break;
                default:
                    break;
            }

            switch (government)
            {
                case 0:
                case 5:
                    techLevelMod += 1;
                    break;
                case 7:
                    techLevelMod += 2;
                    break;
                case 13:
                case 14:
                    techLevelMod += -2;
                    break;
                default:
                    break;
            }

            techLevel = Services.RollDice() + techLevelMod;
            return Math.Min(30, Math.Max(0, techLevel));
        }
    }
}