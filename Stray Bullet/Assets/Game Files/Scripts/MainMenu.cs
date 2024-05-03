using UnityEngine;

namespace Com.Elrecoal.Stray_Bullet
{
    public class MainMenu : MonoBehaviour
    {

        public Launcher launcher;

        private void Start()
        {
            Pause.paused = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void JoinMatch()
        {

            launcher.Join();

        }

        public void CreateMatch()
        {

            launcher.Create();

        }

        public void QuitGame()
        {

            Application.Quit();

        }

    }
}