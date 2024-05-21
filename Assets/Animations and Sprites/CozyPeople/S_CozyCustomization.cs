using System;
using UnityEngine;

public enum bodyChoices
{
    body
}

public enum hairChoices
{
    none,
    braids,
    bob,
    midiwave,
    ponytail,
    spacebuns,
    wavy
}

public enum hairAccessoryChoices
{
    none,
    braids_tie
}

public enum eyeChoices
{
    eyes
}



public class S_CozyCustomization : MonoBehaviour
{
    public string[] choiceNames;
    private bodyChoices bodyChoice;
    public hairChoices hairChoice;
    private hairAccessoryChoices hairAccessoryChoice;
    private eyeChoices eyeChoice;


    public void UpdateChoices()
    {
        if (hairChoice == hairChoices.braids) { hairAccessoryChoice = hairAccessoryChoices.braids_tie; }
        else { hairAccessoryChoice = hairAccessoryChoices.none; }

        choiceNames = new string[]
        {
            Enum.GetName(typeof (bodyChoices), bodyChoice),
            Enum.GetName(typeof (hairChoices), hairChoice),
            Enum.GetName(typeof (hairAccessoryChoices), hairAccessoryChoice),
            Enum.GetName(typeof (eyeChoices), eyeChoice)
        };
    }








    

    public void Start()
    {
        UpdateChoices();
    }

    public void OnValidate()
    {
        UpdateChoices();

        //render animations in editor
        S_AnimationController_CozyPeople controller = GetComponent<S_AnimationController_CozyPeople>();
        controller.SetCustomizationOptions(this);
        controller.SetAnimation("idle_down");
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject childObject = transform.GetChild(i).gameObject;
            childObject.GetComponent<S_AnimationPlayer>()?.Animate();
        }
    }
}
