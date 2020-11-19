using Leopotam.Ecs;

namespace Client
{
    sealed class ProgressLevelSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world = null;
        private LevelProgress _levelProgress = null;
        private SceneData _sceneData = null;
        public void Init()
        {
            _sceneData.CurrentColorPalette = _sceneData.ColorPalette1;
        }
        public void Run()
        {

            if (_sceneData.CamAnimatior != null)
            {
                if (_levelProgress.Score >= 10 && _levelProgress.Score < 20)
                {
                    _sceneData.CurrentColorPalette = _sceneData.ColorPalette2;
                }
                else if (_levelProgress.Score >= 20 && _levelProgress.Score < 30)
                {
                    _sceneData.CurrentColorPalette = _sceneData.ColorPalette3;
                }
                else if (_levelProgress.Score >= 30 && _levelProgress.Score < 40)
                {
                    _sceneData.CurrentColorPalette = _sceneData.ColorPalette4;
                }
                else if (_levelProgress.Score >= 40 && _levelProgress.Score < 50)
                {
                    _sceneData.CurrentColorPalette = _sceneData.ColorPalette5;
                }
                else if (_levelProgress.Score >= 50)
                {
                    _sceneData.CurrentColorPalette = _sceneData.ColorPalette6;
                }
                
            }
            
        }
    }
}