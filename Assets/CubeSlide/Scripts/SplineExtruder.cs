using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.Splines;

using UnityEngine;
using UnityEngine.Splines;
using System.Collections.Generic;

[RequireComponent(typeof(SplineContainer), typeof(MeshFilter), typeof(MeshRenderer))]
public class SolidSplineExtruder : MonoBehaviour
{
    [Header("Referanslar")]
    private SplineContainer splineContainer;
    private MeshFilter meshFilter;

    [Header("Mesh Ayarları")]
    [SerializeField]
    private float boxWidth = 1.0f;
    [SerializeField]
    private float boxHeight = 1.0f;

    [Header("Detay Ayarları")]
    [Range(2, 200)]
    [SerializeField]
    private int segmentsPerUnit = 10;

    private void OnValidate()
    {
        if (splineContainer == null) splineContainer = GetComponent<SplineContainer>();
        if (meshFilter == null) meshFilter = GetComponent<MeshFilter>();
        if (splineContainer == null || meshFilter == null || splineContainer.Spline == null) return;
        GenerateMesh();
    }
    
    public void GenerateMesh()
    {
        Spline spline = splineContainer.Spline;
        if (spline == null || spline.Count < 2) return;

        Mesh mesh = new Mesh();
        var vertices = new List<Vector3>();
        var triangles = new List<int>();

        // Kutu kesiti (4 köşe)
        float w = boxWidth / 2f;
        float h = boxHeight / 2f;
        Vector3[] crossSection = new Vector3[]
        {
            new Vector3(-w, -h, 0), new Vector3(w, -h, 0),
            new Vector3(w, h, 0), new Vector3(-w, h, 0)
        };

        int totalSegments = Mathf.Max(1, Mathf.RoundToInt(spline.GetLength() * segmentsPerUnit));

        // YAN DUVARLARI OLUŞTURMA
        for (int i = 0; i <= totalSegments; i++)
        {
            float t = (float)i / totalSegments;
            spline.Evaluate(t, out Unity.Mathematics.float3 position, out Unity.Mathematics.float3 tangent, out Unity.Mathematics.float3 upVector);

            // BÜKÜLMEYİ ÖNLEYEN STABİL YÖNELİM HESAPLAMASI
            Quaternion orientation;
            if (Mathf.Abs(Vector3.Dot(tangent, Vector3.up)) > 0.99f) // Eğer tam yukarı/aşağı bakıyorsa farklı bir referans kullan
            {
                orientation = Quaternion.LookRotation(tangent, Vector3.forward);
            }
            else
            {
                orientation = Quaternion.LookRotation(tangent, Vector3.up);
            }

            for (int j = 0; j < crossSection.Length; j++)
            {
                vertices.Add((Vector3)position + orientation * crossSection[j]);
            }
        }

        for (int i = 0; i < totalSegments; i++)
        {
            int rootIndex = i * crossSection.Length;
            for (int j = 0; j < crossSection.Length; j++)
            {
                int nextJ = (j + 1) % crossSection.Length;
                triangles.Add(rootIndex + j);
                triangles.Add(rootIndex + nextJ + crossSection.Length);
                triangles.Add(rootIndex + nextJ);
                triangles.Add(rootIndex + j);
                triangles.Add(rootIndex + j + crossSection.Length);
                triangles.Add(rootIndex + nextJ + crossSection.Length);
            }
        }

        // KAPAKLARI OLUŞTURMA (İÇİNİ DOLDURMA)
        // Başlangıç Kapağı
        int startIndex = 0;
        triangles.Add(startIndex + 0);
        triangles.Add(startIndex + 2);
        triangles.Add(startIndex + 1);
        triangles.Add(startIndex + 0);
        triangles.Add(startIndex + 3);
        triangles.Add(startIndex + 2);

        // Bitiş Kapağı
        int endIndex = vertices.Count - crossSection.Length;
        triangles.Add(endIndex + 0);
        triangles.Add(endIndex + 1);
        triangles.Add(endIndex + 2);
        triangles.Add(endIndex + 0);
        triangles.Add(endIndex + 2);
        triangles.Add(endIndex + 3);

        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        meshFilter.mesh = mesh;
    }
}