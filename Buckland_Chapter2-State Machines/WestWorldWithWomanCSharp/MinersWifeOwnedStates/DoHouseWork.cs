using System;

namespace WestWorldWithWoman
{

    public sealed class DoHouseWork : IState<MinersWife>
    {
        private static DoHouseWork _instance = null;
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

        public void Execute(MinersWife wife)
        {
            switch (_random.Next(0, 2))
            {
                case 0:
                    wife.Speak("Moppin' the floor");
                    break;
                case 1:
                    wife.Speak("Washin' the dishes");
                    break;
                case 2:
                    wife.Speak("Makin' the bed");
                    break;
            }
        }
    }
}