using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float destroyTimerMax;
    private float destroyTimerCur;
    private bool setDestroy;
    
    private void Start()
    {
        destroyTimerCur = destroyTimerMax;
        setDestroy = false;
    }

   
    void FixedUpdate()
    {
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
        setDestroy = true;
    }
}
