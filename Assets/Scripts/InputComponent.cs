namespace Client
{
    public struct InputComponent
    {
        public MoveState MoveState;
    }

    public enum MoveState
    {
        Up,
        Down,
        Left,
        Right
    }
}