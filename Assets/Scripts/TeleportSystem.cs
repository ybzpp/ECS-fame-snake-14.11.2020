using Leopotam.Ecs;

namespace Client
{
    sealed class TeleportSystem : IEcsRunSystem
    {
        private EcsFilter<PositionComponent, TeleportComponent> _filter = null;
        private EcsWorld _world = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var sourcePosition = ref _filter.Get1(index).Position;
                ref var teleportPosition = ref _filter.Get2(index).Position;

                sourcePosition = teleportPosition;
            }
        }

    }



}