using Leopotam.Ecs;

namespace Client
{
    sealed class UISystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private SceneData _sceneData = null;
        private LevelProgress _levelProgress = null;


        public void Run()
        {
            _sceneData.UI.GetComponent<UIData>().ScoreText.text = _levelProgress.Score.ToString();
        }

    }



}