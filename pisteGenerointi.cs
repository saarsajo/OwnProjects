using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pisteGenerointi : MonoBehaviour
{
    public float nopeus = 10.0f;
    private Rigidbody2D tasokivi;
    private Vector2 ruudunRajat;


    void Start()
    {
        tasokivi = this.GetComponent<Rigidbody2D>();
        tasokivi.velocity = new Vector2(0, -nopeus);
        ruudunRajat = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    void Update()
    {
        if(transform.position.y < ruudunRajat.y * -2)
        {
            Destroy(this.gameObject);
        }
    }
}
