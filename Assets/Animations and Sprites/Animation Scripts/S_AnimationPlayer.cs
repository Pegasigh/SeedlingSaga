using System;
using UnityEngine;

public class S_AnimationPlayer : MonoBehaviour
{
    private SO_SpriteAnimation spriteAnimation = null;

    public void SetAnimation(SO_SpriteAnimation animation_, Action callbackFunction_ = null)
    {
        if(spriteAnimation != animation_)
        {
            callbackFunction = callbackFunction_;
            spriteAnimation = animation_;
            animationStartTime = Time.time;
        }
    }




    
    public SpriteRenderer s_renderer;
    private float animationStartTime;
    private Action callbackFunction;



    private void Update()
    {
        Animate();
    }

    public void Animate()
    {
        if(spriteAnimation != null)
        {
            int index = (int)((Time.time - animationStartTime) / spriteAnimation.secondsBetweenFrames);

            if (index >= spriteAnimation.sprites.Length)
            {
                if(spriteAnimation.loops)
                {
                    index %= spriteAnimation.sprites.Length;
                    animationStartTime += spriteAnimation.secondsBetweenFrames * spriteAnimation.sprites.Length; //used so that index never outgrows an int
                }
                else
                {
                    var localCallback = callbackFunction; //just in case callback gets reassigned when doing the next action
                    callbackFunction = null;
                    localCallback?.Invoke();
                    return;
                }
            }
            s_renderer.sprite = spriteAnimation.sprites[index];
        }
        else //animation is null
        {
            s_renderer.sprite = null;
        }
    }

    public void SetSprites()
    {
        s_renderer.sprite = spriteAnimation.sprites[0];
    }
}
