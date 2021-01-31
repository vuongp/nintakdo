using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSizeScript : MonoBehaviour
{
    [Range(1,3)]
    public int exitWallDoors;
    public GameObject door;
    float doorsize;
    float doorHeight;
    public int correctDoor;
    // Start is called before the first frame update
    void Start()
    {
        doorsize = door.GetComponent<Renderer>().bounds.size.x / transform.localScale.x;//2 / transform.localScale.x; 
        doorHeight = door.GetComponent<Renderer>().bounds.size.y / transform.localScale.y;
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
                    renderer.material.mainTextureScale = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.y);

                }
                else
                {
                    renderer.material.mainTextureScale = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.z);

                }
            }
            if (child.name == "End Wall") {
                Destroy(child.gameObject.GetComponent<MeshCollider>());
                Mesh mesh = new Mesh();
                child.GetComponent<MeshFilter>().mesh = mesh;
                
                mesh.Clear();
                Vector3[] vertices = GenerateVertices(child);
                mesh.vertices = vertices;
                mesh.triangles = GenerateTriangles();
                Vector2[] uvs = new Vector2[vertices.Length];

                for (int i = 0; i < uvs.Length; i++)
                {
                    uvs[i] = new Vector2(vertices[i].x/10, vertices[i].z/10);
                }
                mesh.uv = uvs;
                child.gameObject.AddComponent<MeshCollider>();
            }
        }
    }

    Vector3[] GenerateVertices(Transform wall) {
        Vector3[] vertices = new Vector3[4 + 6*exitWallDoors];
        vertices[0] = new Vector3(-5, 0, -5);
        vertices[1] = new Vector3(-5, 0, 5);
        for (int i =0; i < exitWallDoors; i++)
        {
            vertices[2 + i * 6] = new Vector3( ((10 * (i + 1) / (exitWallDoors + 1)) -  5 -doorsize/2)  , 0, -5) + (((exitWallDoors -1)/2 == i)?Vector3.zero: new Vector3(0.5f,0,0));
            vertices[3 + i * 6] = new Vector3( (10  * (i + 1) / (exitWallDoors + 1)) -  5 - doorsize / 2, 0, -5+doorHeight) + (((exitWallDoors - 1) / 2 == i) ? Vector3.zero : new Vector3(0.5f, 0, 0));
            vertices[4 + i * 6] = new Vector3( (10 * (i + 1) / (exitWallDoors + 1)) -  5 - doorsize / 2, 0, 5) + (((exitWallDoors - 1) / 2 == i) ? Vector3.zero : new Vector3(0.5f, 0, 0));
            vertices[5 + i * 6] = new Vector3( (10 * (i + 1) / (exitWallDoors + 1)) -5 + doorsize / 2, 0, -5) + (((exitWallDoors - 1) / 2 == i) ? Vector3.zero : new Vector3(0.5f, 0, 0));
            vertices[6 + i * 6] = new Vector3( (10 *( i + 1) / (exitWallDoors + 1)) -  5 + doorsize / 2, 0, - 5+doorHeight) + (((exitWallDoors - 1) / 2 == i) ? Vector3.zero : new Vector3(0.5f, 0, 0));
            vertices[7 + i * 6] = new Vector3( (10  * (i + 1) / (exitWallDoors + 1)) -  5 + doorsize / 2, 0, 5) + (((exitWallDoors - 1) / 2 == i) ? Vector3.zero : new Vector3(0.5f, 0, 0));

            Instantiate(door, wall.position+new Vector3((10 * transform.localScale.x * (i + 1) / (exitWallDoors + 1)) - transform.localScale.x *5, -5 * transform.localScale.y,0),Quaternion.AngleAxis(180,Vector3.up));
            GameObject doorobj = Instantiate(door, wall.position+new Vector3((10 * transform.localScale.x * (i + 1) / (exitWallDoors + 1)) - transform.localScale.x *5, -5,0),Quaternion.AngleAxis(180,Vector3.up));
            doorobj.transform.SetParent(transform.Find("Doors"));
            if (i + 1 == correctDoor) {
                doorobj.AddComponent<DoorScript>();
            }
        }
        vertices[3 + 6 * exitWallDoors] = new Vector3(5, 0, -5);
        vertices[2 + 6 * exitWallDoors] = new Vector3(5, 0, 5);
        return vertices;
    }

    int[] GenerateTriangles() {
        int[] triangles = new int[6 + 12 * exitWallDoors];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 4;
        for (int i = 0; i < exitWallDoors; i++) {
            triangles[5 + (12 * i) + 1] = 3 + i * 6;
            triangles[5 + (12 * i) + 2] = 4 + i * 6;
            triangles[5 + (12 * i) + 3] = 6 + i * 6;
            triangles[5 + (12 * i) + 4] = 6 + i * 6;
            triangles[5 + (12 * i) + 5] = 4 +i * 6;
            triangles[5 + (12 *i) + 6] = 7 + i * 6;


            triangles[5 + (12 *i) + 7] = ((i == exitWallDoors - 1)?5:10) + i * 6;
            triangles[5 + (12 *i) + 8] = ((i == exitWallDoors - 1)? 7:5) + i * 6;
            triangles[5 + (12 *i) + 9] = ((i == exitWallDoors - 1) ? 9 : 7) + i * 6;
            triangles[5 + (12 *i) + 10] = ((i == exitWallDoors - 1) ? 7:8) + i * 6;
            triangles[5 + (12 * i) + 11] = ((i == exitWallDoors - 1) ?8: 5) + i * 6;
            triangles[5 + (12 * i) + 12] = ((i == exitWallDoors-1)?9:10) + i * 6;
        }
        return triangles;
    }
}
