using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    public Transform BasuraInicio;

    [Header("Configuración del Rectángulo")]
    public Vector2 rectangleSize = new Vector2(60f, 30f);

    [Header("Prefabs")]
    public List<GameObject> prefabs;

    [Header("Configuración de Generación")]
    public int numberOfSpawns = 14;
    public int prefabsPerGroup = 4;

    private void Start()
    {
        GeneratePrefabsInRectangle();
    }

    private void GeneratePrefabsInRectangle()
    {
        if (prefabs == null || prefabs.Count == 0)
        {
            Debug.LogWarning("No hay prefabs asignados en la lista.");
            return;
        }

        for (int i = 0; i < numberOfSpawns; i++)
        {
            // Generar un punto aleatorio dentro del rectángulo
            Vector2 randomPosition = new Vector2(
                Random.Range(BasuraInicio.transform.position.x -(rectangleSize.x / 2), BasuraInicio.transform.position.x + (rectangleSize.x / 2)),
                Random.Range(BasuraInicio.transform.position.y -(rectangleSize.y / 2), BasuraInicio.transform.position.y + (rectangleSize.y / 2))
            );

            // Generar un grupo de prefabs en el punto aleatorio
            for (int j = 0; j < prefabsPerGroup; j++)
            {
                // Seleccionar un prefab al azar
                GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Count)];

                // Calcular una posición ligeramente desplazada dentro del grupo
                Vector2 offset = Random.insideUnitCircle * 0.5f;
                Vector2 spawnPosition = randomPosition + offset;

                // Instanciar el prefab
                Instantiate(randomPrefab, new Vector2(spawnPosition.x,  spawnPosition.y), Quaternion.identity);
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Dibujar el rectángulo en la vista de escena
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(BasuraInicio.transform.position, new Vector2(rectangleSize.x, rectangleSize.y));
    }
}
