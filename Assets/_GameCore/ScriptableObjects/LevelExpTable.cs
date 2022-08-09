using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelExpTable", order = 1)]
public class LevelExpTable : ScriptableObject
{
   public List<LevelExperience> ExperienceTable;
}
