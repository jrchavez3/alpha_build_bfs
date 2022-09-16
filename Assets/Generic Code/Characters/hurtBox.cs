using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtBox : MonoBehaviour
{
     CompositeCollider2D hitbox;
    Rigidbody2D rb;
    public float defense;
    
    public float kBM = 0;
    public float health;


    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<CompositeCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool hit(float damage, float kBPower, float kBMinc, double hitStun, GameObject attacker) {
        health -= damage / defense;
        float vX = transform.position.x - attacker.transform.position.x;
        float vY = transform.position.y - attacker.transform.position.y;
        float n = Mathf.Sqrt(vX * vX + vY * vY); 
        rb.AddForce(new Vector2(vX, vY) / n * kBPower * (kBM + 1) / defense, ForceMode2D.Impulse);
        kBM += kBMinc;
        return true;
    }

    public bool hit(float angle, float damage, float kBPower, float kBMinc, double hitStun, GameObject attacker) {
        health -= damage / defense;
        angle *= (Mathf.PI / 180);
        rb.AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * kBPower * (kBM + 1) / defense, ForceMode2D.Impulse);
        kBM += kBMinc;
        return true;
    }
}
