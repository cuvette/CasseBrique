using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int vies = 3;
    public int briques = 20;
    public float delaiAvantReset = 1f;
    public Text TexteVies;
    public GameObject gameOver;
    public GameObject Bravo;
    public GameObject prefabBrique;
    public GameObject barre;
    public GameObject particuleBrique;
    public static GameManager instance = null;

    private GameObject cloneBarre;
    private Scene sceneActuelle;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();

    }

    public void Setup()
    {
        cloneBarre = Instantiate(barre, transform.position, Quaternion.identity) as GameObject;
        Instantiate(prefabBrique, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (briques < 1)
        {
            Bravo.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", delaiAvantReset);
        }

        if (vies < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", delaiAvantReset);
        }

    }

    void Reset()
    {
        Time.timeScale = 1f;
        sceneActuelle = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneActuelle.name);
    }

    public void LoseLife()
    {
        vies--;
        TexteVies.text = "Vies " + vies;
        Instantiate(particuleBrique, cloneBarre.transform.position, Quaternion.identity);
        Destroy(cloneBarre);
        Invoke("SetupPaddle", delaiAvantReset);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        cloneBarre = Instantiate(barre, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        briques--;
        CheckGameOver();
    }
}