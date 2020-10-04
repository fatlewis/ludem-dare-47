using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;

    public int floaterCount = 1;

    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;

    public Transform surface;

    private void FixedUpdate()
    {
        WaveManager waveManager = surface.GetComponentInParent<WaveManager>();

        // Add Gravity at floater position
        rigidBody.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);

        float waveHeight = waveManager.GetWaveHeight(transform.position.x) + surface.position.y;
        if (transform.position.y < waveHeight)
        {
            // Clamp Between 1 and 100 so it doesn't displace too much
            float displacementMultiplier = Mathf.Clamp((waveHeight - transform.position.y) / depthBeforeSubmerged, 0, 100) * displacementAmount;

            rigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rigidBody.AddForce(displacementMultiplier * -rigidBody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidBody.AddTorque(displacementMultiplier * -rigidBody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
