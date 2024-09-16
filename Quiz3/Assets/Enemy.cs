using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private float orbitRadius;
    private float baseSpeed;
    private int rand;
    private float angle;

    void Start()
    {
        rand = Random.Range(0, 2);
        if(rand == 0)
        {
            orbitRadius = transform.position.x;
        }
        if(rand == 1)
        {
            orbitRadius = -transform.position.x;
        }
        baseSpeed = orbitRadius;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        float speed = baseSpeed * (distanceToPlayer/50);

        angle += speed * Time.deltaTime;
        if (angle > 64f) angle -= 64f;
        if (angle < -64f) angle += 64f;

        float x = Mathf.Cos(angle) * orbitRadius;
        float y = Mathf.Sin(angle) * orbitRadius;

        transform.position = player.position + new Vector3(x, y, 0);

        transform.up = (player.position - transform.position).normalized;
    }
}
