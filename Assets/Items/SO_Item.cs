using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/Item")]
public class SO_Item : ScriptableObject
{
    public string itemName;
    public Sprite image;
    public bool stackable = false;
    public int maxCount = 10;
    public bool sellable = true;
    public int price = 1;
}