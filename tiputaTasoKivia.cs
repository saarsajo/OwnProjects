using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiputaTasoKivia : MonoBehaviour
{
    public GameObject tasokiviPrafab;
    public float tiputusAika = 1.0f;
    private Vector2 ruudunRajat;

    void Start(){
        ruudunRajat = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(tasoKivienTiputusKutsu());
    }


    private void tiputaKivi(){
        GameObject tasokivi = Instantiate(tasokiviPrafab) as GameObject;
        tasokivi.transform.position = new Vector2(Random.Range(0, ruudunRajat.x), ruudunRajat.y);
    }
    

    IEnumerator tasoKivienTiputusKutsu()
    {
        while (true) {
            yield return new WaitForSeconds(tiputusAika);
            tiputaKivi();
        }
    }
}
