using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject pivot;
    
    public float speed=0f;

    public bool isAlive = true;

    Controller controller;

    private void Start()
    {
        controller = FindObjectOfType<Controller>();
        
    }

    void Update()
    {
        pivot.transform.Rotate(0,speed * Time.deltaTime,0);
       // this.transform.Rotate(0, 5f * Time.deltaTime, 0);

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = speed * -1f;
            this.transform.Rotate(0, 180, 0);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
            isAlive = false;

            int x = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(x);
        }
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
            controller.startCount--;
        }
    }
}
