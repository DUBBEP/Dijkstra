using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnBehaviorScene()
    {
        SceneManager.LoadScene(1);
    }
    public void OnCollisionAvoidance()
    {
        SceneManager.LoadScene(2);
    }
    public void onDuckHuntScene()
    {
        SceneManager.LoadScene(3);
    }
    public void OnFlockDemoScene()
    {
        SceneManager.LoadScene(4);
    }
    public void OnMazeScene()
    {
        SceneManager.LoadScene(5);
    }
}
