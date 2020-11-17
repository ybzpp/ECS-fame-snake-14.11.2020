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
                ref var prefab = ref _filter.Get1(index).Prefab;
                ref var entity = ref _filter.Get1(index).Entity;

                ref var position = ref _filter.Get2(index).Position;
                ref var rotation = ref _filter.Get2(index).Rotation;

                var spawnPosition = _sceneData.SpawnPoint.position;

                var player = Object.Instantiate(_sceneData.PlayerPrefab, spawnPosition, Quaternion.identity);

                prefab = player;
                entity = _filter.GetEntity(index);
                position = player.transform;
                rotation = player.transform;



            }
        }

    }
}