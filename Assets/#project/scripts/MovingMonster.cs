using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class MovingMonster : Monster
{
    public Vector2 speed = Vector2.zero; //constante qui donne un vecteur (0,0)

    private SpriteRenderer spriteRenderer;

    [Tooltip("if the monster detects an obstacle at a distance equal or less, they turn")]
    public float hitRange = 0.1f;

    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    virtual protected void Update()
    {
        //orientation de l'image

        Vector2 start;
        Vector2 direction;

        if (speed.x < 0)
        {
            //si j'ai pas d'animation, il faut automatiquement un flip pour moi : les deux anim sont autonomes
            if (animator != null)
            {
                animator.SetBool("Right", false);
            }
            else
            {
                spriteRenderer.flipX = true;
            }

            //spriteRenderer.flipX = (speed.x < 0);

            start = (Vector2)transform.position + Vector2.left * 0.51f;
            direction = Vector2.left;
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("Right", true);
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            start = (Vector2)transform.position + Vector2.right * 0.51f;
            direction = Vector2.right;
        }
        RaycastHit2D hit = Physics2D.Raycast(start, direction, hitRange); //permet de voir ce qu'il y a devant nous
        Debug.DrawRay(transform.position, Vector2.right, Color.red);

        if (hit.collider != null && !hit.transform.CompareTag("Player"))
        {
            speed.x *= -1; //s'il y a un Collider, on invesre la vitesse en X
        }

        //déplacement
        Vector2 deplacement = speed * Time.deltaTime;
        transform.position += (Vector3)deplacement; //casting : je veux caster déplacement en Vector3



    }
}
