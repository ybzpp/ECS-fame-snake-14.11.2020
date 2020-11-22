using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class GameOverSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<SnakeViewComponent> _filterSnake = null;
        private LevelProgress _levelProgress = null;
        private Vector3 _snakePosition;
        public void Run()
        {
            foreach (var index in _filterSnake)
            {
                var positionSnakeHead = _filterSnake.Get1(index).Prefab.transform.position;
                _snakePosition = positionSnakeHead;
            }

            foreach (var index in _levelProgress.TailsColections)
            {
                var tailPosition = index.transform.position;

                if (_snakePosition == tailPosition)
                {
                    _levelProgress.GameState = GameState.GameOver;
                }
            }
        }
    }
}