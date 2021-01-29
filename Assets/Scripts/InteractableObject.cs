using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public virtual void Start()
    {
        gameObject.tag = "Interactable";
    }

    public virtual void UseAction()
    {
        
    }
}
