using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowController : MonoBehaviour
{

    public Text FirstName;
    public Text LastName;
    public Text Email;

    public void SetAllFields(string firstName, string lastName, string email)
    {
        FirstName.text = firstName;
        LastName.text = lastName;
        Email.text = email;
    }
        
}
