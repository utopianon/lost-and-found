using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public Profile CustomerProfile;
    public Profile SuitorProfile;


    [SerializeField]
    private Object currentCustomer;
    [SerializeField]
    private Object currentSuitor;

    [SerializeField]
    private List<Object> objectsList = new List<Object>();

    private int suitorCounter;



    private void PickCustomer()
    {
        int randomCustomer = Random.Range(0, objectsList.Count - 1);
        currentCustomer = objectsList[randomCustomer];
        objectsList.Remove(currentCustomer);
        List<Object> shuffledList = objectsList.OrderBy(x => Random.value).ToList();
        objectsList = shuffledList;
        suitorCounter = 0;
        currentSuitor = objectsList[0];
        updateCustomer();
        updateSuitor();
    }

    private void updateCustomer()
    {
        CustomerProfile.SetCurrentObject(currentCustomer);
        updateSuitor();

    }
    private void updateSuitor()
    {
        suitorCounter = objectsList.IndexOf(currentSuitor);
        SuitorProfile.SetCurrentObject(currentSuitor);
    }

    private void Match()
    {
        if (currentCustomer.match.name == currentSuitor.name)
        {
            if (objectsList.Count <= 2)
            {
                //end game
                Debug.Log("end of game!!");
            }
            else
            {
                currentCustomer = null;
                //send email
                objectsList.Remove(currentSuitor);
            }

            Debug.Log("succesful match!");
        }
        else
        {
            objectsList.Add(currentCustomer);
            currentCustomer = null;
            //send email
            Debug.Log("not a proper match");
        }

        PickCustomer();
    }

    public void MoveBack()
    {
        if (suitorCounter <= 0)
        {
            currentSuitor = objectsList[objectsList.Count - 1];
        }
        else
        {
            currentSuitor = objectsList[objectsList.IndexOf(currentSuitor) - 1];
        }

        updateSuitor();
    }

    public void MoveNext()
    {
        if (suitorCounter >= objectsList.Count - 1)
        {
            currentSuitor = objectsList[0];
        }
        else
        {
            currentSuitor = objectsList[objectsList.IndexOf(currentSuitor) + 1];
        }

        updateSuitor();
    }

    public void ButtonMatch()
    {
        Match();
    }

    void Start()
    {
        PickCustomer();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveBack();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveNext();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Match();
        }
    }


}
