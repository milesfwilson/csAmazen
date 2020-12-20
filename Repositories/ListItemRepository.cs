using System;
using System.Collections.Generic;
using System.Data;
using csAmazen.Models;
using Dapper;

namespace csAmazen.Repositories
{
  public class ListItemRepository
  {

    private readonly IDbConnection _db;

    private readonly string populateCreator = "SELECT listItem.*, profile.* FROM listItems listItem INNER JOIN profiles profile ON listItem.creatorId = profile.id ";
    public ListItemRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(ListItem newListItem)
    {

      string sql = @"INSERT INTO listItems
            (listId, itemId, creatorId, id)
            VALUES
            (@listId, @itemId, @creatorId, @id);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newListItem);
    }

    internal IEnumerable<ListItem> Get()
    {
      string sql = populateCreator;
      return _db.Query<ListItem, Profile, ListItem>(sql, (listItem, profile) => { listItem.Creator = profile; return listItem; }, splitOn: "id");
    }

    internal void Edit(ListItem editedListItem)
    {
      string sql = @"
      UPDATE listItems
      SET
      itemId = @ItemId,
      listId = @listId
WHERE id = @Id;";
      _db.Execute(sql, editedListItem);
    }

    internal bool Delete(int id)
    {
      string sql = @"DELETE FROM listItems WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    internal IEnumerable<Item> GetItemsByListId(int listId)
    {
      string sql = @"
        SELECT item.*,
        listitem.id as ListItemId,
        profile.*
        FROM listitems listitem
        JOIN items item ON item.id = listitem.itemId
        JOIN profiles profile ON profile.id = item.creatorId
        WHERE listId = @ListId;
        ";
      return _db.Query<ListItemViewModel, Profile, ListItemViewModel>(sql, (item, profile) => { item.Creator = profile; return item; }, new { listId }, splitOn: "id");

    }

    internal ListItem GetOne(int id)
    {
      string sql = "SELECT * FROM listItems WHERE id = @Id";
      return _db.QueryFirstOrDefault<ListItem>(sql, new { id });
    }
  }
}