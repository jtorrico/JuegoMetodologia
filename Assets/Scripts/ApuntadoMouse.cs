using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuntadoMouse : MonoBehaviour {


    //Metodo que permite el movimiento del mouse para el apuntado del sentido de rotacion del jugador.
    private void LateUpdate()
    {

        var mouse = Input.mousePosition;
        var puntoPantalla = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rango = new Vector2(mouse.x - puntoPantalla.x, mouse.y - puntoPantalla.y);
        var angulo = Mathf.Atan2(rango.y, rango.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }
}