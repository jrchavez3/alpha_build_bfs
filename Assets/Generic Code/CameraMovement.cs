using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public List<GameObject> focusObjects;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] temp = Tools.FindObjectsOnLayer(6);
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].transform.parent == null)
                focusObjects.Add(temp[i]);
        }
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 max = focusObjects[0].transform.position, min = focusObjects[0].transform.position;
        for (int i = 0; i < focusObjects.Count; i++) {
            if (focusObjects[i].transform.position.x < min.x)
                min = focusObjects[i].transform.position;
            if (focusObjects[i].transform.position.x > max.x)
                max = focusObjects[i].transform.position;
        }
        float Xaverage = ((min.x) + (max.x)) / 2;
        float Yaverage = ((min.y) + (max.y)) / 2;
        float dist = Mathf.Sqrt((max.x - min.x) * (max.x - min.x) + (max.y - min.y) * (max.y - min.y));

        transform.position = new Vector3(Xaverage, Yaverage + 2, transform.position.z);
        cam.orthographicSize = 3f + dist / 3;
    }
}
