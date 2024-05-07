using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] PlayerCharacter pc;
    [SerializeField] BasicAttack ba;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;
        
        if(Input.GetKeyDown(KeyCode.Escape))
            SettingsManager.singleton.ToggleOptions();
        if(!Clock.singleton.timePaused)
        {
            if(Input.GetKey(KeyCode.W)){
                input.y += 1;
            }
            if(Input.GetKey(KeyCode.S)){
                input.y -= 1;
            }
            if(Input.GetKey(KeyCode.A)){
                input.x  -= 1;
            }
            if(Input.GetKey(KeyCode.D)){
                input.x  += 1;
            }
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                pc.run = !pc.run;
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 trans = pc.transform.position;
                trans.x += pc.GetComponent<SpriteRenderer>().flipX ? -1.5f : 1.5f;
                ba.BaseAttack(trans);
            }

            pc.MovePC(input);
        }
    }
}
