using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] short maxHealth = 100;
    [SerializeField] short maxStamina = 300;
    
    [SerializeField] public int gold = 500;
    short curHealth;
    short curStamina;
    short iFrames;

    bool spDepleted = false;
    public bool run = false;

    Rigidbody2D pc;
    SpriteRenderer sr;
    
    [SerializeField] HealthBar hb;
    [SerializeField] StaminaBar sb;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        curStamina = maxStamina;
        //set hb max health

        pc = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        hb.SetMaxHP(maxHealth);
        sb.SetMaxSP(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        if(iFrames >= 0) iFrames -=1; 
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
        pc.velocity = run ? direction * (speed + 3) : direction * speed;
    }

    public void TakeDamage(short dmg)
    {   
        if(iFrames > 0) return;
        curHealth -= dmg;
        hb.UpdateHP(curHealth);
        iFrames = 5;
    }

    public void LoseStamina(short stam)
    {
        if(spDepleted)
            TakeDamage(stam);
        else
        {
            spDepleted = curStamina <= 0;
            curStamina -= spDepleted ? (short) 0 : stam;
            sb.UpdateSP(curStamina); 
        }
    }
}
