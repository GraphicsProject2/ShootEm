using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSection
{

    private static readonly int MAX_OBSTACLES = 18;

    /// <summary>
    /// Number of each obstacle type held by this object
    /// </summary>
    private readonly int NUM_TREES01 = 1;
    private readonly int NUM_TREES02 = 2;
    private readonly int NUM_ROCKS01 = 1;
    private readonly int NUM_ROCKS02 = 2;

    /// <summary>
    /// References to the cube and cylinder prefabs.
    /// </summary>
    private readonly GameObject TREE01_PREFAB = Resources.Load<GameObject>("Prefabs/Darth_artisan/Free_Trees/Prefabs/Fir_Tree");
    private readonly GameObject ROCK01_PREFAB = Resources.Load<GameObject>("Prefabs/Rocks and Boulders 2/Rocks/Prefabs_snow/Rock1E");
    private readonly GameObject ROCK02_PREFAB = Resources.Load<GameObject>("Prefabs/Rocks and Boulders 2/Rocks/Prefabs_snow/Rock2");
    private readonly GameObject TREE02_PREFAB = Resources.Load<GameObject>("Prefabs/Darth_artisan/Free_Trees/Prefabs/Poplar_Tree");
    

    /// <summary>
    /// Position of this section's slope.
    /// </summary>
    private Vector3 position;

    /// <summary>
    /// Number of obstacles per section.
    /// </summary>
    private int numPerSection = 6;

    /// <summary>
    /// The length of the x dimension of the slope.
    /// </summary>
    private float xLen;

    /// <summary>
    /// The length of the z dimension of the slop.
    /// </summary>
    private float zLen;

    /// <summary>
    /// These two fields hold references to the obstacles so that they can be
    /// recycled.
    /// </summary>
    private List<GameObject> rocks01 = new List<GameObject>();
    private List<GameObject> rocks02 = new List<GameObject>();
    private List<GameObject> trees01 = new List<GameObject>();
    private List<GameObject> trees02 = new List<GameObject>();

    private List<GameObject> currentObstacles = new List<GameObject>();
    private GameObject currentItem;

    public ObstacleSection(Vector3 position, float xLen, float zLen)
    {
        this.position = position;
        this.xLen = xLen;
        this.zLen = zLen;

        InstantiateObstacles(rocks01, ROCK01_PREFAB, NUM_ROCKS01);
        InstantiateObstacles(rocks02, ROCK02_PREFAB, NUM_ROCKS02);
        InstantiateObstacles(trees01, TREE01_PREFAB, NUM_TREES01);
        InstantiateObstacles(trees02, TREE02_PREFAB, NUM_TREES02);
    }


    /// <summary>
    /// Updates the coordinates of this section and randomises the obstacle locations.
    /// </summary>
    /// <param name="position">The new position for this section of obstacles.</param>
    public void UpdateCoordinates(Vector3 position)
    {
        this.position = position;

        // Increase the number of obstacles whenever this is recycled, up to a max
        if (numPerSection < MAX_OBSTACLES)
        {
            numPerSection += 2;
        }

        RandomiseObstacles();
    }

    /// <summary>
    /// Randomises the obstacles locations and make-up of 
    /// </summary>
    private void RandomiseObstacles()
    {

        // Pick some random obstacles
        int rock01Index = 0;
        int rock02Index = 0;
        int tree01Index = 0;
        int tree02Index = 0;

        for (int i = 0; i < numPerSection; i++)
        {
            float randomValue = UnityEngine.Random.Range(1, 100);

            if (randomValue < 40 && tree01Index < NUM_TREES01)
            {
                ActivateObstacle(trees01[tree01Index], 0);
                tree01Index++;
            }else if (randomValue< 40 && tree02Index< NUM_TREES02)
            {
                ActivateObstacle(trees02[tree02Index], 0);
                tree02Index++;
            }
            else
            {
                if (randomValue % 2 == 0 && rock02Index < NUM_ROCKS02)
                {
                    ActivateObstacle(rocks02[rock02Index], 0.5f);
                    rock02Index++;
                }
                else
                {
                    ActivateObstacle(rocks01[rock01Index], 0.5f);
                    rock01Index++;
                }

            }
        }
    }

    /// <summary>
    /// Rotates an obstacle.
    /// </summary>
    /// <param name="obstacle">The obstacle to rotate.</param>
    private void RotateObstacle(GameObject obstacle)
    {
        float newYRot = UnityEngine.Random.Range(0, 360);
        obstacle.transform.rotation = Quaternion.Euler(new Vector3(0, newYRot, 0));
    }


    /// <summary>
    /// Adds obstacle to the current obstacle list and activates it in the game in a random position
    /// </summary>
    /// <param name="obstacle">The obstacle to be activated.</param>
    /// <param name="maxZPos">The obstacle's position on the y=axis</param>
    private void ActivateObstacle(GameObject obj, float yPos)
    {
        currentObstacles.Add(obj);
        RandomisePosition(obj, yPos);
        RotateObstacle(obj);
        obj.SetActive(true);
    }

    /// <summary>
    /// Randomises the position and rotation of an obstacle.
    /// </summary>
    /// <param name="obstacle">The obstacle whose position will be randomised.</param>
    /// <param name="maxZPos">The obstacle's position on the y=axis</param>
    private void RandomisePosition(GameObject obstacle, float yPos)
    {
        // The maximum and minimum possible X and Z positions of the obstacle
        float maxZPos = position.z + (zLen / 2);
        float minZPos = position.z - (zLen / 2);
        float maxXPos = position.x + (xLen / 2) - 5;
        float minXPos = position.x - (xLen / 2) + 5;

        float newX = UnityEngine.Random.Range(minXPos, maxXPos);
        float newZ = UnityEngine.Random.Range(minZPos, maxZPos);
        obstacle.transform.position = new Vector3(newX, yPos, newZ);
    }


    /// <summary>
    /// Instantiates the obstacles.
    /// </summary>
    /// <param name="obstacleList">The obstacles container to populate.</param>
    /// <param name="prefab">The obstacle prefab to instantiate from.</param>
    /// <param name="num">The number of prefabs to instantiate.</param>
    private void InstantiateObstacles(List<GameObject> obstacleList, GameObject prefab, int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
            gameObject.SetActive(false);
            obstacleList.Add(gameObject);
        }
    }
}