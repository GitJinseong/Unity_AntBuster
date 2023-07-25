using System.Collections;
using UnityEngine;

public class ForTopSpawner : MonoBehaviour
{
    public static ForTopSpawner instance;

    public GameObject forTop_0_Prefab = default;
    public GameObject forTop_1_Prefab = default;
    public GameObject forTop_2_Prefab = default;
    ObjectDetector objectDetector = default;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        objectDetector = new ObjectDetector();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnForTop(float x, float y)
    {
        Vector2 position = new Vector2(x, y);
        Debug.Log(objectDetector.CheckForObject(position));
        if (objectDetector.CheckForObject(position) == false)
        {
            CreateInstanceForTop(position);
            GameManager.instance.grid.SetActive(false);
        }
        else
        {
            Debug.Log("설치된 오브젝트가 있습니다.");
            StartCoroutine(NoticeErrorMessage());
        }
    }

    public void CreateInstanceForTop(Vector2 position)
    {
        GameObject forTop = default;
        switch(GameManager.instance.type)
        {
            case 0:
                GameManager.instance.AddGold(-100);
                forTop = Instantiate(forTop_0_Prefab, position, transform.rotation,
                transform);
                break;
            case 1:
                GameManager.instance.AddGold(-500);
                forTop = Instantiate(forTop_1_Prefab, position, transform.rotation,
                transform);
                break;
            case 2:
                GameManager.instance.AddGold(-1000);
                forTop = Instantiate(forTop_2_Prefab, position, transform.rotation,
                transform);
                break;
        }
    }

    public IEnumerator NoticeErrorMessage()
    {
        GameManager.instance.gridErrorMsg.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.gridErrorMsg.SetActive(false);
    }

}
