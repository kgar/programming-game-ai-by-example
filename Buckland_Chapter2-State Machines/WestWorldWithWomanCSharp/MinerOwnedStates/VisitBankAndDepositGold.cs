namespace WestWorldWithWoman
{
    public class VisitBankAndDepositGold : IState<Miner>
    {
        private static VisitBankAndDepositGold _instance = null;
        private static readonly object padlock = new object();

        public VisitBankAndDepositGold() { }

        public static VisitBankAndDepositGold Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new VisitBankAndDepositGold();
                    }
                    return _instance;
                }
            }
        }

        public void Enter(Miner miner)
        {
            if (miner.Location != Location.Bank)
            {
                miner.Speak("Goin' to the bank. Yes siree");
                miner.ChangeLocation(Location.Bank);
            }
        }

        public void Execute(Miner miner)
        {
            miner.AddToWealth(miner.GoldCarried);
            miner.GoldCarried = 0;

            miner.Speak($"Depositing gold. Total savings now: {miner.MoneyInBank}");

            if (miner.MoneyInBank >= Miner.ComfortLevel)
            {
                miner.Speak("WooHoo! Rich enough for now. Back home to mah li'lle lady");
                miner.ChangeState(GoHomeAndSleepTilRested.Instance);
            }
            else
            {
                miner.ChangeState(EnterMineAndDigForNugget.Instance);
            }

        }

        public void Exit(Miner miner)
        {
            miner.Speak("Leavin' the bank");
        }
    }
}