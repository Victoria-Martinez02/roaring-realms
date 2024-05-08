using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gold : MonoBehaviour
{
    [SerializeField] PlayerCharacter pc;
    [SerializeField] TextMeshProUGUI gold;

    public static Gold singleton;

    void Awake()
    {
        if(singleton != null)
        {
            Destroy(this.gameObject);
        }
        singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gold.text = pc.gold.ToString();
    }

    public void UpdateGold()
    {
        gold.text = pc.gold.ToString();
    }
}
