using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class WinSystem : IEcsRunSystem
    {
        private EcsFilter<SnakeViewComponent> _filterSnake = null;
        private EcsFilter<TailComponent> _filterTail = null;
        private LevelProgress _levelProgress = null;
        private EcsWorld _world = null;
        private Vector3 _snakePosition;

        public void Run()
        {
        }
    }
}