using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 bullet;
    Vector3 hedef;

    [SerializeField] Transform ball;

    [SerializeField] Transform Gun;

    int level;

    [Header("Shooting")]
    [SerializeField]float shotCounter = 1f; // serializefield kontrol için sonra sil
    //[SerializeField] float minTimeBetweenShots = 0.2f;
    //[SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    //[SerializeField] float projectileSpeed = 10f;
    UI uý;

    private void Awake()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        shotCounter = 1f - ((float)level * 0.05f);
        
    }
    void Start()
    {

        uý = FindObjectOfType<UI>();
        hedef.x = 0f;
        hedef.y = 0f;
        hedef.z = 0f;
       // shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        if (uý.isStart)
        {
            CountDownAndShoot();
        }
        
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            
            Fire();
            // shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
            shotCounter = 1f - ((float)level * 0.08f);
        }
    }

    private void Fire()
    {
        //  hedef.x = Random.Range(-30,30);
        // hedef.z = Random.Range(-30,30);

        hedef.x = Random.Range(ball.position.x +2f , ball.position.x + 4f);
        hedef.z = Random.Range(ball.position.z +2f, ball.position.z + 4f);
        
        GameObject laser = Instantiate(
            projectile,
            Gun.position,
            Quaternion.identity
            ) as GameObject;
        laser.GetComponent<Rigidbody>().velocity = hedef * (1f +((float)level * 0.4f));
        Destroy(laser, 0.9f);
    }

}
