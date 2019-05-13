using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private int _id;
    private string _about;

    public Client (string name, string about, int id=0)
    {
      _name = name;
      _id = id;
      _about = about;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetAbout()
    {
      return _about;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (client_name, client_about) VALUES (@client_name, @client);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@client_name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      MySqlParameter about = new MySqlParameter();
      about.ParameterName = "@client_about";
      about.Value = this._about;
      cmd.Parameters.Add(about);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
