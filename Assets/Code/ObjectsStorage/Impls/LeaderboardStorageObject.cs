using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ObjectsStorage.Impls
{
    public class LeaderboardStorageObject: StorageObject<LeaderboardStorageObject.Leaderboard>
    {
        public override string Key => "Leaderboard";
        
        [Serializable]
        public class Leaderboard
        {
            [JsonProperty]
            public List<LeaderboardRecord> Records { get; set; }
        }
        
        [Serializable]
        public class LeaderboardRecord
        {
            [JsonProperty]
            public string Name { get; set; }
            [JsonProperty]
            public int Coins { get; set; }
            [JsonProperty]
            public int Time { get; set; }
        }

        public override Leaderboard GetDefaultData() => new Leaderboard()
        {
            Records = new List<LeaderboardRecord>()
        };
    }
}