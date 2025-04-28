using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // プレイヤーの位置
    public float followSpeed = 5f;  // カメラの追従スピード
    public float zoomOutSize = 5f;  // カメラがズームアウトする際のサイズ
    public float zoomInSize = 3f;   // ズームインする際のサイズ
    public Vector3 offset;  // プレイヤーとのオフセット（カメラとプレイヤーの間の距離）

    private Camera cam;

    void Start()
    {
        cam = Camera.main;  // メインカメラを取得
        offset = new Vector3(0f, 0f, -5f);  // プレイヤーからカメラを近づける位置に設定
        cam.orthographicSize = zoomOutSize=2f;  // 初期ズームを設定
    }

    void Update()
    {
        // カメラがプレイヤーを追従
        Vector3 targetPosition = player.position + offset;  // プレイヤーの位置 + オフセット
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // 例：キー入力でズームを変更
        if (Input.GetKeyDown(KeyCode.Z))
        {
            cam.orthographicSize = zoomInSize;  // ズームイン
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            cam.orthographicSize = zoomOutSize=1f;  // ズームアウト
        }
    }
}

