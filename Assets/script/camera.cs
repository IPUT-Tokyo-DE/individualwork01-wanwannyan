using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // �v���C���[�̈ʒu
    public float followSpeed = 5f;  // �J�����̒Ǐ]�X�s�[�h
    public float zoomOutSize = 5f;  // �J�������Y�[���A�E�g����ۂ̃T�C�Y
    public float zoomInSize = 3f;   // �Y�[���C������ۂ̃T�C�Y
    public Vector3 offset;  // �v���C���[�Ƃ̃I�t�Z�b�g�i�J�����ƃv���C���[�̊Ԃ̋����j

    private Camera cam;

    void Start()
    {
        cam = Camera.main;  // ���C���J�������擾
        offset = new Vector3(0f, 0f, -5f);  // �v���C���[����J�������߂Â���ʒu�ɐݒ�
        cam.orthographicSize = zoomOutSize=2f;  // �����Y�[����ݒ�
    }

    void Update()
    {
        // �J�������v���C���[��Ǐ]
        Vector3 targetPosition = player.position + offset;  // �v���C���[�̈ʒu + �I�t�Z�b�g
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // ��F�L�[���͂ŃY�[����ύX
        if (Input.GetKeyDown(KeyCode.Z))
        {
            cam.orthographicSize = zoomInSize;  // �Y�[���C��
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            cam.orthographicSize = zoomOutSize=1f;  // �Y�[���A�E�g
        }
    }
}

