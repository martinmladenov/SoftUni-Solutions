CREATE TRIGGER tr_OrdersUpdate ON Orders FOR UPDATE AS
UPDATE p
SET StockQty += op.Quantity
FROM inserted i
JOIN deleted d ON d.OrderId = i.OrderId
JOIN OrderParts op ON op.OrderId = i.OrderId
JOIN Parts p ON p.PartId = op.PartId
WHERE i.Delivered = 1 AND d.Delivered = 0