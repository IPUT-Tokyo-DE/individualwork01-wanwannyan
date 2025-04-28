using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");  // 正しいシーン名を入力
    }
}
