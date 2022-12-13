using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float destroyTimerMax;
    private float destroyTimerCur;
    private bool setDestroy;
    public ParticleSystem explosion;
    
    private void Start()
    {
        destroyTimerCur = destroyTimerMax;
        setDestroy = false;
    }

   
    void FixedUpdate()
    {
        //on collision start timer to blow up
        if (setDestroy)
        {
            destroyTimerCur -= .1f;
            if (destroyTimerCur <= 0)
            {
                Destroy(gameObject);
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //create explosion
        Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
        setDestroy = true;
    }
}
