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
            if (_levelProgress.GameState == GameState.GameOver)
            {
                _uiData.UIGameOver.SetActive(true);
            }
            else 
            {
                _uiData.UIGameOver.SetActive(false);
            }

            if (_levelProgress.GameState == GameState.Menu)
            {
                _uiData.UIGameStart.SetActive(true);
            }
            else
            {
                _uiData.UIGameStart.SetActive(false);
                if (_levelProgress.GameState == GameState.Game)
                {
                    _uiData.ScoreText.text = $"Score: {_levelProgress.Score.ToString()}";
                    _uiData.SpeedText.text = $"Speed: {_sceneData.Speed.ToString()}";
                    _uiData.AppleToLevelMaxText.text = $"Apple max: {_sceneData.AppleToLevelMax.ToString()}";
                    _uiData.GridSizeText.text = $"Grid size: {_configuration.GridSize.ToString()} x {_configuration.GridSize.ToString()}";
                    _uiData.TailLengthText.text = $"Tail length: {_sceneData.TailLength.ToString()}";
                    _uiData.TimeText.text = $"Time: {Mathf.Round(Time.time)} sec";
                    _uiData.DirectionText.text = $"Direction: {_sceneData.MoveState}";

                    if (!_sceneData.CameraGrid.enabled)
                    {
                        _uiData.CameraText.text = $"Camera: Player";
                    }
                    else
                    {
                        _uiData.CameraText.text = $"Camera: Grid";
                    }
                }
                
            }
        }
    }
}