using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject player;//aca tendriamos q poner el nombre del script del personaje

    private bool juegoTerminado = false;

    private void Start()
    {
        if (player != null)
        {
            //player.OnDeath.AddListener(IrAGameOver);
            //player.OnVictory.AddListener(IrAVictoria);
        }
        else
        {
            Debug.LogError("Jugador no asignado en GameManager");
        }
    }

    public void IrAGameOver()
    {
        if (!juegoTerminado)
        {
            juegoTerminado = true;
            StartCoroutine(CargarGameOver());
        }
    }

    public void IrAVictoria()
    {
        if (!juegoTerminado)
        {
            juegoTerminado = true;
            StartCoroutine(CargarVictoria());
        }
    }

    private System.Collections.IEnumerator CargarGameOver()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2); // pongan el numero que le corresponderia a la esena 
    }

    private System.Collections.IEnumerator CargarVictoria()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("NextLevel"); // ponganle el nombre que tendria la esena de victoria
    }

    private void OnDestroy()
    {
        if (player != null)
        {
            //player.OnDeath.RemoveListener(IrAGameOver);
            //player.OnVictory.RemoveListener(IrAVictoria);
        }
    }
}
