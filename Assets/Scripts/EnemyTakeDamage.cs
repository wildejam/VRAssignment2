using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{

    [SerializeField]
    private GameObject parentObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DamageFromPlayer")
        Destroy(parentObject);
    }
}
