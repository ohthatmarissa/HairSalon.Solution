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
    private int _stylistId;

    public Client (string name, string about, int stylistId, int id=0)
    {
      _name = name;
      _id = id;
      _about = about;
      _stylistId = stylistId;
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

    public int GetStylistId()
    {
      return _stylistId;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (client_name, client_about, stylist_id) VALUES (@client_name, @client_about, @stylist_Id);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@client_name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      MySqlParameter about = new MySqlParameter();
      about.ParameterName = "@client_about";
      about.Value = this._about;
      cmd.Parameters.Add(about);
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylist_id";
      stylistId.Value = this._stylistId;
      cmd.Parameters.Add(stylistId);
      cmd.ExecuteNonQuery();
      _id = (int)cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
       Client newClient = (Client) otherClient;
       bool idEquality = this.GetId() == newClient.GetId();
       bool nameEquality = this.GetName() == newClient.GetName();
       bool aboutEquality = this.GetAbout() == newClient.GetAbout();
       bool stylistIdEquality = this.GetStylistId() == newClient.GetStylistId();
       return (idEquality && nameEquality && aboutEquality && stylistIdEquality);
      }
    }


      public static List<Client> GetAll()
      {
        List<Client> allClients = new List<Client> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int id = rdr.GetInt32(0);
          string name = rdr.GetString(1);
          string about = rdr.GetString(2);
          int stylistId = rdr.GetInt32(3);
          Client newClient = new Client(name, about, stylistId, id);
          allClients.Add(newClient);
        }
            conn.Close();
            if (conn != null)
            {
              conn.Dispose();
            }
            return allClients;
          }

          public static Client Find(int thisId)
          {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id = @searchID;";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = thisId;
            cmd.Parameters.Add(searchId);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id = 0;
            string name = "";
            string about = "";
            int stylistId = 0;
            while(rdr.Read())
            {
              id = rdr.GetInt32(0);
              name = rdr.GetString(1);
              about = rdr.GetString(2);
              stylistId = rdr.GetInt32(3);
            }
            Client newClients = new Client(name, about, stylistId, id);
            conn.Close();
            if (conn != null)
            {
              conn.Dispose();
            }
            return newClients;
          }

          public static void ClearAll()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"DELETE FROM clients;";
          cmd.ExecuteNonQuery();
          conn.Close();
          if (conn != null)
          {
           conn.Dispose();
          }
        }




  }
}
