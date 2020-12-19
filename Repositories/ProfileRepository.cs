using System;
using System.Data;
using csAmazen.Models;
using Dapper;

namespace csAmazen.Repositories
{
  public class ProfileRepository
  {

    private readonly IDbConnection _db;

    public ProfileRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile GetById(string id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @Id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal Profile Create(Profile userInfo)
    {
      string sql = @"INSERT INTO profiles
                (id, name, email, picture)
                VALUES 
                (@Id, @Name, @Email, @Picture)";
      _db.Execute(sql, userInfo);
      return userInfo;
    }
  }
}