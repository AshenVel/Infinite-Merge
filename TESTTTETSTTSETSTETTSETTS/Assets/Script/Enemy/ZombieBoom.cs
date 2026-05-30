using System;
using UnityEngine;

public class ZombieBoom : MonoBehaviour
{

    public GameObject Boom;
    private void Update()
    {
        if (GetComponent<ZombieScript>().PV < 0)
        {
            Instantiate(Boom, transform.position, Boom.transform.rotation);
            Destroy(gameObject);
        }
    }
}
