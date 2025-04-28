using UnityEngine;
using TMPro; // TextMeshPro用！
using UnityEngine.SceneManagement; // シーン切り替え用！

public class PlayerShapeSwitcher : MonoBehaviour
{
    public enum Shape { Circle, Triangle, Square } // プレイヤーの形
    public Shape currentShape = Shape.Circle; // 初期形はCircle

    public GameObject circleObj;   // Circleの見た目
    public GameObject triangleObj; // Triangleの見た目
    public GameObject squareObj;   // Squareの見た目

    private Rigidbody2D rb; // プレイヤーの物理コンポーネント
    public float jumpForce = 500f; // ジャンプの力
    public float moveSpeed = 5f;   // 移動速度

    public GameObject[] triangleWalls; // Triangle形態で見える壁
    public GameObject[] normalWalls;   // CircleとSquareで見える壁

    public TMP_Text shapeText; // 現在の形を表示するテキスト（TextMeshPro用）

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2Dを取得
        rb.freezeRotation = true; // プレイヤーが回転しないようにする

        UpdateShapeVisuals(); // 初期形の見た目を更新
        UpdateShapeText();    // 初期形のテキストを更新

        SetWallsVisibility(triangleWalls, false); // Triangle用の壁を非表示
        SetWallsVisibility(normalWalls, true);    // 通常壁を表示
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchShape(); // Qキーで形を切り替える
        }

        MovePlayer();    // 横移動
        ApplyAbilities(); // 形ごとの特殊能力を使う
    }

    void SwitchShape()
    {
        // 現在の形を次の形に切り替える（Circle→Triangle→Square→Circle...）
        currentShape = (Shape)(((int)currentShape + 1) % 3);

        UpdateShapeVisuals(); // 見た目更新
        UpdateShapeText();    // テキスト更新
    }

    void UpdateShapeVisuals()
    {
        // 現在の形に応じて表示するオブジェクトを切り替え
        circleObj.SetActive(currentShape == Shape.Circle);
        triangleObj.SetActive(currentShape == Shape.Triangle);
        squareObj.SetActive(currentShape == Shape.Square);
    }

    void UpdateShapeText()
    {
        // テキストが紐付いていれば、現在の形＋効果を表示
        if (shapeText != null)
        {
            switch (currentShape)
            {
                case Shape.Circle:
                    shapeText.text = "● Increased jumping power";
                    break;
                case Shape.Triangle:
                    shapeText.text = "▲ The invisible wall is visible.";
                    break;
                case Shape.Square:
                    shapeText.text = "■ Can press the switch.";
                    break;
            }
        }
    }

    void ApplyAbilities()
    {
        // 現在の形に応じてジャンプ力や壁の表示を切り替える
        switch (currentShape)
        {
            case Shape.Circle:
                if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
                {
                    rb.AddForce(Vector2.up * jumpForce * 1.5f); // 高くジャンプ
                }
                SetWallsVisibility(triangleWalls, false); // Triangle壁非表示
                SetWallsVisibility(normalWalls, true);    // 通常壁表示
                break;

            case Shape.Triangle:
                if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
                {
                    rb.AddForce(Vector2.up * jumpForce); // 普通ジャンプ
                }
                SetWallsVisibility(triangleWalls, true);  // Triangle壁表示
                SetWallsVisibility(normalWalls, false);  // 通常壁非表示
                break;

            case Shape.Square:
                if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
                {
                    rb.AddForce(Vector2.up * jumpForce); // 普通ジャンプ
                }
                SetWallsVisibility(triangleWalls, false); // Triangle壁非表示
                SetWallsVisibility(normalWalls, true);    // 通常壁表示
                break;
        }
    }

    void SetWallsVisibility(GameObject[] walls, bool visible)
    {
        // 指定された壁たちを一括で表示/非表示
        foreach (var wall in walls)
        {
            if (wall != null)
            {
                wall.SetActive(visible);
            }
        }
    }

    void MovePlayer()
    {
        // 水平方向の入力を取得して、移動
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    // ゴールエリアに入ったらクリアシーンへ
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("ClearScene"); // クリア用シーンに移動
        }
    }
}
