using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    public GameObject furniture;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();   //assign button
        btn.onClick.AddListener(SelectObject);  //when we click button, it selects
    }

    void SelectObject()
    {
        DataHandler.Instance.furniture = furniture;
    }

}
