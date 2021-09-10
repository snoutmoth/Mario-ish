using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMonster : MovingMonster
{
   //retirer start et update pour éviter redéfinition!
   override protected void Update() { //réécrire de l'autre méthode, protected = variable qui s'hérite mais invisible)

       Vector2 start = (Vector2)transform.position + Vector2.down * 0.51f; //
       Vector2 direction = Vector2.down;

       if(speed.x < 0) {
           start += Vector2.left * 0.51f;
           
       }
       else {
           start += Vector2.right * 0.51f;
       }

        RaycastHit2D hit = Physics2D.Raycast(start, direction, hitRange); //permet de voir ce qu'il y a devant nous
        Debug.DrawRay(transform.position, Vector2.right, Color.green);

        if(hit.collider == null) {
            speed.x *= - 1; //s'il y a un Collider, on inverse la vitesse en X
       }

       base.Update();
           
    }
}
