using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {   
        Player = GameObject.FindWithTag("Player");        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Player.transform.position - transform.position;

        Quaternion newRotation = Quaternion.LookRotation(direction);
        GetComponent<Rigidbody>().MoveRotation(newRotation);

        Vector3 moveDirection = Player.transform.position - transform.position;
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (moveDirection.normalized * Speed * Time.deltaTime));
    }
}
