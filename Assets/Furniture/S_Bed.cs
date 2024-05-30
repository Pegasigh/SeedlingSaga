using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Bed : MonoBehaviour, I_Interactable
{
    public S_CalendarSystem calendarSystem;


    public void InteractionA(S_Player player)
    {
        if (calendarSystem != null) calendarSystem.NextDay();
    }

    public void InteractionB(S_Player player)
    {
        //no secondary interaction for bed
    }
}
