using UnityEngine;

public class HeavyBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerShapeSwitcher>();
        if (player != null && player.currentShape != PlayerShapeSwitcher.Shape.Square)
        {
            // �v���C���[���l�p�`�łȂ��Ȃ畨���I�ȗ͂��󂯂Ȃ��悤�ɂ���
            GetComponent<Rigidbody2D>().mass = 1000f;
        }
        else
        {
            GetComponent<Rigidbody2D>().mass = 10f;
        }
    }
}
