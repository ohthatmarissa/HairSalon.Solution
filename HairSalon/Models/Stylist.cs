using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
// using System.ComponentModel.DataAnnotations;

namespace HairSalon.Models
{
    public class Stylist
    {
      private string _name;
      private int _id;
      public string _about;


      public Stylist (string name, string about, int id=0)
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
      cmd.CommandText = @"INSERT INTO stylists (stylist_name, stylist_about) VALUES (@stylist_name, @stylist_about);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@stylist_name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      MySqlParameter about = new MySqlParameter();
      about.ParameterName = "@stylist_about";
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

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
       Stylist newStylist = (Stylist) otherStylist;
       bool idEquality = this.GetId() == newStylist.GetId();
       bool nameEquality = this.GetName() == newStylist.GetName();
       bool aboutEquality = this.GetAbout() == newStylist.GetAbout();
       return (idEquality && nameEquality && aboutEquality);
      }
    }


    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string about = rdr.GetString(2);
        Stylist newStylist = new Stylist(name, about, id);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }


    public static Stylist Find(int thisId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = @searchID;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = thisId;
      cmd.Parameters.Add(searchId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int id = 0;
      string name = "";
      string about = "";
      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        about = rdr.GetString(2);
      }
      Stylist newStylists = new Stylist(name, about, id);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newStylists;
    }

    public List<Client> GetClients()
    {
      List<Client> foundClients = new List<Client>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this._id;
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

        Client newClient = new Client(name, about, stylistId, id);
        foundClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClients;
    }

    public void Edit (int id, string newName, string newAbout)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET stylist_name = @newName, stylist_about = @newAbout WHERE id = @SearchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this._id;
      cmd.Parameters.Add(searchId);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newName;
      cmd.Parameters.Add(name);
      MySqlParameter about = new MySqlParameter();
      about.ParameterName = "@newAbout";
      about.Value = newAbout;
      cmd.Parameters.Add(about);
      cmd.ExecuteNonQuery();
      _name = newName;
      _about = newAbout;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Delete ()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE id = @StylistId;";
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@StylistId";
      stylistId.Value = this.GetId();
      cmd.Parameters.Add(stylistId);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }

    public void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

      public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }
  }
}
