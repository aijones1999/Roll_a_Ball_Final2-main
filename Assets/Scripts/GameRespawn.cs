using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;

   void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3((float)-6.65, (float)0.752, -8);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
