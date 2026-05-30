using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    private GameObject Player;

    public GameObject ZombieClassique;
    public GameObject ZombieBoom;
    public GameObject ZombieTank;
    public GameObject ZombieSpeed;

    public GameObject Spawner;

    public int ZombieKilledAllTime;

    private List<int> TypeZombie = new List<int>();
    private List<int> TypeZombie5 = new List<int>();
    private List<int> TypeZombie10 = new List<int>();
    private List<int> TypeZombie7 = new List<int>();

    private void Start()
    {
        ZombieKilledAllTime = 1;

        Player = GameObject.Find("Player");
        // 0 : ZombieClassique 1 : ZombieSpeed 2 : ZombieTank 3 : ZombieBoom
        TypeZombie.AddRange(new int[] {100,0,0,0});
        TypeZombie5.AddRange(new int[] {90,100,0,0});
        TypeZombie10.AddRange(new int[] {60,85,95,100});
        TypeZombie7.AddRange(new int[] {60,80,0,100});
    }
    public void StarterWave()
    {
        ZombieKilledAllTime += Player.GetComponent<PlayerManager>().Wave * 7 + 1;

        int nbZombie = Player.GetComponent<PlayerManager>().Wave * 7 + 1;

        if(Player.GetComponent<PlayerManager>().Wave == 5)
        {
            TypeZombie = new List<int>(TypeZombie5);
        }
        if (Player.GetComponent<PlayerManager>().Wave == 10)
        {
            TypeZombie = new List<int>(TypeZombie10);
        }
        if (Player.GetComponent<PlayerManager>().Wave == 7)
        {
            TypeZombie = new List<int>(TypeZombie7);
        }
        StartCoroutine(Spawns(nbZombie));
    }

    private IEnumerator Spawns(int NbZombie)
    {
        int compteur = 0;
        for (int i = 0; i < NbZombie; i++)
        {
            if(compteur >= 10)
                {
                    compteur = 0;
                    yield return new WaitForSeconds(1);
                }

            int type = Random.Range(0, 101);

            if (type <= TypeZombie[0])
                {
                    Spawner.GetComponent<Spawner>().Spawn(ZombieClassique);
                }
            else if(type <= TypeZombie[1])
                {
                    Spawner.GetComponent<Spawner>().Spawn(ZombieSpeed);
                }
            else if (type <= TypeZombie[2])
                {
                    Spawner.GetComponent<Spawner>().Spawn(ZombieTank);
                }
            else if (type <= TypeZombie[3])
                {
                    Spawner.GetComponent<Spawner>().Spawn(ZombieBoom);
                }

            compteur++;
        }

    }

    private void Update()
    {
        if (Player.GetComponent<PlayerManager>().ZombieKilled >= ZombieKilledAllTime) 
        {
            Player.GetComponent<PlayerManager>().Wave++;
            StarterWave();
        }
    }
}


