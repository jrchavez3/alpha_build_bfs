using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public Tools() {}

    public static GameObject[] FindObjectsOnLayer(int Layer) {
        GameObject[] all = FindObjectsOfType<GameObject>(false);
        List<GameObject> found = new List<GameObject>();
        for (int i = 0; i < all.Length; i++) {
            if (all[i].layer == Layer) 
                found.Add(all[i]);
        }
        return found.ToArray();
    }
}
