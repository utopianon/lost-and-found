using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmailDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject emailField;
    [SerializeField]
    private GameObject subjectField;
    [SerializeField]
    private GameObject emailBody;
    [SerializeField]
    private GameObject goodDateImage;
    [SerializeField]
    private GameObject badDateImage;
    [SerializeField]
    private GameObject spriteA;
    [SerializeField]
    private GameObject spriteB;

    public bool popUpActive;

    public void DisplayTextEmail(string address, string subject, string body)
    {
        SetBody(body);
        SetAddress(address);
        SetSubject(subject);
        PopUp();
    }

    public void DisplayPictureEmail()
    {

    }

    private void SetAddress(string address)
    {
        emailField.GetComponent<TMP_Text>().text = address;
    }

    private void SetSubject(string subject)
    {

        subjectField.GetComponent<TMP_Text>().text = subject;

    }

    private void SetBody(string body)
    {
        emailBody.GetComponentInChildren<TMP_Text>().tag = body;
    }

    public void PopUp()
    {
        canvas.SetActive(true);
        popUpActive = true;
    }

    public void Close()
    {
        canvas.SetActive(true);
        popUpActive = false;
    }

}
