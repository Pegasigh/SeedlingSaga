using UnityEngine;

[CreateAssetMenu(menuName = "Animations/Sprite Animation")]
public class SO_SpriteAnimation : ScriptableObject
{
    public Sprite[] sprites;
    public bool loops;
    public float secondsBetweenFrames = 0.01f;
}
