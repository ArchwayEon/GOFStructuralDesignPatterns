using FacadePattern.GOF;
using System;

namespace FacadePattern
{
   /// <summary>
   /// MainApp startup class for Structural
   /// Facade Design Pattern.
   /// </summary>
   class MainApp
   {
      /// <summary>
      /// Entry point into console application.
      /// </summary>

      public static void Main()
      {
         GenericExample();
         Console.WriteLine("\n");
         GOFExample();
         // Wait for user
         Console.ReadKey();
      }

      private static void GenericExample()
      {
         Facade facade = new Facade();

         facade.MethodA();
         facade.MethodB();
      }

      private static void GOFExample()
      {
         Compiler compiler = new Compiler();
         compiler.Compile(new Stream());
      }
   }

   /// <summary>
   /// The 'Subsystem ClassA' class
   /// </summary>
   class SubSystemOne
   {
      public void MethodOne()
      {
         Console.WriteLine(" SubSystemOne Method");
      }
   }

   /// <summary>
   /// The 'Subsystem ClassB' class
   /// </summary>
   class SubSystemTwo
   {
      public void MethodTwo()
      {
         Console.WriteLine(" SubSystemTwo Method");
      }
   }

   /// <summary>
   /// The 'Subsystem ClassC' class
   /// </summary>
   class SubSystemThree
   {
      public void MethodThree()
      {
         Console.WriteLine(" SubSystemThree Method");
      }
   }

   /// <summary>
   /// The 'Subsystem ClassD' class
   /// </summary>
   class SubSystemFour
   {
      public void MethodFour()
      {
         Console.WriteLine(" SubSystemFour Method");
      }
   }

   /// <summary>
   /// The 'Facade' class
   /// </summary>
   public class Facade
   {
      private SubSystemOne _one;
      private SubSystemTwo _two;
      private SubSystemThree _three;
      private SubSystemFour _four;

      public Facade()
      {
         _one = new SubSystemOne();
         _two = new SubSystemTwo();
         _three = new SubSystemThree();
         _four = new SubSystemFour();
      }

      public void MethodA()
      {
         Console.WriteLine("\nMethodA() ---- ");
         _one.MethodOne();
         _two.MethodTwo();
         _four.MethodFour();
      }

      public void MethodB()
      {
         Console.WriteLine("\nMethodB() ---- ");
         _two.MethodTwo();
         _three.MethodThree();
      }
   }

}
