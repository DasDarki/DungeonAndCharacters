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
        /// The strength attribute of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Strength { get; set; }

        /// <summary>
        /// The modifier for strength. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        [JsonIgnore]
        public int StrengthMod => CalculateMod(Strength);
        
        /// <summary>
        /// The dexterity attribute of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Dexterity { get; set; }

        /// <summary>
        /// The modifier for dexterity. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        [JsonIgnore]
        public int DexterityMod => CalculateMod(Dexterity);
        
        /// <summary>
        /// The constitution attribute of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Constitution { get; set; }

        /// <summary>
        /// The modifier for constitution. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        [JsonIgnore]
        public int ConstitutionMod => CalculateMod(Constitution);
        
        /// <summary>
        /// The intelligence attribute of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Intelligence { get; set; }

        /// <summary>
        /// The modifier for intelligence. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        [JsonIgnore]
        public int IntelligenceMod => CalculateMod(Intelligence);
        
        /// <summary>
        /// The wisdom attribute of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Wisdom { get; set; }

        /// <summary>
        /// The modifier for wisdom. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        [JsonIgnore]
        public int WisdomMod => CalculateMod(Wisdom);
        
        /// <summary>
        /// The charisma attribute of the character.
        /// This is just the plain value, from here the modifier gets calculated.
        /// </summary>
        public int Charisma { get; set; }

        /// <summary>
        /// The modifier for charisma. The result of the dice roll and this modifier
        /// is the check value for checks.
        /// </summary>
        [JsonIgnore]
        public int CharismaMod => CalculateMod(Charisma);

        /// <summary>
        /// The base initiative of the character.
        /// </summary>
        [JsonIgnore]
        public int Initiative => DexterityMod;

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
        /// A list containing every skill the character has.
        /// </summary>
        public List<Skill> Skills { get; set; } = new List<Skill>();
        
        private static int CalculateMod(int score)
        {
            return (int) Math.Floor((score - 10) / 2f);
        }
    }
}