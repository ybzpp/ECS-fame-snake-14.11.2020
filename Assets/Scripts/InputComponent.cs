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

    public enum GameState
    {
        Menu,
        Game,
        Pause,
        Win,
        GameOver
    }
}