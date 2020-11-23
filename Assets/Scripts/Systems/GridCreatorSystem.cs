using Leopotam.Ecs;

namespace Client
{
    sealed class GridCreatorSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter <GridCreateEvent> _filter = null;
        private Configuration _configuration = null;
        private LevelProgress _levelProgress = null;

        public void Run()
        {
            //if (_levelProgress.Score%10 == 0)
            //{
            //    _world.NewEntity().Get<GridCreateEvent>();
            //}

            //var gridSize = _configuration.GridSize;

            //foreach (var index in _filter)
            //{
                
            //}
        }
    }
}
