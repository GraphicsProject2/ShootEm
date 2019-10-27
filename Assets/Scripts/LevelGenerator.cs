using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    

    private string playerName = "Enemy2(Clone)";

    private String object1;
    private String object2;
    private String object3;
    private String object4;

    private String barrel;

    private String healthCrate;

    public int numObject1;
    public int numObject2;
    public int numObject3;
    public int numObject4;
    private int numExtras = 10;

    public GameObject terrain;

    private MeshCollider mc;

    // Start is called before the first frame update
    void Start()
    {
        mc = terrain.GetComponent<MeshCollider>();
        int level= PlayerPrefs.GetInt("Location");
        if (level == -1)
        {
            level= (int)UnityEngine.Random.Range(0, 3);
        }
        generateLevel(level);
    }

    private void generateLevel(int level)
    {

        barrel = "Oil_Drum";
        healthCrate = "ScifiCrate_2";

        if (level==3)
        {
            object1= "Rock1A";
            object2 = "Rock1B";
            object3 = "Rock1C";
            object4 = "Rock1D";
            terrain.GetComponent<Renderer>().material = Resources.Load("RockyMaterial", typeof(Material)) as Material;
        }
        else if (level==2)
        {
            object1 = "tree_a";
            object2 = "tree_b";
            object3 = "tree_c";
            object4 = "tree_d";
            terrain.GetComponent<Renderer>().material = Resources.Load("ForestMaterial", typeof(Material)) as Material;
        }
        else if (level==0)
        {
            object1 = "rus_build_2et_01c_low";
            object2 = "rus_build_5et_03e_low";
            object3 = "rus_build_5et_05_low";
            object4 = "rus_build_9et_02b_low";
            terrain.GetComponent<Renderer>().material = Resources.Load("CityMaterial", typeof(Material)) as Material;
        }
        else if (level == 1)
        {
            object1 = "Mixed_Cactus_01";
            object2 = "Mixed_Cactus_02";
            object3 = "Mixed_Tree_02";
            object4 = "Mixed_Well_01";
            terrain.GetComponent<Renderer>().material = Resources.Load("DesertMaterial", typeof(Material)) as Material;
        }

        GenerateGameObjects();

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
        GenerateIndividualObject(barrel, numExtras);
        GenerateIndividualObject(healthCrate, numExtras);
    }

    private void GenerateIndividualObject(String obj, int count)
    {
        if (obj == null) return;

        for (int i = 0; i < count; i++)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load(obj,typeof(GameObject)));
            Vector3 randomPoint = GenerateRandomPoint();
            if (obj == "ScifiCrate_2")
            {
                temp.transform.localScale = Vector3.one * 0.20f;
            }
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
