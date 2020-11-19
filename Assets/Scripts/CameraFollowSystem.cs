using UnityEngine;
using Leopotam.Ecs;

namespace Client
{
    sealed class CameraFollowSystem : IEcsRunSystem
    {
        private EcsFilter<SnakeViewComponent> _filter;
        private EcsWorld _world = null;
        private SceneData _sceneData = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var targetTransform = ref _filter.Get1(index).Prefab;
                ref var camera = ref _sceneData.CameraPlayer;
                var speed = _sceneData.CameraSpeed;

                var posX = targetTransform.transform.position.x + _sceneData.CameraOffset.x;
                var posY = targetTransform.transform.position.y + _sceneData.CameraOffset.y;
                var posZ = targetTransform.transform.position.z + _sceneData.CameraOffset.z;

                camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(posX, posY, posZ), speed * Time.deltaTime);
            }
        }
    }

}
