namespace WestWorld1
{
    public class BaseGameEntity
    {
        public BaseGameEntity(EntityName name)
        {
            Name = name;
        }

        public EntityName Name { get; }
    }
}