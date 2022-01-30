using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Email : MonoBehaviour
{
    [SerializeField]
    private GameObject emailPrefab;
    [SerializeField]
    private GameObject emailField;
    [SerializeField]
    private GameObject subjectField;
    [SerializeField]
    private GameObject emailBody;

    public string bossEmailAdress;
    public string endOfDaySubject;

    public void PopUp()
    {
        //turn gameObjectOn at top of sorting order
        //may do a scale/transform animation
    }

    public void SetEmail()
    {
        emailField.GetComponentInChildren<TMP_Text>().text = bossEmailAdress;
    }

    public void SetSubject()
    {

        emailField.GetComponentInChildren<TMP_Text>().text = endOfDaySubject;

    }

    public virtual void SetBody()
    {

    }

}
