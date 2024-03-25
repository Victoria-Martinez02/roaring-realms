using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] PlayerCharacter pc;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = pc.transform.position + new Vector3(0, 1, -5);
        transform.position = new Vector3(Mathf.Clamp(newPosition.x, minX, maxX),Mathf.Clamp(newPosition.y, minY, maxY), -5f);
    }
}
