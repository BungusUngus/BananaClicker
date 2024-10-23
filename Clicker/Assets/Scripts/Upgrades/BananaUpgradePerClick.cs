using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Banana Upgrade/Bananas Per Click", fileName ="Bananas Per Click")]
public class BananaUpgradePerClick : BananaUpgrade
{
    public override void ApplyUpgrade()
    {
        GameManager.instance.BananasPerClickUpgrade += UpgradeAmount;
    }
}
