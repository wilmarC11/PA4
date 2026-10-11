using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Objetivo")]
    public int totalColeccionables = 10;
    private int coleccionablesRecogidos = 0;

    [Header("UI")]
    public TextMeshProUGUI textoContador;
    public GameObject panelVictoria;

    void Awake()
    {
        // Singleton simple
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        ActualizarUI();
        if (panelVictoria != null) panelVictoria.SetActive(false);
    }

    public void RecogerColeccionable()
    {
        coleccionablesRecogidos++;
        ActualizarUI();

        if (coleccionablesRecogidos >= totalColeccionables)
        {
            Ganar();
        }
    }

    void ActualizarUI()
    {
        if (textoContador != null)
            textoContador.text = "Coleccionables: " + coleccionablesRecogidos + " / " + totalColeccionables;
    }

    void Ganar()
    {
        if (panelVictoria != null) panelVictoria.SetActive(true);
        if (AudioManager.Instance != null) AudioManager.Instance.ReproducirVictoria();
    }
}