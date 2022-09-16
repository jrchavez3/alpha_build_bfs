using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorFollow : MonoBehaviour
{
    public GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {   

        float a = cursor.transform.position.y - transform.position.y;
        float b = cursor.transform.position.x - transform.position.x; 
        float zrot = Mathf.Atan2(a, b) * (180 / Mathf.PI);
        transform.rotation = Quaternion.Euler(transform.rotation.x, 
            transform.parent.transform.parent.transform.rotation.y * 180, (zrot + 90) * Mathf.Sign(b));
        
    }
}
