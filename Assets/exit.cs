using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
public class exit : MonoBehaviour
{
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    // Update is called once per frame
    void TaskOnClick()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;

#else
        Application.Quit();
        Debug.Log("QUIT");
#endif
    }
}
