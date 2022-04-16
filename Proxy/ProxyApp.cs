using Proxy.GOF;
using System;

namespace Proxy
{
   /// <summary>
   /// MainApp startup class for Structural
   /// Proxy Design Pattern.
   /// </summary>
   class MainApp
   {
      /// <summary>
      /// Entry point into console application.
      /// </summary>
      static void Main()
      {
         // Create proxy and request a service
         GenericExample();
         Console.WriteLine("\n");
         GOFExample();

         // Wait for user
         Console.ReadKey();
      }

      private static void GenericExample()
      {
         Proxy proxy = new Proxy();
         proxy.Request();
      }

      private static void GOFExample()
      {
         DocumentEditor editor = new DocumentEditor();
         editor.Graphic = new ImageProxy();
         editor.Report();
      }
   }

   /// <summary>
   /// The 'Subject' abstract class
   /// </summary>

   abstract class Subject
   {
      public abstract void Request();
   }

   /// <summary>
   /// The 'RealSubject' class
   /// </summary>
   class RealSubject : Subject
   {
      public override void Request()
      {
         Console.WriteLine("Called RealSubject.Request()");
      }
   }

   /// <summary>
   /// The 'Proxy' class
   /// </summary>
   class Proxy : Subject
   {
      private RealSubject _realSubject;

      public override void Request()
      {
         // Use 'lazy initialization'
         if (_realSubject == null)
         {
            _realSubject = new RealSubject();
         }
         _realSubject.Request();
      }
   }

}
