using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMonster : Monster
{
    public Vector2 speed = Vector2.zero; //constante qui donne un vecteur (0,0)

    private SpriteRenderer spriteRenderer;

    public float hitRange = 0.1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    virtual protected void Update()
    {
        //orientation de l'image

        Vector2 start;
        Vector2 direction;

        if(speed.x < 0) {                  //spriteRenderer.flipX = (speed.x < 0);
            spriteRenderer.flipX = true;
            start = (Vector2)transform.position + Vector2.left * 0.51f;
            direction = Vector2.left;
        }
        else {
            spriteRenderer.flipX = false;
            start = (Vector2)transform.position + Vector2.right * 0.51f;
            direction = Vector2.right;
        }
        RaycastHit2D hit = Physics2D.Raycast(start, direction, hitRange); //permet de voir ce qu'il y a devant nous
        Debug.DrawRay(transform.position, Vector2.right, Color.red);

        if(hit.collider != null) {
            speed.x *= - 1; //s'il y a un Collider, on invesre la vitesse en X
        }

        //déplacement
        Vector2 deplacement = speed * Time.deltaTime;
        transform.position += (Vector3)deplacement; //casting : je veux caster déplacement en Vector3
        

        
    }
}
