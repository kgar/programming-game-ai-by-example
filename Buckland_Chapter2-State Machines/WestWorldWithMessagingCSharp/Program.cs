using System;
using System.Threading.Tasks;

namespace WestWorldWithMessaging
{
    internal static class Program
    {
        private static async Task Main()
        {
            var bob = EntityManager.RegisterEntity(new Miner(EntityName.MinerBob));
            var elsa = EntityManager.RegisterEntity(new MinersWife(EntityName.Elsa));

            for (int i = 0; i < 20; i++)
            {
                bob.Update();
                elsa.Update();

                MessageDispatcher.DispatchDelayedMessages();

                await Task.Delay(800).ConfigureAwait(false);
            }

            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }
    }
}
