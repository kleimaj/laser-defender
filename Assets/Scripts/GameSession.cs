using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour {

    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Awake() {
        SetUpSingleton();
    }

    private void Update() {
        UpdateCanvasScore();
    }

    private void SetUpSingleton() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UpdateScore(int score) {
        this.score += score;
        UpdateCanvasScore();
    }

    public void UpdateCanvasScore() {
        textMeshProUGUI.text = score.ToString();
    }

    public void ResetGame() {
        Destroy(gameObject);
    }
}
