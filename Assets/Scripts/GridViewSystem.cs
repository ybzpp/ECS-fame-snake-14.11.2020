using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class GridViewSystem : IEcsInitSystem
    {
        private EcsFilter<GridViewComponent, PositionComponent, ColorComponent> _filter = null;
        private EcsWorld _world = null;
        private SceneData _sceneData = null;

        public void Init()
        {
            foreach (var index in _filter)
            {
                ref var x = ref _filter.Get2(index).Position.x;
                ref var z = ref _filter.Get2(index).Position.z;
                ref var prefab = ref _filter.Get1(index).Prefab;
                ref var gridState = ref _filter.Get3(index).GridState;
                var gridSize = _sceneData.GridSize;

                if (x == gridSize/2 || z == gridSize / 2 || x == ((gridSize / 2) + 1) * (-1) || z == ((gridSize / 2) + 1) * (-1))
                {
                    ref var position = ref _filter.Get2(index).Position;
                    var gridView = Object.Instantiate(_sceneData.GridEndPrefab, _sceneData.ParentSceneObjects);
                    gridView.transform.position = position;
                    prefab = gridView;
                    gridState = GridState.Wall;
                }

                else if(x != 0 && x % 2 == 0 && z != 0 && (z + 1) % 2 == 0 || x == 0 && z != 0 && (z + 1) % 2 == 0 || z != 0 && (x + 1) % 2 == 0 && z % 2 == 0 || z == 0 && x > 0 && (x + 1) % 2 == 0 || z == 0 && x < 0 && (x - 1) % 2 == 0)
                {
                    ref var position = ref _filter.Get2(index).Position;
                    var gridView = Object.Instantiate(_sceneData.GridPrefabBlack, _sceneData.ParentSceneObjects);
                    gridView.transform.position = position;
                    prefab = gridView;
                    gridState = GridState.GridA;
                }
                else
                {
                    ref var position = ref _filter.Get2(index).Position;
                    var gridView = Object.Instantiate(_sceneData.GridPrefabGray, _sceneData.ParentSceneObjects);
                    gridView.transform.position = position;
                    prefab = gridView;
                    gridState = GridState.GridB;
                }
                
                
            }
        }
    }
}