using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public GameObject rightHandReference;
    public GameObject leftHandReference;

    private Vector3 rightHandPreviousPos = Vector3.zero;
    private Vector3 leftHandPreviousPos = Vector3.zero;
    private float rightHandDistanceMoved = 0;
    private float leftHandDistanceMoved = 0;

    private void Start()
    {
        rightHandPreviousPos = rightHandReference.transform.position;
        leftHandPreviousPos = leftHandReference.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between current pos and previous pos
        Vector3 rightHandCurrentPos = rightHandReference.transform.position;
        Vector3 leftHandCurrentPos = leftHandReference.transform.position;
        rightHandDistanceMoved = Vector3.Distance(rightHandPreviousPos, rightHandCurrentPos);
        leftHandDistanceMoved = Vector3.Distance(leftHandPreviousPos, leftHandCurrentPos);


        // Use the distance travelled since the previous frame to inform the timescale of the simulation
        Time.timeScale = (rightHandDistanceMoved + leftHandDistanceMoved) * 90;

        rightHandPreviousPos = rightHandCurrentPos;
        leftHandPreviousPos = leftHandCurrentPos;
    }
}
