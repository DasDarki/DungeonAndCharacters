﻿using DungeonAndCharacters.API.UI;
using DungeonAndCharacters.API.UI.Layout;

namespace DungeonAndCharacters.UI.Layout
{
    internal class FieldBody : Parent, IFieldBody
    {
        internal FieldBody(IElement parent, string id, SetupSettings settings) : base(parent, id, settings)
        {
        }

        internal override string GetHTML(string classes)
        {
            return $"<div id=\"{ID}\", class=\"field-body {classes}\"></div>";
        }
    }
}
