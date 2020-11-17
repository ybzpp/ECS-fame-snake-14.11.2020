using Leopotam.Ecs;

namespace Client
{
    sealed class BoostSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private Configuration _configuration = null;
        private LevelProgress _levelProgress = null;

        public void Run()
        {
        }

    }



}