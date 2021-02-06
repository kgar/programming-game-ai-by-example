namespace WestWorldWithWoman
{
    public class EnterMineAndDigForNugget : IState<Miner>
    {
        private static EnterMineAndDigForNugget _instance;
        private static readonly object padlock = new();

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

        public void Enter(Miner entity)
        {
            if (entity.Location != Location.Goldmine)
            {
                entity.Speak("Walkin' to the goldmine");
                entity.ChangeLocation(Location.Goldmine);
            }
        }

        public void Execute(Miner entity)
        {
            entity.AddToGoldCarried(1);
            entity.IncreaseFatigue();

            entity.Speak("Pickin' up a nugget");

            if (entity.PocketsFull())
            {
                entity.ChangeState(VisitBankAndDepositGold.Instance);
            }

            if (entity.Thirsty())
            {
                entity.ChangeState(QuenchThirst.Instance);
            }
        }

        public void Exit(Miner entity)
        {
            entity.Speak("Ah'm leavin' the goldmine with mah pockets full o' sweet gold");
        }
    }
}