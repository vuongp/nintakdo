using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Sass : MonoBehaviour
{
    public bool canSass;
    public AudioManager audioManager;
    public int nextSound;
    // Start is called before the first frame update
    void Start()
    {
        canSass = false;
        SetRandomSass();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Sass
            switch(nextSound)
            {
                case 1:
                    audioManager.Play("yeet");
                    break;
                case 2:
                    audioManager.Play("skeet");
                    break;
                case 3:
                    audioManager.Play("deleet");
                    break;
                default:
                    break;
            }
            canSass = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canSass = true;
        }
    }

    private void SetRandomSass()
    {
        nextSound = Random.Range(1, 3);
    }

    private void SetRandomSass(int exclusion)
    {
        nextSound = Random.Range(1, 3);
        if(nextSound == exclusion)
        {
            SetRandomSass(exclusion);
        }
    }
}
