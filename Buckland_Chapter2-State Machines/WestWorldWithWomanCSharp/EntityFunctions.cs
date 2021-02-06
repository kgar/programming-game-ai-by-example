namespace WestWorldWithWoman
{
    public static class EntityFunctions
    {
        public static string GetNameOfEntity(EntityName name)
        {
            return name switch
            {
                EntityName.MinerBob => "Miner Bob",
                EntityName.Elsa => "Elsa",
                _ => "UNKNOWN"
            };
        }
    }
}