namespace ObjectsStorage
{
    public abstract class StorageObject<TData>
    {
        public abstract string Key { get; }

        public TData Data { get; set; }
        
        public abstract TData GetDefaultData();
    }
}