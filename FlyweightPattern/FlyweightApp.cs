using System;
using System.Collections;

namespace FlyweightPattern
{
   /// <summary>
   /// MainApp startup class for Structural 
   /// Flyweight Design Pattern.
   /// </summary>
   class MainApp
   {
      /// <summary>
      /// Entry point into console application.
      /// </summary>
      static void Main()
      {
         GenericExample();
         Console.WriteLine("\n");
         GOFExample();

         // Wait for user
         Console.ReadKey();
      }

      private static void GenericExample()
      {
         // Arbitrary extrinsic state
         int extrinsicstate = 22;

         FlyweightFactory factory = new FlyweightFactory();

         // Work with different flyweight instances
         Flyweight fx = factory.GetFlyweight("X");
         fx.Operation(--extrinsicstate);

         Flyweight fy = factory.GetFlyweight("Y");
         fy.Operation(--extrinsicstate);

         Flyweight fz = factory.GetFlyweight("Z");
         fz.Operation(--extrinsicstate);

         UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight();

         fu.Operation(--extrinsicstate);
      }

      static void GOFExample()
      {
         GlyphContext gc = new GlyphContext();
         gc.SetFont(new Font { Name = "F1:" }, 2);
         gc.SetFont(new Font { Name = "F2:" }, 2);
         gc.SetFont(new Font { Name = "F3:" }, 1);

         GlyphFactory factory = new GlyphFactory();
         foreach (Character ch in factory.Characters)
         {
            ch.Draw(gc);
         }
      }
   }

   /// <summary>
   /// The 'FlyweightFactory' class
   /// </summary>
   class FlyweightFactory
   {
      private Hashtable flyweights = new Hashtable();

      // Constructor
      public FlyweightFactory()
      {
         flyweights.Add("X", new ConcreteFlyweight());
         flyweights.Add("Y", new ConcreteFlyweight());
         flyweights.Add("Z", new ConcreteFlyweight());
      }

      public Flyweight GetFlyweight(string key)
      {
         return ((Flyweight)flyweights[key]);
      }
   }

   /// <summary>
   /// The 'Flyweight' abstract class
   /// </summary>
   abstract class Flyweight
   {
      public abstract void Operation(int extrinsicstate);
   }

   /// <summary>
   /// The 'ConcreteFlyweight' class
   /// </summary>
   class ConcreteFlyweight : Flyweight
   {
      public override void Operation(int extrinsicstate)
      {
         Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
      }
   }

   /// <summary>
   /// The 'UnsharedConcreteFlyweight' class
   /// </summary>
   class UnsharedConcreteFlyweight : Flyweight
   {
      public override void Operation(int extrinsicstate)
      {
         Console.WriteLine("UnsharedConcreteFlyweight: " +
           extrinsicstate);
      }
   }

}
