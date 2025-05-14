using UnityEngine;

public class Enemy : MonoBehaviour, IPresentacion, ITakeDamage
{
    public EnemyData enemyData;

    void Start()  
    {
        Debug.Log($"Enemigo generado: {enemyData.nombre}");
    }

    public void Accion()  
    {
        Debug.Log($"{enemyData.nombre} dice: {enemyData.saludo}");
    }

    public void RecibirDanio(int cantidad)  
    {
        enemyData.vida -= cantidad;
        Debug.Log($"{enemyData.nombre} recibió {cantidad} de daño. Vida restante: {enemyData.vida}");
    }
}