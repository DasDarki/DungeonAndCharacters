using System.Collections.Generic;
using DungeonAndCharacters.API.Model;

namespace DungeonAndCharacters.API.Traits
{
    /// <summary>
    /// The trait action does something to a character on activation.
    /// </summary>
    public interface ITraitAction
    {
        /// <summary>
        /// The type of the action.
        /// </summary>
        ActionType Type { get; }

        /// <summary>
        /// Gets called when the action is being saved. The action
        /// can than save the its data to the given data storage.
        /// </summary>
        /// <param name="storage">The storage which will save the data</param>
        void Save(Dictionary<string, object> storage);

        /// <summary>
        /// Gets called when the action is being loaded. The action
        /// can than load its data from the given data storage.
        /// </summary>
        /// <param name="storage">The storage which holds the data</param>
        void Load(Dictionary<string, object> storage);

        /// <summary>
        /// Activates the action for the given character.
        /// </summary>
        /// <param name="character">The given character</param>
        void Activate(Character character);
    }
}