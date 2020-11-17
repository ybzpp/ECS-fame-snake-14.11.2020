using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class ColorPaletteSystem : IEcsRunSystem
    {
        private EcsFilter<GridViewComponent,ColorComponent> _filter = null;
        private EcsWorld _world = null;
        private SceneData _sceneData = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var gridState = _filter.Get2(index).GridState;

                switch (gridState)
                {
                    case GridState.GridA:
                        _filter.Get1(index).Prefab.GetComponent<MeshRenderer>().material.color = _sceneData.ColorPalette.ColorA;
                        break;
                    case GridState.GridB:
                        _filter.Get1(index).Prefab.GetComponent<MeshRenderer>().material.color = _sceneData.ColorPalette.ColorB;
                        break;
                    case GridState.Wall:
                        _filter.Get1(index).Prefab.GetComponent<MeshRenderer>().material.color = _sceneData.ColorPalette.ColorWalls;
                        break;

                }

            }
        }
    }
}