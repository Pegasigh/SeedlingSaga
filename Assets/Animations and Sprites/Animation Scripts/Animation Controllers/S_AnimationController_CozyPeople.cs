using System.Collections.Generic;
using UnityEngine;

public class S_AnimationController_CozyPeople : S_AnimationController
{
    private S_CozyCustomization customizationOptions;

    protected override void Start()
    {
        base.Start();
        customizationOptions = GetComponent<S_CozyCustomization>();
    }

    public override void SetAnimation(string animationName)
    {
        //for each part
        for (int i = 0; i < partLayers.Count; i++)
        {
            //adding customization name to animation name: e.g. braids_idle_down instead of just idle_down
            string animationName_ = customizationOptions.choiceNames[i] + "_" + animationName;

            //find animation by name and give it to all layer players
            SO_SpriteAnimation anim = FindAnimationByName(animationTables[i], animationName_);
            partLayers[i].GetComponent<S_AnimationPlayer>().SetAnimation(anim);
        }
    }

    //used for onvalidate call from customization script
    public void SetCustomizationOptions(S_CozyCustomization s_cozyCustomization)
    {
        customizationOptions = s_cozyCustomization;
    }
}
