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
        public UIDataStart _uiDataStart = null;
        private UIData _uiData = null;
        private float _timeInGame;

        public void Run()
        {
            UIMenu();
            UIView();
            UIText();
        }
        void GameStateSet(GameState gameState)
        {
            _levelProgress.GameState = gameState;
        }
        void UIMenu()
        {
            //button
            _uiData.BackButton.onClick.AddListener(() => GameStateSet(GameState.Game));
            _uiData.UIButtonSettingInGame.onClick.AddListener(() => GameStateSet(GameState.Pause));


            //slider
            if (_levelProgress.GameState == GameState.Pause)
            {
                if (_uiData.SpeedSlider.value != _sceneData.Speed)
                {
                    _sceneData.Speed = _uiData.SpeedSlider.value;
                }
            }
            else if (_levelProgress.GameState == GameState.Game)
            {
                _uiData.SpeedSlider.value = _sceneData.Speed;
            }
        }
        void UIView()
        {
            switch (_levelProgress.GameState)
            {
                case (GameState.Menu):
                    _uiData.UIScreenInGame.SetActive(false);
                    _uiDataStart.UIGameOver.SetActive(false);
                    _uiDataStart.UIGameStart.SetActive(true);
                    _uiDataStart.UIInGame.SetActive(false);
                    break;
                case (GameState.Game):
                    _uiData.UIScreenInGame.SetActive(true);
                    _uiDataStart.UIGameStart.SetActive(false);
                    _uiDataStart.UIInGame.SetActive(true);
                    _uiData.UIScreenView(false);
                    break;
                case (GameState.Pause):
                    _uiData.UIScreenInGame.SetActive(false);
                    _uiDataStart.UIInGame.SetActive(false);
                    _uiData.UIScreenView(true);
                    break;
                case (GameState.GameOver):
                    _uiDataStart.UIInGame.SetActive(false);
                    _uiData.UIScreenInGame.SetActive(false);
                    _uiDataStart.UIGameOver.SetActive(true);
                    break;
                case (GameState.Win):
                    break;
            }

        }
        void UIText()
        {
            if (_levelProgress.GameState == GameState.Menu)
            {
                _timeInGame = 0f;
            }

            _uiDataStart.UILevelText.text = $"LEVEL {_levelProgress.Level.ToString().ToUpper()}";
            _uiDataStart.UITimeText.text = $"{Mathf.Round(_timeInGame += Time.deltaTime).ToString().ToUpper()} SEC";

            _uiData.ScoreValueIngameText.text = $"{_levelProgress.Score.ToString().ToUpper()}";

            _uiData.ScoreValueText.text = $"{_levelProgress.Score.ToString().ToUpper()}";
            _uiData.LevelText.text = $"LEVEL {_levelProgress.Level.ToString().ToUpper()}";
            _uiData.SpeedText.text = $"X{_sceneData.Speed.ToString().ToUpper()}";
            _uiData.FoodToLevelMaxText.text = $"{_sceneData.FoodToLevelMax.ToString().ToUpper()}";
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