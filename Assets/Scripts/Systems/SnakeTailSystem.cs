using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace Client
{
    sealed class SnakeTailSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private SceneData _sceneData = null;
        private EcsFilter<TailComponent> _filter = null;
        private LevelProgress _levelProgress = null;

        public void Run () 
        {
            foreach (var index in _filter)
            {
                _levelProgress.TailsColections.Add(Object.Instantiate(_sceneData.TailPrefab, _filter.Get1(index).Position, Quaternion.identity));
            }
            Debug.Log(_levelProgress.TailsColections.Count);
            if (_levelProgress.TailsColections.Count > _sceneData.TailLength)
            {
                Object.Destroy(_levelProgress.TailsColections[0]);
                _levelProgress.TailsColections.RemoveAt(0);
            }
        }
    }
}