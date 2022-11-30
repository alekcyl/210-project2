using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject Missile;
    public GameObject Missile2;
    public float MissileSpeed;



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(Missile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0,0,-90)));

            
            shot.GetComponent<Rigidbody2D>().AddForce(new Vector2(MissileSpeed, 0));

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject shot = Instantiate(Missile2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, -90)));


            shot.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 0));

        }

        float movementInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(0, movementInput, 0);

        
    }

}
