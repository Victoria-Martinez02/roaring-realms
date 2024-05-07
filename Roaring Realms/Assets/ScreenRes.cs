using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenRes : MonoBehaviour
{
    [SerializeField] SettingsManager sm;
    [SerializeField] ScreenRes sr;
    TMP_Dropdown drop;
    Toggle tog;

    // Start is called before the first frame update
    void Start()
    {
        tog = FindObjectOfType<Toggle>().GetComponent<Toggle>();
        drop = sr.GetComponent<TMP_Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        drop.onValueChanged.AddListener(delegate {
            DropdownValueChanged(drop.value);
        });
        tog.onValueChanged.AddListener(delegate {
            ToggleValueChanged(tog.isOn);
        });
    }


    void DropdownValueChanged(int val)
    {
        //sm.ChangeResolution(val);
    }

    void ToggleValueChanged(bool on)
    {
        //sm.ChangeView(on);
    }
}
