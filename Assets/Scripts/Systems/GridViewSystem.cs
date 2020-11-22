using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class GridViewSystem : IEcsInitSystem , IEcsRunSystem
    {
        private EcsWorld _world = null;
        private SceneData _sceneData = null;
        private EcsFilter<GridViewComponent, PositionComponent, FloorComponent> _filterFloor = null;
        private EcsFilter<GridViewComponent, PositionComponent, WallCompanent> _filterWall = null;

        public void Init()
        {
            foreach (var index in _filterFloor)
            {
                _filterFloor.Get1(index).Prefab = Object.Instantiate(_sceneData.GridPrefabBlack, _filterFloor.Get2(index).Position, Quaternion.identity, _sceneData.ParentSceneObjects);


                ref var position = ref _filterFloor.Get2(index).Position;

                if (position.x % 2 == 0 && position.z % 2 == 0 || position.x % 2 == 1 && position.z % 2 == 1)
                {
                    _filterFloor.GetEntity(index).Get<ColorAComponent>();
                }
                else
                {
                    _filterFloor.GetEntity(index).Get<ColorBComponent>();
                }
                _filterFloor.GetEntity(index).Get<ColorUpdateComponent>();
            }

            foreach (var index in _filterWall)
            {
                _filterWall.Get1(index).Prefab = Object.Instantiate(_sceneData.GridEndPrefab, _filterWall.Get2(index).Position, Quaternion.identity, _sceneData.ParentSceneObjects);
                _filterWall.GetEntity(index).Get<ColorWallComponent>();
                _filterWall.GetEntity(index).Get<ColorUpdateComponent>();
            }
        }
        public void Run()
        {
            
        }
    }
}