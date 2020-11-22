using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class InputSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _filter = null;
        private LevelProgress _levelProgress = null;
        private SceneData _sceneData = null;
        private EcsWorld _world = null;
        private UIData _uiData = null;
        
        void IEcsRunSystem.Run () 
        {
            foreach (var index in _filter) 
            {
                var gameState = _levelProgress.GameState;
                Debug.Log($"GameState: {gameState}");

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    switch (gameState)
                    {
                        case GameState.Game:
                            _levelProgress.GameState = GameState.Pause;
                            break;

                        case GameState.Pause:
                            _levelProgress.GameState = GameState.Game;

                            break;
                        case GameState.Win:
                            GameRestart();
                            break;

                        case GameState.GameOver:
                            GameRestart();
                            break;
                    }
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    GameRestart();
                }

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    _sceneData.MoveState = MoveState.Up;

                    if (_levelProgress.GameState == GameState.Menu)
                    {
                        _levelProgress.GameState = GameState.Game;
                    }
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    _sceneData.MoveState = MoveState.Down;

                    if (_levelProgress.GameState == GameState.Menu)
                    {
                        _levelProgress.GameState = GameState.Game;
                    }
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    _sceneData.MoveState = MoveState.Left;

                    if (_levelProgress.GameState == GameState.Menu)
                    {
                        _levelProgress.GameState = GameState.Game;
                    }
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    _sceneData.MoveState = MoveState.Right;

                    if (_levelProgress.GameState == GameState.Menu)
                    {
                        _levelProgress.GameState = GameState.Game;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    switch (gameState)
                    {
                        case GameState.Game:
                            ChangeCamera(_sceneData.CameraGrid);
                            break;
                    }
                }
                _uiData.UIButtonCameraInGame.onClick.AddListener(() => ChangeCamera(_sceneData.CameraGrid)); // â ui system

                void GameRestart()
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
                void ChangeCamera(Camera camera)
                {
                    camera.enabled = !camera.enabled;
                }
            }
        }
    }
}