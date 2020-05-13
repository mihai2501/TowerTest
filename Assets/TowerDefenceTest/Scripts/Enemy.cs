using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Transform target;
    private int waypointIndex = 0;
    [Header("HealthBarStuff")]
    private int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;

    private Animator _enemyAnimator;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _enemyAnimator = GetComponent<Animator>();
        target = Waypoints.points[0];

    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {

            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {

            EndPath();

            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            //_enemyAnimator.SetTrigger("death");
            Destroy(gameObject);
        }
    }
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
