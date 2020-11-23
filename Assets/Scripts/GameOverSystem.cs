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
                _snakePosition = _filterSnake.Get1(index).Prefab.transform.position;
            }

            foreach (var index in _levelProgress.TailsColections)
            {
                if (_snakePosition == index.transform.position)
                {
                    _levelProgress.GameState = GameState.GameOver;
                }
            }
        }
    }
}