using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Spawns;

    public void Spawn(GameObject Zombie)
    {
        int number = Random.Range(0, Spawns.Length);

        Instantiate(Zombie, Spawns[number].transform.position, Zombie.transform.rotation);
    }
}
