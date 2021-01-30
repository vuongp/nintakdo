using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : InteractableObject
{
    public override void UseAction()
    {
        GetComponentInParent<RoomScript>().LevelComplete();
    }
}
