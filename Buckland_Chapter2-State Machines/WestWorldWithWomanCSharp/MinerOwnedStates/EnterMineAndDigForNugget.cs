namespace WestWorldWithWoman
{
    public class EnterMineAndDigForNugget : IStateOld
    {
        private static EnterMineAndDigForNugget _instance = null;
        private static readonly object padlock = new object();

        private EnterMineAndDigForNugget() { }

        public static EnterMineAndDigForNugget Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new EnterMineAndDigForNugget();
                    }
                    return _instance;
                }
            }
        }

        public void Enter(Miner miner)
        {
            if (miner.Location != Location.Goldmine)
            {
                miner.Speak("Walkin' to the goldmine");
                miner.ChangeLocation(Location.Goldmine);
            }
        }

        public void Execute(Miner miner)
        {
            miner.AddToGoldCarried(1);
            miner.IncreaseFatigue();

            miner.Speak("Pickin' up a nugget");

            if (miner.PocketsFull()) {
                miner.ChangeState(VisitBankAndDepositGold.Instance);
            }

            if (miner.Thirsty()) {
                miner.ChangeState(QuenchThirst.Instance);
            }
        }

        public void Exit(Miner miner)
        {
            miner.Speak("Ah'm leavin' the goldmine with mah pockets full o' sweet gold");
        }
    }
}