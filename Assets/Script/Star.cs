using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    Controller controller;

    private void Awake()
    {
        controller = FindObjectOfType<Controller>();
        controller.startCount++;
    }
   
}
