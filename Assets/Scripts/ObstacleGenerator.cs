using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator
{
    public GameObject tree01 = Resources.Load("Assets/Prefabs/Darth_Artisan/Free_Trees/Meshes/Fir_Tree") as GameObject;
    public GameObject tree02 = Resources.Load("Assets/Prefabs/Darth_Artisan/Free_Trees/Meshes/Fir_Tree") as GameObject;
	public GameObject rock01 = Resources.Load("Assets/Prefabs/Darth_Artisan/Free_Trees/Meshes/Fir_Tree") as GameObject;
	public GameObject rock02 = Resources.Load("Assets/Prefabs/Darth_Artisan/Free_Trees/Meshes/Fir_Tree") as GameObject;

	public int numberOfTree01 = 1;
    public int numberOfTree02 = 20;
    public int numberOfRock01 = 20;
    public int numberOfRock02 = 20;

    private MeshCollider mc;
	private GameObject terrain;

	public ObstacleGenerator(GameObject terrain, GameObject objects)
	{
		this.terrain = terrain;
		mc = this.terrain.GetComponent<MeshCollider>();
		GenerateGameObjects(objects);

	}

	public void GenerateGameObjects(GameObject objects)
    {
        Debug.Log("Generate");
        GenerateIndividualObject(objects, numberOfTree01);
        //GenerateIndividualObject(objects, numberOfTree02);
        //GenerateIndividualObject(objects, numberOfRock01);
        //GenerateIndividualObject(objects, numberOfRock02);
    }

    private void GenerateIndividualObject(GameObject obj, int count)
    {
        if (obj == null) return;
        for (int i = 0; i < 1; i++)
        {
            GameObject temp = UnityEngine.Object.Instantiate(obj);
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
