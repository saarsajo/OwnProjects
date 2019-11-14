using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelaajaTormaaHandler : MonoBehaviour
{
    public GameObject kallo;
    private float ajastimenAika = 1.0f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Tormays toimii");
        GameObject kal = Instantiate(kallo) as GameObject;
        Destroy(other.gameObject);
        kal.transform.position = transform.position;
    }
}
