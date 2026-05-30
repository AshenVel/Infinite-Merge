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

    public float DamageFire = 2f;
    public float DamageThunder = 1f;

    public float TimeFire = 3f;
    public float TimeThunder = 3f;
    public float TimeIce = 3f;

    public float StrIce = 0.5f;


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
        yield return new WaitForSeconds(TimeFire);
        FireCooldownAct = false;
    }

    private IEnumerator IceStartCooldown()
    {
        BackupSpeed = GetComponent<ZombieScript>().Speed;
        GetComponent<ZombieScript>().Speed = GetComponent<ZombieScript>().Speed * StrIce;
        IceCooldownAct = true;
        yield return new WaitForSeconds(TimeIce);
        IceCooldownAct = false;
        GetComponent<ZombieScript>().Speed = GetComponent<ZombieScript>().Speed / StrIce;
    }

    private IEnumerator ThunderStartCooldown()
    {
        BackupSpeed = GetComponent<ZombieScript>().Speed;
        GetComponent<ZombieScript>().Speed = 0;
        ThunderCooldownAct = true;
        yield return new WaitForSeconds(TimeThunder);
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
                GetComponent<HealthManager>().TakeDamage(DamageFire);
                FireCooldown = 0;
            }
        }

        if (ThunderCooldownAct)
        {
            ThunderCooldown += Time.deltaTime;
            if (ThunderCooldown >= 0.5f)
            {
                GetComponent<HealthManager>().TakeDamage(DamageThunder);
                ThunderCooldown = 0;
            }
        }
    }

}
