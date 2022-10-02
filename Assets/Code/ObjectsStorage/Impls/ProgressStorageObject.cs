using System;
using Newtonsoft.Json;

namespace ObjectsStorage.Impls
{
    public class ProgressStorageObject: StorageObject<ProgressStorageObject.Progress>
    {
        public override string Key => "Progress";
        
        [Serializable]
        public class Progress
        {
            [JsonProperty]
            public int TotalCollectedCoins { get; set; }
            [JsonProperty]
            public int TotalCompletedLevels { get; set; }
        }

        public override Progress GetDefaultData() => new Progress()
        {
            TotalCollectedCoins = 0,
            TotalCompletedLevels = 0
        };
    }
}