using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogClicker : MonoBehaviour {

    public int setPage = 0;
    public int setChild = 0;
    
    private int page = 0;
    private int child = 0;
    
    public Color regularFont = Color.white;
    public Color dimmedFont = Color.gray;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        SetPageAndParagraph(setPage, setChild);
    }

    // Update is called once per frame
    void Update() {
        if (setPage != page || setChild != child) {
            SetPageAndParagraph(setPage, setChild);
        }

        if (Input.GetMouseButtonDown(0)) {
            OnClick();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            OnClick();
        }
    }
    
    void SetPageAndParagraph(int page, int child) {
        this.page = page;
        this.child = child;
        setPage = page;
        setChild = child;
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        var pageTransform = transform.GetChild(page);
        if (pageTransform) {
            pageTransform.gameObject.SetActive(true);
            for (int i = 0; i < pageTransform.childCount; i++) {
                var ch = pageTransform.GetChild(i);
                if (i < child) {
                    ch.gameObject.SetActive(true);
                    if (ch.GetComponent<TextMeshProUGUI>()) {
                        ch.GetComponent<TextMeshProUGUI>().faceColor = dimmedFont;
                    }
                } else if (i == child) {
                    ch.gameObject.SetActive(true);
                    if (ch.GetComponent<TextMeshProUGUI>()) {
                        ch.GetComponent<TextMeshProUGUI>().faceColor = regularFont;
                    }
                } else {
                    ch.gameObject.SetActive(false);
                }
            }
        }
    }
    
    void OnClick() {
        var pageTransform = transform.GetChild(page);
        if (child < pageTransform.childCount - 1) {
            child++;
            SetPageAndParagraph(page, child);
        } else if (page < transform.childCount - 1) {
            page++;
            child = 0;
            SetPageAndParagraph(page, child);
        } else {
            OnStartGame();
        }
    }
    
    public void OnStartGame() {
        SceneManager.LoadScene(0);
    }
    
}
