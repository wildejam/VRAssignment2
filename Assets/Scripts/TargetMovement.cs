using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public Vector3 initialPosition;
    public Vector3 movementOffset = new Vector3(1f, 0f, 0f);

    private void Start()
    {
        transform.position = initialPosition;

    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Destroy(collision.body);
    }
    private void FixedUpdate()
    {
        float basePosOffset = Mathf.PingPong(Time.time, 1);
        transform.position = Vector3.Lerp(transform.position - movementOffset, transform.position + movementOffset, basePosOffset);
    }
}
