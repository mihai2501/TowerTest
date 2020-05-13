using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    
    public void GoToTarget(Transform _target)
    {
        target = _target;
    }
    
    private void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude<=distanceThisFrame && target !=null)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized*distanceThisFrame,Space.World);
    }

    private void HitTarget()
    {
        
        Destroy(gameObject);
        target.gameObject.GetComponent<Enemy>().TakeDamage(50);
    }
}
