using UnityEngine;
using Leopotam.Ecs;

namespace Client
{
    sealed class TailSystem : IEcsRunSystem
    {
        private EcsFilter<TailComponent> _filter = null;
        private EcsWorld _world = null;
        private SceneData _sceneData;
        private int _number = 1;

        public void Run()
        {

            //foreach (var index in _filter)
            //{
            //    if (_number< _filter.Get1(index).Number)
            //    {
            //        _number = _filter.Get1(index).Number;
            //    }
            //}

            //foreach (var index in _filter)
            //{
            //    ref var prefab = ref _filter.Get1(index).Prefab;
            //    ref var number = ref _filter.Get1(index).Number;
            //    if (number < _number + 1 - _sceneData.TailLength)
            //    {
            //        Object.Destroy(prefab);
            //        _filter.GetEntity(index).Destroy();
            //    }
            //}
        }
    }
}