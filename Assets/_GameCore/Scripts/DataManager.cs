using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   public static DataManager Instance { get; private set; }

   public LevelExpTable expTable;
   
   public int level = 1;

   //todo: playerpreff.
   //todo: so ya bağlayacağız ilk için datamanager olsun.
   
   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;             
      }
      else if (Instance != this)
      {
         Destroy(this);
      }
   }

   public int GetLevelRequiredExpPoint()
   {
      int expPoint = expTable.ExperienceTable[level].RequiredExpPoint;

      return expPoint;
   }
   
   
   
   
}
