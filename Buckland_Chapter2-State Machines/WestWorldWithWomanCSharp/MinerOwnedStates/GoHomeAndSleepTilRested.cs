namespace WestWorldWithWoman
{
    public class GoHomeAndSleepTilRested : IState<Miner>
    {
        private static GoHomeAndSleepTilRested _instance = null;
        private static readonly object padlock = new object();

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

        public void Enter(Miner miner)
        {
            if (miner.Location != Location.Shack)
            {
                miner.Speak("Walkin' home");
                miner.ChangeLocation(Location.Shack);
            }
        }

        public void Execute(Miner miner)
        {
            if (!miner.Fatigued())
            {
                miner.Speak("What a God darn fantastic nap! Time to find more gold");
                miner.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else
            {
                miner.DecreaseFatigue();
                miner.Speak("ZZZZ... ");
            }
        }

        public void Exit(Miner miner)
        {
            miner.Speak("Leaving the house");
        }
    }
}