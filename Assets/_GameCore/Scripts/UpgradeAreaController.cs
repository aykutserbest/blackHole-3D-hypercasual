using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAreaController : MonoBehaviour
{
    [SerializeField] private Material onMat;
    [SerializeField] private Material offMat;

    private void OnTriggerEnter(Collider other)
    { 
        if (!other.name.Contains("HoleParent")) return;

        EventManager.ShowUpgradePanel?.Invoke();
        
        SetAreaColor(onMat);
    }

    private void OnTriggerExit(Collider other)
    {
        EventManager.HideUpgradePanel?.Invoke();
        
        SetAreaColor(offMat);
    }


    void SetAreaColor(Material currentMat)
    {
        gameObject.GetComponent<MeshRenderer>().material = currentMat;
    }
}
