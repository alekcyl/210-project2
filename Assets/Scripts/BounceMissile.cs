using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMissile : MonoBehaviour
{
    
    public ParticleSystem explosion;

    private void Start()
    {
    }


    void FixedUpdate()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        
    }
}
