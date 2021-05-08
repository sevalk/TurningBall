using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject topToStart;
    [SerializeField] ChaScript Girl;
    [SerializeField] Player Ship;
    public bool isStart = false;
    float speed = 40f;
    [SerializeField] Text levelText;
    int level;

    private void Awake()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        levelText.text = "LEVEL " + level.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        Girl.anim.SetBool("Attack", false);
        speed = 40f + (level * 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            topToStart.SetActive(false);
            Girl.anim.SetBool("Attack", true);
            Ship.speed = speed;
            isStart = true;
        }

    }
}

