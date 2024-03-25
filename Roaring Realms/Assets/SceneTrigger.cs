using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] string scene;
    [SerializeField] bool door;

    void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene(scene);
    }
}
