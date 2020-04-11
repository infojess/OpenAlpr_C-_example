using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using openalprnet;
using System.Drawing;
using System.IO;

namespace testPatentes3Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            
            AlprNet alpr = new openalprnet.AlprNet("us","" ,"");
            
            if (!alpr.IsLoaded())
            {
                Console.WriteLine("OpenAlpr failed to load!");
                return;
            }
            // Optionally apply pattern matching for a particular region
            alpr.DefaultRegion = "md";

            var results = alpr.Recognize(@"samples\us-1.jpg");
            int i = 0;
            foreach (var result in results.Plates)
            {
                Console.WriteLine("Plate {0}: {1} result(s)", i++, result.TopNPlates.Count);
                Console.WriteLine("  Processing Time: {0} msec(s)", result.ProcessingTimeMs);
                foreach (var plate in result.TopNPlates)
                {
                    Console.WriteLine("  - {0}\t Confidence: {1}\tMatches Template: {2}", plate.Characters,
                                      plate.OverallConfidence, plate.MatchesTemplate);
                }
            }

            Console.WriteLine("¡HOLA MUNDO! presiona una tecla para salir");
            Console.ReadKey();
        }
    }
}
