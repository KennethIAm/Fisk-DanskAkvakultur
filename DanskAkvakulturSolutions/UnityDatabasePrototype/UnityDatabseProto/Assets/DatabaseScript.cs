using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string connectionstring = "Server = DESKTOP-QM7D20D; Database = GameProto; Trusted_Connection = True;";
    }

    public void Test()
    {
        print("CONNECTING!");

        //SqlConnection con = new SqlConnection(connectionstring);
        //con.Open();
        //SqlCommand cmd = new SqlCommand("INSERT Username VALUES('JOLLE')", con);
        //cmd.ExecuteNonQuery();

    }
}
