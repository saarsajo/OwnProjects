using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ohjelma jolla luodaan auringolle ja planeetoille vetovoima, joka kasvaa massan mukaisesti
/// </summary>
public class Attractor : MonoBehaviour
{
    const float G = 0.6674f;
    public Rigidbody rb;

    private void FixedUpdate()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach (Attractor attractor in attractors)
        {
            if (attractor != this)
            {
                Attract(attractor);
            }
        }
    }

    /// <summary>
    /// Aliohjelma vetovoiman toteuttamiseen
    /// Massa vaikuttaa vetovoiman suuruuteen
    /// Vetovoiman voimakkain suunta on objekti jolla on isoin massa
    /// </summary>
    /// <param name="objToAttract"></param>

    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = G* (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
