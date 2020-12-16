

drop table if exists accounts.orders
create table accounts.orders
(
    orderID            int IDENTITY (1000,1) PRIMARY KEY,
    timestamp          datetime,
    customerID         int          NOT NULL,
    number_of_products smallint     NOT NULL,
    street             varchar(100) NOT NULL,
    address_1ine_2     varchar(250),
    address_line_3     varchar(250),
    state              varchar(25)  NOT NULL,
    country            CHAR(2)      NOT NULL,
    zip                varchar(15)  NOT NULL,
    paymentID int not null,
    delivery_typeID tinyint default 1,
    delivery_partnerID tinyint default 1,

)


drop table if exists accounts.orderPayments
create table accounts.orderPayments
(
    paymentID      int IDENTITY PRIMARY KEY,
    payment_typeID tinyint      not null,
    street         varchar(100) NOT NULL,
    address_1ine_2 varchar(250),
    address_line_3 varchar(250),
    state          varchar(25)  NOT NULL,
    country        CHAR(2)      NOT NULL,
    zip            varchar(15)  NOT NULL,
    total_sale_amount decimal

)


drop table if exists accounts.ordersDetails
create table accounts.ordersDetails
(
    orderID   int NOT NULL,
    SKU char(10)      NOT NULL,
    quantity  smallint not null,

)


drop table if exists accounts.paymentTypes
create table accounts.paymentTypes
(
    payment_typeID tinyint IDENTITY PRIMARY KEY,
    name           varchar(50)         NOT NULL,
    provider       varchar(50)         NOT NULL,
    email          varchar(100) UNIQUE NOT NULL,
    phone          varchar(15),

)





Alter table accounts.ordersDetails
add constraint FK_Order_Details Foreign key (orderID) REFERENCES accounts.orders(orderID)

Alter table accounts.orders
add constraint FK_Order_Payment Foreign key (paymentID) REFERENCES accounts.orderPayments(paymentID)

Alter table accounts.orders
add constraint FK_Order_DeliveryType Foreign key (delivery_typeID) REFERENCES inventory.deliveryTypes(delivery_typeID)

Alter table accounts.orders
add constraint FK_Order_DeliveryPartner Foreign key (delivery_partnerID) REFERENCES inventory.deliveryPartners(delivery_partnerID)

Alter table accounts.orderPayments
add constraint FK_Payment_PaymentType Foreign key (payment_typeID) REFERENCES accounts.paymentTypes(payment_typeID)

Alter table accounts.orders
add constraint FK_Order_Customer Foreign key (customerID) REFERENCES crm.customers(customerID)

Alter table accounts.ordersDetails
add constraint FK_Order_Product Foreign key (SKU) REFERENCES inventory.products(SKU)

---todo when an order is made - CRM Service, Inventory and Account Service

select * from accounts.paymentTypes
select * from accounts.orderPayments

---Insertions
insert into accounts.paymentTypes
values ('CCAvenue','CC','ccavenue@cc.com','987654321')

insert into accounts.orderPayments
values (1,'1023 E University','1023 E University','1023 E University','AZ','US',85281,420)



insert into accounts.orders
(customerID,paymentID,delivery_typeID,delivery_partnerID,number_of_products,street,address_1ine_2,address_line_3,state,country,zip) values (1,1,1,1,2,'1023 E University','1023 E University','1023 E University','AZ','US',85281)