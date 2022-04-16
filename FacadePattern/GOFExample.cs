using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FacadePattern.GOF
{
   public class Compiler
   {
      public void Compile(Stream stream)
      {
         Scanner scanner = new Scanner
         {
            Stream = stream
         };
         Parser parser = new Parser();
         parser.Parse(scanner);
      }
   }

   public class Stream
   {
      public String[] Tokens { get; set; } =
      {
         "T1", "T2", "T3", "T4", "T5"
      };
   }

   class Scanner
   {
      public Stream Stream { get; set; }

      public virtual IEnumerable<string> Scan()
      {
         foreach(var token in Stream.Tokens)
         {
            yield return token;
         }
      }
   }

   class Parser
   {
      public virtual void Parse(Scanner scanner)
      {
         foreach(var element in scanner.Scan())
         {
            Console.WriteLine($"Parsing {element}");
         }
      }
   }
}
