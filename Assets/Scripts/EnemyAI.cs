using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Patrulla")]
    public Transform[] waypoints;
    private int indiceActual = 0;

    [Header("Persecución")]
    public float distanciaDeteccion = 8f;
    public float distanciaAtaque = 1.5f;
    public Transform jugador;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Si no asignaste el jugador, lo busca por tag
        if (jugador == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) jugador = p.transform;
        }

        IrAlSiguienteWaypoint();
    }

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= distanciaDeteccion)
        {
            // Persecución
            agent.SetDestination(jugador.position);

            if (distancia <= distanciaAtaque)
            {
                // Aquí podrías reiniciar el nivel o quitar vida
                Debug.Log("¡El enemigo te atrapó!");
            }
        }
        else
        {
            // Patrulla
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                IrAlSiguienteWaypoint();
            }
        }
    }

    void IrAlSiguienteWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[indiceActual].position);
        indiceActual = (indiceActual + 1) % waypoints.Length;
    }
}