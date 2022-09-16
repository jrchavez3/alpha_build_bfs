using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathBox : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 6) {
            other.gameObject.transform.position = new Vector2(0, 0);
        }
    }
}
