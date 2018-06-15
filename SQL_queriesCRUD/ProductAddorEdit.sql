CREATE PROC ProductAddorEdit
@Code int,
@Name varchar(100),
@Descriptionn varchar(1000),
@Price int,
@quantity int,
@w_id int,
@ID int
AS
BEGIN
IF(@Code = 0)
BEGIN
	INSERT INTO Product
	(
	Name,
	Descriptionn,
	Price,
	quantity
	)
	VALUES
	(
	@Name,
	@Descriptionn,
	@Price,
	@quantity
	);
	Insert into Warehouse_Product
	(
		WarehouseeId,
		ProductId
	)
	Values
	(
		@w_id,
		@Code
	)
	
	
END
ELSE
BEGIN
	UPDATE Product
	SET
	Name = @Name,
	Descriptionn = @Descriptionn,
	Price = Price,
	quantity = @quantity
	WHERE  Code = @Code

	UPDATE Warehouse_Product
	Set
	ProductId = @Code,
	WarehouseeId = @w_id
	where ID = @ID

END

END