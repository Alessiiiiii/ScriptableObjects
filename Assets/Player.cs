using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()  // Se ejecuta en cada frame
    {
        MoverJugador();

        if (Input.GetKeyDown(KeyCode.R))  // Interacción con enemigos cercanos
        {
            InteractuarConEnemigo();
        }

        if (Input.GetKeyDown(KeyCode.E))  // Ataque a enemigos cercanos
        {
            AtacarEnemigo();
        }
    }

    void MoverJugador()  // Movimiento en X, Y y Z con WASD
    {
        float horizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;  // A/D - Izquierda/Derecha
        float vertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;      // W/S - Adelante/Atrás
        float altura = 0;

        if (Input.GetKey(KeyCode.Space))  // Subir con Espacio
        {
            altura = velocidad * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftControl))  // Bajar con Ctrl
        {
            altura = -velocidad * Time.deltaTime;
        }

        transform.Translate(horizontal, altura, vertical);  // Aplica el movimiento en los tres ejes
    }
    Enemy FindClosestEnemy()
    {
        float rangoDeteccion = 5f;  // Define la distancia máxima de búsqueda
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