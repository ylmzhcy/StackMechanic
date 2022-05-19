using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StackMoney
{
    public class scMenuManager : MonoBehaviour
    {
        [SerializeField]
        GameObject _pausePanel;

        [SerializeField]
        GameObject _bgSound;

        [SerializeField]
        GameObject _stackerSound;

        [SerializeField]
        scAptSettings[] _buildSettings;

        public void BtnPause()
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        public void BtnCloseMenu()
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        public void BtnMute()
        {
            _bgSound.GetComponent<AudioSource>().volume = 0;
            _stackerSound.GetComponent<AudioSource>().volume = 0;
        }

        public void BtnUnMute()
        {
            _bgSound.GetComponent<AudioSource>().volume = 0.05f;
            _stackerSound.GetComponent<AudioSource>().volume = 0.5f;
        }

        public void BtnResetBuild()
        {
            foreach (var item in _buildSettings)
            {
                item.buildIsBought = false;
                item.buildGivedMoney = 0;
            }
            SceneManager.LoadScene("Game");
            Time.timeScale = 1;
        }
        public void BtnMainMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}