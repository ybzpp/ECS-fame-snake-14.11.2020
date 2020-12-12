using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

namespace Client
{
    sealed class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent, InputComponent, SnakeViewComponent> _filter = null;
        private EcsWorld _world = null;
        private Configuration _configuration = null;
        private SceneData _sceneData;
        private float _timeNextUpdate;
        private float _timeUpdate;
        private LevelProgress _levelProgress = null;

        void IEcsRunSystem.Run()
        {
            //timer вынести в отдельный компонент для (MoveSystem,SnakeTailSystem) 

            if (Time.time < _timeNextUpdate)
            {
                return;
            }
            _timeNextUpdate = Time.time + _configuration.Time / (_sceneData.Speed / 100);

            //движение и поворот змейки
            foreach (var index in _filter)
            {
                //добавление хвоста
                var tail = _world.NewEntity();
                tail.Get<TailComponent>().Position = _filter.Get3(index).Prefab.transform.position;

                var step = _configuration.Step;
                var moveState = _sceneData.MoveState;

                ref var transform = ref _filter.Get1(index).Transform;
                ref var direction = ref _filter.Get1(index).Direction;

                switch (moveState)
                {
                    case MoveState.Up:
                        if (transform.rotation != Quaternion.Euler(0f, 180f, 0f) || _levelProgress.GameState == GameState.Menu)
                        {
                            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            direction = new Vector2(0, step);
                        }
                        break;
                    case MoveState.Down:
                        if (transform.rotation != Quaternion.Euler(0f, 0f, 0f) && _levelProgress.GameState != GameState.Menu)
                        {
                            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                            direction = new Vector2(0, step * (-1));
                        }

                        break;
                    case MoveState.Left:
                        if (transform.rotation != Quaternion.Euler(0f, 90f, 0f) || _levelProgress.GameState == GameState.Menu)
                        {
                            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                            direction = new Vector2(step * (-1), 0);
                        }
                        break;
                    case MoveState.Right:

                        if (transform.rotation != Quaternion.Euler(0f, -90f, 0f) || _levelProgress.GameState == GameState.Menu)
                        {
                            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                            direction = new Vector2(step, 0);
                        }
                        break;
                }

                transform.position = new Vector3(transform.position.x + direction.x, transform.position.y, transform.position.z + direction.y);

                // телепорт если вышел за границы
                var gridSize = _configuration.GridSize;

                if (transform.position.x == gridSize)
                {
                    transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                }

                else if (transform.position.z == gridSize)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                }

                else if (transform.position.x == -1f)
                {
                    transform.position = new Vector3(gridSize - 1f, transform.position.y, transform.position.z);
                }

                else if (transform.position.z == -1f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, gridSize - 1f);
                }
            }
        }
    }
    sealed class MoveSmootheeSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent, InputComponent, SnakeViewComponent> _filter = null;
        private EcsWorld _world = null;
        private Configuration _configuration = null;
        private SceneData _sceneData;
        private float _timeNextUpdate;
        private float _timeUpdate;
        private LevelProgress _levelProgress = null;

        void IEcsRunSystem.Run()
        {
            foreach (var index in _filter)
            {
                var step = _configuration.Step;
                var moveState = _sceneData.MoveState;

                ref var transform = ref _filter.Get1(index).Transform;
                ref var direction = ref _filter.Get1(index).Direction;

                switch (moveState)
                {
                    case MoveState.Up:
                        break;
                    case MoveState.Down:
                        break;
                    case MoveState.Left:
                        break;
                    case MoveState.Right:
                        break;
                }
            }
        }
    }
}