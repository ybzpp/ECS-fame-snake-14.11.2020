using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class EcsStartup : MonoBehaviour 
    {
        EcsWorld _world;
        EcsSystems _systems;

        public Configuration Configuration;
        public LevelProgress LevelProgress;
        public UIDataStart UIDataStart;
        public SceneData SceneData;
        public UIData UIData;

        void Start () 
        {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                //.Add(new DungeonGenerator())
                .Add(new GameInitSystem())
                .Add(new GridViewSystem())
                .Add(new GamePauseSystem())
                .Add(new SnakeViewSystem())
                .Add(new InputSystem())
                .Add(new MoveSystem())
                .Add(new SnakeTailSystem())
                .Add(new FoodSystem())
                .Add(new LevelProgresSystem())
                .Add(new ColorPaletteSystem())
                .Add(new GameOverSystem())
                .Add(new UISystem())
                .Add(new CameraFollowSystem())

                .OneFrame<TailComponent>()
                .OneFrame<LevelProgressEvent>()
                .OneFrame<ColorUpdateComponent>()
                .OneFrame<GridCreateEvent>()

                .Inject(new LevelProgress())
                .Inject(Configuration)
                .Inject(SceneData)
                .Inject(UIData)
                .Inject(UIDataStart)
                .Init();
        }
        
        void Update () 
        {
            _systems?.Run ();
        }

        void OnDestroy () 
        {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}