using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class S_InteractableObject : MonoBehaviour
{
    public abstract void InteractionA(S_Player player);
    public abstract void InteractionB(S_Player player);
}
