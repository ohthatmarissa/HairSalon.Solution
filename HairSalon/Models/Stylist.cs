using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
      private string _name;
      private int _id;
      public string _about;

      public Stylist (string name, int id, string about)
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
      cmd.CommandText = @"INSERT INTO stylists (name, id, about) VALUES (@name, @id, @about);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      MySqlParameter id = new MySqlParameter();
      id.ParameterName = "@id";
      id.Value = this._id;
      cmd.Parameters.Add(id);
      MySqlParameter about = new MySqlParameter();
      about.ParameterName = "@about";
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
        Stylist newStylist = new Stylist(name, id, about);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    // public static Stylist Find(int id)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchID);";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = id;
    //   cmd.Parameters.Add(searchId);
    //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int id = 0;
    //   string name = "";
    //   string about = "";
    //   while(rdr.Read())
    //   {
    //     id = rdr.GetInt32(0);
    //     name = rdr.GetString(1);
    //     about = rdr.GetString(2);
    //   }
    //   Stylists newStylists = new Stylists(name, id, about);
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return newStylists;
    // }

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
