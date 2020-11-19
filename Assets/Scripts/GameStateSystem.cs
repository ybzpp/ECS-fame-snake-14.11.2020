using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Events;

namespace Client
{
    sealed class GameStateSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<SnakeViewComponent> _filterSnake = null;
        private EcsFilter<TailComponent> _filterTail = null;
        private LevelProgress _levelProgress = null;
        private EcsWorld _world = null;
        private Vector3 _snakePosition;
        private UIData _uiData = null;
        private UIDataStart _uiDataStart = null;
        private SceneData _sceneData = null;
        private Configuration _configuration = null;

        public void Init()
        {  
            //GameState.Menu
            _levelProgress.GameState = GameState.Menu;
            _uiData.SpeedSlider.minValue = _configuration.MinSpeed;
            _uiData.SpeedSlider.maxValue = _configuration.MaxSpeed;
            _uiData.SpeedSlider.value = _sceneData.Speed;
        }

       public void GameStateSet(GameState gameState)
        {
            _levelProgress.GameState = gameState;
        }

        public void Run()
        {

            // ui slider
            if (_uiData.SpeedSlider.value != _sceneData.Speed)
            {
                _sceneData.Speed = _uiData.SpeedSlider.value;
            }

            var gameState = _levelProgress.GameState;

            switch (gameState)
            {
                case (GameState.Menu):
                    _uiDataStart.UIGameOver.SetActive(false);
                    _uiDataStart.UIGameStart.SetActive(true);
                    break;
                case (GameState.Game):
                    _uiDataStart.UIGameStart.SetActive(false);
                    break;
                case (GameState.Pause):
                    break;
                case (GameState.GameOver):
                    _uiDataStart.UIGameOver.SetActive(true);
                    break;
                case (GameState.Win):
                    break;
            }

            _uiData.BackButton.onClick.AddListener(() => GameStateSet(GameState.Game));

            //GameState.Menu
            if (gameState == GameState.Menu)
            {
                PauseGame();
            }
            
            //GameState.Pause
            else if (gameState == GameState.Pause)
            {
                _uiData.UIScreenView(true);
                PauseGame();
            }

            //GameState.Game
            else if(gameState == GameState.Game)
            {
                _uiData.UIScreenView(false);
                ResumeGame();
            }

            else if(gameState == GameState.GameOver)
            {
                PauseGame();
            }

            //GameState.GameOver
            foreach (var index in _filterSnake)
            {
                var positionSnakeHead = _filterSnake.Get1(index).Prefab.transform.position;
                _snakePosition = positionSnakeHead;
            }

            foreach (var index in _filterTail)
            {
                var tailPosition = _filterTail.Get1(index).Prefab.transform.position;

                if (_snakePosition == tailPosition)
                {
                    _levelProgress.GameState = GameState.GameOver;
                }
            }
        }
        void PauseGame()
        {
            Time.timeScale = 0;
        }

        void ResumeGame()
        {
            Time.timeScale = 1;
        }
    }
}