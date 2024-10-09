using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7 : MonoBehaviour
{
    Transform playerTr; // �v���C���[��Transform
    [SerializeField] float speed = 30; // �G�̓����X�s�[�h
    private bool isMoving = true;
    public float flashSpeed = 0.2f;        // �_�ő��x�i�b�j
    public float flashDuration = 2f;       // �_�ł��鎞��
    private bool isFlashing = false;       // �_�Œ����ǂ���
    private Renderer objRenderer;

    private void Start()
    {
        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        if (objRenderer == null)
        {
            objRenderer = GetComponent<Renderer>();
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            if (Vector2.Distance(transform.position, playerTr.position) > 3f)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    new Vector2(playerTr.position.x, playerTr.position.y),
                    speed * Time.deltaTime);
            }
            else
            {
                StartCoroutine(StartFlashing());
            }
        }
    }

    IEnumerator StartFlashing()
    {
        isFlashing = true;
        isMoving = false;
        GameObject deleteObject = gameObject;
        float FlashEndTime = Time.time + flashDuration;

        // �����œ_��
        while (Time.time < FlashEndTime)
        {
            objRenderer.enabled = !objRenderer.enabled;  // �����_���[��ON/OFF�؂�ւ�
            yield return new WaitForSeconds(flashSpeed); // �_�ŊԊu
        }

        // �Ō�Ƀ����_���[��ON�ɂ���
        objRenderer.enabled = true;

        // �I�u�W�F�N�g�����ł�����
        Destroy(deleteObject);
    }
}
