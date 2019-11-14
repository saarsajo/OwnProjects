using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hyppyControl : MonoBehaviour {

    private Rigidbody2D pelaajaHahmo;
    public float nopeus;
    public float hypynVoima;
    private float pelaajanSyote;
    private bool onkoMaassa;
    public Transform asento;
    public float kulmanTarkastaja;
    public LayerMask maanTunnistus;

    private float hyppyAjanLaskuri;
    public float hyppyAika;
    private bool onHyppaamassa;

    public GameObject nuoli;
    public Vector3 nuolenPaikka;


    void Start()
    {
        pelaajaHahmo = GetComponent<Rigidbody2D>();
        nuoli = GameObject.FindWithTag("nuoli");
    }


    void Update()
    {
        //Tarkastaa ollaanko tasolla
        onkoMaassa = Physics2D.OverlapCircle(asento.position, kulmanTarkastaja, maanTunnistus);
        //Täällä yritän saada nuolen paikkaa///////////////////////////////////////////////////////////
        nuolenPaikka = nuoli.transform.position;

        //Handlataan hyppely
        if (onkoMaassa == true && Input.GetKeyDown(KeyCode.Space)){
            aaniManager.soitaAanet("hyppy");
            onHyppaamassa = true;
            hyppyAjanLaskuri = hyppyAika;

            //TÄSSÄ ON AINAKIN JOTAIN VIALLA////////////////////////////////////////////////////
            pelaajaHahmo.AddForce(nuolenPaikka * hypynVoima);
        }


        //Määrittää hypyn korkeuden nappulan painon ajan mukaan
        if (Input.GetKey(KeyCode.Space) && onHyppaamassa == true)
        {
            if (hyppyAjanLaskuri > 0)
            {
                pelaajaHahmo.AddForce(-nuolenPaikka * hypynVoima);
                hyppyAjanLaskuri -= Time.deltaTime;
            }
            else {
                onHyppaamassa = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            onHyppaamassa = false;
        }
    }
}
