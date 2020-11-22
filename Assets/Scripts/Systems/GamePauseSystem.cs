using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class GamePauseSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private LevelProgress _levelProgress = null;

        public void Run()
        {

            switch (_levelProgress.GameState)
            {
                case (GameState.Menu):
                    PauseGame();
                    break;
                case (GameState.Game):
                    ResumeGame();
                    break;
                case (GameState.Pause):
                    PauseGame();
                    break;
                case (GameState.GameOver):
                    PauseGame();
                    break;
                case (GameState.Win):
                    break;
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