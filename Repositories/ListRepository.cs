using System;
using System.Collections.Generic;
using System.Data;
using csAmazen.Models;
using Dapper;

namespace csAmazen.Repositories
{
  public class ListRepository
  {

    private readonly IDbConnection _db;

    private readonly string populateCreator = "SELECT list.*, profile.* FROM lists list INNER JOIN profiles profile ON list.creatorId = profile.id ";
    public ListRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(List newList)
    {

      string sql = @"INSERT INTO lists
            (title, id, isPublic, creatorId)
            VALUES
            (@Title, @Id, @IsPublic, @CreatorId);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newList);
    }

    internal IEnumerable<List> Get()
    {
      string sql = populateCreator;
      return _db.Query<List, Profile, List>(sql, (list, profile) => { list.Creator = profile; return list; }, splitOn: "id");
    }

    internal void Edit(List editedList)
    {
      string sql = @"
      UPDATE lists
      SET
      title = @Title,
      isPublic = @IsPublic
WHERE id = @Id;";
      _db.Execute(sql, editedList);
    }

    internal bool Delete(int id)
    {
      string sql = @"DELETE FROM lists WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    internal List GetOne(int id)
    {
      string sql = "SELECT * FROM lists WHERE id = @Id";
      return _db.QueryFirstOrDefault<List>(sql, new { id });
    }
  }
}