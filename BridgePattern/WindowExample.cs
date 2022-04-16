using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePattern
{
   public abstract class Window
   {
      public WindowImp WindowImp { get; set; }

      public abstract void Open();

      public abstract void Show();

      public abstract void Close();
   }

   public class MessageBoxWindow : Window
   {
      public override void Close()
      {
         WindowImp.CloseImp();
      }

      public override void Open()
      {
         WindowImp.OpenImp();
      }

      public override void Show()
      {
         WindowImp.ShowImp();
      }
   }

   public abstract class WindowImp
   {
      public abstract void OpenImp();

      public abstract void CloseImp();
      public abstract void ShowImp();
   }

   public class WindowsImp : WindowImp
   {
      public override void CloseImp()
      {
         Console.WriteLine("Closing the Windows Window");
      }

      public override void OpenImp()
      {
         Console.WriteLine("Opening the Windows Window");
      }

      public override void ShowImp()
      {
         Console.WriteLine("&----------------------&");
         Console.WriteLine("|  MESSAGE BOX WINDOW  |");
         Console.WriteLine("&----------------------&");
      }
   }

   public class MacImp : WindowImp
   {
      public override void CloseImp()
      {
         Console.WriteLine("Closing the Mac Window");
      }

      public override void OpenImp()
      {
         Console.WriteLine("Opening the Mac Window");
      }

      public override void ShowImp()
      {
         Console.WriteLine("+----------------------+");
         Console.WriteLine("|  Message Box Window  |");
         Console.WriteLine("+----------------------+");
      }
   }
}
