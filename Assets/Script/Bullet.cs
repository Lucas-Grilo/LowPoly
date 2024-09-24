using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Para fazer a magia andar.

    public float Speed = 200;

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * Speed * Time.deltaTime);
    }


    void OnTriggerEnter(Collider objectCollision) // Para fazer a magia acertar o inimigo.
    {
        if(objectCollision.tag =="Enemy")
        {
            Destroy(objectCollision.gameObject); //Faz o inimigo sumir.
        }
        Destroy (gameObject);
    }
}