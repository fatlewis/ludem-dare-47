using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(WaveManager))]
public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;
    private WaveManager waveManager;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        waveManager = GetComponent<WaveManager>();
    }

    private void Update()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = waveManager.GetWaveHeight(transform.position.x + vertices[i].x);
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
}
