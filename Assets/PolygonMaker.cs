using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonMaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MakeBeam(355, 15, 45, 60, 2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject MakeBeam(float aziMin, float aziMax,
        float elvMin, float elvMax, float ranMin, float ranMax,
        int row = 3, int col = 6)
    {
        GameObject go = new GameObject("Beam");

        /*
        Mesh mesh = new Mesh();
        MeshFilter mf = go.AddComponent<MeshFilter>();
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        Material mt = new Material(Shader.Find("Standard"));
        */


        Vector3[] top = new Vector3[(row+1) * (col+1)];
        Vector3[] bottom = new Vector3[(row+1) * (col+1)];

        Vector3[] left = new Vector3[(row+1) * 2];
        Vector3[] right = new Vector3[(row+1) * 2];

        Vector3[] front = new Vector3[(col+1) * 2];
        Vector3[] back = new Vector3[(col+1) * 2];

        float aziInterval = ((aziMin > aziMax)?(360f-aziMin+aziMax):aziMax-aziMin) / (float)col;
        float elvInterval = (elvMax - elvMin) / (float)row;
        for (int i=0; i<=row; ++i)
        {
            for (int j=0; j<=col; ++j)
            { 
                float yAxis = aziMin + aziInterval * j;
                float yAxisTan = Mathf.Tan(yAxis);

                float xAxis = elvMin + elvMin * i;
                xAxis
                float xAxisTan = Mathf.Tan(xAxis);

                /*
                Vector3 pos = Vector3.zero;
                if (yAxis >= 90f && yAxis < 270f)
                {
                    pos = new Vector3(yAxisTan * -1, 0, -1);
                    pos.Normailized();
                    pos += new Vector3(0, xAxisTan, 0);
                }
                else
                {
                    pos = new Vector3(yAxisTan, 0, 1);
                }
                new Vector3( Vector3.forward * Mathf.Tan(elvMin + elvInterval * j));
                pos = top[i*(col) + j];
                */
            }
        }

        /*
        Vector3[] vertices = {  };
        Vector2[] uvs = {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1)
        };

        int[] triangles = { 0, 1, 2 };
        mt.mainTexture = (Texture) Resources.Load("");
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.normals = new Vector3[] { Vector3.up, Vector3.up, Vector3.up };

        mf.mesh = mesh;
        mr.material = mt;
        */

        return go;
    }

    #region polygon
    public GameObject MakePolygon(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        GameObject go = new GameObject("Polygon");

        Mesh mesh = new Mesh();
        MeshFilter mf = go.AddComponent<MeshFilter>();
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        Material mt = new Material(Shader.Find("Standard"));

        Vector3[] vertices = { p1, p2, p3 };
        Vector2[] uvs = {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1)
        };

        int[] triangles = { 0, 1, 2 };
        mt.mainTexture = (Texture) Resources.Load("");
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.normals = new Vector3[] { Vector3.up, Vector3.up, Vector3.up };

        mf.mesh = mesh;
        mr.material = mt;

        return go;
    }
    #endregion
}
