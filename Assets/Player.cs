using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()  
    {
        MoverJugador();

        if (Input.GetKeyDown(KeyCode.R))  
        {
            InteractuarConEnemigo();
        }

        if (Input.GetKeyDown(KeyCode.E))  
        {
            AtacarEnemigo();
        }
    }

    void MoverJugador()
    {
        float horizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
        transform.Translate(horizontal, 0, vertical); 

       }
    Enemy FindClosestEnemy()
    {
        float rangoDeteccion = 5f;  
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangoDeteccion);

        Enemy enemigoMasCercano = null;
        float distanciaMinima = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            Enemy enemigo = collider.GetComponent<Enemy>();
            if (enemigo != null)
            {
                float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
                if (distancia < distanciaMinima)
                {
                    distanciaMinima = distancia;
                    enemigoMasCercano = enemigo;
                }
            }
        }
        return enemigoMasCercano;
    }

    void InteractuarConEnemigo()
    {
        Enemy enemigoCercano = FindClosestEnemy();
        if (enemigoCercano != null)
        {
            enemigoCercano.Accion();
        }
    }

    void AtacarEnemigo()
    {
        Enemy enemigoCercano = FindClosestEnemy();
        if (enemigoCercano != null)
        {
            enemigoCercano.RecibirDanio(10);
        }
    }
}