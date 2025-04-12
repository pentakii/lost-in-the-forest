using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private Animator Animator;

    [SerializeField] private Transform[] waypoints;  //Es el camino que sigue el enemigo
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float chaseRange = 5f;    //Es la distancia para empezar a seguir al jugador
    [SerializeField] private float loseRange = 7f;      //es la distancia para dejar de seguirlo
    [SerializeField] private Transform player;

    private int waypointIndex = 0;
    private bool isChasing = false;

    void Start()
    {
        Animator = GetComponent<Animator>();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (isChasing)
        {
            if (distanceToPlayer > loseRange)
            {
                isChasing = false; // el jugador se alejo
            }
            else
            {
                ChasePlayer();
                return;
            }
        }
        else
        {
            if (distanceToPlayer <= chaseRange)
            {
                isChasing = true; // el jugador se acerco
                ChasePlayer();
                return;
            }
        }

        Path();
    }

    private void Path()
    {
        if (waypoints.Length == 0) return;

        Vector2 targetPos = waypoints[waypointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        Vector2 direction = (targetPos - (Vector2)transform.position).normalized;
        Animator.SetFloat("Horizontal", direction.x);
        Animator.SetFloat("Vertical", direction.y);

        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }

    private void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        Animator.SetFloat("Horizontal", direction.x);
        Animator.SetFloat("Vertical", direction.y);
    }
}