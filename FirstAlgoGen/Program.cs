using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAlgoGen
{
    class Program
    {
        static void Main(string[] args)
        {
            //INIT
            int numGen = 0;
            int bestFitness = 0;
            int oldBestFitness= 0;
            int bodySize = 10;
            int populationSize = 10;

            Population population = new Population(populationSize, bodySize);

           while(bestFitness != bodySize)
            {
                numGen++;

                population.Selection();
                population.Hybridation();
                population.Mutation();
                population.UpdateFitness();
                oldBestFitness = bestFitness;
                bestFitness = population.people.Max().fitness;
               
                if(bestFitness != oldBestFitness)  Console.WriteLine("GENERATION "+numGen +" : best fitness = "+bestFitness);
            }

            Console.WriteLine("Last generation got perfect individual !");
            Console.ReadKey();
        }
    }
}
