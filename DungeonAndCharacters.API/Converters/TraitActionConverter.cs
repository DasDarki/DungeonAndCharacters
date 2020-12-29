using System;
using System.Collections.Generic;
using System.Diagnostics;
using DungeonAndCharacters.API.Traits;
using Newtonsoft.Json;

namespace DungeonAndCharacters.API.Converters
{
    internal class TraitActionConverter : JsonConverter<ITraitAction>
    {
        public override void WriteJson(JsonWriter writer, ITraitAction action, JsonSerializer serializer)
        {
            Dictionary<string, object> storage = new Dictionary<string, object> {{"Type", (int) action.Type}};
            action.Save(storage);
            writer.WriteValue(storage);
        }

        public override ITraitAction ReadJson(JsonReader reader, Type objectType, ITraitAction existingAction, bool hasExistingValue,
            JsonSerializer serializer)
        {
            Dictionary<string, object> storage = (Dictionary<string, object>) reader.Value;
            Debug.Assert(storage != null, nameof(storage) + " != null");
            ActionType type = (ActionType) (int) storage["Type"];
            ITraitAction action = ActionRegistry.Create(type);
            action.Load(storage);
            return action;
        }
    }
}