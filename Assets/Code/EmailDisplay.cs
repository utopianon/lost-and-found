using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    private GameObject DateForeground;
    [SerializeField]
    private GameObject DateBackground;
    [SerializeField]
    private GameObject spriteAGood;
    [SerializeField]
    private GameObject spriteBGood;
    [SerializeField]
    private GameObject spriteABad;
    [SerializeField]
    private GameObject spriteBBad;
    [SerializeField]
    private Sprite goodDateForeground;
    [SerializeField]
    private Sprite goodDateBackground;
    [SerializeField]
    private Sprite badDateForeground;
    [SerializeField]
    private Sprite badDateBackground;
    [SerializeField]
    private Sprite spriteA;
    [SerializeField]
    private Sprite spriteB;

    public bool popUpActive;

    public void DisplayTextEmail(string address, string subject, string body)
    {
        spriteAGood.SetActive(false);
        spriteBGood.SetActive(false);
        canvas.SetActive(false);
        DateBackground.SetActive(false);
        spriteABad.SetActive(false);
        spriteBBad.SetActive(false);
        DateForeground.SetActive(false);
        SetBody(body);
        SetAddress(address);
        SetSubject(subject);
        PopUp();
    }

    public void DisplayPictureEmail(string address, string subject, DateType type, Object obj1, Object obj2)
    {
        SetAddress(address);
        SetSubject(subject);
        if (type == DateType.bad)
        {
            DateBackground.SetActive(true);
            spriteABad.SetActive(true);
            spriteBBad.SetActive(true);
            DateForeground.SetActive(true);
            DateBackground.GetComponent<Image>().sprite = badDateBackground;
            DateForeground.GetComponent<Image>().sprite = badDateForeground;
            spriteABad.GetComponent<Image>().sprite = obj1.picture;
            spriteBBad.GetComponent<Image>().sprite = obj2.picture;
        }
        else
        {
            Debug.Log("good date image!!");
            DateBackground.SetActive(true);
            spriteAGood.SetActive(true);
            spriteBGood.SetActive(true);
            DateForeground.SetActive(true);
            DateBackground.GetComponent<Image>().sprite = goodDateBackground;
            DateForeground.GetComponent<Image>().sprite = goodDateForeground;
            spriteAGood.GetComponent<Image>().sprite = obj1.picture;
            spriteBGood.GetComponent<Image>().sprite = obj2.picture;
        }

        PopUp();
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
        emailBody.GetComponentInChildren<TMP_Text>().text = body;
    }

    public void PopUp()
    {
        canvas.SetActive(true);
        popUpActive = true;
    }

    public void Close()
    {
        spriteAGood.SetActive(false);
        spriteBGood.SetActive(false);
        canvas.SetActive(false);
        DateBackground.SetActive(false);
        spriteABad.SetActive(false);
        spriteBBad.SetActive(false);
        DateForeground.SetActive(false);
        popUpActive = false;
    }

}
