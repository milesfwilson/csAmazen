using System;
using System.Collections.Generic;
using System.Data;
using csAmazen.Models;
using Dapper;

namespace csAmazen.Repositories
{
  public class OptionRepository
  {

    private readonly IDbConnection _db;

    public OptionRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(Option newOption)
    {
      string sql = @"INSERT INTO options
            (color, itemId, id, creatorId)
            VALUES
            (@Color, @ItemId, @Id, @CreatorId);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newOption);
    }


    internal IEnumerable<Option> Get()
    {
      string sql = "SELECT * FROM options";
      return _db.Query<Option>(sql);
    }

    internal void Edit(Option editedOption)
    {
      string sql = @"
      UPDATE options
      SET
      color = @Color,
itemId = @ItemId
WHERE id = @Id;";
      _db.Execute(sql, editedOption);
    }

    internal bool Delete(int id)
    {
      string sql = @"DELETE FROM options WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    internal Option GetOne(int id)
    {
      string sql = "SELECT * FROM options WHERE id = @Id";
      return _db.QueryFirstOrDefault<Option>(sql, new { id });
    }

    internal object GetOptionsByItemId(int id)
    {
      string sql = "SELECT * FROM options WHERE itemId = @Id";
      return _db.Query<Option>(sql, new { id });
    }
  }
}