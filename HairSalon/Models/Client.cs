using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _clientName;
    private int _stylistId;

    public Client(string clientName, int stylistId, int id = 0)
    {
      _clientName = clientName;
      _stylistId = stylistId;
      _id= id;
    }

    public string GetClientName()
    {
      return _clientName;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public int GetId()
    {
      return _id;
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
                bool idEquality = this.GetId().Equals(newClient.GetId());
                bool nameEquality = this.GetClientName().Equals(newClient.GetClientName());
                bool stylistIdEquality = this.GetStylistId().Equals(newClient.GetStylistId());
                return (idEquality && nameEquality && stylistIdEquality);
            }
        }
    public override int GetHashCode()
    {
        return this.GetClientName().GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (client_name, stylist_id) VALUES (@client_name, @stylist_id);";

      MySqlParameter clientName = new MySqlParameter();
      clientName.ParameterName = "@client_name";
      clientName.Value = this._clientName;
      cmd.Parameters.Add(clientName);

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylist_id";
      stylistId.Value = this._stylistId;
      cmd.Parameters.Add(stylistId);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }

    public void Edit(string updateName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET client_name = @updateName WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);

      MySqlParameter client_name = new MySqlParameter();
      client_name.ParameterName = "@updateName";
      client_name.Value = updateName;
      cmd.Parameters.Add(client_name);

      cmd.ExecuteNonQuery();
      _clientName = updateName;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientName, stylistId, clientId);
        allClients.Add(newClient);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int ClientId = 0;
      string clientName = "";
      int stylistClientId = 0;

      while(rdr.Read())
      {
        ClientId = rdr.GetInt32(0);
        clientName = rdr.GetString(1);
        stylistClientId = rdr.GetInt32(2);
      }
      Client newClient = new Client(clientName, stylistClientId, ClientId);
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return newClient;
    }

    // public List<Stylist> GetStylists()
    // {
    //   List<Stylist> allClientStylists = new List<Stylist> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM stylists WHERE id = @stylistId;";
    //
    //   MySqlParameter stylist_id = new MySqlParameter();
    //   stylist_id.ParameterName = "@stylistId";
    //   stylist_id.Value = this.GetId();
    //   cmd.Parameters.Add(stylist_id);
    //
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int id = 0;
    //   string stylistName = "";
    //
    //   while(rdr.Read())
    //   {
    //     id = rdr.GetInt32(0);
    //     stylistName = rdr.GetString(1);
    //     Stylist newStylist = new Stylist(stylistName, id);
    //     allClientStylists.Add(newStylist);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //       conn.Dispose();
    //   }
    //   return allClientStylists;
    // }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE id = @ClientId;";

      MySqlParameter ClientId = new MySqlParameter();
      ClientId.ParameterName = "@ClientId";
      ClientId.Value = this.GetId();
      cmd.Parameters.Add(ClientId);

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
