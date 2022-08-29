using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DischargeAreaController : MonoBehaviour
{
    [SerializeField] private Material onMat;
    [SerializeField] private Material offMat;

    private int _incomeMultiplier = 1;
    private int _total;
    
    private void OnTriggerEnter(Collider other)
    { 
        if (!other.name.Contains("HoleParent")) return;

        _incomeMultiplier = DataManager.Instance.incomeLevel;

        GetHoleItemList(other.gameObject);
        
        SetAreaColor(onMat);
        
    }

    private void GetHoleItemList(GameObject hole)
    {
        var itemList = hole.GetComponent<HoleController>().collecttedList;

        foreach (var item in itemList)
        {
            _total += item.GetComponent<ObstacleController>().experiencePoint * _incomeMultiplier;
        }
        
        hole.GetComponent<HoleController>().collecttedList.Clear();
        GameManager.Instance.canvasManager.moneyTxt.text = _total.ToString();

    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.name.Contains("HoleParent")) return;

        SetAreaColor(offMat);
    }



    void SetAreaColor(Material currentMat)
    {
        gameObject.GetComponent<MeshRenderer>().material = currentMat;
    }
    
}
