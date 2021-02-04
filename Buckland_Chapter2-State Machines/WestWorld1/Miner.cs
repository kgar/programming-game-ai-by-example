namespace WestWorld1
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

        public Location Location { get; private set; } = Location.Shack;
        public int GoldCarried { get; set; } = 0;
        public int MoneyInBank { get; set; } = 0;
        private int _thirst = 0;
        private int _fatigue = 0;
        private IState _currentState = GoHomeAndSleepTilRested.Instance;


        public Miner(EntityName name) : base(name) { }

        public void ChangeState(IState newState)
        {
            _currentState.Exit(this);
            _currentState = newState;
            _currentState.Enter(this);
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
            _thirst += 1;

            if (_currentState != null)
            {
                _currentState.Execute(this);
            }
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