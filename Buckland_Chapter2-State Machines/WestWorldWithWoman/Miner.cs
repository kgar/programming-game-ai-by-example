namespace WestWorldWithWoman
{
    public class Miner : BaseGameEntity
    {
        //the amount of gold a miner must have before he feels comfortable
        public const int ComfortLevel = 5;
        //the amount of nuggets a miner can carry
        public const int MaxNuggets = 3;
        //above this value a miner is thirsty
        public const int ThirstLevel = 5;
        //above this value a miner is sleepy
        public const int TirednessThreshold = 5;

        public StateMachine<Miner> StateMachine { get; set; }
        public Location Location { get; private set; }
        public int GoldCarried { get; set; }
        public int MoneyInBank { get; set; }
        private int _thirst;
        private int _fatigue;

        public Miner(EntityName name) : base(name)
        {
            StateMachine = new StateMachine<Miner>(this);
            StateMachine.ChangeState(GoHomeAndSleepTilRested.Instance);
        }

        public void ChangeState(IState<Miner> newState)
        {
            StateMachine.ChangeState(newState);
        }

        public void AddToGoldCarried(int val)
        {
            GoldCarried += val;
            if (GoldCarried < 0) { GoldCarried = 0; }
        }

        public bool PocketsFull() => GoldCarried >= MaxNuggets;

        public void AddToWealth(int val)
        {
            MoneyInBank += val;
            if (MoneyInBank < 0)
            {
                MoneyInBank = 0;
            }
        }

        public bool Thirsty()
        {
            return _thirst >= ThirstLevel;
        }

        public void BuyAndDrinkAWhiskey()
        {
            _thirst = 0;
            MoneyInBank -= 2;
        }

        public void Update()
        {
            _thirst++;
            StateMachine.CurrentState?.Execute(this);
        }

        public void IncreaseFatigue() => _fatigue++;

        public void DecreaseFatigue() => _fatigue--;

        public bool Fatigued()
        {
            return _fatigue > TirednessThreshold;
        }

        public void ChangeLocation(Location location) => Location = location;

        public void Speak(string text)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine($"{EntityFunctions.GetNameOfEntity(Name)}: {text}");
            System.Console.ResetColor();
        }
    }
}