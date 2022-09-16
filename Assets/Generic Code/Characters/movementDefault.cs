using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementDefault : MonoBehaviour
{
    public float[] fallSpeed, lowFallSpeed, jumpSpeed;
    public float walkSpeed, runSpeed;
    public int maxJumps;
    private int jumps;
    Rigidbody2D rb;
    Collider2D physCol;
    Animator anim;
    
    [SerializeField] private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        physCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = walkSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
            speed = runSpeed;
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0) * Time.deltaTime * speed;
        anim.SetBool("walking", Input.GetAxis("Horizontal") != 0);

        if (physCol.IsTouchingLayers(1 << 3) && !Input.GetKey(KeyCode.W))
            jumps = maxJumps;


        //jump
        if (Input.GetKeyDown(KeyCode.W) && jumps > 0) 
        { jumps--; rb.velocity = Vector2.up * jumpSpeed[jumps]; }

        if (rb.velocity.y < 0 && jumps == maxJumps)
            jumps--;

        //gravity modifiers
        if (rb.velocity.y < 0) 
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallSpeed[jumps] - 1) * Time.deltaTime;
        //when in range (rising peak) and s do slowfall
        else if (rb.velocity.y > -15 && rb.velocity.y < 5 && Input.GetKeyDown(KeyCode.S))
            rb.velocity += Vector2.up * Physics2D.gravity.y * 2;
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W)) 
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowFallSpeed[jumps] - 1) * Time.deltaTime;
        Vector3 mosPos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        float yrot = 0;
        if (mosPos.x - transform.position.x < 0) 
            yrot = 180;
        transform.rotation = Quaternion.Euler(transform.rotation.x, yrot, transform.rotation.z);

    }
}
