namespace WestWorldWithMessaging
{
    public abstract class BaseGameEntity
    {
        protected BaseGameEntity(EntityName name)
        {
            Name = name;
        }

        public EntityName Name { get; }

        public virtual bool HandleMessage(Telegram telegram) { return false;  }
    }
}