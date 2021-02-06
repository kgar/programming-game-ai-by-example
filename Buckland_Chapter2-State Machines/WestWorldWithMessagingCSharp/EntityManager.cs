using System;

namespace WestWorldWithMessaging
{
    internal static class EntityManager
    {
        internal static TEntity RegisterEntity<TEntity>(TEntity entity) where TEntity : BaseGameEntity
        {
            // TODO: Add to manager
            return entity;
        }
    }
}