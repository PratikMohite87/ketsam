select * from Customer;

select * from Category;

select * from Product;

select * from Admin;

insert into Category(CategoryName) values ('electronics');
insert into Category(CategoryName) values ('clothing');

insert into Product(ProductName,Price,Quantity,ImagePath,AdminId,CategoryId) values ('mobile',2300,50,'xyzyxyz',1,1);
insert into Product(ProductName,Price,Quantity,ImagePath,AdminId,CategoryId) values ('jeans',4000,150,'xyzyxyz',1,2);

insert into Admin(AdminName,AdminEmail,AdminPassword) values ('Prasad','prasadpatil@gmail.com','PrasadP@9969');