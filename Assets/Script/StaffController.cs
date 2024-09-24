using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StaffController : MonoBehaviour
{
    public GameObject Magic; //Criando a variavel Magic do tipo GameObject.
    public GameObject StaffTip; // StaffTip é referente a ponta do cajado.


    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(Magic, StaffTip.transform.position, StaffTip.transform.rotation);

        }

    }

}
