using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Client
{
    public class SceneData : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        public GameObject TailPrefab;

        public GameObject GridPrefabBlack;
        public GameObject GridPrefabGray;
        public GameObject GridEndPrefab;

        public ColorPalette CurrentColorPalette;
        public Transform ParentSceneObjects;

        public GameObject Food; //LevelPresets

        public Camera CameraPlayer;
        public Camera CameraGrid;
        public float CameraSpeed;
        public Animator CamAnimatior;
        public Vector3 CameraPlayerOffset;
        public float CameraGridOffset;

        public int GridSize;
        public int TailLength;
        public int FoodToLevelMax;
        public int FoodToLevel;

        public float Speed; //LevelPresets

        public List<LevelPreset> LevelPresets;
        public List<GameObject> FoodPrefabs;

        public MoveState MoveState;


        public void moveStateSet(MoveState moveState)
        {
            MoveState = moveState;
        }

        public void FoodMaxAdd(int value)
        {
            FoodToLevelMax += value;
            FoodMaxTest();
        }
        public void TailLengthAdd(int value)
        {
            TailLength += value;
            TailLengthTest();
        }

        public void FoodMaxTest()
        {
            if (FoodToLevelMax < 1)
            {
                FoodToLevelMax = 1;
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