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

    private readonly string populateCreator = "SELECT item.*, profile.* FROM items item INNER JOIN profiles profile ON item.creatorId = profile.id ";
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

    internal IEnumerable<Item> getItemsByProfile(string profileId)
    {
      string sql = @"
                SELECT
                item.*,
                profile.*
                FROM items item
                JOIN profiles profile ON item.creatorId = profile.id
                WHERE item.creatorID = @profileId;";
      return _db.Query<Item, Profile, Item>(sql, (item, profile) => { item.Creator = profile; return item; }, new { profileId }, splitOn: "id");
    }

    internal IEnumerable<Item> Get()
    {
      string sql = populateCreator;
      return _db.Query<Item, Profile, Item>(sql, (item, profile) => { item.Creator = profile; return item; }, splitOn: "id");
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
isAvailable = @IsAvailable,
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