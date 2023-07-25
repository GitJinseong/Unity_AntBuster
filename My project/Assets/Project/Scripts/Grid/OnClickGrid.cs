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

    // 받아온 위치를 셀 좌표로 계산하는 함수
    public void GetCellSize(float x, float y)
    {
        float cell_X = Mathf.Abs(x - StartPos_X);
        cell_X = Mathf.Floor(cell_X / realGridSize_X);
        float cell_Y = Mathf.Abs(y - StartPos_Y);
        cell_Y = Mathf.Floor(cell_Y / realGridSize_Y);

        float convert_X = startRealPos_X + (realGridSize_X * cell_X);
        float convert_Y = startRealPos_Y - (realGridSize_Y * (cell_Y));
        Debug.LogFormat("[x : {0}, y : {1}]", convert_X, convert_Y);

        // 계산한 좌표에 포탑 생성
        ForTopSpawner.instance.SpawnForTop(convert_X, convert_Y);
    }

    // 클릭한 위치를 확인하는 함수
    public void OnPointerClick(PointerEventData eventData)
    {
        // eventData.position은 클릭된 스크린 좌표(뷰 포트 좌표)를 반환합니다.
        Vector2 clickedPosition = eventData.position;

        // 스크린 좌표를 월드 좌표로 변환
        // 뷰 포트로 계산하면 화면 사이즈가 변하면 오류가 발생한다.
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickedPosition);

        GetCellSize(worldPosition.x, worldPosition.y);
    }

}
