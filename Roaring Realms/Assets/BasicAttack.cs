using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    short pow = 5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.3f);
    }
    public void BaseAttack(Vector3 position)
    {
        Instantiate(GetComponent<BasicAttack>(), position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<Slime>() != null)
        {
            col.GetComponent<Slime>().RecieveDamage(pow);
        }
    }
}
