using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    internal class LevelProgress
    {
        public int Level = 1;
        public int Score = 0;
        public int Food = 0;
        public int FoodToLevel = 0;
        public GameState GameState;
        public List<GameObject> TailsColections = new List<GameObject>();
        public List<GameObject> FoodsColections = new List<GameObject>();
    }
}