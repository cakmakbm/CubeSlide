using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   [Header(" Elements")] 
   [SerializeField] private GameObject menuPanel;
   [SerializeField] private GameObject gamePanel;
   [SerializeField] private GameObject gameOverPanel;
   [SerializeField] private GameObject levelComplete;
   [SerializeField] private TextMeshProUGUI levelText;

   private void Awake()
   {
      
   }

   private void Start() {
      GameManager.onGameStateChange += GameStateChangedCallBack;
      gamePanel.SetActive(false);
      gameOverPanel.SetActive(false);
      levelText.text = "Level " + (PlayerPrefs.GetInt("level", 0)+1);
      levelText.color= Color.black;
     
     
      
   }

   private void Update() {
      
      
      
   }

   public void PlayButtonPressed() {
      
      GameManager.instance.SetGameState(GameManager.GameState.Game);
      menuPanel.SetActive(false);
      gamePanel.SetActive(true);
      
      
   }

   private void OnDestroy() {
      
      GameManager.onGameStateChange -= GameStateChangedCallBack;
      
   }

   private void GameStateChangedCallBack(GameManager.GameState gameState) {

      if (gameState == GameManager.GameState.GameOver) {
         
         ShowGameOver();
         
      }

      if (gameState == GameManager.GameState.LevelComplete) {

         ShowLevelComplete();
         

      }
      
      
      
   }
   public void RetryButtonPressed() {
      
      SceneManager.LoadScene(0);

   }
   
   public void ShowLevelComplete() {
      
      gameOverPanel.SetActive(false);
      levelComplete.SetActive(true);
      
   }
   public void ShowGameOver() {
      
      gamePanel.SetActive(false);
      gameOverPanel.SetActive(true);
      
   }
   
}
