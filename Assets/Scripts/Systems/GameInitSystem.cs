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
            //for (int x = 0; x < gridSize; x++)
            //{
            //    for (int z = 0; z < gridSize; z++)
            //    {
            //        var gridEntity = _world.NewEntity();
            //        gridEntity.Get<PositionComponent>().Position = new Vector3(x, -0.5f, z);
            //        gridEntity.Get<GridViewComponent>();
            //        gridEntity.Get<FloorComponent>();
            //    }
            //}

            for (int x = -gridSize; x < gridSize * 2; x++)
            {
                for (int z = -gridSize; z < gridSize * 2; z++)
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
            _sceneData.CameraGrid.transform.position = new Vector3(_sceneData.GridSize / 2, _sceneData.GridSize * 3, _sceneData.GridSize / 2);
            _sceneData.CurrentColorPalette = _sceneData.LevelPresets[0].ColorPalette;

            var randomFood = Random.Range(0, _sceneData.FoodPrefabs.Count);
            _sceneData.Food = _sceneData.FoodPrefabs[randomFood];

            _uiData.SpeedSlider.minValue = _configuration.MinSpeed;
            _uiData.SpeedSlider.maxValue = _configuration.MaxSpeed;
            _uiData.SpeedSlider.value = _sceneData.Speed;

            _levelProgress.GameState = GameState.Menu;
        }
    }
    sealed class GridCreatorSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter <GridCreateEvent> _filter = null;
        private Configuration _configuration = null;
        private LevelProgress _levelProgress = null;

        public void Run()
        {
            if (_levelProgress.Score%10 == 0)
            {
                _world.NewEntity().Get<GridCreateEvent>();
            }

            var gridSize = _configuration.GridSize;

            foreach (var index in _filter)
            {
                
            }
        }
    }
}
