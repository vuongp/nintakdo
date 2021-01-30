using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koeboes : InteractableObject
{
    public override void UseAction()
    {
        base.UseAction();
        Destroy(this.gameObject);
    }
}
