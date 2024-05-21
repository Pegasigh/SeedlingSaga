using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_AnimationController : MonoBehaviour
{
    public List<S_AnimationPlayer> partLayers;
    public SO_AnimationTable[] animationTables;
    protected string defaultAnimation;

    protected virtual void Start()
    {
        defaultAnimation = "idle_down";
    }

    public virtual void SetAnimation(string animationName)
    {
        //for each part
        for (int i = 0; i < partLayers.Count; i++)
        {
            //find animation by name and give it to all layer players
            SO_SpriteAnimation anim = FindAnimationByName(animationTables[i], animationName);
            if (anim == null) Debug.Log("No animation found: " + animationName);
            partLayers[i].GetComponent<S_AnimationPlayer>().SetAnimation(anim);
        }
    }

    protected SO_SpriteAnimation FindAnimationByName(SO_AnimationTable table, string actionName)
    {
        foreach (SO_SpriteAnimation anim in table.animations)
        {
            if (anim.name == actionName) return anim;
        }
        return null;
    }
}
