using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
   [SerializeField] private GameObject upgradePanelObj;

   [SerializeField] private TextMeshProUGUI areaLevelTxt;
   [SerializeField] private int areaLevel;
   
   [SerializeField] private TextMeshProUGUI incomeLevelTxt;
   [SerializeField] private int incomeLevel;

   private void OnEnable()
   {
      EventManager.ShowUpgradePanel += ShowUpgragePanel;
      EventManager.HideUpgradePanel += HideUpgragePanel;
   }

   private void OnDisable()
   {
      EventManager.ShowUpgradePanel -= ShowUpgragePanel;
      EventManager.HideUpgradePanel -= HideUpgragePanel;
   }

   private void ShowUpgragePanel()
   {
      RefreshData();
      upgradePanelObj.SetActive(true);
   }
   
   private void HideUpgragePanel()
   {
      upgradePanelObj.SetActive(false);
   }

   private void RefreshData()
   {
      areaLevel = DataManager.Instance.areaLevel;
      incomeLevel = DataManager.Instance.incomeLevel;
      
      areaLevelTxt.text = areaLevel.ToString();
      incomeLevelTxt.text = incomeLevel.ToString();
   }

   public void LevelUpArea()
   {
      areaLevel++;
      DataManager.Instance.SaveAreaLevel(areaLevel);
      RefreshData();
      GameManager.Instance.SetHoleArea();
   }
   
   public void LevelUpIncome()
   {
      
   }
}
