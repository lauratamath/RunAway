using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Movimiento : MonoBehaviour
{
    private NavMeshAgent jugador;
    public GameObject wp; //WayPoint
    // Start is called before the first frame update
    void Start()
    {
        jugador = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Se coloca 0 para indicar que es el izquierdo
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Para sacar un ray directamente del mouse

            RaycastHit hitInfo;

            if(Physics.Raycast(myRay,out hitInfo))
            {
                jugador.SetDestination(hitInfo.point);
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
            Destroy(gameObject);
    }
}
