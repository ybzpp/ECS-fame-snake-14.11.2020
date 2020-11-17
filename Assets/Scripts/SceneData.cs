using UnityEngine;

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
    }

}