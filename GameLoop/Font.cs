﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoop
{
    public class Font
    {
        Texture _texture;
        Dictionary<char, CharacterData> _characterData;
        public Font(Texture texture, Dictionary<char, CharacterData>
            characterData)
        {
            _texture = texture;
            _characterData = characterData;
        }
        public CharacterSprite CreateSprite(char c)
        {
            CharacterData charData = _characterData[c];
            sprite sprite = new sprite();
            sprite.Texture = _texture;
            Point topLeft = new Point((float)charData.X / (float)_texture.Width,
                (float)charData.Y / (float)_texture.Height);
            Point bottomRight = new Point(topLeft.X + ((float)charData.Height /
                (float)_texture.Width),
                topLeft.Y + ((float)charData.Height / (float)_texture.Height));

            sprite.SetUVs(topLeft, bottomRight);
            sprite.SetWidth(charData.Width);
            sprite.SetHeight(charData.Height);
            sprite.SetColor(new Color(1, 1, 1, 1));

            return new CharacterSprite(sprite, charData);
        }
    }
}
