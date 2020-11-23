using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class RotateCameraSystem : IEcsRunSystem
    {
        private EcsFilter<SnakeViewComponent> _filter = null;
        private EcsWorld _world = null;
        private SceneData _sceneData;

        void IEcsRunSystem.Run()
        {
            foreach (var index in _filter)
            {
                _sceneData.CameraPlayer.transform.rotation = Quaternion.LookRotation(_filter.Get1(index).Prefab.transform.position);
            }
        }
    }
}