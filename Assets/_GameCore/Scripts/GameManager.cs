using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }

   public CanvasManager canvasManager;

   [SerializeField] private GameObject holeParent;
   
   void Awake()
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

   private void Start()
   {
      canvasManager = gameObject.GetComponent<CanvasManager>();
      Init();
   }

   private void Init()
   {
      
   }

   public void SetHoleArea()
   {
      holeParent.GetComponent<HoleController>().SetArea();
   }
}
