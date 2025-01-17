using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeUpgrades : MonoBehaviour
{
   public void Initialize(BananaUpgrade[] upgrades, GameObject UIToSpawn, Transform spawnParent)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            int currentIndex = i;

            GameObject go = Instantiate(UIToSpawn, spawnParent);

            //reset cost
            upgrades[currentIndex].CurrentUpgradeCost = upgrades[currentIndex].OriginalUpgradeCost;

            //set text
            UpgradeButtonRefrences buttonRef = go.GetComponent<UpgradeButtonRefrences>();
            buttonRef.UpgradeButtonText.text = upgrades[currentIndex].UpgradeButtonText;
            buttonRef.UpgradeDescriptionText.SetText(upgrades[currentIndex].UpgradeButtonDescription, upgrades[currentIndex].UpgradeAmount);
            buttonRef.UpgradeCostText.text = "Cost: " + upgrades[currentIndex].CurrentUpgradeCost;

            //set onClick
            buttonRef.UpgradeButton.onClick.AddListener(delegate { GameManager.instance.OnUpgradeButtonClick(upgrades[currentIndex], buttonRef); });
        }
    }


}
