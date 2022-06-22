CREATE TABLE Product
(
    Id INT IDENTITY
        CONSTRAINT  PK_Product_Id
            PRIMARY KEY,
    [Name] NVARCHAR(300)
);

CREATE TABLE Category
(
    Id INT IDENTITY
        CONSTRAINT  PK_Category_Id
            PRIMARY KEY,
    [Name] NVARCHAR(100)
);

CREATE TABLE ProductCategoryXRef
(
    ProductID INT
        CONSTRAINT FK_ProductCategoryXRef_Product_Id
            REFERENCES Product,
    CategoryID INT
        CONSTRAINT FK_ProductCategoryXRef_Category_Id
            REFERENCES Category,
    PRIMARY KEY (ProductID, CategoryID)
)

INSERT INTO Product ([Name]) VALUES
(N'Молоко'),
(N'Томаты'),
(N'Шкаф'),
(N'Ford GT 40'),
(N'Тарелка')

INSERT INTO Category ([Name]) VALUES
(N'Молочная продукция'),
(N'Овощи'),
(N'Мебель'),
(N'Автомобиль'),
(N'Еда'),
(N'Гоночный автомобиль');

INSERT INTO ProductCategoryXRef (productid, categoryid) VALUES
(1,1),
(1,5),
(2,2),
(2,5),
(3,3),
(4,4),
(4,6);

SELECT Product.name as Product, C.Name as Category FROM Product
    LEFT JOIN ProductCategoryXRef PCXR on Product.Id = PCXR.ProductID
    FULL JOIN Category C on C.Id = PCXR.CategoryID