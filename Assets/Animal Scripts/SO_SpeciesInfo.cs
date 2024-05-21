using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Species Info")]
public class SO_SpeciesInfo : ScriptableObject
{
    public string speciesName;
    public AnimalBuildingType homeType;
    public string animationPrefix;
    public string speciesType; //TODO: what was this???
    public int daysToReproduce; //pregnancy length or incubation time
    public bool liveBirths;
    public bool incubationBirths;
    public int offspringCount;
    public int daysToMature; //days spent as a baby
    public int lifespan; //total days this animal can live
    public SO_Produce[] produce;
}
