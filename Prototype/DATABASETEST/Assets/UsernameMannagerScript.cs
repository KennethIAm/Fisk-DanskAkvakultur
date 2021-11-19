using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using TMPro;
using UnityEngine;

public class UsernameMannagerScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI inputField;

    string connectionstring;

    // Start is called before the first frame update
    void Start()
    {
        print("CONNECTING!");
        //connectionstring = "Server = DESKTOP-QM7D20D; Database = GameProto; Integrated Security=true;";
        connectionstring = "Server = 127.0.0.1; Database = GameProto; Trusted_Connection = True;";
    }


    public void sendData()
    {
        SqlConnection con = new SqlConnection(connectionstring);
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT Username VALUES('"+inputField.text+"')", con);
        cmd.ExecuteNonQuery();
    }
}
