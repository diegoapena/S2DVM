using UnityEngine;
using Unity.AI.Navigation;
 

public class Obstacle : MonoBehaviour
{
    private NavMeshLink navMeshLink; // Referencia al componente NavMeshLink
    private float timer = 0f; // Temporizador
    private float randomTime; // Tiempo aleatorio para el próximo cambio

    public float minTime = 1f; // Tiempo mínimo
    public float maxTime = 3f; // Tiempo máximo

    void Start()
    {
        // Obtén el componente NavMeshLink del GameObject
        navMeshLink = GetComponent<NavMeshLink>();

        if (navMeshLink == null)
        {
            Debug.LogError("No se encontró un componente NavMeshLink en este GameObject.");
            return;
        }

        // Genera un tiempo aleatorio inicial
        randomTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        // Incrementa el temporizador
        timer += Time.deltaTime;

        // Si el temporizador supera el tiempo aleatorio, alterna el estado
        if (timer >= randomTime)
        {
            navMeshLink.enabled = !navMeshLink.enabled; // Activa o desactiva el NavMeshLink
            Debug.Log("NavMeshLink activado: " + navMeshLink.enabled);

            // Reinicia el temporizador y genera un nuevo tiempo aleatorio
            timer = 0f;
            randomTime = Random.Range(minTime, maxTime);
        }
    }
}
