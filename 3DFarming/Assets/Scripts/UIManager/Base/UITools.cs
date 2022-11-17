using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BaseTools
{
    public class UITools
    {
        #region change scene
        public static void ChangeScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        public static void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public static void ReloadScene()
        {
            try
            {
                int index = SceneManager.GetActiveScene().buildIndex;
                ChangeScene(index);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                throw;
            }
        }
        #endregion

        #region exit game

        public static void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
        #endregion

        #region Pause

        public static void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public static void ResumeGame()
        {
            Time.timeScale = 1f;
        }

        #endregion
    }   
}