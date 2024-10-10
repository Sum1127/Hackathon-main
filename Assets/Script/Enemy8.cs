using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8 : MonoBehaviour
{
    public float horizontalSpeed = 8f;  // ���������̈ړ����x
    public float verticalAmplitude = 10f;  // �㉺�ړ��̕��i�U���j
    public float verticalFrequency = 5f;  // �㉺�ړ��̑��x�i���g���j
    public float phaseShift = Mathf.PI/2;  // ���g���̃V�t�g

    private Vector3 startPosition;  // �I�u�W�F�N�g�̏����ʒu��ۑ�
    private float lifetime = 8f; // �I�u�W�F�N�g�̎���

    void Start()
    {
        // �I�u�W�F�N�g�̏����ʒu��ۑ�
        startPosition = transform.position;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // ���������Ɉ�葬�x�ňړ�
        transform.position += Vector3.right * horizontalSpeed * Time.deltaTime;

        // �㉺�ړ��̌v�Z�i�ʑ��V�t�g��������j
        float verticalOffset = Mathf.Sin(Time.time * verticalFrequency + phaseShift) * verticalAmplitude;

        // �㉺�ړ������������V�����ʒu��ݒ�
        transform.position = new Vector3(transform.position.x, startPosition.y + verticalOffset, transform.position.z);
    }
}
