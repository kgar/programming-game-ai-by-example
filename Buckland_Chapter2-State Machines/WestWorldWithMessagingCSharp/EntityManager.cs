using System.Collections.Generic;
using System.Data;

namespace WestWorldWithMessaging
{
    public static class EntityManager
    {
        private static readonly Dictionary<EntityName, BaseGameEntity> EntityDictionary = new();

        public static TEntity RegisterEntity<TEntity>(TEntity entity) where TEntity : BaseGameEntity
        {
            EntityDictionary[entity.Name] = entity;
            return entity;
        }

        public static BaseGameEntity GetEntityFromName(EntityName name)
        {
            return EntityDictionary.TryGetValue(name, out var entity)
                ? entity
                : throw new DataException("Entity not found. All entities must be registered.");
        }
    }
}