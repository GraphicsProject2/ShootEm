using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private String object1;
    private String object2;
    private String object3;
    private String object4;

    public int numObject1;
    public int numObject2;
    public int numObject3;
    public int numObject4;

    public GameObject terrain;

    private MeshCollider mc;

    // Start is called before the first frame update
    void Start()
    {
        mc = terrain.GetComponent<MeshCollider>();
        int random= (int)UnityEngine.Random.Range(1,4);
        generateLevel(random);
        GenerateGameObjects();
    }

    private void generateLevel(int random)
    {
        if (random==1)
        {
            object1= "Rock1A";
            object2 = "Rock1B";
            object3 = "Rock1C";
            object4 = "Rock1D";
        }else if (random==2)
        {
            object1 = "tree_a";
            object2 = "tree_b";
            object3 = "tree_c";
            object4 = "tree_d";
        }
        else if (random==3)
        {
            object1 = "rus_build_2et_01c_low";
            object2 = "rus_build_5et_03e_low";
            object3 = "rus_build_5et_05_low";
            object4 = "rus_build_9et_02b_low";
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    private void GenerateGameObjects()
    {
        GenerateIndividualObject(object1, numObject1);
        GenerateIndividualObject(object2, numObject2);
        GenerateIndividualObject(object3, numObject3);
        GenerateIndividualObject(object4, numObject4);
    }

    private void GenerateIndividualObject(String obj, int count)
    {
        if (obj == null) return;

        for (int i = 0; i < count; i++)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load(obj,typeof(GameObject)));
            Vector3 randomPoint = GenerateRandomPoint();
            temp.gameObject.transform.position = new Vector3(randomPoint.x, temp.gameObject.transform.position.y, randomPoint.z);
        }
    }


    Vector3 GenerateRandomPoint()
    {
        int xRandom = 0;
        int zRandom = 0;


        xRandom = (int)UnityEngine.Random.Range(mc.bounds.min.x, mc.bounds.max.x);
        zRandom = (int)UnityEngine.Random.Range(mc.bounds.min.z, mc.bounds.max.z);

        return new Vector3(xRandom, 0.0f, zRandom);
    }

}
