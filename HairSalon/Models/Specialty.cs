using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Specialty
  {
    private int _id;
    private string _service;

    public Specialty(string service, int id = 0)
    {
      _service = service;
      _id = id;
    }

    public string GetService()
    {
      return _service;
    }
    public int GetId()
    {
      return _id;
    }

    public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty) otherSpecialty;
                bool idEquality = this.GetId().Equals(newSpecialty.GetId());
                bool serviceEquality = this.GetService().Equals(newSpecialty.GetService());
                return (idEquality && serviceEquality);
            }
        }
    public override int GetHashCode()
    {
        return this.GetId().GetHashCode();
    }

    public static List<Specialty> GetAllSpecialties()
    {
        List<Specialty> allSpecialties = new List<Specialty>{};
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM specialties;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int specialtyId = rdr.GetInt32(0);
          string specialtyService = rdr.GetString(1);
          Specialty newSpecialty = new Specialty(specialtyService, specialtyId);
          allSpecialties.Add(newSpecialty);
        }

        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allSpecialties;
    }

    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO specialties (service) VALUES (@service);";

        MySqlParameter service = new MySqlParameter();
        service.ParameterName = "@service";
        service.Value = this._service;
        cmd.Parameters.Add(service);

        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }

    public static Specialty Find(int id)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId)";

        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int specialtyId = 0;
        string specialtyService = "";

        while(rdr.Read())
        {
          specialtyId = rdr.GetInt32(0);
          specialtyService = rdr.GetString(1);
        }

        Specialty newSpecialty = new Specialty(specialtyService, specialtyId);
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return newSpecialty;
    }

    public void AddStylists(Stylist newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@StylistId";
      stylistId.Value = newStylist.GetId();
      cmd.Parameters.Add(stylistId);

      MySqlParameter specialtyId = new MySqlParameter();
      specialtyId.ParameterName = "@SpecialtyId";
      specialtyId.Value = _id;
      cmd.Parameters.Add(specialtyId);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Stylist> GetStylists()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM specialties
      JOIN stylists_specialties ON (specialties.id = stylists_specialties.specialty_id)
      JOIN stylists ON (stylists_specialties.stylist_id = stylists.id)
      WHERE specialties.id = @SpecialtyId;";

      MySqlParameter SpecialtyId = new MySqlParameter();
      SpecialtyId.ParameterName = "@SpecialtyId";
      SpecialtyId.Value = _id;
      cmd.Parameters.Add(SpecialtyId);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Stylist> allStylists = new List<Stylist>{};

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE id = @StylistId;";

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@StylistId";
      stylistId.Value = this.GetId();
      cmd.Parameters.Add(stylistId);

      cmd.ExecuteNonQuery();
      conn.Close();

      if (conn != null)
      {
          conn.Dispose();
      }
    }

    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM specialties;";
        cmd.ExecuteNonQuery();
        conn.Close();

        if (conn != null)
        {
            conn.Dispose();
        }
    }

  }
}
