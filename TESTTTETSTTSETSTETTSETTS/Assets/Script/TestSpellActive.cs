using UnityEngine;

public class TestSpellActive : MonoBehaviour
{
    public string Type;
    public string Effect;

    public GameObject Player;


    public void FEU()
    {
        Player.GetComponent<SpellsManager>().SpellLauncher(Type, Effect);
    }

    
}
