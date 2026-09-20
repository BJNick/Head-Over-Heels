using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isGameOver = false;
    public GameObject gameOverPanel;

    void Start()
    {
        if(!isGameOver){
            //gameOverPanel.SetActive(false);
        }

        instance = this;
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

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; 
    }
}
