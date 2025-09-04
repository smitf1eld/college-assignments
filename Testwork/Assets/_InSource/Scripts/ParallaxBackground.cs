using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float parallaxEffect = 0.5f; // ���� ������� ���������� (0 - ����� �� �����, 1 - �������� ��� �������� ����)
    private float length; // ����� ������ ������� ����
    private float startPos; // ��������� ������� �� X

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x; // �������� ����� ������� ��������� �������
    }

    void Update()
    {
        // ���������� ������ ��� �����
        float temp = (Camera.main.transform.position.x * (1 - parallaxEffect));
        float dist = (Camera.main.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        // ���� ������ �������� � ���� �������, ������������ ��� ������
        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}