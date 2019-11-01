using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



using Random = UnityEngine.Random;
public class EnemySpawnner : MonoBehaviour
{
    public Transform floorPlain;
    Transform parentObj;

    float spawnHeight;
    float counter;
   
    // Start is called before the first frame update
    void Start()
    {
        
        parentObj = gameObject.transform;
    }

    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            counter = 2;
            CreateEnemy();
        }
     
    }
    private void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(Random.Range(0,3), 0, Random.Range(0, 3)).normalized*Time.deltaTime;
    }
    void CreateEnemy()
    {
            bool validSpot = false;
            Vector3 spawnLoc = RandomSpot();
            Vector3 size = Vector3.one * Random.Range(.5f, 7);
            Vector3 dir = new Vector3(1, 0, 1); 
        while (!validSpot)
        {
            if (Physics.OverlapBox(spawnLoc, size / 2, Quaternion.identity, LayerMask.GetMask("Player", "Enemy","Walls")).Length < 0) ;
            {
              
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"));
                go.transform.localScale = size;
                go.transform.position = spawnLoc;
                go.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
                go.transform.SetParent(parentObj);
            
                dir = dir.normalized;
                Rigidbody rb = go.GetComponent<Rigidbody>();
                rb.velocity = dir * 10;

                validSpot = true;

            }
         
        }
    }
    Vector3 RandomSpot()
    {

        return new Vector3(Random.Range(-floorPlain.localScale.x / 2, floorPlain.localScale.x / 2) * 10,
        1,
        Random.Range(-floorPlain.localScale.z / 2, floorPlain.localScale.x / 2) * 10) + floorPlain.transform.position;
    }
   
  
}
