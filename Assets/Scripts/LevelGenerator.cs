using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject tree01;
    public GameObject tree02;
    public GameObject rock01;
    public GameObject rock02;

    public int numberOfTree01;
    public int numberOfTree02;
    public int numberOfRock01;
    public int numberOfRock02;

    public GameObject terrain;

    private MeshCollider mc;

    // Start is called before the first frame update
    void Start()
    {
        this.tree01 = Resources.Load("Assets/Prefabs/Darth_Artisan/Free_Trees/Meshes/Fir_Tree") as GameObject;
        mc = terrain.GetComponent<MeshCollider>();
        GenerateGameObjects();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }


    private void GenerateGameObjects()
    {
        GenerateIndividualObject(tree01, numberOfTree01);
        GenerateIndividualObject(tree02, numberOfTree02);
        GenerateIndividualObject(rock01, numberOfRock01);
        GenerateIndividualObject(rock02, numberOfRock02);
    }

    private void GenerateIndividualObject(GameObject obj, int count)
    {
        if (obj == null) return;

        for (int i = 0; i < count; i++)
        {
            GameObject temp = GameObject.Instantiate(obj);
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
