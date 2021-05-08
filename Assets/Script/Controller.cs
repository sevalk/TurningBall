using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public int startCount=0;
    int scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if(startCount == 0)
        {
            SceneManager.LoadScene(scene + 1);
        }
    }

}
