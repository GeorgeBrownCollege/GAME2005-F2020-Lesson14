using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Color = UnityEngine.Color;


[System.Serializable]
public class CubeBehaviour : MonoBehaviour
{
    public Vector3 size;
    public Vector3 max;
    public Vector3 min;
    public bool isColliding;
    public CubeBehaviour otherCube;

    private MeshFilter meshFilter;
    private Bounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        bounds = meshFilter.mesh.bounds;
        size = bounds.size;

    }

    // Update is called once per frame
    void Update()
    {
        max = Vector3.Scale(bounds.max, transform.localScale) + transform.position;
        min = Vector3.Scale(bounds.min, transform.localScale) + transform.position;

        CheckCollision(otherCube);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireCube(transform.position, Vector3.Scale(new Vector3(1.0f, 1.0f, 1.0f), transform.localScale));
    }

    private void CheckCollision(CubeBehaviour b)
    {
        if ((min.x <= b.max.x && max.x >= b.min.x) &&
            (min.y <= b.max.y && max.y >= b.min.y) &&
            (min.z <= b.max.z && max.z >= b.min.z))
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }
}
