using UnityEngine;

public class HeavyBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerShapeSwitcher>();
        if (player != null && player.currentShape != PlayerShapeSwitcher.Shape.Square)
        {
            // プレイヤーが四角形でないなら物理的な力を受けないようにする
            GetComponent<Rigidbody2D>().mass = 1000f;
        }
        else
        {
            GetComponent<Rigidbody2D>().mass = 10f;
        }
    }
}
