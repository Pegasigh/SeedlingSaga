using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Produce")]
public class SO_Produce : ScriptableObject
{
    //public Item produceItem
    public int daysToProduce;
    public int daysSinceProduced;
    public bool isDropHarvest;
}
