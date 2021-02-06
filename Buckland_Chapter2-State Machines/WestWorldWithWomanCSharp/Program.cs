using System;
using System.Threading.Tasks;

namespace WestWorldWithWoman
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var miner = new Miner(EntityName.MinerBob);

            for (int i = 0; i < 20; i++)
            {
                miner.Update();

                await Task.Delay(800);
            }

            System.Console.WriteLine("Press any key to continue...");
            System.Console.Read();
        }
    }
}
