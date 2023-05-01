using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.Linq;

public class SqliteTest : MonoBehaviour
{

    // Use this for initialization
    private string[] tableName = new string[] { "User", "Card", "UserCard", "Board", "BoardPlayer", "Box", "BoardBox" };
    private string connection;
    void Start()
    {
        // Create database
        this.connection = "URI=file:" + Application.persistentDataPath + "/" + "test";

        // Open connection
        IDbConnection dbcon = new SqliteConnection(this.connection);
        dbcon.Open();
        // Create table
        ExecQuery( dbcon, "CREATE TABLE IF NOT EXISTS User (user_id INTEGER PRIMARY KEY AUTOINCREMENT, user_name TEXT,  user_score integer,  user_best_score integer)");
        ExecQuery(dbcon, "CREATE TABLE IF NOT EXISTS Card (card_id integer PRIMARY KEY AUTOINCREMENT, card_name TEXT, card_action TEXT, card_desc TEXT,  card_value INTEGER)");
        ExecQuery(dbcon, "CREATE TABLE IF NOT EXISTS UserCard ( user_id INTEGER, card_id INTEGER, FOREIGN KEY(user_id) REFERENCES User(user_id), FOREIGN KEY(card_id) REFERENCES Card(card_id))");
        ExecQuery(dbcon, "CREATE TABLE IF NOT EXISTS Board ( board_id INTEGER PRIMARY KEY AUTOINCREMENT, board_user INTEGER, board_case INTEGER)");
        ExecQuery(dbcon, "CREATE TABLE IF NOT EXISTS BoardPlayer ( board_id INTEGER, user_id INTEGER, FOREIGN KEY(board_id) REFERENCES Board(board_id), FOREIGN KEY(board_id) REFERENCES Board(board_id))");
        ExecQuery(dbcon, "CREATE TABLE IF NOT EXISTS Box ( box_id INTEGER PRIMARY KEY AUTOINCREMENT, box_owner INTEGER, box_desc TEXT, box_build INTEGER)");
        ExecQuery(dbcon, "CREATE TABLE IF NOT EXISTS BoardBox ( board_id INTEGER, box_id INTEGER, FOREIGN KEY(board_id) REFERENCES Board(board_id), FOREIGN KEY(box_id) REFERENCES Box(box_id))");
        //ExecQuery(dbcon, "INSERT INTO Card (card_name, card_action, card_desc, card_value) VALUES ('a', 'zction', 'desc', 7)");


        // Close connection
        dbcon.Close();

    }

    //Execute a sqlite command with no output for modify a table for example
    private void ExecQuery(IDbConnection dbcon, string qCreateTable)
    {
        IDbCommand dbcmd;
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = qCreateTable;
        dbcmd.ExecuteReader();
    }

    //Execute a sqlite command with output for a command like select, you can select multiple row
    private string [][] ExecQueryWithOutput(IDbConnection dbcon, string qCreateTable, int numberOfRow)
    {
        List<string[]> result = new List<string[]>();
        List<string> row = new List<string>();

        IDbCommand dbcmd;
        IDataReader reader;
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = qCreateTable;
        reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            for (int i = 0; i < numberOfRow; i++)
            {
                row.Add(reader[i].ToString());
            }
            result.Add(row.ToArray());
            row.Clear();
        }
        return result.ToArray();

    }
    
    //Delet all the content of all Table
    private void ClearTable(IDbConnection dbcon)
    {
        foreach (string table in tableName)
        {
            ExecQuery(dbcon, "DELETE FROM " + table);
        }
    }

    // Select an element in the database
    public string[][] Select(string[] column, string table, string condition = "")
    {
        IDbConnection dbcon = new SqliteConnection(this.connection);
        dbcon.Open();
       string[][] result =  ExecQueryWithOutput(dbcon, ("Select " + String.Join(", ", column) + " FROM " + table + " " + condition), column.Length);
       dbcon.Close();
       return result;
    }
}