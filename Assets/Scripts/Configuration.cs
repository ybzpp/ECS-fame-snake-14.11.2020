using UnityEngine;

namespace Client
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        public float Step = 1;
        public float Time = 0.5f;

        public int GridSize = 10;
        public int TailLength = 3;
        public int AppleToLevelMax = 2;
        public float Speed = 1;
    }
}

