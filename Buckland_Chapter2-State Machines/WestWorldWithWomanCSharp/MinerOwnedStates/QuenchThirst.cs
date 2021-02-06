namespace WestWorldWithWoman
{
    public class QuenchThirst : IStateOld
    {
        private static QuenchThirst _instance = null;
        private static readonly object padlock = new object();

        public QuenchThirst() { }

        public static QuenchThirst Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new QuenchThirst();
                    }
                    return _instance;
                }
            }
        }

        public void Enter(Miner miner)
        {
            if (miner.Location != Location.Saloon)
            {
                miner.ChangeLocation(Location.Saloon);
                miner.Speak("Boy, ah sure is thusty! Walking to the saloon");
            }
        }

        public void Execute(Miner miner)
        {
            if (miner.Thirsty())
            {
                miner.BuyAndDrinkAWhiskey();
                miner.Speak("That's mighty fine sippin liquer");
                miner.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine("\nERROR!\nERROR!\nERROR!");
            }
        }

        public void Exit(Miner miner)
        {
            miner.Speak("Leaving the saloon, feelin' good");
        }

    }
}