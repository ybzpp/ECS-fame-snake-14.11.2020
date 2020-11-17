using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class GameInitSystem : IEcsInitSystem 
    {
        private EcsWorld _world = null;
        private Configuration _configuration = null;
        private SceneData _sceneData = null;

        public void Init () 
        {
            //config
            _sceneData.GridSize = _configuration.GridSize;
            _sceneData.TailLength = _configuration.TailLength;
            _sceneData.AppleToLevelMax = _configuration.AppleToLevelMax;
            _sceneData.Speed = _configuration.Speed;

            //player init
            var playerEntity = _world.NewEntity();
            playerEntity.Get<InputComponent>();
            playerEntity.Get<MoveComponent>();
            playerEntity.Get<SnakeViewComponent>();
            playerEntity.Get<SnakeTailComponent>();

            //grid init
            var gridSize = _configuration.GridSize;
            var step = _configuration.Step;

            for (int x = 0 - (gridSize / 2) - 1 ; x < (gridSize / 2) + 1; x++)
            {
                for (int z = 0 - (gridSize / 2) - 1; z < (gridSize / 2) + 1; z++)
                {
                    var gridEntity = _world.NewEntity();
                    gridEntity.Get<PositionComponent>().Position = new Vector3(x * step, 0f, z * step);
                    gridEntity.Get<GridViewComponent>();
                    gridEntity.Get<ColorComponent>();
                }
            }

        }
    }
}