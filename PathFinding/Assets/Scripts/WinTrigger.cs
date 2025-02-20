using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Flocker")
        {
            WinGame();
        }
    }

    void WinGame()
    {
        winScreen.SetActive(true);
    }
}
