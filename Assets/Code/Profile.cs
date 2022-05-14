using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Profile : MonoBehaviour
{
    [SerializeField]
    private GameObject nameField;
    [SerializeField]
    private GameObject bioField;
    [SerializeField]
    private GameObject picField;


    private int pointer;

    private void SetNameField(Object _currentObj)
    {
        nameField.GetComponentInChildren<TMP_Text>().text = _currentObj.name;
    }

    private void SetBioField(Object _currentObj)
    {
        bioField.GetComponentInChildren<TMP_Text>().text = _currentObj.Description;
    }

    private void SetPic(Object _currentObj)
    {
        picField.GetComponent<Image>().sprite = _currentObj.picture;
    }

    public void SetCurrentObject(Object _currentObj)
    {     
        UpdateInfo(_currentObj);
    }

    private void UpdateInfo(Object _currentObj)
    {
        SetNameField(_currentObj);
        SetBioField(_currentObj);
        SetPic(_currentObj);
    }
   
    
}
