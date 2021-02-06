using System;

namespace WestWorldWithWoman
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
            if (_random.NextDouble() < 0.1)
            {
                entity.StateMachine.ChangeState(VisitBathroom.Instance);
            }
        }
    }
}