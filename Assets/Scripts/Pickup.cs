using UnityEngine;

public class Pickup : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Notificar al GameManager
            if (GameManager.Instance != null)
                GameManager.Instance.RecogerColeccionable();

            // Reproducir sonido
            if (AudioManager.Instance != null)
                AudioManager.Instance.ReproducirRecoger();

            // Efecto visual (si tienes un prefab de partículas)
            // Instantiate(particulaPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}