using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Finished.");
        Invoke("ReloadScene",delayTime);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
