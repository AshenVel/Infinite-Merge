using System;
using UnityEngine;

public class Défaut : MonoBehaviour
{
    public GameObject ZombieClassique;
    public GameObject ZombieSpeed;
    public GameObject ZombieBoom;
    public GameObject ZombieTank;

    public GameObject Ball;
    public GameObject Meteor;
    public GameObject Laser;
    public GameObject Storm;

    private void Start()
    {
        Ball.GetComponent<BallExplosion>().Damage = 15;
        Meteor.GetComponent<Meteor>().Damage = 10;
        Laser.GetComponent<Laser>().Damage = 30;
        Storm.GetComponent<Storm>().TimeOnStage = 1.5f;

        ZombieClassique.GetComponent<EffectManager>().DamageFire = 2;
        ZombieSpeed.GetComponent<EffectManager>().DamageFire = 2;
        ZombieBoom.GetComponent<EffectManager>().DamageFire = 2;
        ZombieTank.GetComponent<EffectManager>().DamageFire = 2;

        ZombieClassique.GetComponent<EffectManager>().TimeFire = 4;
        ZombieSpeed.GetComponent<EffectManager>().TimeFire = 4;
        ZombieBoom.GetComponent<EffectManager>().TimeFire = 4;
        ZombieTank.GetComponent<EffectManager>().TimeFire = 4;

        ZombieClassique.GetComponent<EffectManager>().StrIce = 0.6f;
        ZombieSpeed.GetComponent<EffectManager>().StrIce = 0.6f;
        ZombieBoom.GetComponent<EffectManager>().StrIce = 0.6f;
        ZombieTank.GetComponent<EffectManager>().StrIce = 0.6f;

        ZombieClassique.GetComponent<EffectManager>().TimeIce = 4;
        ZombieSpeed.GetComponent<EffectManager>().TimeIce = 4;
        ZombieBoom.GetComponent<EffectManager>().TimeIce = 4;
        ZombieTank.GetComponent<EffectManager>().TimeIce = 4;

        ZombieClassique.GetComponent<EffectManager>().DamageThunder = 1;
        ZombieSpeed.GetComponent<EffectManager>().DamageThunder = 1;
        ZombieBoom.GetComponent<EffectManager>().DamageThunder = 1;
        ZombieTank.GetComponent<EffectManager>().DamageThunder = 1;

        ZombieClassique.GetComponent<EffectManager>().TimeThunder = 4;
        ZombieSpeed.GetComponent<EffectManager>().TimeThunder = 4;
        ZombieBoom.GetComponent<EffectManager>().TimeThunder = 4;
        ZombieTank.GetComponent<EffectManager>().TimeThunder = 4;
    }

}
