using System;

namespace WestWorldWithMessaging
{
    public class GoHomeAndSleepTilRested : IState<Miner>
    {
        private static GoHomeAndSleepTilRested _instance;
        private static readonly object padlock = new();

        public static GoHomeAndSleepTilRested Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new GoHomeAndSleepTilRested();
                    }
                    return _instance;
                }
            }
        }

        public void Enter(Miner entity)
        {
            if (entity.Location != Location.Shack)
            {
                entity.Speak("Walkin' home");
                entity.ChangeLocation(Location.Shack);

                MessageDispatcher.DispatchMessage(
                    MessageDispatcherConstants.SendNow,
                    entity.Name,
                    EntityName.Elsa,
                    MessageType.HiHoneyImHome);
            }
        }

        public void Execute(Miner entity)
        {
            if (!entity.Fatigued())
            {
                entity.Speak("What a God darn fantastic nap! Time to find more gold");
                entity.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else
            {
                entity.DecreaseFatigue();
                entity.Speak("ZZZZ... ");
            }
        }

        public void Exit(Miner entity)
        {
            entity.Speak("Leaving the house");
        }

        public bool OnMessage(Miner miner, Telegram message)
        {
            if (message.Message == MessageType.StewReady)
            {
                Console.WriteLine($"Message handled by {EntityFunctions.GetNameOfEntity(miner.Name)} at time: {DateTime.Now}");
                miner.Speak("Okay Hun, ahm a comin'!");
                miner.StateMachine.ChangeState(EatStew.Instance);
                return true;
            }

            return false;
        }
    }
}