
Create database Orders

drop table if exists orders
create table orders
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


drop table if exists orderPayments
create table orderPayments
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


drop table if exists ordersDetails
create table ordersDetails
(
    orderID   int IDENTITY (1000,1) PRIMARY KEY,
    productID int      NOT NULL,
    quantity  smallint not null,

)


drop table if exists paymentTypes
create table paymentTypes
(
    payment_typeID tinyint IDENTITY PRIMARY KEY,
    name           varchar(50)         NOT NULL,
    provider       varchar(50)         NOT NULL,
    email          varchar(100) UNIQUE NOT NULL,
    phone          varchar(15),

)


drop table if exists deliveryPartners
    create table deliveryPartners
    (delivery_partnerID tinyint NOT NULL PRIMARY KEY,
    name varchar(100)
    )

drop table if exists deliveryTypes
    create table deliveryTypes
    (delivery_typeID tinyint NOT NULL PRIMARY KEY,
    name varchar(100)
    )


Alter table ordersDetails
add constraint FK_Order_Details Foreign key (orderID) REFERENCES orders(orderID)

Alter table orders
add constraint FK_Order_Payment Foreign key (orderID) REFERENCES orderPayments(paymentID)

Alter table orders
add constraint FK_Order_DeliveryType Foreign key (delivery_typeID) REFERENCES deliveryTypes(delivery_typeID)

Alter table orders
add constraint FK_Order_DeliveryPartner Foreign key (delivery_partnerID) REFERENCES deliveryPartners(delivery_partnerID)

Alter table orderPayments
add constraint FK_Payment_PaymentType Foreign key (payment_typeID) REFERENCES paymentTypes(payment_typeID)





---todo attaching customerID when an order is made from CRM Service