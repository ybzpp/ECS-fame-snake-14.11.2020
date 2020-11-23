using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class GameInitSystem : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private Configuration _configuration = null;
        private SceneData _sceneData = null;
        private LevelProgress _levelProgress = null;
        private UIData _uiData = null;

        public void Init()
        {
            //player init
            var playerEntity = _world.NewEntity();
            playerEntity.Get<InputComponent>();
            playerEntity.Get<MoveComponent>();
            playerEntity.Get<SnakeViewComponent>();
            playerEntity.Get<CameraFollowComponent>();

            //grid init
            var gridSize = _configuration.GridSize;

            for (int x = -1; x < gridSize +1; x++)
            {
                for (int z = -1; z < gridSize + 1; z++)
                {
                    var wallEntity = _world.NewEntity();
                    wallEntity.Get<PositionComponent>().Position = new Vector3(x, -0.5f, z);
                    wallEntity.Get<GridViewComponent>();
                    if (x >= 0 && x < gridSize && z >= 0 && z < gridSize)
                    {
                        wallEntity.Get<FloorComponent>();
                    }
                    else
                    {
                        wallEntity.Get<WallCompanent>();
                    } 
                }
            }

            //data init

            _sceneData.GridSize = _configuration.GridSize;
            _sceneData.TailLength = _configuration.TailLength;
            _sceneData.FoodToLevelMax = _configuration.AppleToLevelMax;
            _sceneData.CurrentColorPalette = _sceneData.LevelPresets[0].ColorPalette;

            var randomFood = Random.Range(0, _sceneData.FoodPrefabs.Count);
            _sceneData.Food = _sceneData.FoodPrefabs[randomFood];

            _uiData.SpeedSlider.minValue = _configuration.MinSpeed;
            _uiData.SpeedSlider.maxValue = _configuration.MaxSpeed;
            _uiData.SpeedSlider.value = _sceneData.Speed;

            _sceneData.CameraGrid.orthographic = true;
            _sceneData.CameraGrid.orthographicSize = _sceneData.GridSize + _sceneData.CameraGridOffset;
            _sceneData.CameraGrid.transform.position = new Vector3(_sceneData.GridSize / 2, _sceneData.GridSize, _sceneData.GridSize / 2);

            _levelProgress.GameState = GameState.Menu;
        }
    }
}
