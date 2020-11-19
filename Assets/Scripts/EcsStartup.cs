using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class EcsStartup : MonoBehaviour 
    {
        EcsWorld _world;
        EcsSystems _systems;

        public Configuration Configuration;
        public SceneData SceneData;
        public LevelProgress LevelProgress;
        public UIData UIData;
        public UIDataStart UIDataStart;

        void Start () 
        {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new GameInitSystem())
                .Add(new ProgressLevelSystem())
                .Add(new GridViewSystem())
                .Add(new ColorPaletteSystem())
                .Add(new InputSystem())
                .Add(new MoveSystem())
                .Add(new SnakeViewSystem())
                .Add(new SnakeTailSystem())
                .Add(new TailSystem())
                .Add(new AppleSystem())
                .Add(new UISystem())
                .Add(new CameraFollowSystem())
                .Add(new GameStateSystem())

                // register one-frame components (order is important), for example:

                //.OneFrame<ColorComponent> ()
                //.OneFrame<TeleportComponent> ()
                //.OneFrame<ViewComponent>()

                // inject service instances here (order doesn't important), for example:
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