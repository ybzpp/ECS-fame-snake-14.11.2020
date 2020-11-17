using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class InputSystem : IEcsRunSystem 
    {
        private EcsFilter<InputComponent> _filter = null;
        private EcsWorld _world = null;
        private SceneData _sceneData = null;

        void IEcsRunSystem.Run () 
        {
            foreach (var index in _filter)
            {
                ref var moveState = ref _filter.Get1(index).MoveState;

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    if (moveState != MoveState.Down)
                        moveState = MoveState.Up;
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    if (moveState != MoveState.Up)
                        moveState = MoveState.Down;
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    if (moveState != MoveState.Right)
                        moveState = MoveState.Left;
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    if (moveState != MoveState.Left)
                        moveState = MoveState.Right;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                     _sceneData.CameraGrid.enabled = !_sceneData.CameraGrid.enabled;
                
            }
        }
    }
}