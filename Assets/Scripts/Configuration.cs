using UnityEngine;

namespace Client
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        public float Step { get { return _step; } }
        [SerializeField] private float _step = 1;
        public float Time { get { return _time; } }
        [SerializeField] private float _time = 0.5f;

        public int GridSize { get { return _gridSize; } }
        [SerializeField] private int _gridSize = 10;

        public int TailLength { get { return _tailLength; } }
        [SerializeField] private int _tailLength = 1;

        public int FoodToLevelMax { get { return _foodToLevelMax; } }
        [SerializeField] private int _foodToLevelMax = 2;

        public float MinSpeed { get { return _minSpeed; } }
        [SerializeField] private float _minSpeed = 10;
        public float MaxSpeed { get { return _maxSpeed; } }
        [SerializeField] private float _maxSpeed = 300;
    }
}

