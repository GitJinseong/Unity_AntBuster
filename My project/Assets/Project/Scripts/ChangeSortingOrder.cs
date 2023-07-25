using UnityEngine;

public class ChangeSortingOrder : MonoBehaviour
{
    public string sortingLayerName = "ForTop"; // 변경할 Sorting Layer의 이름
    public int newSortingOrder = 3; // 변경할 Sorting Order 값

    void Start()
    {
        // Renderer 컴포넌트를 가져옴
        Renderer renderer = GetComponent<Renderer>();

        // Sorting Layer를 변경할 때는 sortingLayerID 또는 sortingLayerName을 사용합니다.
        // sortingLayerName을 사용하는 경우, 해당 이름의 Sorting Layer가 존재해야 합니다.
        renderer.sortingLayerName = sortingLayerName;

        // Sorting Order를 변경
        renderer.sortingOrder = newSortingOrder;
    }
}