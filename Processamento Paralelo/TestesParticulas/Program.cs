using System.Collections.Concurrent;
using System.Numerics;

namespace TestesParticulas
{
    internal class Program
    {
        static Random random = new Random();
        static List<Particle> particulas = new List<Particle>(5000000);
        static int quantidadeFiltravel = 0;
        static List<Particle> particulasFiltradas = new List<Particle>();
        static ConcurrentBag<Particle> particulasFiltradasCBag = new ConcurrentBag<Particle>();
        static void Main(string[] args)
        {
            for(int i = 0; i < particulas.Capacity; i++)
            {
                Particle particula = new Particle(new Vector2(random.Next(0, 1001), random.Next(0, 1001)), 0.1f * random.Next(1, 101));
                particulas.Add(particula);
                if (particula.Position.X > 100 && particula.Life > 0.5)
                {
                    quantidadeFiltravel++;
                }
            }
            Console.WriteLine($"Quantidade de partículas geradas: {particulas.Count}");
            Console.WriteLine($"Quantidade de partículas filtráveis: {quantidadeFiltravel}");
            //PARTE ABAIXO NEM SEMPRE FUNCIONA (intencional)
            //Parallel.ForEach(particulas, (particula) =>
            //{
            //    if (particula.Position.X > 100 && particula.Life > 0.5)
            //    {
            //        Particle filtrada = new Particle(particula.Position, particula.Life);
            //        particulasFiltradas.Add(filtrada);
            //    }
            //});
            //Console.WriteLine($"Partículas filtradas (list): {particulasFiltradas.Count}");

            Parallel.ForEach(particulas, (particula) =>
            {
                if (particula.Position.X > 100 && particula.Life > 0.5)
                {
                    particulasFiltradasCBag.Add(particula);
                }
            });
            Console.WriteLine($"Partículas filtradas (concurrent bag): {particulasFiltradasCBag.Count}");
        }
    }

    internal class Particle
    {
        public Vector2 Position{ get; private set; }
        public float Life { get; private set; }

        public Particle(Vector2 position, float life)
        {
            this.Position = position;
            this.Life = life;
        }
    }
}
