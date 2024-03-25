using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] PlayerCharacter pc;
    Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = pc.transform.position + new Vector3(0, 1, -5);
        transform.position = new Vector3(Mathf.Clamp(newPosition.x, -1.75f, 4.5f),newPosition.y, -5f);
    }
}
