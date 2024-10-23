using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Banana Upgrade/Banana Per Second", fileName = "Bananas er Second")]
public class BananaUpgradePerSecond : BananaUpgrade
{

    public override void ApplyUpgrade()
    {
        GameObject go = Instantiate(GameManager.instance.BananasPerSecondObjToSpawn, Vector3.zero, Quaternion.identity);
        go.GetComponent<BananaPerSecondTimer>().BananasPerSecond = UpgradeAmount;

        GameManager.instance.SimpleBananaPerSecondIncrease(UpgradeAmount);
    }

}
