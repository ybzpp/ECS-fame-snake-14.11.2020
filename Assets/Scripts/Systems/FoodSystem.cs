using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class FoodSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent> _filter = null;
        private EcsFilter<FoodComponent, PositionComponent> _filterFood = null;
        private LevelProgress _levelProgress = null;
        private SceneData _sceneData = null;
        private EcsWorld _world = null;
        private bool _busy;

        public void Run()
        {
            //create food
            var gridSize = _sceneData.GridSize - 1;
            var randomPosition = new Vector3(Mathf.Round(Random.Range(0f, gridSize)), 0f, Mathf.Round(Random.Range(0f, gridSize)));


            _busy = false;
            foreach (var item in _levelProgress.FoodsColections)
            {
                if (item.transform.position == randomPosition)
                {
                    _busy = true;
                }
            }
            foreach (var item in _levelProgress.TailsColections)
            {
                if (item.transform.position == randomPosition)
                {
                    _busy = true;
                }
            }

            if (_levelProgress.FoodToLevel < _sceneData.FoodToLevelMax)
            {
                if (!_busy)
                {
                    var appleEntity = _world.NewEntity();
                    appleEntity.Get<FoodComponent>().Prefab = Object.Instantiate(_sceneData.Food, randomPosition, Quaternion.identity);
                    appleEntity.Get<PositionComponent>().Position = randomPosition;
                    _levelProgress.FoodToLevel++;
                }
            }


            //destroy food
            foreach (var index in _filterFood)
            {
                var prefab = _filterFood.Get1(index).Prefab;

                if (prefab != null)
                {
                    if (prefab.GetComponent<Food>().isTrigger)
                    {
                        Object.Destroy(prefab);
                        _filterFood.GetEntity(index).Destroy();
                        _levelProgress.FoodToLevel--;

                        _world.NewEntity().Get<LevelProgressEvent>();
                    }
                }
            }
        }
    }
}