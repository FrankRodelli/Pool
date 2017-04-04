using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name != "cueball" || collision.gameObject.name != "8Ball")
        {
            Destroy(collision.gameObject);
        }
        
    }
}
