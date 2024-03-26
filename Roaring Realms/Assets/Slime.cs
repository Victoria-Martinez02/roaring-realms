using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    short hp = 25;
    short speed = 2;
    short power = 4;

    
    Transform trans;
    GameObject pc;
    ChasePlayer cp;
    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(1,100) == 100)
        {
            hp *= 4;
            speed += 1;
            power *= 2;
            trans.localScale *= 4;
        }
        cp = GetComponent<ChasePlayer>();
    }

    void Update()
    {
        if(pc == null)
            pc = GameObject.FindGameObjectWithTag("Player");
        else
            cp.Chase(pc, GetComponent<SpriteRenderer>(), speed);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.GetComponent<PlayerCharacter>() != null)
        {
            col.GetComponent<PlayerCharacter>().TakeDamage(power);
        } 
    }

    public void RecieveDamage(short pow)
    {
        hp -= pow;
        Debug.Log(hp);
        if(hp <=  0)
            Destroy(this.gameObject);
    }
}
