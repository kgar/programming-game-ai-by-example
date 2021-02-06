using System;

namespace WestWorldWithWoman
{

    public class VisitBathroom : IState<MinersWife>
    {
        private static VisitBathroom _instance = null;
        private static readonly object padlock = new();

        public static VisitBathroom Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new();
                    }
                    return _instance;
                }
            }
        }

        public void Enter(MinersWife wife)
        {
            wife.Speak("Walkin' to the can. Need to powda mah pretty li'lle nose");
        }

        public void Execute(MinersWife wife)
        {
            wife.Speak("Ahhhhhh! Sweet relief!");
            wife.StateMachine.RevertToPreviousState();
        }

        public void Exit(MinersWife wife)
        {
            wife.Speak("Leavin' the Jon");
        }
    }
}