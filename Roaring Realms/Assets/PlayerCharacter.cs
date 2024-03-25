using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] float speed = 4f;

    [SerializeField] short health = 100;
    [SerializeField] short stamina = 300;
    [SerializeField] int gold = 500;

    Rigidbody2D pc;
    SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePC(Vector3 direction)
    {
        if(direction.x < 0 && !sr.flipX)
        {
            sr.flipX = !sr.flipX;
        }
        if(direction.x > 0 && sr.flipX)
        {
            sr.flipX = !sr.flipX;
        }
        pc.velocity = direction * speed;
    }
}
