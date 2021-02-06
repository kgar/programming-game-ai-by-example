namespace WestWorldWithMessaging
{
    public class QuenchThirst : IState<Miner>
    {
        private static QuenchThirst _instance;
        private static readonly object padlock = new();

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

        public void Enter(Miner entity)
        {
            if (entity.Location != Location.Saloon)
            {
                entity.ChangeLocation(Location.Saloon);
                entity.Speak("Boy, ah sure is thusty! Walking to the saloon");
            }
        }

        public void Execute(Miner entity)
        {
            if (entity.Thirsty())
            {
                entity.BuyAndDrinkAWhiskey();
                entity.Speak("That's mighty fine sippin liquer");
                entity.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine("\nERROR!\nERROR!\nERROR!");
            }
        }

        public void Exit(Miner entity)
        {
            entity.Speak("Leaving the saloon, feelin' good");
        }
    }
}