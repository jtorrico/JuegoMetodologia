using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarArma : MonoBehaviour {

    // Objetos que representan a cada arma, como avatares.
    public GameObject armaPistola, armaRifle, armaEscopeta;

	// Use this for initialization
	void Start () {

		//En cada inicializacion siempre se activa el primer objeto (Pistola).
		armaPistola.gameObject.SetActive (true);
		armaRifle.gameObject.SetActive (false);
        armaEscopeta.gameObject.SetActive(false);
    }

    void Update()
    {
        //Cuando se cambia de arma, se activa el objeto correspondiente y se desactivan los demas.
        if (Input.GetKey(KeyCode.Alpha1))
        {
            armaPistola.gameObject.SetActive(true);
            armaRifle.gameObject.SetActive(false);
            armaEscopeta.gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            armaPistola.gameObject.SetActive(false);
            armaRifle.gameObject.SetActive(true);
            armaEscopeta.gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            armaPistola.gameObject.SetActive(false);
            armaRifle.gameObject.SetActive(false);
            armaEscopeta.gameObject.SetActive(true);
        }
    }
}