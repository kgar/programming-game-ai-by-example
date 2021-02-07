using System;

namespace WestWorldWithMessaging
{
    public class MinersWife : BaseGameEntity
    {
        public StateMachine<MinersWife> StateMachine { get; set; }
        public Location Location { get; set; }

        public MinersWife(EntityName name) : base(name)
        {
            StateMachine = new StateMachine<MinersWife>(this)
            {
                CurrentState = DoHouseWork.Instance,
                GlobalState = WifesGlobalState.Instance
            };
        }

        public void Update()
        {
            StateMachine.Update();
        }

        public void Speak(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{EntityFunctions.GetNameOfEntity(Name)}: {text}");
            Console.ResetColor();
        }

        public override bool HandleMessage(Telegram telegram)
        {
            return StateMachine.HandleMessage(telegram);
        }
    }
}