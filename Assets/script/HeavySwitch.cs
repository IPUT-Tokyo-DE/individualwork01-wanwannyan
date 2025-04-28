using UnityEngine;

public class HeavySwitch : MonoBehaviour
{
    public GameObject door;
    private int activationCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsHeavyEnough(other))
        {
            activationCount++;
            UpdateDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsHeavyEnough(other))
        {
            activationCount--;
            UpdateDoor();
        }
    }

    void UpdateDoor()
    {
        door.SetActive(activationCount <= 0); // 0�ȉ��Ȃ����A1�ȏ�Ȃ�J����
    }

    bool IsHeavyEnough(Collider2D other)
    {
        // �v���C���[�������ǂ���
        PlayerShapeSwitcher player = other.GetComponent<PlayerShapeSwitcher>();
        if (player != null && player.currentShape == PlayerShapeSwitcher.Shape.Square)
        {
            return true;
        }

        // �d�����̂��ǂ����i���ʂŔ��f�j
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null && rb.mass >= 3f)
        {
            return true;
        }

        return false;
    }
}
