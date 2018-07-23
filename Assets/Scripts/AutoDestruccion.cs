using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruccion : MonoBehaviour {

    //Tiempo en el cual los projectiles va a seguir funcionando.
    public float tiempo = 5f;

	void Update ()
    {

        //En caso de los projectiles sigan su destino sin haber colisionado, se usara el tiempo para que cuando pasen 5 segundos, el objeto se autodestruya.
        //Esto evita la creacion ilimitada de projectiles que pueden provocar inestabilidad en el sistema.

        tiempo -= Time.deltaTime;

        if (tiempo <= 0)
        {
            Destroy(gameObject);
        } 
	}
}