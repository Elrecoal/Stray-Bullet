using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.Elrecoal.Stray_Bullet
{
    public class Pause : MonoBehaviourPunCallbacks
    {

        public static bool paused = false;
        private bool disconnecting = false;

        public void TogglePause()
        {
            if (disconnecting) return;

            paused = !paused;

            transform.GetChild(0).gameObject.SetActive(paused);
            Cursor.lockState = (paused) ? CursorLockMode.None : CursorLockMode.Confined;
            Cursor.visible = paused;
        }

        public void Quit()
        {
            disconnecting = true;
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene(0);
        }

        public override void OnLeftRoom()
        {
            // Carga la escena del lobby o men� principal
            SceneManager.LoadScene("MainMenu");
        }


    }
}