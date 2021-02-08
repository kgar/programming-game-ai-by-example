using System;

namespace WestWorldWithMessaging
{
    public class CookStew : IState<MinersWife>
    {
        private static CookStew _instance;
        private static readonly object padlock = new();

        public static CookStew Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new CookStew();
                    }
                    return _instance;
                }
            }
        }

        public void Enter(MinersWife wife)
        {
            if (!wife.IsCooking)
            {
                wife.Speak("Putting the stew in the oven");
                MessageDispatcher.DispatchMessage(TimeSpan.FromSeconds(1.5), wife.Name, wife.Name, MessageType.StewReady);
                wife.IsCooking = true;
            }
        }
        public void Execute(MinersWife wife)
        {
            wife.Speak("Fussin' over food");
        }
        public void Exit(MinersWife wife)
        {
            wife.Speak("Puttin' the stew on the table");
        }
        public bool OnMessage(MinersWife wife, Telegram telegram)
        {
            if (telegram.Message == MessageType.StewReady)
            {
                System.Console.WriteLine($"Message received by {EntityFunctions.GetNameOfEntity(wife.Name)} at time {DateTime.Now}");
                wife.Speak("Stew ready! Let's eat");
                MessageDispatcher.DispatchMessage(MessageDispatcherConstants.SendNow, wife.Name, EntityName.MinerBob, MessageType.StewReady);
                wife.IsCooking = false;
                wife.StateMachine.ChangeState(DoHouseWork.Instance);
                return true;
            }

            return false;
        }
    }
}