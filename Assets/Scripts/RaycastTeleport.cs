using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastTeleport : MonoBehaviour
{
    [SerializeField]
    private GameObject playerOrigin;
    [SerializeField]
    private LayerMask teleportMask;
    [SerializeField]
    private InputActionReference teleportButtonPress;

    private void Start()
    {
        teleportButtonPress.action.performed += DoRaycast;
    }

    void DoRaycast(InputAction.CallbackContext __)
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, teleportMask))
        {
            // Debug.Log(hit.collider.gameObject.name);
            playerOrigin.transform.position = hit.collider.gameObject.transform.position;
        }
    }


}
