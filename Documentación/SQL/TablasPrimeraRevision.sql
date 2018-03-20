CREATE DATABASE Proyecto;

USE Proyecto;

CREATE TABLE Regions(
	region_id int IDENTITY(1,1) PRIMARY KEY,
	region_name varchar(45) NOT NULL
);

CREATE TABLE Countries(
	country_id int IDENTITY(1,1) PRIMARY KEY,
	country_name varchar(45) NOT NULL,
	region_id int FOREIGN KEY REFERENCES Regions(region_id)
);

CREATE TABLE Locations(
	location_id int IDENTITY(1,1) PRIMARY KEY,
	street_address varchar(50) NOT NULL,
	postal_code char(8) NOT NULL,
	city varchar(30) NOT NULL,
	state_province varchar(30) NOT NULL,
	country_id int FOREIGN KEY REFERENCES Countries(country_id)
);

CREATE TABLE Jobs(
	job_id int IDENTITY(1,1) PRIMARY KEY,
	job_title varchar(35) NOT NULL,
	min_salary decimal NOT NULL,
	max_salary decimal NOT NULL
);

CREATE TABLE Employees(
	employee_id int IDENTITY(1,1) PRIMARY KEY,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	email varchar(50) NOT NULL,
	phone_number char(15) NOT NULL,
	hire_date date NOT NULL,
	job_id int FOREIGN KEY REFERENCES Jobs(job_id),
	salary decimal NOT NULL,
	commission_pct decimal NOT NULL,
	manager_id int FOREIGN KEY REFERENCES Employees(employee_id),
	department_id int
);

CREATE TABLE Departments(
	department_id int IDENTITY(1,1) PRIMARY KEY,
	department_name varchar(45) NOT NULL,
	manager_id int FOREIGN KEY REFERENCES Employees(employee_id),
	location_id int FOREIGN KEY REFERENCES Locations(location_id)
);

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Departments FOREIGN KEY (department_id) REFERENCES Departments(department_id);

CREATE TABLE JobHistory(
	employee_id int NOT NULL FOREIGN KEY REFERENCES Employees(employee_id),
	start_date date NOT NULL,
	end_date date,
	job_id int NOT NULL FOREIGN KEY REFERENCES Jobs(job_id),
	department_id int NOT NULL FOREIGN KEY REFERENCES Departments(department_id),
	CONSTRAINT PK_JobHistory PRIMARY KEY (employee_id, job_id)
);


CREATE TABLE Customers(
	customer_id int IDENTITY(1,1) PRIMARY KEY,
	cust_first_name varchar(50) NOT NULL,
	cust_last_name varchar(50) NOT NULL,
	cust_address varchar(80) NOT NULL,
	phone_number char(15) NOT NULL,
	nls_language char(2) NOT NULL,
	nls_territory char(2) NOT NULL,
	credit_limit decimal NOT NULL,
	cust_email varchar(50) NOT NULL,
	account_mgr_id int FOREIGN KEY REFERENCES Employees(employee_id),
	cust_geo_location geography,
	date_of_birth date NOT NULL,
	marital_status varchar(12),
	gender char(1),
	income_level varchar(12)
);

CREATE INDEX IDX_Language ON Customers(nls_language);

CREATE TABLE Warehouses(
	warehouse_id int IDENTITY(1,1) PRIMARY KEY,
	warehouse_spec varchar(12),
	warehouse_name varchar(45) NOT NULL,
	location_id int FOREIGN KEY REFERENCES Locations(location_id),
	wh_geo_location geography
);

CREATE TABLE Orders(
	order_id int IDENTITY(1,1) PRIMARY KEY,
	order_date date NOT NULL,
	order_mode varchar(15),
	customer_id int FOREIGN KEY REFERENCES Customers(customer_id),
	order_status varchar(15),
	order_total decimal,
	sales_rep_id int FOREIGN KEY REFERENCES Employees(employee_id),
	promotion_id int
);

CREATE TABLE ProductInformation(
	product_id int IDENTITY(1,1) PRIMARY KEY,
	product_name varchar(45) NOT NULL,
	product_description varchar(100) NOT NULL,
	category_id int,
	weight_class varchar(15),
	warranty_period date,
	supplier_id int,
	product_status varchar(15),
	list_price decimal NOT NULL,
	min_price decimal NOT NULL,
	catalog_url varchar(50)
);

CREATE TABLE ProductDescriptions(
	product_id int IDENTITY(1,1) PRIMARY KEY,
	language_id char(2),
	translated_name varchar(45) NOT NULL,
	translated_description varchar(100) NOT NULL
);

CREATE TABLE OrderItems(
	order_id int NOT NULL FOREIGN KEY REFERENCES Orders(order_id),
	line_item_id int,
	product_id int NOT NULL FOREIGN KEY REFERENCES ProductInformation(product_id),
	unit_price decimal NOT NULL,
	quantity decimal NOT NULL,
	CONSTRAINT PK_OrderItems PRIMARY KEY (order_id, product_id)
);

CREATE TABLE Inventories(
	product_id int NOT NULL FOREIGN KEY REFERENCES ProductInformation(product_id),
	warehouse_id int NOT NULL FOREIGN KEY REFERENCES Warehouses(warehouse_id),
	quantity_on_hand decimal NOT NULL,
	CONSTRAINT PK_Inventories PRIMARY KEY (product_id, warehouse_id) 
);