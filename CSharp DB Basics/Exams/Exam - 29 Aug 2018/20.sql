CREATE TRIGGER tr_OrderItemDeleted
  ON OrderItems
  AFTER DELETE AS
  INSERT INTO DeletedOrders (OrderId, ItemId, ItemQuantity) 
      (SELECT OrderId, ItemId, Quantity FROM deleted)
