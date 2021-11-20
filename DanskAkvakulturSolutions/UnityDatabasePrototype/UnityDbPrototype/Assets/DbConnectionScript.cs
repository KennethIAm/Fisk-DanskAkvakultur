using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System;

public class DbConnectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InsertData()
    {
        print("Inserting Data");

        try
        {
            using (SqlConnection conn = new SqlConnection() { ConnectionString = "Server=127.0.0.1,1433;Database=UnityPrototype;User Id=sa;Password=Kode1234!;" })
            {
                using (SqlCommand cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO [ResultPrototype] ([Number]) VALUES (@number)",
                    CommandType = System.Data.CommandType.Text,
                    Connection = conn
                })
                {
                    var rnd = new System.Random(DateTime.Now.GetHashCode());
                    cmd.Parameters.AddWithValue("@number", rnd.Next(1, int.MaxValue));

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            print("Finished inserting data.");
        }
    }
}
