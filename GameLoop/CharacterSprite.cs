using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoop
{
   public class CharacterSprite
    {
        public sprite Sprite { get; set; }
        public CharacterData Data { get; set; } 
        public CharacterSprite (sprite sprite, CharacterData data)
        {
            Data = data;
            Sprite = sprite;
        }
    }
}
