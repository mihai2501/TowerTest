using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMonsters : MonoBehaviour
{
    [Header("Unity stuff")]
    [SerializeField]private Transform target;    
    public GameObject projectile;
    public Transform towerShootPosition;
    [Header("Attributes to change")]
    public float range = 2.1f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    private void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }
    private void Update()
    {
        if (target==null)
        {
            return;
        }
        if (fireCountdown<=0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bulletGameObj =  Instantiate(projectile, towerShootPosition.position, towerShootPosition.rotation);
        Bullet bullet = bulletGameObj.GetComponent<Bullet>();
        if (bullet!=null)
        {
            bullet.GoToTarget(target);
        }
    }

    public void ShootTarget(Vector3 location)
    {       
        Instantiate(projectile, location,Quaternion.identity);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("FlyingEnemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
            if (distanceToEnemy<shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy!=null && shortestDistance<=range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
