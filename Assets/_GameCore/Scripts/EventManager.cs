using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{

    public static Action<int> HoleObstacleTriggerEnter;
    public static Action<int> ChangeMoneyUI;
    public static Action ShowUpgradePanel;
    public static Action HideUpgradePanel;

}
