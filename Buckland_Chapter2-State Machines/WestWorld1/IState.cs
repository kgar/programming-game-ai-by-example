namespace WestWorld1
{
    public interface IState {
        void Enter(Miner miner) {}
        void Execute(Miner miner) {}
        void Exit(Miner miner) {}
    }
}