

alter Proc crm.spResetCustomers
AS
BEGIN

    drop table if exists crm.customers
    create table crm.customers
    (
        customerID  int IDENTITY PRIMARY KEY,
        first_name    varchar(100)        NOT NULL,
        last_name     varchar(100),
        age          TINYINT,
        gender       Char(1),
        street       varchar(100)        NOT NULL,
        address_1ine_2 varchar(250),
        address_line_3 varchar(250),
        state        varchar(25)         NOT NULL,
        country      CHAR(2)             NOT NULL,
        zip      varchar(15)         NOT NULL,
        email        varchar(100) UNIQUE NOT NULL,
        phone        varchar(15),
    )

end



---Insertions

insert into crm.customers
(first_name,street,state,country,zip,email) values ('Aravind','7009 Laurel Ct','NJ','US','02740','aravind@gmail.com')

insert into crm.customers
(first_name,street,state,country,zip,email) values ('Ajith','3751 State Rd','NJ','US','66666','ajith@inrika.com')


select * from crm.customers