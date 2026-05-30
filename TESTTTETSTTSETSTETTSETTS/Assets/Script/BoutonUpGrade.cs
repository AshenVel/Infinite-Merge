using UnityEngine;

public class BoutonUpGrade : MonoBehaviour
{
    public int Num;

    public GameObject UpgradeManager;

    public void Selected()
    {
        UpgradeManager.GetComponent<UpgradeManager>().ApplyUpgrade(Num);
    }
}
