using System;

namespace WestWorldWithMessaging
{
    public class StateMachine<TEntity> where TEntity : BaseGameEntity
    {
        public IState<TEntity> CurrentState { get; set; }
        public IState<TEntity> PreviousState { get; set; }
        public IState<TEntity> GlobalState { get; set; }

        private readonly TEntity _owner;

        public StateMachine(TEntity owner)
        {
            _owner = owner;
        }

        public void Update()
        {
            GlobalState?.Execute(_owner);
            CurrentState?.Execute(_owner);
        }

        public bool IsInState(IState<TEntity> state) => CurrentState == state;

        public void RevertToPreviousState()
        {
            ChangeState(PreviousState);
        }

        public void ChangeState(IState<TEntity> newState)
        {
            PreviousState = CurrentState;

            CurrentState?.Exit(_owner);

            CurrentState = newState ?? throw new ArgumentNullException(nameof(newState));

            CurrentState.Enter(_owner);
        }
    }
}