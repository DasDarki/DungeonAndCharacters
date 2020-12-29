using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DungeonAndCharacters.API.Model.Characteristics;
using Newtonsoft.Json;

namespace DungeonAndCharacters.API.Model
{
    /// <summary>
    /// The character is the model which represents the being of a player when
    /// role playing.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The name of the player who plays the character.
        /// </summary>
        public string Player { get; set; }
        
        /// <summary>
        /// A list containing all classes of this character.
        /// </summary>
        public List<Class> Classes { get; set; }
        
        /// <summary>
        /// The experience points of the character.
        /// </summary>
        public int Exp { get; set; }
        
        /// <summary>
        /// The race of the character.
        /// </summary>
        public Race Race { get; set; }
        
        /// <summary>
        /// The background of the character.
        /// </summary>
        public Background Background { get; set; }
        
        /// <summary>
        /// The alignment of the character.
        /// </summary>
        public Alignment Alignment { get; set; }
        
        /// <summary>
        /// The strength attribute score of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Strength { get; set; }

        /// <summary>
        /// The modifier for strength. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        public int StrengthMod { get; set; }
        
        /// <summary>
        /// The dexterity attribute score of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Dexterity { get; set; }

        /// <summary>
        /// The modifier for dexterity. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        public int DexterityMod { get; set; }
        
        /// <summary>
        /// The constitution attribute score of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Constitution { get; set; }

        /// <summary>
        /// The modifier for constitution. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        public int ConstitutionMod { get; set; }
        
        /// <summary>
        /// The intelligence attribute score of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Intelligence { get; set; }

        /// <summary>
        /// The modifier for intelligence. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        public int IntelligenceMod { get; set; }
        
        /// <summary>
        /// The wisdom attribute score of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Wisdom { get; set; }

        /// <summary>
        /// The modifier for wisdom. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        public int WisdomMod { get; set; }
        
        /// <summary>
        /// The charisma attribute score of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Charisma { get; set; }

        /// <summary>
        /// The modifier for charisma. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        public int CharismaMod { get; set; }

        /// <summary>
        /// The base initiative of the character.
        /// </summary>
        public int Initiative { get; set; }

        /// <summary>
        /// The avatar image as raw base64 data.
        /// </summary>
        public string RawAvatar { get; set; }
        
