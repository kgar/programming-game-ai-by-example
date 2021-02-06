using System;

namespace WestWorldWithWoman
{
    public sealed class DoHouseWork : IState<MinersWife>
    {
        private static DoHouseWork _instance;
        private readonly Random _random;
        private static readonly object padlock = new();

        private DoHouseWork()
        {
            _random = new Random();
        }

        public static DoHouseWork Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new DoHouseWork();
                    }
                    return _instance;
                }
            }
        }

        public void Execute(MinersWife entity)
        {
            switch (_random.Next(0, 2))
            {
                case 0:
                    entity.Speak("Moppin' the floor");
                    break;
                case 1:
                    entity.Speak("Washin' the dishes");
                    break;
                case 2:
                    entity.Speak("Makin' the bed");
                    break;
            }
        }
    }
}