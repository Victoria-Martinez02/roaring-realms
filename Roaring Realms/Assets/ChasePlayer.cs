using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] GameObject pc;
    public SpriteRenderer sr;
    float distance;
    // Start is called before the first frame update

    // Update is called once per frame
    public void Chase(GameObject pc, SpriteRenderer sr, short speed)
    {
        if(sr != null && pc != null)
        {
            distance = Vector2.Distance(transform.position, pc.transform.position);

            if(distance < 5)
                transform.position = Vector2.MoveTowards(transform.position, pc.transform.position, speed * Time.deltaTime);

            //sr.flipX = rb.velocity.x < 0;
        }
    }
}
