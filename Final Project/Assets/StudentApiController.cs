using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;


public class StudentApiController : MonoBehaviour
{
    public GameObject RowPrefab;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetAllStudents());
    }

    IEnumerator GetAllStudents()
    {
        var getAllStudentsEndpoint = UnityWebRequest.Get("http://localhost:56072/api/v1/persons");

        yield return getAllStudentsEndpoint.SendWebRequest();

        if(getAllStudentsEndpoint.isNetworkError || getAllStudentsEndpoint.isHttpError)
        {
            Debug.Log(getAllStudentsEndpoint.error);
        }

        else
        {
            Debug.Log("Web Request status: " + getAllStudentsEndpoint.responseCode);
            var jsonResult = getAllStudentsEndpoint.downloadHandler.text;
            var students = JsonConvert.DeserializeObject<List<StudentViewModel>>(jsonResult);

            foreach (var student in students)
            {
                var row = GameObject.Instantiate(RowPrefab, Panel.transform);
                row.GetComponent<RowController>().SetAllFields(

                    student.FirstName,
                    student.LastName,
                    student.Email                   
                    );
            }
        }
    }

}
