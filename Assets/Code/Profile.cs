using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Profile : MonoBehaviour
{
    [SerializeField]
    private Object currentObj;
    [SerializeField]
    private List<Object> objectsList = new List<Object>();

    [SerializeField]
    private GameObject nameField;
    [SerializeField]
    private GameObject bioField;
    [SerializeField]
    private GameObject picField;


    private int pointer;

    private void SetNameField()
    {
        nameField.GetComponentInChildren<TMP_Text>().text = currentObj.name;
    }

    private void SetBioField()
    {
        bioField.GetComponentInChildren<TMP_Text>().text = currentObj.Description;
    }

    private void SetPic()
    {
        picField.GetComponent<Image>().sprite = currentObj.picture;
    }

    private void UpdatedInfo()
    {
        SetNameField();
        SetBioField();
        SetPic();
        pointer = objectsList.IndexOf(currentObj);
    }
    void Start()
    {
        if (currentObj == null)
            currentObj = objectsList[0];



        UpdatedInfo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (pointer <= 0)
            {
                currentObj = objectsList[objectsList.Count - 1];
            }
            else
            {
                currentObj = objectsList[objectsList.IndexOf(currentObj)-1];
            }

            UpdatedInfo();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (pointer >= objectsList.Count-1)
            {
                currentObj = objectsList[0];
            }
            else
            {
                currentObj = objectsList[objectsList.IndexOf(currentObj) + 1];
            }

            UpdatedInfo();
        }
    }
}
