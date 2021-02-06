namespace WestWorldWithWoman
{
    public interface IState<TEntity> where TEntity : BaseGameEntity
    {
        void Enter(TEntity entity) { }
        void Execute(TEntity entity) { }
        void Exit(TEntity entity) { }
    }
}