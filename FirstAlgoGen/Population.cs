using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstAlgoGen
{
    public class Population
    {
        public List<Individu> people;
        public int populationSize;
        public int bodySize;
        private Random random;

        public Population(int _populationSize, int _bodySize)
        {
            random = new Random();
            people = new List<Individu>();
            populationSize = _populationSize;
            bodySize = _bodySize;

            for (int i = 0; i < populationSize; i++)
            {
                Individu temp = new Individu(bodySize);
                temp.FirstGeneration();
                people.Add(temp);
            }
        }

        internal void UpdateFitness()
        {
            foreach(Individu individu in people)
            {
                individu.UpdateFitness();
            }
        }

        internal void Mutation()
        {
            foreach (Individu individu in people)
            {
                individu.Mutation();
            }
        }

        internal void Hybridation()
        {
            while(people.Count < populationSize)
            {
                Individu temp = new Individu(bodySize);
                int father = random.Next(0, populationSize/2);
                int mother;
                do
                {
                    mother = random.Next(0, populationSize / 2);
                } while (mother == father);


                temp.Hybridation(people[father], people[mother]);
                people.Add(temp);
            }
           
        }

        internal void Selection()
        {
            List<Individu> bestPeople = new List<Individu>();

            foreach (Individu i in people)
            {
                bestPeople.Add(i);
                if (bestPeople.Count > populationSize / 2)
                {
                    Individu worst = bestPeople.Min();
                    bestPeople.Remove(worst);
                }
            }
            people = bestPeople;
        }
    }
}
