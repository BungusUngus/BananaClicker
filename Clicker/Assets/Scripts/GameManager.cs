using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject MainGameCanvas;
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private TextMeshProUGUI _bananaCountText;
    [SerializeField] private TextMeshProUGUI _bananasPerSecondText;
    [SerializeField] private GameObject _bananaObj;
    public GameObject BananaTextPopUp;
    [SerializeField] private GameObject _backgroundObj;

    [Space]
    public BananaUpgrade[] CookieUpgrades;
    [SerializeField] private GameObject _upgradeUIToSpawn;
    [SerializeField] private Transform _upgradeUIParent;
    public GameObject BananasPerSecondObjToSpawn;

    public double CurrentBananaCount { get; set; }
    public double CurrentBananasPerSecond { get; set; }

    public double BananasPerClickUpgrade { get; set; }

    private InitializeUpgrades _initializeUpgrades;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        UpdateBananaUI();
        UpdateBananasPerSecondUI();

        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);

        _initializeUpgrades = GetComponent<InitializeUpgrades>();
        _initializeUpgrades.Initialize(CookieUpgrades, _upgradeUIToSpawn, _upgradeUIParent);
    }

    #region On Banana Clicked

    public void OnBananaClicked()
    {
        IncreaseBanana();
    }

    public void IncreaseBanana()
    {
        CurrentBananaCount += 1 + BananasPerClickUpgrade;
        UpdateBananaUI();
    }

    #endregion

    #region UI Updates

    private void UpdateBananaUI()
    {
        _bananaCountText.text = CurrentBananaCount.ToString();
    }

    private void UpdateBananasPerSecondUI()
    {
        _bananasPerSecondText.text = CurrentBananasPerSecond.ToString() + " P/S";
    }

    #endregion

    #region Button Presses

    public void OnUpgradeButtonPress()
    {
        MainGameCanvas.SetActive(false);
        _upgradeCanvas.SetActive(true);
    }

    public void OnResumeButtonPress()
    {
        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);
    }

    #endregion

    #region Simple Increases

    public void SimpleBananaIncrease(double amount)
    {
        CurrentBananaCount += amount;
        UpdateBananaUI();
    }

    public void SimpleBananaPerSecondIncrease(double amount)
    {
        CurrentBananasPerSecond += amount;
        UpdateBananasPerSecondUI();
    }

    #endregion

    #region Events

    public void OnUpgradeButtonClick(BananaUpgrade upgrade, UpgradeButtonRefrences buttonRef)
    {
        if (CurrentBananaCount >= upgrade.CurrentUpgradeCost)
        {
            upgrade.ApplyUpgrade();

            CurrentBananaCount -= upgrade.CurrentUpgradeCost;
            UpdateBananaUI();

            upgrade.CurrentUpgradeCost = Mathf.Round((float)(upgrade.CurrentUpgradeCost * (1 + upgrade.CostIncreaseMultiplierPerPurchase)));

            buttonRef.UpgradeCostText.text = "Cost: " + upgrade.CurrentUpgradeCost;
        }
    }

    #endregion
}
