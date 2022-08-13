using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Obstacles")) return;

        int obstacleExpPoint = other.GetComponent<ObstacleController>().experiencePoint;
        EventManager.HoleObstacleTriggerEnter?.Invoke(obstacleExpPoint);
        
        gameObject.GetComponentInParent<HoleController>().collecttedList.Add(other.gameObject);
        
    }
}
