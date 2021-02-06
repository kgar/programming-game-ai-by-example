using System;

namespace WestWorldWithWoman
{
    public interface IState<TEntity> where TEntity : BaseGameEntity
    {
        void Enter(TEntity miner) { }
        void Execute(TEntity miner) { }
        void Exit(TEntity miner) { }
    }
}