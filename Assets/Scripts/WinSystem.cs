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

            foreach (var index in _filterSnake)
            {
                var positionSnakeHead = _filterSnake.Get1(index).Prefab.transform.position;
                _snakePosition = positionSnakeHead;
            }

            foreach (var index in _filterTail)
            {
                var tailPosition = _filterTail.Get1(index).Prefab.transform.position;

                if (_snakePosition == tailPosition)
                {
                    _levelProgress.GameState = GameState.GameOver;
                }
            }
        }
    }
}