using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gold : MonoBehaviour
{
    [SerializeField] PlayerCharacter pc;
    [SerializeField] TextMeshProUGUI gold;
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
