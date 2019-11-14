using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ohjelma aluksen liikuttamiseen avaruudessa
/// </summary>
public class playerMove : MonoBehaviour
{

    CharacterController charcontrol;
    public float speed = 15f;
    public Transform ship;
    float pitch = 0f;
    public float mouseSpeed = 1f;

    void Start()
    {
        charcontrol = GetComponent<CharacterController>();
    }

    /// <summary>
    /// Kuunnellaan käyttäjän inputtia.
    /// Liikutetaan alusta syötteen mukaiseen suuntaan * deltaTime * Määritetty nopeus
    /// deltaTimea käytetään liikkeen sulavuuden parantamiseen
    /// </summary>
    void Update()
    {
        //Hiiren liikkeet X akselilta
        float xMouse = Input.GetAxis("Mouse X") * mouseSpeed;
        transform.Rotate(0, xMouse, 0);

        //Hiiren liikkeet Y akselilta -45asteen ja 45 asteen väliltä... Mieti vaihtaako public floatiksi?
        pitch -= Input.GetAxis("Mouse Y") * mouseSpeed;
        pitch = Mathf.Clamp(pitch, -45f, 45f);
        Quaternion shipRotation = Quaternion.Euler(pitch, 0, 0);
        ship.localRotation = shipRotation;

        //Näppäin liikkeet
        float xInput = Input.GetAxis("Horizontal") * speed;
        float zInput = Input.GetAxis("Vertical") * speed;

        //Tarkastaa ollaanko liikkeessä x tai z akselilla, jottei alus liiku pelkästään hiirtä osoittamalla. Tarkastaa myös mennäänkö etu vai takaperin, joka vaikuttaa kumpaan suuntaan alus ohjautuu y akselilla.
        if (xInput != 0 || zInput > 0)
        {
            Vector3 move = new Vector3(xInput, pitch * (-1) / 2, zInput);
            moveShip(move);
        }

        if (xInput != 0 || zInput < 0)
        {
            Vector3 move = new Vector3(xInput, pitch / 2, zInput);
            moveShip(move);
        }
    }

    /// <summary>
    /// Hoitaa aluksen konkreettisen liikuttamisen.
    /// </summary>
    /// <param name="move"></param>
    private void moveShip (Vector3 move)
    {
        move = Vector3.ClampMagnitude(move, speed);

        //Muuttaa akselia suhteessa alukseen, jotta hiirellä osoitettu suunta on esim eteenpäin
        move = transform.TransformVector(move);
        charcontrol.Move((move) * Time.deltaTime * speed);
    }
}