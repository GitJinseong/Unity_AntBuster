using UnityEngine;

public class ChangeSortingOrder : MonoBehaviour
{
    public string sortingLayerName = "ForTop"; // ������ Sorting Layer�� �̸�
    public int newSortingOrder = 3; // ������ Sorting Order ��

    void Start()
    {
        // Renderer ������Ʈ�� ������
        Renderer renderer = GetComponent<Renderer>();

        // Sorting Layer�� ������ ���� sortingLayerID �Ǵ� sortingLayerName�� ����մϴ�.
        // sortingLayerName�� ����ϴ� ���, �ش� �̸��� Sorting Layer�� �����ؾ� �մϴ�.
        renderer.sortingLayerName = sortingLayerName;

        // Sorting Order�� ����
        renderer.sortingOrder = newSortingOrder;
    }
}