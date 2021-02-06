namespace WestWorldWithWoman
{
    public class VisitBankAndDepositGold : IState<Miner>
    {
        private static VisitBankAndDepositGold _instance;
        private static readonly object padlock = new();

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

        public void Enter(Miner entity)
        {
            if (entity.Location != Location.Bank)
            {
                entity.Speak("Goin' to the bank. Yes siree");
                entity.ChangeLocation(Location.Bank);
            }
        }

        public void Execute(Miner entity)
        {
            entity.AddToWealth(entity.GoldCarried);
            entity.GoldCarried = 0;

            entity.Speak($"Depositing gold. Total savings now: {entity.MoneyInBank}");

            if (entity.MoneyInBank >= Miner.ComfortLevel)
            {
                entity.Speak("WooHoo! Rich enough for now. Back home to mah li'lle lady");
                entity.ChangeState(GoHomeAndSleepTilRested.Instance);
            }
            else
            {
                entity.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public void Exit(Miner entity)
        {
            entity.Speak("Leavin' the bank");
        }
    }
}