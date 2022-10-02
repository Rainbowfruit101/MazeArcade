using System;
using Models;
using Newtonsoft.Json;
using ObjectsStorage;

namespace ScenesLoader
{
    public class GameStateStorageObject : StorageObject<GameStateStorageObject.GameState>
    {
        public override string Key => "GameState";

        [Serializable]
        public class GameState
        {
            [JsonProperty] public MazeModel MazeModel { get; set; }
            [JsonProperty] public CoinModel[] CoinModels { get; set; }
            [JsonProperty] public PlayerModel PlayerModel { get; set; }
        }

        public override GameState GetDefaultData() => new GameState()
        {
            MazeModel = null,
            CoinModels = null,
            PlayerModel = null
        };
    }
}