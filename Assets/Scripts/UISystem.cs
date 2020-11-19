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
            UIText();
        }
        void UIText()
        {
            _uiData.ScoreValueText.text = $"{_levelProgress.Score.ToString().ToUpper()}";
            _uiData.LevelText.text = $"LEVEL {_levelProgress.Level.ToString().ToUpper()}";
            _uiData.SpeedText.text = $"X{_sceneData.Speed.ToString().ToUpper()}";
            _uiData.AppleToLevelMaxText.text = $"{_sceneData.AppleToLevelMax.ToString().ToUpper()}";
            _uiData.GridSizeText.text = $"{_configuration.GridSize.ToString().ToUpper()} X {_configuration.GridSize.ToString().ToUpper()}";
            _uiData.TailLengthText.text = $"{_sceneData.TailLength.ToString().ToUpper()} CM";
            _uiData.TimeText.text = $"{Mathf.Round(Time.time).ToString().ToUpper()} SEC";
            _uiData.DirectionText.text = $"{_sceneData.MoveState.ToString().ToUpper()}";

            if (!_sceneData.CameraGrid.enabled)
            {
                _uiData.CameraText.text = $"PLAYER";
            }
            else
            {
                _uiData.CameraText.text = $"GRID";
            }
            
        }
    }
}