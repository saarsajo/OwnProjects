using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbiteAround : MonoBehaviour
{
    public GameObject sun;
    public float speed;
    public float direction = 0;
    void Update()
    {
        OrbitAround();
    }

    //Voidaan muokata Unityn sisällä mihin suuntaan planeetta pyörii
    void OrbitAround ()
    {
        if (direction == 0) {
            transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
        }


        if (direction > 0)
        {
            transform.RotateAround(sun.transform.position, Vector3.right, speed * Time.deltaTime);
        }


        if (direction < 0)
        {
            transform.RotateAround(sun.transform.position, Vector3.down, speed * Time.deltaTime);
        }


    }
}
