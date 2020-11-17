using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

namespace Client
{
    sealed class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent, InputComponent> _filter = null;
        private EcsWorld _world = null;
        private Configuration _configuration = null;
        private SceneData _sceneData;
        private float _timeNextUpdate;
        private float _timeUpdate;

        void IEcsRunSystem.Run()
        {

            //timer вынести в отдельный компонент для (MoveSystem,SnakeTailSystem) 
            var speed = _sceneData.Speed;

            if (speed < 10)
            {
                if (Time.time < _timeNextUpdate)
                {
                    return;
                }

                _timeUpdate = _configuration.Time / 0.1f;
                _timeNextUpdate = Time.time + _timeUpdate;
            }
            else
            {
                if (Time.time < _timeNextUpdate)
                {
                    return;
                }

                _timeUpdate = _configuration.Time / (_sceneData.Speed / 100);
                _timeNextUpdate = Time.time + _timeUpdate;


            }

            foreach (var index in _filter)
            {
                var step = _configuration.Step;
                var moveState = _filter.Get2(index).MoveState;
                ref var position = ref _filter.Get1(index).Position;
                ref var rotation = ref _filter.Get1(index).Rotation;
                ref var direction = ref _filter.Get1(index).Direction;
                var gridSize = _sceneData.GridSize / 2;

                switch (moveState)
                {
                    case MoveState.Up:
                        rotation.rotation = Quaternion.Euler(0f, 0f, 0f);
                        direction = new Vector2(0, step);
                        break;
                    case MoveState.Down:

                        rotation.rotation = Quaternion.Euler(0f, 180f, 0f);
                        direction = new Vector2(0, step * (-1));
                        break;
                    case MoveState.Left:

                        rotation.rotation = Quaternion.Euler(0f, -90f, 0f);
                        direction = new Vector2(step * (-1), 0);
                        break;
                    case MoveState.Right:

                        rotation.rotation = Quaternion.Euler(0f, 90f, 0f);
                        direction = new Vector2(step, 0);
                        break;
                }

                position.position = new Vector3(position.position.x + direction.x, position.position.y, position.position.z + direction.y);

                if      (position.position.x == (gridSize * step))
                {
                    position.position = new Vector3((gridSize * step * (-1)), position.position.y, position.position.z); 
                }

                else if (position.position.z == (gridSize * step))
                {
                    position.position = new Vector3(position.position.x, position.position.y, (gridSize * step * (-1)));
                }

                else if (position.position.x == ((gridSize * step) * (-1)) - 1)
                {
                    position.position = new Vector3(((gridSize * step) - 1) , position.position.y, position.position.z);
                }
                else if (position.position.z == ((gridSize * step) * (-1)) - 1)
                {
                    position.position = new Vector3(position.position.x, position.position.y, ((gridSize * step) - 1));
                }
                               
            }
        }

    }
}