using System;

namespace DecoratorPattern
{
   /// <summary>
   /// MainApp startup class for Structural 
   /// Decorator Design Pattern.
   /// </summary>
   class MainApp
   {
      static void Main()
      {
         GenericExample();
         Console.WriteLine();
         GOFExample();

         Console.ReadKey();
      }

      private static void GenericExample()
      {
         // Create ConcreteComponent and two Decorators
         ConcreteComponent c = new ConcreteComponent();
         ConcreteDecoratorA d1 = new ConcreteDecoratorA();
         ConcreteDecoratorB d2 = new ConcreteDecoratorB();

         // Link decorators
         d1.SetComponent(c);
         d2.SetComponent(d1);

         d2.Operation();
      }

      private static void GOFExample()
      {
         Window textWin = new TextWindow();
         WindowDecorator borderedTextWin = new BorderDecorator
         {
            Component = textWin
         };

         textWin.Show();
         Console.WriteLine("\n");
         borderedTextWin.Show();
      }
   }

   /// <summary>
   /// The 'Component' abstract class
   /// </summary>
   abstract class Component
   {
      public abstract void Operation();
   }

   /// <summary>
   /// The 'ConcreteComponent' class
   /// </summary>
   class ConcreteComponent : Component
   {
      public override void Operation()
      {
         Console.WriteLine("ConcreteComponent.Operation()");
      }
   }

   /// <summary>
   /// The 'Decorator' abstract class
   /// </summary>
   abstract class Decorator : Component
   {
      protected Component component;

      public void SetComponent(Component component)
      {
         this.component = component;
      }

      public override void Operation()
      {
         if (component != null)
         {
            component.Operation();
         }
      }
   }

   /// <summary>
   /// The 'ConcreteDecoratorA' class
   /// </summary>
   class ConcreteDecoratorA : Decorator
   {
      public override void Operation()
      {
         base.Operation();
         Console.WriteLine("ConcreteDecoratorA.Operation()");
      }
   }

   /// <summary>
   /// The 'ConcreteDecoratorB' class

   /// </summary>
   class ConcreteDecoratorB : Decorator
   {
      public override void Operation()
      {
         base.Operation();
         AddedBehavior();
         Console.WriteLine("ConcreteDecoratorB.Operation()");
      }

      void AddedBehavior()
      {
         Console.WriteLine("Some added behavior");
      }
   }

}
