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
    private string[] tableName = new string[] { "User", "Card", "UserCard", "Box"};
    private string connection;
    void Start()
    {
        // Create database
        this.connection = "URI=file:" + Application.persistentDataPath + "/" + "Monopalu";

        // Open connection
        IDbConnection dbcon = new SqliteConnection(this.connection);
        dbcon.Open();

        // Create table
        ExecQuery(dbcon, "CREATE TABLE IF NOT EXISTS User (user_id INTEGER PRIMARY KEY AUTOINCREMENT, user_name TEXT,  user_score integer,  user_best_score integer)");
        ExecQuery(dbcon, "CREATE TABLE IF NOT EXISTS Card (card_id integer PRIMARY KEY AUTOINCREMENT, card_name TEXT, card_action TEXT, card_desc TEXT,  card_value INTEGER)");
        ExecQuery(dbcon, "CREATE TABLE IF NOT EXISTS UserCard ( user_id INTEGER, card_id INTEGER, FOREIGN KEY(user_id) REFERENCES User(user_id), FOREIGN KEY(card_id) REFERENCES Card(card_id))");
        ExecQuery(dbcon, "CREATE TABLE IF NOT EXISTS Box ( box_id INTEGER PRIMARY KEY AUTOINCREMENT, box_owner INTEGER, box_desc TEXT, box_build INTEGER, box_value INTEGER)");
        ExecQuery(dbcon, "DELETE FROM Box");
        //ExecQuery(dbcon, "ALTER TABLE Box ADD box_value INTEGER");
        // Close connection
        //ClearTable(dbcon);
        dbcon.Close();
        SetDB();
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
    private string[][] ExecQueryWithOutput(IDbConnection dbcon, string qCreateTable, int numberOfRow)
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

    //Delete all the content of all Table
    private void ClearTable(IDbConnection dbcon)
    {
        foreach (string table in tableName)
        {
            ExecQuery(dbcon, "DELETE FROM " + table);
        }
    }

    // Select an element in the database
    /*
    - column : all the column that you want to have
            exemple : "user_id" is a column
    - table : the name of the table containing your data
            exemple : "User" is a table
    - condition : If you want to add parameter
            exemple "WHERE user_id = 4" with this he return only the line where user_id = 4
     */
    public string[][] Select(string[] column, string table, string condition = "")
    {
        this.connection = "URI=file:" + Application.persistentDataPath + "/" + "Monopalu";
        IDbConnection dbcon = new SqliteConnection(this.connection);
        dbcon.Open();
        string[][] result = ExecQueryWithOutput(dbcon, ("Select " + String.Join(", ", column) + " FROM " + table + " " + condition), column.Length);
        dbcon.Close();
        return result;
    }

    //Insert element in a table
    /*
    - table : the name of the table that you want to add data
            exemple : "User" is a table
    - column : all the column of element (only the AUTOINCREMENT is not necessary)
            exemple : "user_id" is a column
    - value : all the value for wich column, need the same number of item and he need to have "''" if it is a string
            exemple : new string[][]
                    {
                        new string[] { "0", "'Person'", "0", "0"},
                        new string[] { "1", "'Player'", "0", "0"},
                        new string[] { "2", "'Ordi1'", "0", "0"},
                        new string[] { "3", "'Ordi2'", "0", "0"},
                        new string[] { "4", "'Ordi3'", "0", "0"},
                    }
     */
    public void InsertInto(string table, string[] column, string[][] values)
    {
        this.connection = "URI=file:" + Application.persistentDataPath + "/" + "Monopalu";
        IDbConnection dbcon = new SqliteConnection(this.connection);
        dbcon.Open();
        List<string> valueJoin = new List<string> { };
        foreach (var value in values)
        {
            valueJoin.Add("(" + String.Join(", ", value) + ")");
        }
        string[][] result = ExecQueryWithOutput(dbcon, ("INSERT INTO " + table + " (" + String.Join(", ", column) + ") VALUES " + String.Join(", ", valueJoin.ToArray())), column.Length);

        dbcon.Close();
    }

    // Delete row in a table
    /*
    - table : the name of the table that you want to delete data
            exemple : "User" is a table
    - condition : If you want to add parameter
            exemple "WHERE user_id = 4" with this he return only the line where user_id = 4
     */
    public void DeleteElement(string table, string condition)
    {
        this.connection = "URI=file:" + Application.persistentDataPath + "/" + "Monopalu";
        IDbConnection dbcon = new SqliteConnection(this.connection);
        dbcon.Open();
        ExecQuery(dbcon, "DELETE FROM " + table + " " + condition);
        string[][] testIsEmpty = Select(new string[] { "*" }, "Box");
        if (testIsEmpty.Length < 1)
        {
            SetDefaultBox();
        }
        dbcon.Close();
    }

    // modify column in table
    /*
     - table : the name of the table that you want to delete data
            exemple : "User" is a table
    - column : all the column of element (only the AUTOINCREMENT is not necessary)
            exemple : "user_id" is a column
     - value : all the value for wich column, need the same number of item and he need to have "''" if it is a string
            exemple : "'toto'" is a value
    - condition : If you want to add parameter !! You need to put a space in the start 
            exemple " WHERE user_id = 4" with this he return only the line where user_id = 4

     */
    public void ModifyElement(string table, string[] column, string[] value, string condition = "")
    {

        this.connection = "URI=file:" + Application.persistentDataPath + "/" + "Monopalu";
        IDbConnection dbcon = new SqliteConnection(this.connection);
        dbcon.Open();
        int index = 0;
        List<string> change = new List<string> { };
        foreach (var item in column)
        {
            change.Add(item + " = " + value[index]);
            index++;
        }
        dbcon.Close();
    }

    // Preset of the data base
    private void SetDB()
    {
        string[][] testIsEmpty = Select(new string[] { "*" }, "Card");
        if (testIsEmpty.Length < 1)
        {
            SetDefaultCard();
        }
        testIsEmpty = Select(new string[] { "*" }, "User");
        if (testIsEmpty.Length < 1)
        {
            SetDefaultUser();
        }
        testIsEmpty = Select(new string[] { "*" }, "Box");
        if (testIsEmpty.Length < 1)
        {
            SetDefaultBox();
        }
    }
    // Create all default card in the table "Card"
    private void SetDefaultCard()
    {
        InsertInto("Card", new string[] { "card_id", "card_name", "card_action", "card_desc", "card_value" }, new string[][]
        {
            new string[] { "0", "'Card1'", "'1'", "'move of 1 case'", "1"},
            new string[] { "1", "'Card2'", "'2'", "'move of 2 case'", "1"},
            new string[] { "2", "'Card3'", "'3'", "'move of 3 case'", "1"},
            new string[] { "3", "'Card4'", "'4'", "'move of 4 case'", "1"},
            new string[] { "4", "'Card5'", "'5'", "'move of 5 case'", "1"},
            new string[] { "5", "'Card6'", "'6'", "'move of 6 case'", "1"},
            new string[] { "6", "'Card7'", "'7'", "'move of 7 case'", "1"},
            new string[] { "7", "'Card8'", "'8'", "'move of 8 case'", "1"},
            new string[] { "8", "'Card9'", "'9'", "'move of 9 case'", "1"},
            new string[] { "9", "'Card10'", "'10'", "'move of 10 case'", "1"},
            new string[] { "10", "'Card11'", "'11'", "'move of 11 case'", "1"},
            new string[] { "11", "'Card12'", "'12'", "'move of 12 case'", "1"}
        });
    }

    // Create all default user in the table "User"
    private void SetDefaultUser()
    {
        InsertInto("User", new string[] { "user_id", "user_name", "user_score", "user_best_score" }, new string[][]
        {
            new string[] { "0", "'Person'", "0", "0"},
            new string[] { "1", "'Player'", "0", "0"},
            new string[] { "2", "'Ordi1'", "0", "0"},
            new string[] { "3", "'Ordi2'", "0", "0"},
            new string[] { "4", "'Ordi3'", "0", "0"},
        });
    }
    // Create all default case in the table "Box"
    private void SetDefaultBox()
    {
        InsertInto("Box", new string[] { "box_id", "box_owner", "box_desc", "box_build", "box_value" }, new string[][]
        {
            new string[] { "0", "0", "'Start'", "0", "0"},
            new string[] { "1", "0", "'Property'", "0", "1"},
            new string[] { "2", "0", "'Chest'", "0", "0"},
            new string[] { "3", "0", "'Property'", "0", "1"},
            new string[] { "4", "0", "'Money'", "0", "0"},
            new string[] { "5", "0", "'Train'", "0", "0"},
            new string[] { "6", "0", "'Property'","0", "2"},
            new string[] { "7", "0", "'Lucky'", "0", "0"},
            new string[] { "8", "0", "'Property'", "0", "2"},
            new string[] { "9", "0", "'Property'", "0", "2"},
            new string[] { "10", "0", "'Jail'", "0", "0"},
            new string[] { "11", "0", "'Property'", "0", "3"},
            new string[] { "12", "0", "'Light'", "0", "0"},
            new string[] { "13", "0", "'Property'", "0", "3"},
            new string[] { "14", "0", "'Property'", "0", "3"},
            new string[] { "15", "0", "'Train'", "0", "0"},
            new string[] { "16", "0", "'Property'", "0", "4"},
            new string[] { "17", "0", "'Chest'", "0", "0"},
            new string[] { "18", "0", "'Property'", "0", "4"},
            new string[] { "19", "0", "'Property'", "0", "4"},
            new string[] { "20", "0", "'Wait'", "0", "0"},
            new string[] { "21", "0", "'Property'", "0", "5"},
            new string[] { "22", "0", "'Lucky'", "0", "0"},
            new string[] { "23", "0", "'Property'", "0", "5"},
            new string[] { "24", "0", "'Property'", "0", "5"},
            new string[] { "25", "0", "'Train'", "0", "0"},
            new string[] { "26", "0", "'Property'", "0", "6"},
            new string[] { "27", "0", "'Property'", "0", "6"},
            new string[] { "28", "0", "'Light'", "0", "0"},
            new string[] { "29", "0", "'Property'", "0", "6"},
            new string[] { "30", "0", "'Stop'", "0", "0"},
            new string[] { "31", "0", "'Property'", "0", "7"},
            new string[] { "32", "0", "'Property'", "0", "7"},
            new string[] { "33", "0", "'Chest'", "0", "0"},
            new string[] { "34", "0", "'Property'", "0", "7"},
            new string[] { "35", "0", "'Train'", "0", "0"},
            new string[] { "36", "0", "'Lucky'", "0", "0"},
            new string[] { "37", "0", "'Property'", "0", "8"},
            new string[] { "38", "0", "'Money'", "0", "0"},
            new string[] { "39", "0", "'Property'", "0", "8"},
        });
    }
}