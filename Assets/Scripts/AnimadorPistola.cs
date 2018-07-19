using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimadorPistola : MonoBehaviour
{
    //Animador para el uso de animaciones (en este caso para la pistola).
    Animator AnimacionPistola;


    void Start()
    {

        AnimacionPistola = GetComponent<Animator>();
    }

    void Update()
    {

        //Animacion Pistola.
        //Animacion de Movimiento.
        //Al presionar y mantener la tecla, cambia el estado de la variable y reproduce la animacion.

        if (Input.GetKeyDown(KeyCode.W))
        {
            AnimacionPistola.SetInteger("Mover", 1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AnimacionPistola.SetInteger("Mover", 1);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AnimacionPistola.SetInteger("Mover", 1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AnimacionPistola.SetInteger("Mover", 1);
        }

        //Cuando se deja de presionar la tecla, cambia el estado y detiene la animacion.

        if (Input.GetKeyUp(KeyCode.W))
        {
            AnimacionPistola.SetInteger("Mover", 0);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            AnimacionPistola.SetInteger("Mover", 0);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            AnimacionPistola.SetInteger("Mover", 0);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            AnimacionPistola.SetInteger("Mover", 0);
        }
    }
}