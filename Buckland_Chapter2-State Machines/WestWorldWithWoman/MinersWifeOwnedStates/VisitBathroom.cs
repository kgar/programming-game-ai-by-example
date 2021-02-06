namespace WestWorldWithWoman
{
    public class VisitBathroom : IState<MinersWife>
    {
        private static VisitBathroom _instance;
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

        public void Enter(MinersWife entity)
        {
            entity.Speak("Walkin' to the can. Need to powda mah pretty li'lle nose");
        }

        public void Execute(MinersWife entity)
        {
            entity.Speak("Ahhhhhh! Sweet relief!");
            entity.StateMachine.RevertToPreviousState();
        }

        public void Exit(MinersWife entity)
        {
            entity.Speak("Leavin' the Jon");
        }
    }
}