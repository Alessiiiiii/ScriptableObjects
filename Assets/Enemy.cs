using UnityEngine;

public class Enemy : MonoBehaviour, IPresentacion, ITakeDamage
{
    public EnemyData enemyData;

    void Start()  // Se ejecuta una vez al inicio
    {
        Debug.Log($"Enemigo generado: {enemyData.nombre}");
    }

    public void Accion()  // Se ejecuta cuando el jugador presiona 'R'
    {
        Debug.Log($"{enemyData.nombre} dice: {enemyData.saludo}");
    }

    public void RecibirDanio(int cantidad)  // Se ejecuta cuando el jugador ataca (presiona 'E')
    {
        enemyData.vida -= cantidad;
        Debug.Log($"{enemyData.nombre} recibió {cantidad} de daño. Vida restante: {enemyData.vida}");
    }
}