        /// <summary>
        /// The <see cref="RawAvatar"/> converted to an image object.
        /// </summary>
        [JsonIgnore]
        public Image Avatar
        {
            get
            {
                using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(RawAvatar)) {Position = 0})
                {
                    return Image.FromStream(stream);
                }
            }
            set
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    value.Save(stream, ImageFormat.Png);
                    RawAvatar = Convert.ToBase64String(stream.GetBuffer());
                }
            }
        }
        
        /// <summary>
        /// A list containing traits which describe the personality of the character.
        /// </summary>
        public List<string> PersonalityTraits { get; set; } = new List<string>();
        
        /// <summary>
        /// A list containing ideals of the character.
        /// </summary>
        public List<string> Ideals { get; set; } = new List<string>();
        
        /// <summary>
        /// A list containing bonds of the character.
        /// </summary>
        public List<string> Bonds { get; set; } = new List<string>();
        
        /// <summary>
        /// A list containing flaws of the character.
        /// </summary>
        public List<string> Flaws { get; set; } = new List<string>();
        
        /// <summary>
        /// The armor class of the character.
        /// </summary>
        public int Armor { get; set; }
        
        /// <summary>
        /// The movement range of the character. Mostly defined by the <see cref="Race"/>.
        /// </summary>
        public int Speed { get; set; }
        
        /// <summary>
        /// The maximum value of the health for this character.
        /// </summary>
        public int MaxHealth { get; set; }
        
        /// <summary>
        /// The current health of the character.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// The temporary health is mostly unused. In some special cases its needed, for example some magical effects
        /// which change the health of the character for a specific time.
        /// </summary>
        public int TempHealth { get; set; }
        
        /// <summary>
        /// This value defines the current state of death saving throws. If this value is in the negative area,
        /// and counts -3, the character counts as death. If the value is in the positive area and counts 3,
        /// the player succeeded the death saving throw. 
        /// </summary>
        public int DeathSavingThrow { get; set; }

        /// <summary>
        /// The proficiency bonus is being added to the skills if the skills are marked as proficiency by
        /// setting <see cref="Skill.IsProficiency"/> to true. By default this value is at +2.
        /// </summary>
        public int ProficiencyBonus { get; set; } = 2;
        
        /// <summary>
        /// The inspiration is a special value which can only be given by the dungeon master.
        /// It is a value which gets decremented on usage and is allowing the player to use advantage
        /// on a roll.
        /// </summary>
        public int Inspiration { get; set; }
        
        /// <summary>
        /// The perception or passive wisdom is a value which is normally calculated by adding the perception
        /// skill value to 10.
        /// </summary>
        public int PassiveWisdom { get; set; }
        
        /// <summary>
        /// A list containing the hit dices for attack rolls of the character. If the same dice is being contained
        /// multiple times, these dices will be merged together. E.g. if there are 3 <see cref="Dice.D4"/> it will be
        /// merged to 3d4.
        /// </summary>
        public List<Dice> HitDices { get; set; } = new List<Dice>();
        
        /// <summary>
        /// A list containing all attacks the character can do and which are not magical.
        /// </summary>
        public List<Attack> Attacks { get; set; } = new List<Attack>();
        
        /// <summary>
        /// The skill defining the strength saving throw of the character.
        /// </summary>
        public Skill StrengthSavingThrow { get; set; } = new Skill("Stärke");
        
        /// <summary>
        /// The skill defining the dexterity saving throw of the character.
        /// </summary>
        public Skill DexteritySavingThrow { get; set; } = new Skill("Geschicklichkeit");
        
        /// <summary>
        /// The skill defining the constitution saving throw of the character.
        /// </summary>
        public Skill ConstitutionSavingThrow { get; set; } = new Skill("Konstitution");
        
        /// <summary>
        /// The skill defining the intelligence saving throw of the character.
        /// </summary>
        public Skill IntelligenceSavingThrow { get; set; } = new Skill("Intelligenz");
        
        /// <summary>
        /// The skill defining the wisdom saving throw of the character.
        /// </summary>
        public Skill WisdomSavingThrow { get; set; } = new Skill("Weisheit");
        
        /// <summary>
        /// The skill defining the charisma saving throw of the character.
        /// </summary>
        public Skill CharismaSavingThrow { get; set; } = new Skill("Charisma");
        
        /// <summary>
        /// The skill defining the acrobatics modifier of the character.
        /// </summary>
        public Skill Acrobatics { get; set; } = new Skill("Akrobatik");
        
        /// <summary>
        /// The skill defining the animal handling modifier of the character.
        /// </summary>
        public Skill AnimalHandling { get; set; } = new Skill("Umgang mit Tieren");
        
        /// <summary>
        /// The skill defining the arcana modifier of the character.
        /// </summary>
        public Skill Arcana { get; set; } = new Skill("Arkana Kunde");
        
        /// <summary>
        /// The skill defining the athletics modifier of the character.
        /// </summary>
        public Skill Athletics { get; set; } = new Skill("Athletik");
        
        /// <summary>
        /// The skill defining the deception modifier of the character.
        /// </summary>
        public Skill Deception { get; set; } = new Skill("Täuschung");
        
        /// <summary>
        /// The skill defining the history modifier of the character.
        /// </summary>
        public Skill History { get; set; } = new Skill("Geschichte");
        
        /// <summary>
        /// The skill defining the insight modifier of the character.
        /// </summary>
        public Skill Insight { get; set; } = new Skill("Einsicht");
        
        /// <summary>
        /// The skill defining the intimidation modifier of the character.
        /// </summary>
        public Skill Intimidation { get; set; } = new Skill("Einschüchtern");
        
        /// <summary>
        /// The skill defining the investigation modifier of the character.
        /// </summary>
        public Skill Investigation { get; set; } = new Skill("Nachforschung");
        
        /// <summary>
        /// The skill defining the medicine modifier of the character.
        /// </summary>
        public Skill Medicine { get; set; } = new Skill("Heilkunde");
        
        /// <summary>
        /// The skill defining the nature modifier of the character.
        /// </summary>
        public Skill Nature { get; set; } = new Skill("Naturkunde");
        
        /// <summary>
        /// The skill defining the perception modifier of the character.
        /// </summary>
        public Skill Perception { get; set; } = new Skill("Wahrnehmung");
        
        /// <summary>
        /// The skill defining the performance modifier of the character.
        /// </summary>
        public Skill Performance { get; set; } = new Skill("Auftreten");
        
        /// <summary>
        /// The skill defining the persuasion modifier of the character.
        /// </summary>
        public Skill Persuasion { get; set; } = new Skill("Überreden");
        
        /// <summary>
        /// The skill defining the religion modifier of the character.
        /// </summary>
        public Skill Religion { get; set; } = new Skill("Religion");
        
        /// <summary>
        /// The skill defining the sleight of hand modifier of the character.
        /// </summary>
        public Skill SleightOfHand { get; set; } = new Skill("Fingerfertigkeit");
        
        /// <summary>
        /// The skill defining the stealth modifier of the character.
        /// </summary>
        public Skill Stealth { get; set; } = new Skill("Heimlichkeit");
        
        /// <summary>
        /// The skill defining the survival modifier of the character.
        /// </summary>
        public Skill Survival { get; set; } = new Skill("Überlebenskunst");
        
        /// <summary>
        /// Recalculates the characters data. Some of the given data is defined by the user or other properties
        /// of e.g. <see cref="Class"/> or <see cref="Race"/> but some of them like <see cref="Initiative"/> needs
        /// to be calculated. This method forces the calculation process for the whole character to be repeated.
        /// </summary>
        public void Recalculate()
        {
            Race.Traits.ForEach(trait => trait.Action.Activate(this));
            Classes.ForEach(@class => @class.Traits.ForEach(trait => trait.Action.Activate(this)));
            StrengthMod = CalculateMod(Strength);
            DexterityMod = CalculateMod(Dexterity);
            WisdomMod = CalculateMod(Wisdom);
            IntelligenceMod = CalculateMod(Intelligence);
            CharismaMod = CalculateMod(Charisma);
            Acrobatics.Value = DexterityMod + (Acrobatics.IsProficiency ? ProficiencyBonus : 0);
            AnimalHandling.Value = WisdomMod + (AnimalHandling.IsProficiency ? ProficiencyBonus : 0);
            Arcana.Value = IntelligenceMod + (Arcana.IsProficiency ? ProficiencyBonus : 0);
            Athletics.Value = StrengthMod + (Athletics.IsProficiency ? ProficiencyBonus : 0);
            Deception.Value = CharismaMod + (Deception.IsProficiency ? ProficiencyBonus : 0);
            History.Value = IntelligenceMod + (History.IsProficiency ? ProficiencyBonus : 0);
            Insight.Value = WisdomMod + (Insight.IsProficiency ? ProficiencyBonus : 0);
            Intimidation.Value = CharismaMod + (Intimidation.IsProficiency ? ProficiencyBonus : 0);
            Investigation.Value = IntelligenceMod + (Investigation.IsProficiency ? ProficiencyBonus : 0);
            Medicine.Value = WisdomMod + (Medicine.IsProficiency ? ProficiencyBonus : 0);
            Nature.Value = IntelligenceMod + (Nature.IsProficiency ? ProficiencyBonus : 0);
            Perception.Value = WisdomMod + (Perception.IsProficiency ? ProficiencyBonus : 0);
            Performance.Value = CharismaMod + (Performance.IsProficiency ? ProficiencyBonus : 0);
            Persuasion.Value = CharismaMod + (Persuasion.IsProficiency ? ProficiencyBonus : 0);
            Religion.Value = IntelligenceMod + (Religion.IsProficiency ? ProficiencyBonus : 0);
            SleightOfHand.Value = DexterityMod + (SleightOfHand.IsProficiency ? ProficiencyBonus : 0);
            Stealth.Value = DexterityMod + (Stealth.IsProficiency ? ProficiencyBonus : 0);
            Survival.Value = WisdomMod + (Survival.IsProficiency ? ProficiencyBonus : 0);
        }
        
        /// <summary>
        /// Calculates the modifier for an attribute by the attribute score / value.
        /// </summary>
        /// <param name="score">The score of the wanted attribute</param>
        /// <returns>The modifier for the attribute</returns>
        public static int CalculateMod(int score)
        {
            return (int) Math.Floor((score - 10) / 2f);
        }
    }
}