using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float move_speed = 100f;
    private GameObject playerTarget;
    private float shootCooldownTimer = 0;

    public GameObject BulletTemplate;
    public GameObject HitBox;
    public float shootPower = 5000f;
    public float shootCooldownValue = 5f;

    private void OnTriggerEnter(Collider other)
    {
        playerTarget = other.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Only move forward/shoot when we have a player target
        if (playerTarget != null)
        {
            transform.LookAt(playerTarget.transform.position);
            transform.position += transform.forward * move_speed * Time.deltaTime;

            // Shoot when cooldown has expired
            if (shootCooldownTimer >= shootCooldownValue)
            {
                Shoot();
                shootCooldownTimer = 0;
            }
            shootCooldownTimer += Time.deltaTime;

        }

    }

    void Shoot()
    {
        Vector3 bulletSpawnPoint = transform.position;
        bulletSpawnPoint.y += 1;
        GameObject newBullet = Instantiate(BulletTemplate, bulletSpawnPoint, transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
    }

}
