using UnityEngine;
using Leopotam.Ecs;

namespace Client
{
    sealed class CameraPositionSystem : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private SceneData _sceneData = null;
        public void Init()
        {
            var gridSize = _sceneData.GridSize;

            //camera player
            ref var cameraPlayer = ref _sceneData.CameraPlayer;

            var offsetX = _sceneData.CameraPlayerOffset.x;
            var offsetY = _sceneData.CameraPlayerOffset.y;
            var offsetZ = _sceneData.CameraPlayerOffset.z;

            cameraPlayer.transform.position = new Vector3(gridSize / 2 + offsetX, offsetY, -gridSize + offsetZ);

            //camera grid 
            ref var cameraGrid = ref _sceneData.CameraGrid;
            var offsetCameraGrid = _sceneData.CameraGridOffset;

            cameraGrid.orthographic = true;
            cameraGrid.orthographicSize = gridSize + offsetCameraGrid;
            cameraGrid.transform.position = new Vector3(gridSize / 2, gridSize, gridSize / 2);
        }

    }

}
