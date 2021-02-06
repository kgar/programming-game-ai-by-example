namespace WestWorldWithWoman
{
    public interface IStateOld {
        void Enter(Miner miner) {}
        void Execute(Miner miner) {}
        void Exit(Miner miner) {}
    }
}