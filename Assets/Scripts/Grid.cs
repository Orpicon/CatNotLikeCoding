using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
    public int xSize, ySize;
    private Vector3[] vertices;
    private Mesh mesh;
    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
       // WaitForSeconds wait = new WaitForSeconds(0.05f);

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
                //  yield return wait;
            }
        }
        mesh.vertices = vertices;
        int[] triangles = new int[xSize * 6 * ySize];
        for (int i = 0, j = 0, y = 0; y < ySize; y++, j++) {
            for (int x = 0; x < xSize; x++, i += 6, j++)
        {
            triangles[i] = j + 0;
            triangles[i + 1] = triangles[i + 4] = j + xSize + 1;
            triangles[i + 2] = triangles[i + 3] = j + 1;
            triangles[i + 5] = j + xSize + 2;
            mesh.triangles = triangles;
            //yield return wait;
        }
    }
    }
}