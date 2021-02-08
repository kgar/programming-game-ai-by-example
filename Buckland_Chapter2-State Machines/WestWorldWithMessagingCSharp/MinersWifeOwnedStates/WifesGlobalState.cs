using System;

namespace WestWorldWithMessaging
{
    public sealed class WifesGlobalState : IState<MinersWife>
    {
        private static WifesGlobalState _instance;
        private readonly Random _random;
        private static readonly object padlock = new();

        private WifesGlobalState()
        {
            _random = new Random();
        }

        public static WifesGlobalState Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new WifesGlobalState();
                    }
                    return _instance;
                }
            }
        }

        public void Execute(MinersWife entity)
        {
            if (_random.NextDouble() < 0.1 && !entity.StateMachine.IsInState(VisitBathroom.Instance))
            {
                entity.StateMachine.ChangeState(VisitBathroom.Instance);
            }
        }

        public bool OnMessage(MinersWife wife, Telegram message)
        {
            if (message.Message == MessageType.HiHoneyImHome)
            {
                System.Console.WriteLine($"Message handle by {EntityFunctions.GetNameOfEntity(wife.Name)} at time: {DateTime.Now}");

                wife.Speak("Hi honey. Let me make you some of mah fine country stew");

                wife.StateMachine.ChangeState(CookStew.Instance);
                return true;
            }

            return false;
        }
    }
}