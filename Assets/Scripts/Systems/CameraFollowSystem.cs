using UnityEngine;
using Leopotam.Ecs;

namespace Client
{
    sealed class CameraFollowSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<SnakeViewComponent> _filter;
        private EcsWorld _world = null;
        private SceneData _sceneData = null;
        public void Init()
        {
            ref var camera = ref _sceneData.CameraPlayer;

            var posX = _sceneData.GridSize / 2;
            var posY = _sceneData.CameraPlayerOffset.y;
            var posZ = -_sceneData.GridSize / 2;

            camera.transform.position = new Vector3(posX, posY, posZ);

            var relativePosition = new Vector3(posX, 0f, posZ) - camera.transform.position;
            var relativeRotation = Quaternion.LookRotation(relativePosition);
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, relativeRotation, Time.deltaTime * 1f);
        }
        public void Run()
        {
            
        }
        
    }

}
