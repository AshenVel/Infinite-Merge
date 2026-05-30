using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SpellAccessManager : MonoBehaviour
{
    public GameObject FireBall;
    public GameObject FireLaser;
    public GameObject FireMeteor;
    public GameObject FireStorm;

    public GameObject IceBall;
    public GameObject IceLaser;
    public GameObject IceMeteor;
    public GameObject IceStorm;

    public GameObject ThunderBall;
    public GameObject ThunderLaser;
    public GameObject ThunderMeteor;
    public GameObject ThunderStorm;

    private List<GameObject> Now = new List<GameObject>();

    private List<GameObject> Level1 = new List<GameObject>();
    private List<GameObject> Level5 = new List<GameObject>();
    private List<GameObject> Level10 = new List<GameObject>();

    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;
    //public GameObject Spawner4;

    private List<GameObject> ListeSpells = new List<GameObject>();

    private List<GameObject> ListeSpawners = new List<GameObject>();

    private GameObject Player;

    public GameObject KillSpell;




    private void Start()
    {
        Player = GameObject.Find("Player");

        ListeSpawners.AddRange(new GameObject[] { Spawner1, Spawner2, Spawner3});

        Now= new List<GameObject>(Level1);
        Level1.AddRange(new GameObject[] { FireBall, FireLaser, FireMeteor, FireStorm });
        Level5.AddRange(new GameObject[] { FireBall, FireLaser, FireMeteor, FireStorm, IceBall,IceLaser,IceMeteor,IceStorm});
        Level10.AddRange(new GameObject[] { FireBall, FireLaser, FireMeteor, FireStorm, IceBall, IceLaser, IceMeteor, IceStorm, ThunderBall, ThunderLaser, ThunderMeteor, ThunderStorm });

        NewSpells();
    }

    public void NewSpells()
    {
        if (Player.GetComponent<PlayerManager>().Level < 5)
        {
            Now = new List<GameObject>(Level1);
        }
        else if (Player.GetComponent<PlayerManager>().Level < 10)
        {
            Now = new List<GameObject>(Level5);
        }
        else
        {
            Now = new List<GameObject>(Level10);
        }

        foreach (GameObject spawn in ListeSpawners)
        {
            int number = Random.Range(0,Now.Count);

            Instantiate(Now[number],spawn.transform.position, Now[number].transform.rotation);

            ListeSpells.Add(Now[number]);

            Now.Remove(Now[number]);
        }
    }
    public void ClearSpells()
    {
        for (int i = 0; KillSpell.GetComponent<KillSpell>().Spells.Count > 0; i++)
        {
            GameObject Spell = KillSpell.GetComponent<KillSpell>().Spells[0];
            Spell.transform.position = new Vector3(111110,11110,0);
            Destroy(Spell);
        }
    }

}
