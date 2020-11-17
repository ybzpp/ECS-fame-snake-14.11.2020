using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class GridViewPrefabSystem : IEcsInitSystem
    {
        private EcsFilter<GridViewComponent,PositionComponent> _filter;
        private EcsWorld _world;
        private SceneData _sceneData;

        public void Init()
        {
            foreach (var index in _filter)
            {

            }
        }
    }
}