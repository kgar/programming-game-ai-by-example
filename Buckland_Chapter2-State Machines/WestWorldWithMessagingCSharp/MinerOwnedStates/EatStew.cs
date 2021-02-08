using System;

namespace WestWorldWithMessaging
{

    public class EatStew : IState<Miner>
    {
        private static EatStew _instance;
        private static readonly object padlock = new();

        public static EatStew Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new EatStew();
                    }
                    return _instance;
                }
            }
        }

        public void Enter(Miner miner)
        {
            miner.Speak("Smells Reaaal goood Elsa!");
        }

        public void Execute(Miner miner)
        {
            miner.Speak("Taste real good too!");
            miner.StateMachine.RevertToPreviousState();
        }

        public void Exit(Miner miner)
        {
            miner.Speak("Thankya li'lle lady. Ah better get back to whatever ah wuz doin'");
        }
    }
}