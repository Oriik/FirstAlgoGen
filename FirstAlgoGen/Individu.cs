using System;
using System.Collections;

namespace FirstAlgoGen
{
    public class Individu : IComparable<Individu>
    {
        public int fitness;
        public int[] body;
        private Random random;

        public Individu(int bodySize)
        {
            body = new int[bodySize];
            random = new Random();
        }

        public int CompareTo(Individu other)
        {
            return fitness.CompareTo(other.fitness);
        }

        public void FirstGeneration()
        {
            for (int i = 0; i < body.Length; i++)
            {
                body[i] = random.Next(0, 1);
            }
            UpdateFitness();
        }

       

        public void Hybridation(Individu father, Individu mother)
        {
            for (int i = 0; i < body.Length; i++)
            {
                int rand = random.Next(0, 1);
                if(rand == 0)
                {
                    body[i] = father.body[i];
                }
                else
                {
                    body[i] = mother.body[i];
                }
            }
        }

        public void Mutation()
        {
            double r = random.NextDouble();
            if (r < 0.05)
            {            
                int rand = random.Next(0, body.Length);
                body[rand] = body[rand] == 0 ? 1 : 0;
            }
        }

        public void UpdateFitness()
        {
            fitness = 0;
            for (int i = 0; i < body.Length; i++)
            {
                fitness += body[i];
            }
        }
    }
}
