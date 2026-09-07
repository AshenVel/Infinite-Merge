using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour
{
    private bool FireCooldownAct = false;
    private bool IceCooldownAct = false;
    private bool ThunderCooldownAct = false;
    private float ThunderCooldown = 0;
    private float FireCooldown = 0;
    private float BackupSpeed;


    public void ApplyEffect(string effect)
    {
        if(effect == "fire")
        {
            Fire();
        }
        if(effect == "ice")
        {
            Ice();
        }
        if(effect == "thunder")
        {
            Thunder();
        }
    }

    private void Fire()
    {
        if (!FireCooldownAct)
        {
            StartCoroutine(FireStartCooldown());
        }
    }
    private void Ice()
    {
        if (!IceCooldownAct)
        {
            StartCoroutine(IceStartCooldown());
        }
    }
    private void Thunder()
    {
        if (!ThunderCooldownAct)
        {
            StartCoroutine(ThunderStartCooldown());
        }
    }

    private IEnumerator FireStartCooldown()
    {
        FireCooldownAct = true;
        yield return new WaitForSeconds(3f);
        FireCooldownAct = false;
    }

    private IEnumerator IceStartCooldown()
    {
        GetComponent<ZombieScript>().Speed = GetComponent<ZombieScript>().Speed * 0.5f;
        IceCooldownAct = true;
        yield return new WaitForSeconds(3f);
        IceCooldownAct = false;
        GetComponent<ZombieScript>().Speed = GetComponent<ZombieScript>().Speed * 2f;
    }

    private IEnumerator ThunderStartCooldown()
    {
        BackupSpeed = GetComponent<ZombieScript>().Speed;
        GetComponent<ZombieScript>().Speed = 0;
        ThunderCooldownAct = true;
        yield return new WaitForSeconds(3f);
        ThunderCooldownAct = false;
        GetComponent<ZombieScript>().Speed = BackupSpeed;
    }

    private void Update()
    {
        if (FireCooldownAct)
        {
            FireCooldown += Time.deltaTime;
            if (FireCooldown >= 0.5f)
            {
                GetComponent<HealthManager>().TakeDamage(2);
                FireCooldown = 0;
            }
        }

        if (ThunderCooldownAct)
        {
            ThunderCooldown += Time.deltaTime;
            if (ThunderCooldown >= 0.5f)
            {
                GetComponent<HealthManager>().TakeDamage(1);
                ThunderCooldown = 0;
            }
        }
    }

}
