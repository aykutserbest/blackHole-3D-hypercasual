using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    
    private int _characterCurrentExp;
    
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
    
    private void OnEnable()
    {
        EventManager.HoleObstacleTriggerEnter += UpdateExp;
    }

    private void OnDisable()
    {
        EventManager.HoleObstacleTriggerEnter -= UpdateExp;
    }
    
    void UpdateExp(int expPoint)
    {
        _characterCurrentExp += expPoint;
        CheckLevel();
    }

    private void CheckLevel()
    {
        var requiredExp = GetLevelReqiuredExpPoint();
      //  Debug.Log("requiredExp : " + requiredExp);
        
        if (_characterCurrentExp >= requiredExp)
        {
            Debug.Log("levelup");
        }
        else
        {
                Debug.Log("devam");
        }
    }

    private int GetLevelReqiuredExpPoint()
    {
        int requiredExp = DataManager.Instance.GetLevelRequiredExpPoint();

        return requiredExp;
    }
    
}
