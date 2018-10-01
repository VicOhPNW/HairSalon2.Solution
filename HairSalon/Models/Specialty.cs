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
          int SpecialtyId = rdr.GetInt32(0);
          string SpecialtyService = rdr.GetString(1);
          Specialty newSpecialty = new Specialty(SpecialtyService, SpecialtyId);
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
        int SpecialtyId = 0;
        string SpecialtyService = "";

        while(rdr.Read())
        {
          SpecialtyId = rdr.GetInt32(0);
          SpecialtyService = rdr.GetString(1);
        }

        Specialty newSpecialty = new Specialty(SpecialtyService, SpecialtyId);
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return newSpecialty;
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
