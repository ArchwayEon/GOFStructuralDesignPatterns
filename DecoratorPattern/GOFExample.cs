using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
   public abstract class Window
   {
      public virtual void Show()
      {
      }
   }
   public class TextWindow : Window
   {
      public override void Show()
      {
         Console.WriteLine("TEXT WINDOW");
      }
   }

   public abstract class WindowDecorator : Window
   {
      public Window Component { get; set; }

      public override void Show()
      {
         Component.Show();
      }
   }

   public class BorderDecorator : WindowDecorator
   {
      public override void Show()
      {
         Console.WriteLine("*********************");
         base.Show();
         Console.WriteLine("*********************");
      }
   }
}
