using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Proxy.GOF
{
   public class DocumentEditor
   {
      public IGraphic Graphic { get; set; }

      public void Report()
      {
         Console.WriteLine("Here is the document");
         Console.WriteLine($"The size of the image is: {Graphic.Size()}");
         Console.WriteLine("The image is:");
         Graphic.Draw();
         Console.WriteLine($"The size of the image is: {Graphic.Size()}");
      }
   }

   public interface IGraphic
   {
      void Draw();
      void Store();
      void Load();
      string Size();
   }

   public class Image : IGraphic
   {
      public void Draw()
      {
         Console.WriteLine("*******");
         Console.WriteLine(" *   * ");
         Console.WriteLine("  ***  ");
         Console.WriteLine("*******");
      }

      public void Load()
      {
         Console.WriteLine("Loading image...");
         Thread.Sleep(500);
         Console.WriteLine("...Image loaded");
      }

      public string Size()
      {
         return "4X7";
      }

      public void Store()
      {
         Console.WriteLine("Storing image...");
         Thread.Sleep(500);
         Console.WriteLine("...Image Stored");
      }
   }

   public class ImageProxy : IGraphic
   {
      public Image Image { get; set; }

      public void Draw()
      {
         if(Image == null)
         {
            Load();
         }
         Image.Draw();
      }

      public void Load()
      {
         Image = new Image();
         Image.Load();
      }

      public string Size()
      {
         if (Image == null)
         {
            return "Don't know";
         }
         return Image.Size();
      }

      public void Store()
      {
         Image.Store();
      }
   }
}
