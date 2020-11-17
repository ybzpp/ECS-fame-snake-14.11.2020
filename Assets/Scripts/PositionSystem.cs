using Leopotam.Ecs;

namespace Client {
    sealed class PositionSystem : IEcsRunSystem 
    {
        private EcsFilter<PositionComponent> _filter;
        private EcsWorld _world = null;

        public void Run () 
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get1(index).Position;
            }
        }
    }
}