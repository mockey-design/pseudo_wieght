using UnityEngine;

// 1) ステップを表すenum（列挙型）
public enum ExperimentStep
{
    IntroText,
    StandardDisplayText,
    StandardDisplay,
    DifferentDisplayText,
    DifferentDisplay,
    Questionnaire,
    End
}

// 2) 実験の流れを管理するクラス
public class ExperimentManager : MonoBehaviour
{
    [Header("UI/Display Objects")]
    [SerializeField] private List<GameObject> uiObjects;

    private int currentIndex = 0;
    // 今どのステップにいるか

    /* private void Start()
     {

     }*/

    private void ShowUI(int index)
    {
        if (index < 0 || index >= uiObjects.Count)
        {
            Debug.LogWarning($"Invaild index: {index}. Check the UI Objects list");
            return;
        }
        foreach (GameObject obj in uiObjects)
        {
            obj.setAvtive(false);
        }


        uiObjects[index].SetActive(true);
        currentIndex = index;
    }

    public void ShowNextUI()
    {
        int nextIndex = (currentIndex + 1) % uiObjects.Count;
        ShowUI(nextIndex);
    }
    public void ShowPreviousUI()
    {
        int previousIndex = (currentIndex - 1 + uiObjects.Count) % uiObjects.Count; // 負の値にならないよう調整
        ShowUI(previousIndex);
    }
   
}
