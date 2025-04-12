using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Animator Animator;
    [SerializeField] private float rayLenght;
    [SerializeField] private int speed;

    [SerializeField] private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;

        //RaycastHit2D VisionField = Physics2D.Raycast(transform.position, direction, rayLenght, layerMask);

        transform.Translate(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0);

        //if (VisionField.collider != null)
        //{
            
        //}

        Animator.SetFloat("Horizontal", direction.x);
        Animator.SetFloat("Vertical", direction.y);
    }

    public void ChangeRayLenght(float newRay)
    {
        rayLenght = newRay;
    }
}