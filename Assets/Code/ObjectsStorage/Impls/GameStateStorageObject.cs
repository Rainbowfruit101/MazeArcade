using System;
using Models;
using Newtonsoft.Json;

namespace ObjectsStorage.Impls
{
    public class GameStateStorageObject : StorageObject<GameStateStorageObject.GameState>
    {
        public override string Key => "GameState";

        [Serializable]
        public class GameState
        {
            [JsonProperty] public bool IsCurrentLevelStarted { get; set; }
            [JsonProperty] public MazeModel MazeModel { get; set; }
            [JsonProperty] public CoinModel[] CoinModels { get; set; }
            [JsonProperty] public PlayerModel PlayerModel { get; set; }
        }

        public override GameState GetDefaultData() => new GameState()
        {
            
        };
    }
}