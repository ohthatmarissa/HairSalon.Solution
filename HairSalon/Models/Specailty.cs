// using System;
// using System.Collections.Generic;
// using MySql.Data.MySqlClient;
//
// namespace HairSalon.Models
// {
//   public class Specialty
//   {
//     private string _description;
//     private int _id;
//
//     public Specialty(string description, int id = 0)
//     {
//       _description = description;
//       _id = id;
//     }
//
//     public string GetDescription()
//     {
//       return _description;
//     }
//
//     public int GetId()
//     {
//       return _id;
//     }
//
//     public static void ClearAll()
//     {
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"DELETE FROM specialties;";
//       cmd.ExecuteNonQuery();
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//     }
//
//     public void Save()
//     {
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"INSERT INTO specialties (description) VALUES (@description);";
//       MySqlParameter description = new MySqlParameter();
//       description.ParameterName = "@description";
//       description.Value = this._description;
//       cmd.Parameters.Add(description);
//       cmd.ExecuteNonQuery();
//       _id = (int) cmd.LastInsertedId;
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//     }
//
//     public override bool Equals(System.Object otherSpecialty)
//     {
//       if (!(otherSpecialty is Specialty))
//       {
//         return false;
//       }
//       else
//       {
//         Specialty newSpecialty = (Specialty) otherSpecialty;
//         bool idEquality = this.GetId() == newSpecialty.GetId();
//         bool descriptionEquality = this.GetDescription() == newSpecialty.GetDescription();
//         return (idEquality && descriptionEquality);
//       }
//     }
//
//     public static List<Specialty> GetAll()
//     {
//       List<Specialty> allSpecialties = new List<Specialty> {};
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"SELECT * FROM specialties;";
//       MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
//       while(rdr.Read())
//       {
//         int id = rdr.GetInt32(0);
//         string description = rdr.GetString(1);
//         Specialty newSpecialty = new Specialty(description, id);
//         allSpecialties.Add(newSpecialty);
//       }
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//       return allSpecialties;
//     }
//
//     public static Specialty Find(int thisId)
//     {
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"SELECT * FROM specialties WHERE id = @searchId;";
//       MySqlParameter searchId = new MySqlParameter();
//       searchId.ParameterName = "@searchId";
//       searchId.Value = thisId;
//       cmd.Parameters.Add(searchId);
//       MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
//       int id = 0;
//       string description = "";
//       while(rdr.Read())
//       {
//         id = rdr.GetInt32(0);
//         description = rdr.GetString(1);
//       }
//       Specialty newSpecialty = new Specialty(description, id);
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//       return newSpecialty;
//     }
//
//     public void AddStylist(Stylist newStylist)
//     {
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";
//       MySqlParameter stylistId = new MySqlParameter();
//       stylistId.ParameterName = "@StylistId";
//       stylistId.Value = newStylist.GetId();
//       cmd.Parameters.Add(stylistId);
//       MySqlParameter specialtyId = new MySqlParameter();
//       specialtyId.ParameterName = "@SpecialtyId";
//       specialtyId.Value = _id;
//       cmd.Parameters.Add(specialtyId);
//       cmd.ExecuteNonQuery();
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//     }
//
//     public static List<Stylist> GetStylists()
//     {
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"SELECT stylists.* FROM specialties
//       JOIN stylists_specialties ON (specialties.id = stylists_specialties.specialty_id)
//       JOIN stylists ON (stylists.id = stylists_specialties.stylist_id)
//       WHERE specialties.id = @SpecialtyId;";
//       MySqlParameter specialtyId = new MySqlParameter();
//       specialtyId.ParameterName = "@SpecialtyId";
//       specialtyId.Value = _id;
//       cmd.Parameters.Add(specialtyId);
//       MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
//       List<Stylist> allStylists = new List<Stylist> {};
//       while(rdr.Read())
//       {
//         int stylistId = rdr.GetInt32(0);
//         string stylistName = rdr.GetString(1);
//         string stylistAbout = rdr.GetString(2);
//         Stylist newStylist = new Stylist(stylistName, stylistAbout, stylistId);
//         allStylists.Add(newStylist);
//       }
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//       return allStylists;
//     }
//
//   }
// }
