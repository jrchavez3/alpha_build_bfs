using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public CircleCollider2D[] hitboxes;
    public KeyCode input;
    public Animation anim;
    public float damage, knockback, knockbackInc, hitStun;

    public List<hurtBox> checkHitboxes() {
        ContactFilter2D filter = new ContactFilter2D(); filter.layerMask = 6;
        Collider2D[] temp = {};
        List<hurtBox> hitList = new List<hurtBox>();
        for (int i = 0; i < hitboxes.Length; i++) {
            hitboxes[i].OverlapCollider(filter, temp);
            for (int j = 0; j < temp.Length; j++) {
                if (temp[j].gameObject.transform.root.gameObject != transform.root.gameObject)
                    hitList.Add(temp[j].gameObject.transform.root.gameObject.GetComponent<hurtBox>());
            }
        }
        return hitList;
    }
}
