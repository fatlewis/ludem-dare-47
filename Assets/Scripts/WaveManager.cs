using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class WaveManager : MonoBehaviour
{
    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;

    public float GetWaveHeight(float x)
    {
        float offset = Time.fixedTime * speed;
        float waveHeightAtX = amplitude * Mathf.Sin(x / length + offset);
        return waveHeightAtX;
    }
}
