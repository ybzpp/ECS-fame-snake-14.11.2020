using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class InputSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _filter = null;
        private LevelProgress _levelProgress = null;
        private SceneData _sceneData = null;
        private EcsWorld _world = null;
        
        void IEcsRunSystem.Run () 
        {
            foreach (var index in _filter) 
            {
                Debug.Log($"GameState: {_levelProgress.GameState}");

                ref var moveState = ref _filter.Get1(index).MoveState;

                var gameState = _levelProgress.GameState;

                if (Input.GetKeyDown(KeyCode.R))
                    Application.LoadLevel(Application.loadedLevel);

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    switch (gameState)
                    {
                        case GameState.Menu:
                            _sceneData.MoveState = MoveState.Up;
                            moveState = MoveState.Up;
                            _levelProgress.GameState = GameState.Game;
                            break;

                        case GameState.Game:
                            _sceneData.MoveState = MoveState.Up;
                            moveState = MoveState.Up;
                            break;
                    }
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    switch (gameState)
                    {
                        case GameState.Menu:
                            _sceneData.MoveState = MoveState.Down;
                            moveState = MoveState.Down;
                            _levelProgress.GameState = GameState.Game;
                            break;

                        case GameState.Game:
                            _sceneData.MoveState = MoveState.Down;
                            moveState = MoveState.Down;
                            break;
                    }
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    switch (gameState)
                    {
                        case GameState.Menu:
                            _sceneData.MoveState = MoveState.Left;
                            moveState = MoveState.Left;
                            _levelProgress.GameState = GameState.Game;
                            break;

                        case GameState.Game:
                            _sceneData.MoveState = MoveState.Left;
                            moveState = MoveState.Left;
                            break;
                    }
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    switch (gameState)
                    {
                        case GameState.Menu:
                            _sceneData.MoveState = MoveState.Right;
                            moveState = MoveState.Right;
                            _levelProgress.GameState = GameState.Game;
                            break;

                        case GameState.Game:
                            _sceneData.MoveState = MoveState.Right;
                            moveState = MoveState.Right;
                            break;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    switch (gameState)
                    {
                        case GameState.Game:
                            _sceneData.CameraGrid.enabled = !_sceneData.CameraGrid.enabled;
                            break;
                    }
                }

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
                            Application.LoadLevel(Application.loadedLevel);
                            break;

                        case GameState.GameOver:
                            Application.LoadLevel(Application.loadedLevel);
                            break;
                    }
                }
            }
        }
    }
}