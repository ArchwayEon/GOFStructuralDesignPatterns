using System;
using System.Collections.Generic;
using System.Text;

namespace FlyweightPattern
{
   public class Glyph
   {
      public virtual void Draw(GlyphContext context) { }
   }

   public class Character : Glyph
   {
      public char TheCharacter { get; set; }

      public override void Draw(GlyphContext context)
      {
         Console.Write(context.GetFont().Name);
         Console.Write(TheCharacter);
      }
   }

   public class Font
   {
      public string Name { get; set; }
   }

   public class GlyphContext
   {
      private int _index = 0;
      private int _fontIndex = 0;

      private Dictionary<int, Font> _fonts = new Dictionary<int, Font>();

      public void SetFont(Font font, int span=1)
      {
         for(int count = 0; count < span; count++)
         {
            _fonts[_index++] = font;
         }
      }

      public Font GetFont()
      {
         return _fonts[_fontIndex++];
      }

   }

   public class GlyphFactory
   {
      public Character[] Characters { get; set; } = new Character[5];

      public GlyphFactory()
      {
         for (int i = 0; i < 5; i++) Characters[i] = new Character();
         Characters[0].TheCharacter = 'A';
         Characters[1].TheCharacter = 'C';
         Characters[2].TheCharacter = 'Z';
         Characters[3].TheCharacter = 'G';
         Characters[4].TheCharacter = 'H';
      }
   }
}
