using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    //https://www.youtube.com/watch?v=yTL0V6LNHR8&list=LL&index=3

    public float PullRadius;
    public float GravitationalPull;
    public float MinRadius;
    public float DistanceMultiplyer;
    public LayerMask LayersToPull;

    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, PullRadius, LayersToPull);

        foreach(var collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector3 direction = transform.position - collider.transform.position;
                //Debug.Log(direction.magnitude);
                if (direction.magnitude > MinRadius)
                { 
                    float distance = direction.sqrMagnitude * DistanceMultiplyer + 1;
                    rb.AddForce(direction.normalized * (GravitationalPull / distance) * rb.mass * Time.deltaTime);
                }
                
            }
            
            
        }
    }
}
