using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EmailType
{
    morning,
    evening,
    date,
    intro,
    end
}

public enum DateType
{
    good,
    bad
}

public class EmailManager : MonoBehaviour
{
    public string bossEmail;
    public string introSubject;
    public string introBody;
    public string morningGoodSubject;
    public string morningBadSubject;
    public string morningGoodDate;
    public string morningBadDate;
    public string endOfDaySubject;
    public string endOfDayBody;
    public string dateSubject;
    public string endOfGameSubject;
    public string endOfGameBody;


    public EmailDisplay emailUI;

    private Queue<Email> emailQueue = new Queue<Email>();

    public bool active;



    public void generateEmail(EmailType _type, DateType _date = DateType.good)
    {
        Email temp = new Email();

        switch (_type)
        {
            case EmailType.morning:
                {
                    if (_date == DateType.bad)
                        temp = new Email(bossEmail, morningBadSubject, morningBadDate, _type);
                    else
                        temp = new Email(bossEmail, morningGoodSubject, morningGoodDate, _type);
                    emailQueue.Enqueue(temp);
                }
                break;
            case EmailType.evening:
                {
                    Email email = new Email(bossEmail, endOfDaySubject, endOfDayBody, _type);
                    emailQueue.Enqueue(email);

                }
                break;
            case EmailType.date:
                {
                    Debug.Log("date email coming through wrong fucntion!");
                }
                break;
            case EmailType.intro:
                {
                    temp = new Email(bossEmail, introSubject, introBody, _type);
                    emailQueue.Enqueue(temp);
                }
                break;
            case EmailType.end:
                {
                    temp = new Email(bossEmail, endOfGameSubject, endOfGameBody, _type);
                    emailQueue.Enqueue(temp);
                }
                break;
            default:
                break;

        }

    }

    public void generateEmail(DateType dateType, Object _object1, Object _object2)
    {
        Email email = new Email(bossEmail, dateSubject, _object1, _object2, dateType);
        emailQueue.Enqueue(email);
    }

    public void displayEmail()
    {
        Email currentEmail = emailQueue.Dequeue();

        if (currentEmail.emailType != EmailType.date)
        {
            emailUI.DisplayTextEmail(currentEmail.address, currentEmail.subject, currentEmail.body);
        }
        else
        {
            emailUI.DisplayPictureEmail(currentEmail.address, currentEmail.subject, currentEmail.dateType, currentEmail.object1, currentEmail.object2);
        }

    }

    public void PopEmail()
    {
        if (emailQueue.Count != 0)
            displayEmail();
        else
        {
            emailUI.Close();
        }

    }


    private void Update()
    {
       if (emailUI.popUpActive)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PopEmail();
            }
        }
    }
}
