using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Leopotam.Ecs;

namespace Client
{
    sealed class DungeonGenerator : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private Configuration _configuration = null;
        private SceneData _sceneData = null;
        private LevelProgress _levelProgress = null;

        [SerializeField]
        private Tile groundTile;
        [SerializeField]
        private Tile pitTile;
        [SerializeField]
        private Tile topWallTile;
        [SerializeField]
        private Tile botWallTile;
        [SerializeField]
        private Tilemap groundMap;
        [SerializeField]
        private Tilemap pitMap;
        [SerializeField]
        private Tilemap wallMap;
        [SerializeField]
        private GameObject player;


        [SerializeField]
        private int deviationRate = 10;
        [SerializeField]
        private int roomRate = 15;
        [SerializeField]
        private int maxRouteLength = 10;
        [SerializeField]
        private int maxRoutes = 20;


        private int routeCount = 10;

        public void Init()
        {
            //int x = 0;
            //int y = 0;
            //int routeLength = 0;
            //GenerateSquare(x, 1, y);
            //Vector2Int previousPos = new Vector2Int(x, y);
            //y += 3;
            //GenerateSquare(x, 1, y);
            //NewRoute(x, y, routeLength, previousPos);

            //FillWalls();
        }

        private void FillWalls()
        {
            BoundsInt bounds = groundMap.cellBounds;
            for (int xMap = bounds.xMin - 10; xMap <= bounds.xMax + 10; xMap++)
            {
                for (int yMap = bounds.yMin - 10; yMap <= bounds.yMax + 10; yMap++)
                {
                    Vector3Int pos = new Vector3Int(xMap, 0, yMap);

                    var gridEntity = _world.NewEntity();
                    gridEntity.Get<PositionComponent>().Position = pos;
                    gridEntity.Get<GridViewComponent>();
                    gridEntity.Get<WallCompanent>();

                }
            }
        }

        private void NewRoute(int x, int y, int routeLength, Vector2Int previousPos)
        {
            if (routeCount < maxRoutes)
            {
                routeCount++;
                while (++routeLength < maxRouteLength)
                {
                    //Initialize
                    bool routeUsed = false;
                    int xOffset = x - previousPos.x; //0
                    int yOffset = y - previousPos.y; //3
                    int roomSize = 1; //Hallway size
                    if (Random.Range(1, 100) <= roomRate)
                        roomSize = Random.Range(3, 6);
                    previousPos = new Vector2Int(x, y);

                    //Go Straight
                    if (Random.Range(1, 100) <= deviationRate)
                    {
                        if (routeUsed)
                        {
                            GenerateSquare(previousPos.x + xOffset, previousPos.y + yOffset, roomSize);
                            NewRoute(previousPos.x + xOffset, previousPos.y + yOffset, Random.Range(routeLength, maxRouteLength), previousPos);
                        }
                        else
                        {
                            x = previousPos.x + xOffset;
                            y = previousPos.y + yOffset;
                            GenerateSquare(x, y, roomSize);
                            routeUsed = true;
                        }
                    }

                    //Go left
                    if (Random.Range(1, 100) <= deviationRate)
                    {
                        if (routeUsed)
                        {
                            GenerateSquare(previousPos.x - yOffset, previousPos.y + xOffset, roomSize);
                            NewRoute(previousPos.x - yOffset, previousPos.y + xOffset, Random.Range(routeLength, maxRouteLength), previousPos);
                        }
                        else
                        {
                            y = previousPos.y + xOffset;
                            x = previousPos.x - yOffset;
                            GenerateSquare(x, y, roomSize);
                            routeUsed = true;
                        }
                    }
                    //Go right
                    if (Random.Range(1, 100) <= deviationRate)
                    {
                        if (routeUsed)
                        {
                            GenerateSquare(previousPos.x + yOffset, previousPos.y - xOffset, roomSize);
                            NewRoute(previousPos.x + yOffset, previousPos.y - xOffset, Random.Range(routeLength, maxRouteLength), previousPos);
                        }
                        else
                        {
                            y = previousPos.y - xOffset;
                            x = previousPos.x + yOffset;
                            GenerateSquare(x, y, roomSize);
                            routeUsed = true;
                        }
                    }

                    if (!routeUsed)
                    {
                        x = previousPos.x + xOffset;
                        y = previousPos.y + yOffset;
                        GenerateSquare(x, y, roomSize);
                    }
                }
            }
        }

        private void GenerateSquare(int x, int y, int radius)
        {
            for (int tileX = x - radius; tileX <= x + radius; tileX++)
            {
                for (int tileY = y - radius; tileY <= y + radius; tileY++)
                {
                    Vector3Int tilePos = new Vector3Int(tileX, tileY, 0);

                    var gridEntity = _world.NewEntity();
                    gridEntity.Get<PositionComponent>().Position = tilePos;
                    gridEntity.Get<GridViewComponent>();
                }
            }
        }

        
    }
}