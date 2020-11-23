using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class LevelProgresSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private LevelProgress _levelProgress = null;
        private SceneData _sceneData = null;
        private EcsFilter<LevelProgressEvent> _filterLevelProgress = null;
        private EcsFilter<GridViewComponent> _filterUpdate = null;

        public void Run()
        {
            foreach (var index in _filterLevelProgress)
            {
                _levelProgress.Food++;
                _levelProgress.Score++;
                _sceneData.TailLength++;
                _sceneData.Speed++;

                if (_levelProgress.Score % 10 == 0)
                {
                    _levelProgress.Level++;
                    LevelUpdate(_levelProgress.Level);
                    _sceneData.CamAnimatior.SetTrigger("LevelProgressTriger");
                }
            }
        }
        public void LevelUpdate(int level)
        {
            Debug.Log($"ProgressLevelUpdate {_levelProgress.Level}");
            if (_sceneData.LevelPresets.Count != 0)
            {
                var currentPallete = _sceneData.CurrentColorPalette;
                var randomPallete = Random.Range(1, _sceneData.LevelPresets.Count);
                if (currentPallete != _sceneData.LevelPresets[randomPallete].ColorPalette)
                {
                    _sceneData.CurrentColorPalette = _sceneData.LevelPresets[randomPallete].ColorPalette;
                }

                //_sceneData.Apple = _sceneData.LevelPresets[level - 1].FoodPrefab;

                var currentFood = _sceneData.Food;
                var randomFood = Random.Range(1, _sceneData.FoodPrefabs.Count);
                if (currentFood != _sceneData.FoodPrefabs[randomFood])
                {
                    _sceneData.Food = _sceneData.FoodPrefabs[randomFood];
                }

                foreach (var index in _filterUpdate)
                {
                    _filterUpdate.GetEntity(index).Get<ColorUpdateComponent>();
                }
            }
        }
    }
}   