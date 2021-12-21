using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject Obstacle;
    public GameObject Obstacle1;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        int randomV = Random.Range(0,2);
        
        
        switch(randomV)
        {
         case 0:
         Instantiate(Obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
         break;

         case 1:
         Instantiate(Obstacle1, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
         break;

        }
    }
}
