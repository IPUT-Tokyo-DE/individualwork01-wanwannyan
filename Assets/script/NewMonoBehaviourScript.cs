using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneController : MonoBehaviour
{
    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene"); // タイトルのシーン名を書く
    }
}
