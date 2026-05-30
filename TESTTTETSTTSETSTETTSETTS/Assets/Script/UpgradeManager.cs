using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using Random = UnityEngine.Random;

public class UpgradeManager : MonoBehaviour
{
    private List<string> Upgrade1_4 = new List<string>();
    private List<string> Upgrade5_9 = new List<string>();
    private List<string> Upgrade10_14 = new List<string>();

    private List<string> UpgradeNow = new List<string>();

    public GameObject Village;

    public GameObject Ball;

    public GameObject Meteor;

    public GameObject Storm;

    public GameObject Laser;

    private GameObject Player;

    public GameObject PoPup;

    public GameObject EffectManager1;
    public GameObject EffectManager2;
    public GameObject EffectManager3;
    public GameObject EffectManager4;



    public TextMeshProUGUI BoutonText1;
    public TextMeshProUGUI BoutonText2;
    public TextMeshProUGUI BoutonText3;

    private string Upgrade1;
    private string Upgrade2;
    private string Upgrade3;

    public int NbPV = 10;

    private int number;
    private void Start()
    {

        Player = GameObject.Find("Player");
        Upgrade1_4.AddRange(new string[] { "Regen", "CooldownMeteor", "CooldownLaser", "CooldownBall", "CooldownStorm", "DBall", "DMeteor", "DLaser","TimeStorm", "DFire", "TimeFire"});
        Upgrade5_9.AddRange(new string[] { "Regen", "CooldownMeteor", "CooldownLaser", "CooldownBall", "CooldownStorm", "DBall", "DMeteor", "DLaser", "TimeStorm", "DFire", "TimeFire", "TimeIce", "StrIce"});
        Upgrade10_14.AddRange(new string[] { "Regen", "CooldownMeteor", "CooldownLaser", "CooldownBall", "CooldownStorm", "DBall", "DMeteor", "DLaser", "TimeStorm", "DFire", "TimeFire", "TimeIce", "StrIce","DThunder","TimeThunder" });
        UpgradeNow = Upgrade1_4;
    }

    public void Select()
    {
        RandomUpgrade();
        PoPup.SetActive(true);
        Time.timeScale = 0;
    }

    public void ApplyUpgrade(int NbUpgrade)
    {
        string Upgrade;

        if (NbUpgrade == 1) 
        {
            Upgrade = Upgrade1;
            TheChosenOne(Upgrade);
        }

        if (NbUpgrade == 2)
        {
            Upgrade = Upgrade2;
            TheChosenOne(Upgrade);
        }

        if (NbUpgrade == 3)
        {
            Upgrade = Upgrade3;
            TheChosenOne(Upgrade);
        }

        Time.timeScale = 1f;
        PoPup.SetActive(false);

    }


    private void TheChosenOne(string Up)
    {
        if (Up == "Regen")
        {
            Village.GetComponent<Village>().Heal(NbPV);
        }
        else if (Up == "CooldownMeteor")
        {
            Player.GetComponent<SpellsManager>().MeteorCooldown = MathF.Round( Player.GetComponent<SpellsManager>().MeteorCooldown * 0.95f,2);
        }
        else if (Up == "CooldownLaser")
        {
            Player.GetComponent<SpellsManager>().LaserCooldown = MathF.Round(Player.GetComponent<SpellsManager>().LaserCooldown * 0.95f, 2);
        }
        else if (Up == "CooldownBall")
        {
            Player.GetComponent<SpellsManager>().BallCooldown = MathF.Round(Player.GetComponent<SpellsManager>().BallCooldown * 0.95f, 2);
        }
        else if (Up == "CooldownStorm")
        {
            Player.GetComponent<SpellsManager>().StormCooldown = MathF.Round(Player.GetComponent<SpellsManager>().StormCooldown * 0.95f, 2);
        }
        else if (Up == "DBall")
        {
            Ball.GetComponent<BallExplosion>().Damage = MathF.Round(Ball.GetComponent<BallExplosion>().Damage * 1.1f, 2); 
        }
        else if (Up == "DMeteor")
        {
            Meteor.GetComponent<Meteor>().Damage = MathF.Round(Meteor.GetComponent<Meteor>().Damage * 1.1f, 2); 
        }
        else if (Up == "DLaser")
        {
            Laser.GetComponent<Laser>().Damage = MathF.Round(Laser.GetComponent<Laser>().Damage * 1.1f, 2); 
        }
        else if (Up == "TimeStorm")
        {
            Storm.GetComponent<Storm>().TimeOnStage = MathF.Round(Storm.GetComponent<Storm>().TimeOnStage * 1.05f, 2); 
        }
        else if (Up == "DFire")
        {
            float DamageFire = MathF.Round(EffectManager1.GetComponent<EffectManager>().DamageFire * 1.1f, 2);
            EffectManager1.GetComponent<EffectManager>().DamageFire =  DamageFire;
            EffectManager2.GetComponent<EffectManager>().DamageFire = DamageFire;
            EffectManager3.GetComponent<EffectManager>().DamageFire = DamageFire;
            EffectManager4.GetComponent<EffectManager>().DamageFire = DamageFire;
        }
        else if (Up == "TimeFire")
        {
            float TimeFire = MathF.Round(EffectManager1.GetComponent<EffectManager>().TimeFire * 1.1f, 2);
            EffectManager1.GetComponent<EffectManager>().TimeFire = TimeFire;
            EffectManager2.GetComponent<EffectManager>().TimeFire = TimeFire;
            EffectManager3.GetComponent<EffectManager>().TimeFire = TimeFire;
            EffectManager4.GetComponent<EffectManager>().DamageFire = TimeFire;
        }
        else if (Up == "TimeIce")
        {
            float TimeIce = MathF.Round(EffectManager1.GetComponent<EffectManager>().TimeIce * 1.1f, 2);
            EffectManager1.GetComponent<EffectManager>().TimeIce = TimeIce;
            EffectManager2.GetComponent<EffectManager>().TimeIce = TimeIce;
            EffectManager3.GetComponent<EffectManager>().TimeIce = TimeIce;
            EffectManager4.GetComponent<EffectManager>().TimeIce = TimeIce;
        }
        else if (Up == "StrIce")
        {
            float StrIce = MathF.Round(EffectManager1.GetComponent<EffectManager>().StrIce * 1.1f, 2);
            EffectManager1.GetComponent<EffectManager>().StrIce = StrIce;
            EffectManager2.GetComponent<EffectManager>().StrIce = StrIce;
            EffectManager3.GetComponent<EffectManager>().StrIce = StrIce;
            EffectManager4.GetComponent<EffectManager>().StrIce = StrIce;
        }
        else if (Up == "DThunder")
        {
            float DamageThunder = MathF.Round(EffectManager1.GetComponent<EffectManager>().DamageThunder * 1.1f, 2);
            EffectManager1.GetComponent<EffectManager>().DamageThunder = DamageThunder;
            EffectManager2.GetComponent<EffectManager>().DamageThunder = DamageThunder;
            EffectManager3.GetComponent<EffectManager>().DamageThunder = DamageThunder;
            EffectManager4.GetComponent<EffectManager>().DamageThunder = DamageThunder;
        }
        else if (Up == "TimeThunder")
        {
            float TimeThunder = MathF.Round(EffectManager1.GetComponent<EffectManager>().TimeThunder * 1.1f, 2);
            EffectManager1.GetComponent<EffectManager>().TimeThunder = TimeThunder;
            EffectManager2.GetComponent<EffectManager>().TimeThunder = TimeThunder;
            EffectManager3.GetComponent<EffectManager>().TimeThunder = TimeThunder;
            EffectManager4.GetComponent<EffectManager>().TimeThunder = TimeThunder;
        }
    }

