Use HR


drop table if exists employees
create table employees
(
    employeeID     char(10) IDENTITY PRIMARY KEY,
    first_name     varchar(100)        NOT NULL,
    last_name      varchar(100),
    age            TINYINT,
    gender         Char(1),
    street         varchar(100)        NOT NULL,
    address_1ine_2 varchar(250),
    address_line_3 varchar(250),
    state          varchar(25)         NOT NULL,
    country        CHAR(2)             NOT NULL,
    zip            varchar(15)         NOT NULL,
    email          varchar(100) UNIQUE NOT NULL,
    phone          varchar(15),
    roleID         smallint            NOT NULL
)


drop table if exists employee_roles
create table employee_roles
(
    roleID       smallint IDENTITY PRIMARY KEY,
    name         varchar(100),
    departmentID smallint NOT NULL,
    salary decimal not null

)

drop table if exists departments
create table departments
(
    departmentID smallint PRIMARY KEY,
    name         varchar(100),

)


Alter table employees
add constraint FK_Employee_Role Foreign key (roleID) REFERENCES employee_roles(roleID)

Alter table employee_roles
add constraint FK_EmployeeRole_Dept Foreign key (departmentID) REFERENCES departments(departmentID)