using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class InputSystem : IEcsRunSystem 
    {
        private EcsFilter<InputComponent> _filter = null;
        private EcsWorld _world = null;
        
        void IEcsRunSystem.Run () 
        {
            foreach (var index in _filter)
            {
                ref var moveState = ref _filter.Get1(index).MoveState;

                if (Input.GetKey(KeyCode.W) && moveState != MoveState.Down)
                {
                    moveState = MoveState.Up;
                }
                else if (Input.GetKey(KeyCode.S) && moveState != MoveState.Up)
                {
                    moveState = MoveState.Down;
                }
                else if (Input.GetKey(KeyCode.A) && moveState != MoveState.Right)
                {
                    moveState = MoveState.Left;
                }
                else if (Input.GetKey(KeyCode.D) && moveState != MoveState.Left)
                {
                    moveState = MoveState.Right;
                }
            }
        }
    }
}