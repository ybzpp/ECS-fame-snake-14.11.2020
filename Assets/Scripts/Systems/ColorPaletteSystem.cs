using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class ColorPaletteSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private SceneData _sceneData = null;
        private EcsFilter<GridViewComponent, ColorAComponent, ColorUpdateComponent> _filterA = null;
        private EcsFilter<GridViewComponent, ColorBComponent, ColorUpdateComponent> _filterB = null;
        private EcsFilter<GridViewComponent, ColorWallComponent, ColorUpdateComponent> _filterWall = null;

        public void Run()
        {
            foreach (var index in _filterA)
            {
                _filterA.Get1(index).Prefab.GetComponent<MeshRenderer>().material.color = _sceneData.CurrentColorPalette.ColorA;
            }

            foreach (var index in _filterB)
            {
                _filterB.Get1(index).Prefab.GetComponent<MeshRenderer>().material.color = _sceneData.CurrentColorPalette.ColorB;
            }

            foreach (var index in _filterWall)
            {
                _filterWall.Get1(index).Prefab.GetComponent<MeshRenderer>().material.color = _sceneData.CurrentColorPalette.ColorWalls;
            }
        }
    }
}