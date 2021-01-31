using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : InteractableObject
{
    public override void UseAction()
    {
        GetComponentInParent<RoomScript>().LevelComplete();
        transform.parent.parent.Find("Unlock Text").gameObject.SetActive(false);
    }

    public void HoverAction()
    {
        transform.parent.parent.Find("Unlock Text").gameObject.SetActive(true);
    }
}
