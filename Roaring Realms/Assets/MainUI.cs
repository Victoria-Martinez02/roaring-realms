using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    Canvas can;
    // Start is called before the first frame update
    public static MainUI singleton;

    void Awake()
    {
        if(singleton != null)
        {
            DestroyImmediate(this.gameObject);
        }
        singleton = this;
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        can = GetComponent<Canvas>();
    }

    void Update()
    {
        if(can.worldCamera == null)
            FindCamera();
    }

    void FindCamera()
    {
        while(can.worldCamera == null)
        {
            can.worldCamera = FindObjectOfType<Camera>();
        }
    }
}
