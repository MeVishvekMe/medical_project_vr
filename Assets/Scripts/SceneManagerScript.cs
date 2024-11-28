using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {
    public void LoadHeartQuizScene() {
        SceneManager.LoadScene("HeartQuiz");
    }

    public void LoadHeartQuizScene2()
    {
        SceneManager.LoadScene("HeartQuiz2");
    }

    public void LoadAnatomyLab() {
        SceneManager.LoadScene("HumanAnatomyScene");
    }

    public void LoadHeartScene() {
        SceneManager.LoadScene("HeartSceneMain");
    }

    public void ReloadScene() {
        Debug.Log("ResetCurrentScene");
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
