using System;
using System.Threading.Tasks;

namespace WestWorldWithWoman
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bob = new Miner(EntityName.MinerBob);
            var elsa = new MinersWife(EntityName.Elsa);

            for (int i = 0; i < 20; i++)
            {
                bob.Update();
                elsa.Update();

                await Task.Delay(800);
            }

            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }
    }
}
