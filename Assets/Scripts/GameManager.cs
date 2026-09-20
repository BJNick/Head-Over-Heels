using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     public static GameManager Instance { get; private set; }

    private bool isGameOver = false;
    public GameObject gameOverPanel;
    private Vector3 checkpointCoords;
    private GameObject player;

    void Awake()
    {
        // If an instance already exists and it's not this one, destroy the duplicate
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the active instance and protect it from scene unloads
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        player = GameObject.Find("Player");
        if(!isGameOver){
            //gameOverPanel.SetActive(false);
        }
        print(checkpointCoords + "...");
        print(checkpointCoords);
        if(checkpointCoords != Vector3.zero)
        {
            player.transform.position = checkpointCoords;
        }
        print("Player position: " + player.transform.position);
        Time.timeScale = 1f; 
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R) || (Input.GetKeyDown(KeyCode.Space) && isGameOver)) {
            Restart(); 
        }
    }

    public void GameOver(){
        if(isGameOver) return;
        isGameOver = true;
        //gameOverPanel.SetActive(true);
        DeathAnim.instance.PlayDeathAnimation();
        Time.timeScale = 0f; 
    }

    public void Restart() {
        isGameOver = false;
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SaveCheckpointCoords()
    {
        checkpointCoords = player.transform.position;
        print("New Checkpoint Coords: " + checkpointCoords);
    }
}
