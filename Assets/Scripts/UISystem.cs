using Leopotam.Ecs;
using UnityEngine;
using TMPro;

namespace Client
{
    sealed class UISystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private SceneData _sceneData = null;
        private LevelProgress _levelProgress = null;
        private Configuration _configuration = null;
        private UIData _uiData = null;

        public void Run()
        {
            if (!_sceneData.CameraGrid.enabled)
            {
                _uiData.CameraText.text = $"Camera: Player";
            }
            else
            {
                _uiData.CameraText.text = $"Camera: Grid";
            }

            _uiData.ScoreText.text = $"Score: {_levelProgress.Score.ToString()}";
            _uiData.SpeedText.text = $"Speed: {_sceneData.Speed.ToString()}";
            _uiData.AppleToLevelMaxText.text = $"Apple max: {_sceneData.AppleToLevelMax.ToString()}";
            _uiData.GridSizeText.text = $"Grid size: {_configuration.GridSize.ToString()} x {_configuration.GridSize.ToString()}";
            _uiData.TailLengthText.text = $"Tail length: {_sceneData.TailLength.ToString()}";
            _uiData.TimeText.text = $"Time: {Mathf.Round(Time.time)} sec";
        }

    }



}