using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class InputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<InputComponent> _filter = null;
        private LevelProgress _levelProgress = null;
        private SceneData _sceneData = null;
        private EcsWorld _world = null;
        public void Init()
        {
            _levelProgress.GameState = GameState.Menu;
        }
        void IEcsRunSystem.Run () 
        {
            foreach (var index in _filter) 
            {
                ref var moveState = ref _filter.Get1(index).MoveState;
                //var gameState = _levelProgress.GameState; 

                if (_levelProgress.GameState == GameState.Menu)
                {
                    if (Input.GetKeyDown(KeyCode.S))
                        _levelProgress.GameState = GameState.Game;
                }

                if (_levelProgress.GameState == GameState.Game)
                {

                    if (Input.GetKeyDown(KeyCode.T))
                        Application.LoadLevel(Application.loadedLevel);

                    if (Input.GetKeyDown(KeyCode.P))
                        _levelProgress.GameState = GameState.Pause;

                    if (Input.GetKeyDown(KeyCode.Space))
                        _sceneData.CameraGrid.enabled = !_sceneData.CameraGrid.enabled;

                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    {
                        if (moveState != MoveState.Down)
                        {
                            _sceneData.MoveState = MoveState.Up;
                            moveState = MoveState.Up;
                        }
                    }
                    else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                    {
                        if (moveState != MoveState.Up)
                        {
                            _sceneData.MoveState = MoveState.Down;
                            moveState = MoveState.Down;
                        }
                    }
                    else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        if (moveState != MoveState.Right)
                        {
                            _sceneData.MoveState = MoveState.Left;
                            moveState = MoveState.Left;
                        }
                    }
                    else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    {
                        if (moveState != MoveState.Left)
                        {
                            _sceneData.MoveState = MoveState.Right;
                            moveState = MoveState.Right;
                        }

                    }
                }

                if (_levelProgress.GameState == GameState.Pause)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                        _levelProgress.GameState = GameState.Game;
                    if (Input.GetKeyDown(KeyCode.T))
                        Application.LoadLevel(Application.loadedLevel);
                }

                if (_levelProgress.GameState == GameState.GameOver)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                        Application.LoadLevel(Application.loadedLevel);
                }

                switch (_levelProgress.GameState)
                {
                    case GameState.Menu:
                        PauseGame();
                        break;
                    case GameState.Win:
                        PauseGame();
                        break;
                    case GameState.Pause:
                        PauseGame();
                        break;
                    case GameState.Game:
                        ResumeGame();
                        break;
                    case GameState.GameOver:
                        PauseGame();
                        break;
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