using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickGrid : MonoBehaviour, IPointerClickHandler
{
    private float StartPos_X = -2.219f;
    private float StartPos_Y = 3.146f;
    private const float realGridSize_X = 0.4491f;
    private const float realGridSize_Y = 0.447f;
    private const float startRealPos_X = -2.0f;
    private const float startRealPos_Y = 2.94f;

    // �޾ƿ� ��ġ�� �� ��ǥ�� ����ϴ� �Լ�
    public void GetCellSize(float x, float y)
    {
        float cell_X = Mathf.Abs(x - StartPos_X);
        cell_X = Mathf.Floor(cell_X / realGridSize_X);
        float cell_Y = Mathf.Abs(y - StartPos_Y);
        cell_Y = Mathf.Floor(cell_Y / realGridSize_Y);

        float convert_X = startRealPos_X + (realGridSize_X * cell_X);
        float convert_Y = startRealPos_Y - (realGridSize_Y * (cell_Y));
        Debug.LogFormat("[x : {0}, y : {1}]", convert_X, convert_Y);

        // ����� ��ǥ�� ��ž ����
        ForTopSpawner.instance.SpawnForTop(convert_X, convert_Y);
    }

    // Ŭ���� ��ġ�� Ȯ���ϴ� �Լ�
    public void OnPointerClick(PointerEventData eventData)
    {
        // eventData.position�� Ŭ���� ��ũ�� ��ǥ(�� ��Ʈ ��ǥ)�� ��ȯ�մϴ�.
        Vector2 clickedPosition = eventData.position;

        // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ
        // �� ��Ʈ�� ����ϸ� ȭ�� ����� ���ϸ� ������ �߻��Ѵ�.
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickedPosition);

        GetCellSize(worldPosition.x, worldPosition.y);
    }

}
