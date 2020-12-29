using System;
using System.Collections.Generic;
using DungeonAndCharacters.API.Traits.Actions;

namespace DungeonAndCharacters.API.Traits
{
    /// <summary>
    /// The action registry is for registering custom <see cref="ITraitAction"/>.
    /// </summary>
    public static class ActionRegistry
    {
        private static readonly Dictionary<ActionType, Type> RegisteredActions = new Dictionary<ActionType, Type>();
        
        /// <summary>
        /// Registers the given type as action in the registry.
        /// The type needs to have default constructor for the creation process later.
        /// </summary>
        /// <param name="type">The action type to which the type gets bound</param>
        /// <typeparam name="T">The type of the action</typeparam>
        public static void Register<T>(ActionType type) where T : ITraitAction
        {
            RegisteredActions.Add(type, typeof(T));
        }

        /// <summary>
        /// Creates a default instance of a <see cref="ITraitAction"/> of the given <see cref="ActionType"/>.
        /// </summary>
        /// <param name="type">The <see cref="ActionType"/> of the wanted <see cref="ITraitAction"/></param>
        /// <returns>The newly created default <see cref="ITraitAction"/> instance</returns>
        public static ITraitAction Create(ActionType type)
        {
            return (ITraitAction) Activator.CreateInstance(RegisteredActions[type]);
        }

        static ActionRegistry()
        {
            Register<TraitAction>(ActionType.Meta);
        }
    }
}