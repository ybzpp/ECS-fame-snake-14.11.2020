using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class ViewSystem : IEcsRunSystem
    {
        private EcsFilter<ViewComponent, PositionComponent>.Exclude<AppleComponent> _filter = null;
        private EcsWorld _world = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var prefab = ref _filter.Get1(index).Prefab;
                ref var position = ref _filter.Get2(index).Position;

                Object.Instantiate(prefab, position, Quaternion.identity);
            }
        
        }
    }
}

