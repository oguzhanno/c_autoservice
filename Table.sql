CREATE TABLE IF NOT EXISTS Person
(
	id serial PRIMARY KEY,
	name VARCHAR(30),
	surname VARCHAR(30),
	patronymic VARCHAR(30),
	gender VARCHAR(10),
	dateBirth DATE,
	telephone VARCHAR(20),
	addres VARCHAR(200)
);

CREATE TABLE IF NOT EXISTS Employee
(
	id serial PRIMARY KEY,
	id_person integer,
	FOREIGN KEY (id_person) REFERENCES Person (id),
	specialty VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS Client
(
	id serial PRIMARY KEY,
	id_person integer,
	FOREIGN KEY (id_person) REFERENCES Person (id)
 );

CREATE TABLE IF NOT EXISTS Vehicle
(
	id serial PRIMARY KEY,
	brand VARCHAR(30),
	model VARCHAR(30),
	year integer,
	vin VARCHAR(20),
	state_number VARCHAR(10),
	id_client integer,
	FOREIGN KEY (id_client) REFERENCES Client (id)
);

CREATE TABLE IF NOT EXISTS Order_outfit
(
	id serial PRIMARY KEY,
	dateReceipt DATE,
	dateExpiration DATE,
	cost integer,
	id_client integer,
	id_vehicle integer,
	FOREIGN KEY (id_client) REFERENCES Client (id),
	FOREIGN KEY (id_vehicle) REFERENCES Vehicle (id)
);

CREATE TABLE IF NOT EXISTS List_of_services
(
	id serial PRIMARY KEY,
	name_of_work VARCHAR(50),
	id_order_outfit integer,
	FOREIGN KEY (id_order_outfit) REFERENCES Order_outfit (id)
);


CREATE TABLE IF NOT EXISTS Detail
(
	id serial PRIMARY KEY,
	catalogue VARCHAR(30),
	manufacturer VARCHAR(30),
	type VARCHAR(100),
	coast integer
);

CREATE TABLE IF NOT EXISTS Parts_sheet
(
	id serial PRIMARY KEY,
	id_detail integer,
	id_order_outfit integer,
	FOREIGN KEY (id_order_outfit) REFERENCES Order_outfit (id),
	FOREIGN KEY (id_detail) REFERENCES Detail (id)
);

CREATE TABLE IF NOT EXISTS Location
(
	id serial PRIMARY KEY,
	id_employee integer,
	id_vehicle integer,
	FOREIGN KEY (id_employee) REFERENCES Employee (id),
	FOREIGN KEY (id_vehicle) REFERENCES Vehicle (id),
	work_time integer,
	dateStart DATE
);

CREATE TABLE IF NOT EXISTS Box
(
	id serial PRIMARY KEY,
	title VARCHAR(30),
	stat integer,
	FOREIGN KEY (stat) REFERENCES Location (id)
);


CREATE TABLE IF NOT EXISTS Users
(
    id serial PRIMARY KEY,
    id_employee integer,
    password VARCHAR(50),
    FOREIGN KEY (id_employee) REFERENCES Employee (id)
);

CREATE TABLE IF NOT EXISTS history (
  id SERIAL,
  table_h VARCHAR(30),
  date TIMESTAMP,
 PRIMARY KEY (id)
); 

CREATE TABLE IF NOT EXISTS hperson (
id_ SERIAL,
id integer,
name VARCHAR(30),
surname VARCHAR(30),
patronymic VARCHAR(30),
gender VARCHAR(10),
dateBirth DATE,
telephone VARCHAR(20),
addres VARCHAR(200),
type_h integer,
PRIMARY KEY (id_)
);

CREATE OR REPLACE FUNCTION hperson()
        RETURNS TRIGGER AS $hperson$ 
		DECLARE
		tt integer;
BEGIN
	IF TG_OP = 'INSERT' THEN
	tt = 1;
	INSERT INTO hperson(id, type_h) VALUES (NEW.id, tt);
    INSERT INTO history(table_h, date) VALUES('person', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'UPDATE' THEN
	tt = 2;
	INSERT INTO hperson(id, name, surname, patronymic, gender, dateBirth, telephone, addres, type_h) VALUES (OLD.id, OLD.name, OLD.surname, OLD.patronymic, OLD.gender, OLD.dateBirth, OLD.telephone, OLD.addres, tt);
	INSERT INTO history(table_h, date) VALUES('person', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'DELETE' THEN
	tt = 3;
	INSERT INTO hperson(id, name, surname, patronymic, gender, dateBirth, telephone, addres, type_h) VALUES (OLD.id, OLD.name, OLD.surname, OLD.patronymic, OLD.gender, OLD.dateBirth, OLD.telephone, OLD.addres, tt);
	INSERT INTO history(table_h, date) VALUES('person', current_timestamp);
	RETURN OLD;
	END IF;
END;
$hperson$  LANGUAGE plpgsql;

CREATE TRIGGER hperson 
BEFORE INSERT OR UPDATE OR DELETE ON person 
FOR EACH ROW 
EXECUTE PROCEDURE hperson ();

CREATE TABLE IF NOT EXISTS hclient (
id_ SERIAL,
id integer,
id_person integer,
type_h integer,
PRIMARY KEY (id_)
);

CREATE OR REPLACE FUNCTION hclient()
        RETURNS TRIGGER AS $hclient$ 
		DECLARE
		tt integer;
BEGIN
	IF TG_OP = 'INSERT' THEN
	tt = 1;
	INSERT INTO hclient(id, type_h) VALUES (NEW.id, tt);
    INSERT INTO history(table_h, date) VALUES('client', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'UPDATE' THEN
	tt = 2;
	INSERT INTO hclient(id,id_person, type_h ) VALUES (OLD.id, OLD.id_person, tt);
	INSERT INTO history(table_h, date) VALUES('client', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'DELETE' THEN
	tt = 3;
	INSERT INTO hclient(id,id_person, type_h ) VALUES (OLD.id, OLD.id_person, tt);
	INSERT INTO history(table_h, date) VALUES('client', current_timestamp);
	RETURN OLD;
	END IF;
END;
$hclient$  LANGUAGE plpgsql;

CREATE TRIGGER hclient
BEFORE INSERT OR UPDATE OR DELETE ON client 
FOR EACH ROW 
EXECUTE PROCEDURE hclient ();

CREATE TABLE IF NOT EXISTS hemployee (
id_ SERIAL,
id integer,
id_person integer,
specialty  VARCHAR(50),
type_h integer,
PRIMARY KEY (id_)
);

CREATE OR REPLACE FUNCTION hemployee()
        RETURNS TRIGGER AS $hemployee$ 
		DECLARE
		tt integer;
BEGIN
	IF TG_OP = 'INSERT' THEN
	tt = 1;
	INSERT INTO hemployee(id, type_h) VALUES (NEW.id, tt);
    INSERT INTO history(table_h, date) VALUES('employee', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'UPDATE' THEN
	tt = 2;
	INSERT INTO hemployee(id,id_person, specialty, type_h ) VALUES (OLD.id, OLD.id_person, OLD.specialty , tt);
	INSERT INTO history(table_h, date) VALUES('employee', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'DELETE' THEN
	tt = 3;
	INSERT INTO hemployee(id,id_person, specialty, type_h ) VALUES (OLD.id, OLD.id_person, OLD.specialty , tt);
	INSERT INTO history(table_h, date) VALUES('employee', current_timestamp);
	RETURN OLD;
	END IF;
END;
$hemployee$  LANGUAGE plpgsql;

CREATE TRIGGER hemployee
BEFORE INSERT OR UPDATE OR DELETE ON employee 
FOR EACH ROW 
EXECUTE PROCEDURE hemployee ();

CREATE TABLE IF NOT EXISTS hvehicle (
id_ SERIAL,
id integer,
brand VARCHAR(30),
model VARCHAR(30),
year integer,
vin VARCHAR(20),
state_number VARCHAR(10),
id_client integer,
type_h integer,
PRIMARY KEY (id_)
);

CREATE OR REPLACE FUNCTION hvehicle()
        RETURNS TRIGGER AS $hvehicle$ 
		DECLARE
		tt integer;
BEGIN
	IF TG_OP = 'INSERT' THEN
	tt = 1;
	INSERT INTO hvehicle(id, type_h) VALUES (NEW.id, tt);
    INSERT INTO history(table_h, date) VALUES('vehicle', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'UPDATE' THEN
	tt = 2;
	INSERT INTO hvehicle(id,brand,model,year,vin,state_number,id_client,type_h ) VALUES (OLD.id,OLD.brand,OLD.model,OLD.year,OLD.vin,OLD.state_number,OLD.id_client, tt);
	INSERT INTO history(table_h, date) VALUES('vehicle', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'DELETE' THEN
	tt = 3;
	INSERT INTO hvehicle(id,brand,model,year,vin,state_number,id_client,type_h ) VALUES (OLD.id,OLD.brand,OLD.model,OLD.year,OLD.vin,OLD.state_number,OLD.id_client, tt);
	INSERT INTO history(table_h, date) VALUES('vehicle', current_timestamp);
	RETURN OLD;
	END IF;
END;
$hvehicle$  LANGUAGE plpgsql;

CREATE TRIGGER hvehicle
BEFORE INSERT OR UPDATE OR DELETE ON vehicle
FOR EACH ROW 
EXECUTE PROCEDURE hvehicle ();

CREATE TABLE IF NOT EXISTS hlist_of_services (
id_ SERIAL,
id integer,
name_of_work VARCHAR(50),
id_order_outfit integer,
type_h integer,
PRIMARY KEY (id_)
);

CREATE OR REPLACE FUNCTION hlist_of_services()
        RETURNS TRIGGER AS $hlist_of_services$ 
		DECLARE
		tt integer;
BEGIN
	IF TG_OP = 'INSERT' THEN
	tt = 1;
	INSERT INTO hlist_of_services(id, type_h) VALUES (NEW.id, tt);
    INSERT INTO history(table_h, date) VALUES('list_of_services', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'UPDATE' THEN
	tt = 2;
	INSERT INTO hlist_of_services(id, name_of_work, id_order_outfit, type_h) VALUES (OLD.id, OLD.name_of_work, OLD.id_order_outfit, tt);
	INSERT INTO history(table_h, date) VALUES('list_of_services', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'DELETE' THEN
	tt = 3;
	INSERT INTO hlist_of_services(id, name_of_work, id_order_outfit, type_h) VALUES (OLD.id, OLD.name_of_work, OLD.id_order_outfit, tt);
	INSERT INTO history(table_h, date) VALUES('list_of_services', current_timestamp);
	RETURN OLD;
	END IF;
END;
$hlist_of_services$  LANGUAGE plpgsql;

CREATE TRIGGER hlist_of_services
BEFORE INSERT OR UPDATE OR DELETE ON list_of_services
FOR EACH ROW 
EXECUTE PROCEDURE hlist_of_services ();

CREATE TABLE IF NOT EXISTS hdetail (
id_ SERIAL,
id integer,
catalogue VARCHAR(30),
manufacturer VARCHAR(30),
type VARCHAR(100),
coast  integer,
type_h integer,
PRIMARY KEY (id_)
);

CREATE OR REPLACE FUNCTION hdetail()
        RETURNS TRIGGER AS $hdetail$ 
		DECLARE
		tt integer;
BEGIN
	IF TG_OP = 'INSERT' THEN
	tt = 1;
	INSERT INTO hdetail(id, type_h) VALUES (NEW.id, tt);
    INSERT INTO history(table_h, date) VALUES('detail', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'UPDATE' THEN
	tt = 2;
	INSERT INTO hdetail(id,catalogue,manufacturer,type,coast,type_h) VALUES (OLD.id,OLD.catalogue,OLD.manufacturer,OLD.type,OLD.coast, tt);
	INSERT INTO history(table_h, date) VALUES('detail', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'DELETE' THEN
	tt = 3;
	INSERT INTO hdetail(id,catalogue,manufacturer,type,coast,type_h) VALUES (OLD.id,OLD.catalogue,OLD.manufacturer,OLD.type,OLD.coast, tt);
	INSERT INTO history(table_h, date) VALUES('detail', current_timestamp);
	RETURN OLD;
	END IF;
END;
$hdetail$  LANGUAGE plpgsql;

CREATE TRIGGER hdetail
BEFORE INSERT OR UPDATE OR DELETE ON detail
FOR EACH ROW 
EXECUTE PROCEDURE hdetail ();

CREATE TABLE IF NOT EXISTS hparts_sheet (
id_ SERIAL,
id integer,
id_detail integer,
id_order_outfit integer,
type_h integer,
PRIMARY KEY (id_)
);

CREATE OR REPLACE FUNCTION hparts_sheet()
        RETURNS TRIGGER AS $hparts_sheet$ 
		DECLARE
		tt integer;
BEGIN
	IF TG_OP = 'INSERT' THEN
	tt = 1;
	INSERT INTO hparts_sheet(id, type_h) VALUES (NEW.id, tt);
    INSERT INTO history(table_h, date) VALUES('parts_sheet', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'UPDATE' THEN
	tt = 2;
	INSERT INTO hparts_sheet(id,id_detail,id_order_outfit,type_h) VALUES (OLD.id, OLD.id_detail, OLD.id_order_outfit , tt);
	INSERT INTO history(table_h, date) VALUES('parts_sheet', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'DELETE' THEN
	tt = 3;
	INSERT INTO hparts_sheet(id,id_detail,id_order_outfit,type_h) VALUES (OLD.id, OLD.id_detail, OLD.id_order_outfit , tt);
	INSERT INTO history(table_h, date) VALUES('parts_sheet', current_timestamp);
	RETURN OLD;
	END IF;
END;
$hparts_sheet$  LANGUAGE plpgsql;

CREATE TRIGGER hparts_sheet
BEFORE INSERT OR UPDATE OR DELETE ON parts_sheet
FOR EACH ROW 
EXECUTE PROCEDURE hparts_sheet ();

CREATE TABLE IF NOT EXISTS horder_outfit (
id_ SERIAL,
id integer,
dateReceipt DATE,
dateExpiration DATE,
cost integer,
id_client integer,
id_vehicle integer,
type_h integer,
PRIMARY KEY (id_)
);

CREATE OR REPLACE FUNCTION horder_outfit()
        RETURNS TRIGGER AS $horder_outfit$ 
		DECLARE
		tt integer;
BEGIN
	IF TG_OP = 'INSERT' THEN
	tt = 1;
	INSERT INTO horder_outfit(id, type_h) VALUES (NEW.id, tt);
    INSERT INTO history(table_h, date) VALUES('order_outfit', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'UPDATE' THEN
	tt = 2;
	INSERT INTO horder_outfit(id, dateReceipt, dateExpiration , cost,id_client, id_vehicle, type_h) VALUES (OLD.id, OLD.dateReceipt, OLD.dateExpiration , OLD.cost,OLD.id_client, OLD.id_vehicle, tt);
	INSERT INTO history(table_h, date) VALUES('order_outfit', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'DELETE' THEN
	tt = 3;
	INSERT INTO horder_outfit(id, dateReceipt, dateExpiration , cost,id_client, id_vehicle, type_h) VALUES (OLD.id, OLD.dateReceipt, OLD.dateExpiration , OLD.cost,OLD.id_client, OLD.id_vehicle, tt);
	INSERT INTO history(table_h, date) VALUES('order_outfit', current_timestamp);
	RETURN OLD;
	END IF;
END;
$horder_outfit$  LANGUAGE plpgsql;

CREATE TRIGGER horder_outfit
BEFORE INSERT OR UPDATE OR DELETE ON order_outfit
FOR EACH ROW 
EXECUTE PROCEDURE horder_outfit ();

CREATE TABLE IF NOT EXISTS hlocation (
id_ SERIAL,
id integer,
id_employee integer,
id_vehicle integer,
work_time integer,
datestart date,
type_h integer,
PRIMARY KEY (id_)
);

CREATE OR REPLACE FUNCTION hlocation()
        RETURNS TRIGGER AS $hlocation$ 
		DECLARE
		tt integer;
BEGIN
	IF TG_OP = 'INSERT' THEN
	tt = 1;
	INSERT INTO hlocation(id, type_h) VALUES (NEW.id, tt);
    INSERT INTO history(table_h, date) VALUES('location', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'UPDATE' THEN
	tt = 2;
	INSERT INTO hlocation(id,id_employee,id_vehicle,work_time,datestart, type_h) VALUES (OLD.id, OLD.id_employee, OLD.id_vehicle, OLD.work_time, OLD.datestart, tt);
	INSERT INTO history(table_h, date) VALUES('location', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'DELETE' THEN
	tt = 3;
	INSERT INTO hlocation(id,id_employee,id_vehicle,work_time,datestart, type_h) VALUES (OLD.id, OLD.id_employee, OLD.id_vehicle, OLD.work_time, OLD.datestart, tt);
	INSERT INTO history(table_h, date) VALUES('location', current_timestamp);
	RETURN OLD;
	END IF;
END;
$hlocation$  LANGUAGE plpgsql;

CREATE TRIGGER hlocation
BEFORE INSERT OR UPDATE OR DELETE ON location
FOR EACH ROW 
EXECUTE PROCEDURE hlocation ();

CREATE TABLE IF NOT EXISTS hbox(
id_ SERIAL,
id integer,
title VARCHAR(30),
stat integer,
type_h integer,
PRIMARY KEY (id_)
);

CREATE OR REPLACE FUNCTION hbox()
        RETURNS TRIGGER AS $hbox$ 
		DECLARE
		tt integer;
BEGIN
	IF TG_OP = 'INSERT' THEN
	tt = 1;
	INSERT INTO hbox(id, type_h) VALUES (NEW.id, tt);
    INSERT INTO history(table_h, date) VALUES('box', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'UPDATE' THEN
	tt = 2;
	INSERT INTO hbox(id,title,stat, type_h) VALUES (OLD.id, OLD.title, OLD.stat, tt);
	INSERT INTO history(table_h, date) VALUES('box', current_timestamp);
	RETURN NEW;
	ELSIF TG_OP = 'DELETE' THEN
	tt = 3;
	INSERT INTO hbox(id,title,stat, type_h) VALUES (OLD.id, OLD.title, OLD.stat, tt);
	INSERT INTO history(table_h, date) VALUES('box', current_timestamp);
	RETURN OLD;
	END IF;
END;
$hbox$  LANGUAGE plpgsql;

CREATE TRIGGER hbox
BEFORE INSERT OR UPDATE OR DELETE ON box
FOR EACH ROW 
EXECUTE PROCEDURE hbox ();


INSERT INTO box (title) VALUES ('Стоянка 1');
INSERT INTO box (title) VALUES ('Стоянка 2');
INSERT INTO box (title) VALUES ('Покрасочная');
INSERT INTO box (title) VALUES ('Стапель');
INSERT INTO box (title) VALUES ('Моторный');
INSERT INTO box (title) VALUES ('Стенд сход-развал');
INSERT INTO box (title) VALUES ('Подъемник 1');
INSERT INTO box (title) VALUES ('Подъемник 2');

INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone, addres) VALUES
('Егор','Симонов','Витальевич','Мужской','1988-10-18','+7(928)-553-13-31','г. Ростов-на-Дону, пер. Университетский 14, кв 17.');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone, addres) VALUES
('Вано','Авасян','Арамович','Мужской','1984-01-27','+7(988)-651-99-01','г. Батайск ул. Главная 17 кв.6');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone, addres) VALUES
('Александр','Петров','Евгеньевич','Мужской','1993-12-02','+7(989)-543-19-00','г. Ростов-на-Дону ул.Социалистическая 47, кв. 9.');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone, addres) VALUES
('Никита','Иванов','Семенович','Мужской','1991-08-13','+7(965)-111-57-16','г.Ростов-на-Дону ул. Шолохова 4,кв.7');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone, addres) VALUES
('Андрей','Краевой','Петрович','Мужской','1987-09-22','+7(928)-135-33-55','г. Аксай пр. Октября 94 кв 9');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone, addres) VALUES
('Павел','Новацкий','Сергеевич','Мужской','1979-02-13','+7(999)-763-30-87','г. Аксай, пер. Школьный 98');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone, addres) VALUES
('Анатолий','Анчинко','Геннадьевич','Мужской','1970-08-15','+7(999)-178-80-16','г. Шахты ул. Ленина 165, кв. 1');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone, addres) VALUES
('Роман','Шевченко','Сергеевич','Мужской','1977-01-23','+7(987)-133-89-89','г. Ростов-на-Дону ул. Шаумяна 147, кв 8.');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone) VALUES
('Валерий','Киров','Владимирович','Мужской','1997-05-01','+7(987)-190-65-41');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone) VALUES
('Анна','Клинова','Александровна','Женский','1981-12-02','+7(999)-165-09-09');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone) VALUES
('Евгений','Самаров','Артемович','Мужской','1979-11-08','+7(986)-190-88-88');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone) VALUES
('Семен','Маркелов','Олегович','Мужской','1991-09-09','+7(965)-765-32-55');
INSERT INTO person (name, surname, patronymic, gender, datebirth, telephone) VALUES
('Илья','Стругин','Сергеевич','Мужской','1998-03-08','+7(991)-761-03-00');

INSERT INTO client (id_person) VALUES ('9');
INSERT INTO client (id_person) VALUES ('10');
INSERT INTO client (id_person) VALUES ('11');
INSERT INTO client (id_person) VALUES ('12');
INSERT INTO client (id_person) VALUES ('13');

INSERT INTO employee (id_person,specialty) VALUES ('1','Специалист по ремонту ходовой.');
INSERT INTO employee (id_person,specialty) VALUES ('2','Диагност-приемщик');
INSERT INTO employee (id_person,specialty) VALUES ('3','Электрик');
INSERT INTO employee (id_person,specialty) VALUES ('4','Кузовщик-жестяншик');
INSERT INTO employee (id_person,specialty) VALUES ('5','Автомаляр');
INSERT INTO employee (id_person,specialty) VALUES ('6','Моторист');
INSERT INTO employee (id_person,specialty) VALUES ('7','Зав.склад');
INSERT INTO employee (id_person,specialty) VALUES ('8','Директор');

INSERT INTO detail (catalogue, manufacturer, type, coast) VALUES
('56059500','AJUSA','Прокладка крышки головки цилиндров','1200');
INSERT INTO detail (catalogue, manufacturer, type, coast) VALUES
('8EA012528041','HELLA','Стартер','7800');
INSERT INTO detail (catalogue, manufacturer, type, coast) VALUES
('334341','KAYABA','Амортизатор задний','5450');
INSERT INTO detail (catalogue, manufacturer, type, coast) VALUES
('DCN02007','DENSO','Радиатор кондиционера','11300');
INSERT INTO detail (catalogue, manufacturer, type, coast) VALUES
('TKF3211','SCT','Воздушный фильтр','347');

INSERT INTO Vehicle (brand, model, year, vin, state_number, id_client) VALUES
('BMW','180i','2009','Z9873K983PNM331','Е188ЕВ 61',	'1');
INSERT INTO Vehicle (brand, model, year, vin, state_number, id_client) VALUES
('Toyota','Camry','2001','T898EDKL0981NCD','О881СА 161','2');
INSERT INTO Vehicle (brand, model, year, vin, state_number, id_client) VALUES
('Lada','21124','2007','U763XYW2391MLO','У431ВВ 61','3');
INSERT INTO Vehicle (brand, model, year, vin, state_number, id_client) VALUES
('Volkswagen','Touareg','2012','KI3SAD883SNDAPP','Р763ТЕ 777','4');
INSERT INTO Vehicle (brand, model, year, vin, state_number, id_client) VALUES
('Volkswagen','Passat','2008','KI3GGD003SNDAPP','С247ЕТ 161','5');

INSERT INTO order_outfit (datereceipt, dateexpiration, cost, id_client, id_vehicle) VALUES
('2019-09-22','2019-09-24','2500','2','2');
INSERT INTO order_outfit (datereceipt, dateexpiration, cost, id_client, id_vehicle) VALUES
('2019-09-19','2019-09-20','2000','3','3');
INSERT INTO order_outfit (datereceipt, dateexpiration, cost, id_client, id_vehicle) VALUES
('2019-09-17','2019-09-17','1000','1','1');
INSERT INTO order_outfit (datereceipt, dateexpiration, cost, id_client, id_vehicle) VALUES
('2019-09-20','2019-09-21','4500','5','5');
INSERT INTO order_outfit (datereceipt, dateexpiration, cost, id_client, id_vehicle) VALUES
('2019-09-19','2019-09-19','800','4','4');

INSERT INTO users (id_employee, password) VALUES ('2','qwerty');
INSERT INTO users (id_employee, password) VALUES ('8','director');
INSERT INTO users (id_employee, password) VALUES ('7','sclad');
INSERT INTO users (id_employee, password) VALUES ('1','qwerty1');
INSERT INTO users (id_employee, password) VALUES ('3','qwerty1');
INSERT INTO users (id_employee, password) VALUES ('4','qwerty1');
INSERT INTO users (id_employee, password) VALUES ('5','qwerty1');
INSERT INTO users (id_employee, password) VALUES ('6','qwerty1');

INSERT INTO history (table_h, date) VALUES ('BASE','27.01.2020');