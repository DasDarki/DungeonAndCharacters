using System.Collections.Generic;

namespace DungeonAndCharacters.API.Model
{
    /// <summary>
    /// The attack defines the possible physical attacks of a character.
    /// </summary>
    public class Attack
    {
        /// <summary>
        /// The name of the attack.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The description of the attack. Can be some explanation of effect for example.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// If the character is skilled in an attack he gets this bonus on his attack roll.
        /// </summary>
        public int PracticeBonus { get; set; }
        
        /// <summary>
        /// The attribute which defines the <see cref="PracticeBonus"/> of the attack.
        /// </summary>
        public string PracticeAttribute { get; set; }
        
        /// <summary>
        /// The range in meters how far this attack can go.
        /// </summary>
        public double Range { get; set; }
        
        /// <summary>
        /// The attack modifier which gets added to the attack roll. The result is the value which needs to
        /// be under the targets armor class.
        /// </summary>
        public int Bonus { get; set; }
        
        /// <summary>
        /// A list containing the hit dices of the attack. See <see cref="Character.HitDices"/> for more information.
        /// </summary>
        public List<Dice> HitDices { get; set; } = new List<Dice>();
        
        /// <summary>
        /// The value which gets added to the rolled hit dices result.
        /// </summary>
        public int HitBonus { get; set; }
    }
}