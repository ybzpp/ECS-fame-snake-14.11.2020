using UnityEngine;
using Leopotam.Ecs;

namespace Client
{
    sealed class SnakeTailSystem : IEcsRunSystem
    {
        private EcsFilter<SnakeTailComponent, SnakeViewComponent> _filter = null;
        private EcsWorld _world = null;
        private Configuration _configuration = null;
        private SceneData _sceneData = null;

        private float _timeNextUpdate;
        private float _timeUpdate;
        private Vector3 _position = new Vector3(0f, 0f, 0f);
        private int _tailNumber = 1;


        public void Run () 
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
                if (_position != new Vector3(0f,0f,0f))
                {
                    var prefab = _sceneData.TailPrefab;

                    var tail = _world.NewEntity();
                    
                    tail.Get<TailComponent>().Prefab = Object.Instantiate(prefab, _position, Quaternion.identity);
                    tail.Get<TailComponent>().Number = _tailNumber;
                    tail.Get<ColorComponent>();
                    _tailNumber++;
                }

                _position = _filter.Get2(index).Prefab.transform.position;
            }
        }
    }
}