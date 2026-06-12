using System.Collections.Concurrent;
using System.Numerics;

namespace TestesParticulas
{
    internal class Program
    {
        const int numeroDeParticulas = 5000000;
        static Random random = new Random();

        static async Task Main(string[] args)
        {
            ConcurrentBag<Particle> particles = new ConcurrentBag<Particle>();
            Parallel.For(0, numeroDeParticulas, i =>
            {
                particles.Add(new Particle(new Vector3((float)random.NextDouble()*100,
                    (float)random.NextDouble() * 100,
                    (float)random.NextDouble() * 100),
                    (float)random.NextDouble()));
            });
            Console.WriteLine($"particulas criadas: {particles.Count}");

            ConcurrentBag<Particle> particulasVivas = await Task<ConcurrentBag<Particle>>.Run(() =>
            {
                ConcurrentBag<Particle> p = new ConcurrentBag<Particle>();

                Parallel.ForEach(particles, particle =>
                {
                    if(particle.Life >= 0.5)
                    {
                        p.Add(particle);
                    }
                });

                return p;
            });

            Console.WriteLine($"particulas vivas: {particulasVivas.Count}");
        }
    }

    internal class Particle
    {
        Vector3 position;
        float life;

        public Vector3 Position => position;
        public float Life => life;

        public Particle(Vector3 position, float life)
        {
            this.position = position;
            this.life = life;
        }
    }
}