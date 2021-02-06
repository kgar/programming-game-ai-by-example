namespace WestWorldWithWoman
{
    public class GoHomeAndSleepTilRested : IState<Miner>
    {
        private static GoHomeAndSleepTilRested _instance;
        private static readonly object padlock = new();

        public GoHomeAndSleepTilRested() { }

        public static GoHomeAndSleepTilRested Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new GoHomeAndSleepTilRested();
                    }
                    return _instance;
                }
            }
        }

        public void Enter(Miner entity)
        {
            if (entity.Location != Location.Shack)
            {
                entity.Speak("Walkin' home");
                entity.ChangeLocation(Location.Shack);
            }
        }

        public void Execute(Miner entity)
        {
            if (!entity.Fatigued())
            {
                entity.Speak("What a God darn fantastic nap! Time to find more gold");
                entity.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else
            {
                entity.DecreaseFatigue();
                entity.Speak("ZZZZ... ");
            }
        }

        public void Exit(Miner entity)
        {
            entity.Speak("Leaving the house");
        }
    }
}