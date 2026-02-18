using Unity.VisualScripting;
using UnityEngine;

public class TESTSPELL : MonoBehaviour
{
    public GameObject Zombie;

    public string SpellName;

    public void UseSpell()
    {
        if(SpellName == "fire")
        {
            Zombie.GetComponent<EffectManager>().ApplyEffect(SpellName);    
        }
        if (SpellName == "ice")
        {
            Zombie.GetComponent<EffectManager>().ApplyEffect(SpellName);
        }
        if (SpellName == "thunder")
        {
            Zombie.GetComponent<EffectManager>().ApplyEffect(SpellName);
        }

    }
}
