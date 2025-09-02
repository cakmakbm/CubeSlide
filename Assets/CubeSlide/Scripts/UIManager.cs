using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   [Header(" Elements")] 
   [SerializeField] private GameObject menuPanel;
   [SerializeField] private GameObject gamePanel;
   [SerializeField] private GameObject gameOverPanel;

   private void Awake()
   {
      
   }

   private void Start() {
      GameManager.onGameStateChange += GameStateChangedCallBack;
      gamePanel.SetActive(false);
      //gameOverPanel.SetActive(false);
      //settingsPanel.SetActive(false);
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
         
         //ShowGameOver();
         
      }

      if (gameState == GameManager.GameState.LevelComplete) {

         //ShowLevelComplete();
         

      }
      
      
      
   }
   
}
