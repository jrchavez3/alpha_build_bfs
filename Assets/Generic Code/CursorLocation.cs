using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLocation : MonoBehaviour
{

    [SerializeField] private Camera mainCam;
    CircleCollider2D cursorBox;
    public Collider2D[] collisionList;
    // Start is called before the first frame update
    void Start() {
        cursorBox = GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
