using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Animal : S_InteractableObject
{
    S_AnimationController animationController;
    SO_AnimationTable animations;
    private string animationPrefix_; //might contain "baby"

    //instance data
    public SO_SpeciesInfo speciesInfo;
    public string nickname;
    public S_AnimalBuilding home;
    private bool isAlive;
    private int age; //days lived
    private bool isFull;
    private bool hasBeenPet;
    private float timeOutside; //hours spent outdoors
    private float health; //0-100


    private void Start()
    {
        animationController = GetComponent<S_AnimationController>();
        animationPrefix_ = speciesInfo.animationPrefix + "baby_";
        //TODO: uncomment this:
        //animationController.SetAnimation(animationPrefix_ + "idle_down");
        //TODO: remove this:
        animationController.SetAnimation(speciesInfo.animationPrefix + "idle_down");

        nickname = speciesInfo.speciesName;
        //TODO: give a home?
        isAlive = true;
        age = 0;
        isFull = false;
        hasBeenPet = false;
        timeOutside = 0;
        health = 100;
    }

    public void Overnight()
    {
        if(isAlive)
        {
            //if timeOutside > ???: isFull = true
            //else if home.eat returns true: isFull = true
            if (isFull == false) health -= 15;
            if (hasBeenPet == false) health -= 2;
            //if weather is bad: health -= timeOutside * 2;
            //if weather is good and timeOutside < 6: health -= 10;
            //health -= home.overpopulatedCount * 2;
            if (health <= 0) Die();

            //item production
            for (int i = 0; i < speciesInfo.produce.Length; i++)
            {
                speciesInfo.produce[i].daysSinceProduced++;
                if (speciesInfo.produce[i].isDropHarvest && speciesInfo.produce[i].daysSinceProduced > speciesInfo.produce[i].daysToProduce) //check if needs to be >=
                {
                    //TODO: tell barn to drop item
                    speciesInfo.produce[i].daysSinceProduced = 0;
                }
            }

            //aging
            age++;
            if (age > speciesInfo.daysToMature) animationPrefix_ = speciesInfo.animationPrefix; //removes "baby_" from animation prefix
            if (age > speciesInfo.lifespan) Die();
        }
    }

    private void Wander()
    {
        if (isAlive)
        {

        }
    }

    private void Die()
    {
        isAlive = false;
        animationController.SetAnimation(speciesInfo.animationPrefix + "die");
    }

    public override void InteractionA(S_Player player)
    {
        Debug.Log("InteractionA");

        if (isAlive)
        {
            //if player is not holding anything & if has been pet is false: emote/animation occur, dialogue happens & hasbeenpet = true. 
            //Dialogue indicates if animal is sick


            //change this to work with produce type stuff
            //if player is holding bucket & produce type is milk & hasProduceToday is true: emote/animation occur, hasProduceToday = false, and player is given produceType
            //if player is holding sheers & produce type is wool & hasProduceToday is true: emote/animation occur, hasProduceToday = false, and player is given produceType


            //if player is holding medicine and health < 50: medicine is consumed and health += 25
        }
        else
        {
            //dialogue option to dispose of dead body
        }
    }

    public override void InteractionB(S_Player player)
    {
        Debug.Log("InteractionB");

        if (isAlive)
        {
            //opens interaction menu
        }
    }
}