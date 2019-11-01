using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEat : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
       GameObject go = FindObjectOfType<GameObject>();
        Debug.Log(go.name);
       float x= Mathf.Pow(go.transform.localScale.x,1);
        float y = Mathf.Pow(go.transform.localScale.y, 1);
        float z = Mathf.Pow(go.transform.localScale.z, 1);
        float volume = x * y * z;
        Debug.Log(volume);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
}
