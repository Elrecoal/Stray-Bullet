using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.Elrecoal.Stray_Bullet
{
    public class MainMenu : MonoBehaviour
    {
        public Launcher launcher;

        //Main menu
        private void Start()
        {
            Pause.paused = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void JoinMatch() { launcher.Join(); }
        public void CreateMatch() { launcher.Create(); }
        public void QuitGame() { Application.Quit(); }
        public void Settings() { SceneManager.LoadScene("SettingsMenu"); }
        public void Stats() { SceneManager.LoadScene("StatsMenu"); }
        public void Play() { SceneManager.LoadScene("PlayMenu"); }
        public void CreateMatchMenu() { SceneManager.LoadScene("CreateMatchMenu"); }

        //Secondary menus
        public void ReturnToMainMenu() { SceneManager.LoadScene("MainMenu"); }

    }

}