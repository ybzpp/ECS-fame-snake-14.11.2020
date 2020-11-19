using UnityEngine;
using UnityEngine.Events;

namespace Client
{
    public class SceneData : MonoBehaviour
    {
        public Transform SpawnPoint;
        public GameObject PlayerPrefab;
        public GameObject TailPrefab;

        public GameObject GridPrefabBlack;
        public GameObject GridPrefabGray;
        public GameObject GridEndPrefab;

        public ColorPalette ColorPalette;
        public Transform ParentSceneObjects;
        public GameObject Apple;

        public Camera CameraPlayer;
        public Camera CameraGrid;
        public float CameraSpeed;
        public Vector3 CameraOffset;

        public int GridSize;
        public int TailLength;
        public int AppleToLevelMax;
        public int AppleToLevel;
        public float Speed;



        public MoveState MoveState;

        public void moveStateSet(MoveState moveState)
        {
            MoveState = moveState;
        }

        public void AppleMaxAdd(int value)
        {
            AppleToLevelMax += value;
            AppleMaxTest();
        }
        public void TailLengthAdd(int value)
        {
            TailLength += value;
            TailLengthTest();
        }

        public void AppleMaxTest()
        {
            if (AppleToLevelMax < 1)
            {
                AppleToLevelMax = 1;
            }
            //не больше чем размер поля - количество хвоста - голова
        }
        public void TailLengthTest()
        {
            if (TailLength < 0)
            {
                TailLength = 0;
            }
            //не больше чем размер поля - количество хвоста - голова
        }
    }


}