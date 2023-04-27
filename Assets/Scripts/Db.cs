using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using Newtonsoft.Json.Linq;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;
using System;
using System.Linq;

public class dbAccess
{
    // variables for basic query access
    private string connection;
    private IDbConnection dbcon;
    private IDbCommand dbcmd;
    private IDataReader reader;
   
    public void OpenDB(string p)
    {
        connection = "URI=file:" + p; // we set the connection to our database
        dbcon = new SqliteConnection(connection);
        dbcon.Open();
    }

    public IDataReader BasicQuery(string q,bool r)
    { // run a baic Sqlite query
        dbcmd = dbcon.CreateCommand(); // create empty command
        dbcmd.CommandText = q; // fill the command
        reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        if (r)
        { // if we want to return the reader
            return reader; // return the reader
        } else
        {
            return null;
        }
    }

    public void CreateTable(string name, string[] col, string[] colType)
    { // Create a table, name, column array, column type array
        String query;
        query = "CREATE TABLE " + name + "(" + col[0] + " " + colType[0];
        for (var i = 1; i < col.Length; i++)
        {
            query += ", " + col[i] + " " + colType[i];
        }
        query += ")";
        dbcmd = dbcon.CreateCommand(); // create empty command
        dbcmd.CommandText = query; // fill the command
        reader = dbcmd.ExecuteReader(); // execute command which returns a reader

    }

    public void InsertIntoSingle(string tableName, String colName, String value)
    { // single insert
        String query;
        query = "INSERT INTO " + tableName + "(" + colName + ") " + "VALUES (" + value + ")";
        dbcmd = dbcon.CreateCommand(); // create empty command
        dbcmd.CommandText = query; // fill the command
        reader = dbcmd.ExecuteReader(); // execute command which returns a reader
    }

    public void InsertIntoSpecific(string tableName, Array[] col, Array[] values)
    { // Specific insert with col and values
        String query;
        query = "INSERT INTO " + tableName + "(" + col[0];
        for (int i = 1; i < col.Length; i++)
        {
            query += ", " + col[i];
        }
        query += ") VALUES (" + values[0];
        for (int i = 1; i < values.Length; i++)
        {
            query += ", " + values[i];
        }
        query += ")";
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = query;
        reader = dbcmd.ExecuteReader();
    }

    public void InsertInto(String tableName, int[] values)
    { // basic Insert with just values
        String query;
        query = "INSERT INTO " + tableName + " VALUES (" + values[0];
        for (var i = 1; i < values.Length; i++)
        {
            query += ", " + values[i];
        }
        query += ")";
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = query;
        reader = dbcmd.ExecuteReader();
    }

    public void SingleSelectWhere(String tableName, String itemToSelect, String wCol, String wPar, String wValue)
    { // Selects a single Item
        String query;
        query = "SELECT " + itemToSelect + " FROM " + tableName + " WHERE " + wCol + wPar + wValue;
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = query;
        reader = dbcmd.ExecuteReader();
        Array[] readArray;
        while (reader.Read())
        {
            readArray.Append(readArray, reader.GetString(0)); // Fill array with all matches
        }
        return readArray; // return matches
    }


    public void CloseDB()
    {
        reader.Close(); // clean everything up
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }

}