    private void RandomUpgrade()
    {
        if (Player.GetComponent<PlayerManager>().Level > 0 && Player.GetComponent<PlayerManager>().Level < 5)
        {
            UpgradeNow = new List<string>(Upgrade1_4);
        }
        if (Player.GetComponent<PlayerManager>().Level > 4 && Player.GetComponent<PlayerManager>().Level < 10)
        {
            UpgradeNow = new List<string>(Upgrade5_9);
        }
        if (Player.GetComponent<PlayerManager>().Level > 9)
        {
            UpgradeNow = new List<string>(Upgrade10_14);
        }

        number = Random.Range(0, UpgradeNow.Count);

        TextSelector(UpgradeNow[number], BoutonText1);
        Upgrade1 = UpgradeNow[number];

        UpgradeNow.Remove(UpgradeNow[number]);


        number = Random.Range(0, UpgradeNow.Count);

        TextSelector(UpgradeNow[number], BoutonText2);
        Upgrade2 = UpgradeNow[number];

        UpgradeNow.Remove(UpgradeNow[number]);


        number = Random.Range(0, UpgradeNow.Count);

        TextSelector(UpgradeNow[number], BoutonText3);
        Upgrade3 = UpgradeNow[number];

    }

    private void TextSelector(string Up, TextMeshProUGUI Bouton)
    {
        if (Up == "Regen")
        {
            Bouton.text = "Regeneration : Soigne 10 PV";
        }
        else if (Up == "CooldownMeteor")
        {
            Bouton.text = "Concentration Spatiale : Diminue le temps d'attente de 5% apres l'utilisation des meteorites";
        }
        else if (Up == "CooldownLaser")
        {
            Bouton.text = "Concentration Technologique : Diminue le temps d'attente de 5% apres l'utilisation des lasers";
        }
        else if (Up == "CooldownBall")
        {
            Bouton.text = "Concentration Spirituelle : Diminue le temps d'attente de 5% apres l'utilisation des boules";
        }
        else if (Up == "CooldownStorm")
        {
            Bouton.text = "Concentration Magique : Diminue le temps d'attente de 5% après l'utilisation des tempetes";
        }
        else if (Up == "DBall")
        {
            Bouton.text = "Force Magique : Augmente les degats des boules de 10%";
        }
        else if (Up == "DMeteor")
        {
            Bouton.text = "Force Spatiales : Augmente les degats des meteorites de 10%";
        }
        else if (Up == "DLaser")
        {
            Bouton.text = "Force Technologique : Augmente les degats des lasers de 10%";
        }
        else if (Up == "TimeStorm")
        {
            Bouton.text = "Endurance Magique : Augmente la duree des tempetes sur le terrain de 5%";
        }
        else if (Up == "DFire")
        {
            Bouton.text = "Force du feu : Augmente les degats du feu de 10%";
        }
        else if (Up == "TimeFire")
        {
            Bouton.text = "Endurance volcanique : Augmente la duree du feu sur les ennemis de 10%";
        }
        else if (Up == "TimeIce")
        {
            Bouton.text = "Endurance glaciale : Augmente la duree de la glace sur les ennemis de 10%";
        }
        else if (Up == "StrIce")
        {
            Bouton.text = "Force glaciale : Augmente la reduction de la vitesse avec la glace sur les ennemis de 10%";
        }
        else if (Up == "DThunder")
        {
            Bouton.text = "Force de la foudre : Augmente les degats de la foudre de 10%";
        }
        else if (Up == "TimeThunder")
        {
            Bouton.text = "Endurance de la foudre : Augmente la duree de la foudre sur les ennemis de 5%";
        }
    }

}
