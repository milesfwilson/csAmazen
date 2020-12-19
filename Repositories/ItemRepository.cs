using System;
using System.Collections.Generic;
using System.Data;
using csAmazen.Models;
using Dapper;

namespace csAmazen.Repositories
{
  public class ItemRepository
  {
    private readonly IDbConnection _db;

    public ItemRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(Item newItem)
    {
      string sql = @"INSERT INTO items
            (title, description, price, salePrice, picture, quantity, id, rating, isAvailable, creatorId)
            VALUES
            (@Title, @Description, @Price, @SalePrice, @Picture, @Quantity, @Id, @Rating, @IsAvailable, @CreatorId);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newItem);
    }

    internal IEnumerable<Item> Get()
    {
      string sql = @"SELECT * FROM items";
      return _db.Query<Item>(sql);
    }

    internal void Edit(Item editedItem)
    {
      string sql = @"
      UPDATE items
      SET
      title = @Title,
description = @Description,
price = @Price,
salePrice = @SalePrice,
picture = @Picture,
quantity = @Quantity,
rating = @Rating
WHERE id = @Id;";
      _db.Execute(sql, editedItem);
    }

    internal bool Delete(int id)
    {
      string sql = @"DELETE FROM items WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    internal Item GetOne(int id)
    {
      string sql = "SELECT * FROM items WHERE id = @Id";
      return _db.QueryFirstOrDefault<Item>(sql, new { id });
    }
  }
}