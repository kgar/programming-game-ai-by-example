using System;

namespace WestWorldWithWoman
{
    public class MinersWife : BaseGameEntity
    {
        public StateMachine<MinersWife> StateMachine { get; set; }
        public Location Location { get; set; } = Location.Shack;

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

        internal void Speak(string text)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine($"{EntityFunctions.GetNameOfEntity(Name)}: {text}");
        }
    }
}