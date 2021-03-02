using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WallGenerator
{
    public class RestartBtn : MonoBehaviour
    {
        Button restartBtn;

        private void Awake()
        {
            restartBtn = GetComponent<Button>();
            restartBtn.onClick.AddListener(RestartTheScene);
        }

        void RestartTheScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
