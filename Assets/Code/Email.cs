using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Email
{  
    public string address;
    public string subject;
    public string body;
    public Sprite picture;
    public Object object1;
    public Object object2;
    public EmailType emailType;
    public DateType dateType;


    public Email()
    {

    }
    public Email (string _address, string _subject, string _body, EmailType _emailType)
    {
        Debug.Log("creating new emoil");
        subject = _subject;
        address = _address;
        body = _body;
    }

    public Email(string _address, string _subject, Object _object1, Object _object2, DateType _dateType)
    {
        emailType = EmailType.date;
        dateType = _dateType;
        address = _address;
        subject = _subject;
        object1 = _object1;
        object2 = _object2;
    }   

}
