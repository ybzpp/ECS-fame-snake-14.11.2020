using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class SnakeViewSystem : IEcsInitSystem
    {
        private EcsFilter<SnakeViewComponent, MoveComponent> _filter;
        private EcsWorld _world;
        private SceneData _sceneData;

        public void Init()
        {
            foreach (var index in _filter)
            {
                var gridSize = _sceneData.GridSize;
                if (gridSize % 2 == 1)
                {
                    gridSize -= 1;
                }

                ref var prefab = ref _filter.Get1(index).Prefab;
                ref var transform = ref _filter.Get2(index).Transform;

                var spawnPosition = new Vector3(gridSize / 2, 0f, (gridSize / 2) - 1); // -1 тут потому что змейка в самом начале успевает сделать шаг

                prefab = Object.Instantiate(_sceneData.PlayerPrefab, spawnPosition, Quaternion.identity);
                transform = prefab.transform;
            }
        }
    }
}