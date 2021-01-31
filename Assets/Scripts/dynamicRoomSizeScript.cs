using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicRoomSizeScript : RoomSizeScript
{
    public GameObject player;
    void Update()
    {
        if (GetComponent<RoomScript>().active)
        {
            float distance =(2 * (player.transform.position - transform.position)).z;
            if (distance > 1)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, distance);
                foreach (Transform child in transform)
                {
                    if (child.tag == "Room")
                    {
                        Renderer renderer = child.GetComponent<Renderer>();
                        if (child.name.Contains("Side Wall"))
                        {
                            renderer.material.mainTextureScale = new Vector2(gameObject.transform.localScale.z, gameObject.transform.localScale.y);
                        }
                        else if (child.name.Contains("Wall"))
                        {
                        }
                        else
                        {
                            renderer.material.mainTextureScale = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.z);

                        }
                    }
                }
            }
        }
    }
}
