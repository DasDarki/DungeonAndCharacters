using System.Collections.Generic;
using DungeonAndCharacters.API.Model;

namespace DungeonAndCharacters.API.Traits.Actions
{
    /// <summary>
    /// The default trait action which has the type <see cref="ActionType.Meta"/>.
    /// </summary>
    public class TraitAction : ITraitAction
    {
        /// <summary>
        /// <see cref="ITraitAction.Type"/>
        /// </summary>
        public ActionType Type { get; } = ActionType.Meta;

        /// <summary>
        /// <see cref="ITraitAction.Save"/>
        /// </summary>
        public virtual void Save(Dictionary<string, object> storage) {}

        /// <summary>
        /// <see cref="ITraitAction.Load"/>
        /// </summary>
        public void Load(Dictionary<string, object> storage) {}

        /// <summary>
        /// <see cref="ITraitAction.Activate"/>
        /// </summary>
        public void Activate(Character character) {}
    }
}