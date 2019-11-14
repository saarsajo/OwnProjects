using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sydamet : MonoBehaviour
{
    private Rigidbody2D pelaajaHahmo;

    public int hp;
    public int hpMaara;
    public int vahinko = 1;

    public Image[] sydammet;
    public Sprite taysiSydan;
    public Sprite tyhjaSydan;


    void Start()
    {
        pelaajaHahmo = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (hp > hpMaara)
        {
            hp = hpMaara;
        }


        for (int i = 0; i < sydammet.Length; i++)
        {
            if(i < hp)
            {
                sydammet[i].sprite = taysiSydan;
            }
            else
            {
                sydammet[i].sprite = tyhjaSydan;
            }


            if (i < hpMaara)
            {
                sydammet[i].enabled = true;
            }
            else
            {
                sydammet[i].enabled = false;
            }
        }
    }

    void tormaysHandleri(Collision _tormays)
    {
        if (_tormays.gameObject.tag=="tulikivi")
        {
            print("PERKELE TULI DAMAGEE");
            hpMaara = hpMaara - vahinko;
        }
    }
}
