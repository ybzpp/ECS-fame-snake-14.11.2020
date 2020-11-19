using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class AppleSystem : IEcsRunSystem
    {
        private EcsFilter<AppleComponent, PositionComponent> _filterPosition = null;
        private LevelProgress _levelProgress = null;
        private SceneData _sceneData = null;
        private EcsWorld _world = null;

        public void Run()
        {
            var gridSize = _sceneData.GridSize;
            var position = new Vector3(Random.Range((gridSize / 2) * (-1), gridSize / 2), _sceneData.SpawnPoint.position.y, Random.Range((gridSize / 2) * (-1), gridSize / 2));

            if (_levelProgress.AppleToLevel < _sceneData.AppleToLevelMax)
            {
                var appleEntity = _world.NewEntity();
                appleEntity.Get<AppleComponent>().Prefab = Object.Instantiate(_sceneData.Apple, position, Quaternion.identity);
                appleEntity.Get<PositionComponent>().Position = position;
                _levelProgress.AppleToLevel++;
            }

            foreach (var index in _filterPosition)
            {
                var prefab = _filterPosition.Get1(index).Prefab;

                if (prefab != null)
                {
                    var apple = prefab.GetComponent<Apple>();
                    if (apple.isTrigger)
                    {
                        //appleDad delete
                        Object.Destroy(prefab);
                        _filterPosition.GetEntity(index).Del<AppleComponent>();
                        _filterPosition.GetEntity(index).Destroy();
                        _levelProgress.AppleToLevel--;
                        _levelProgress.Apple++;
                        _levelProgress.Score++;
                        _sceneData.TailLength++;
                        _sceneData.Speed++;
                    }
                }
            }

            
        }

    }
}