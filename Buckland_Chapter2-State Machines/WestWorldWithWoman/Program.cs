using System;
using System.Threading.Tasks;

namespace WestWorldWithWoman
{
    internal static class Program
    {
        private static async Task Main()
        {
            var bob = new Miner(EntityName.MinerBob);
            var elsa = new MinersWife(EntityName.Elsa);

            for (int i = 0; i < 20; i++)
            {
                bob.Update();
                elsa.Update();

                await Task.Delay(800).ConfigureAwait(false);
            }

            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }
    }
}
