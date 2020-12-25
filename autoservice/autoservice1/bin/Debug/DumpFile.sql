--
-- PostgreSQL database dump
--

-- Dumped from database version 12.1
-- Dumped by pg_dump version 12.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: hbox(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.hbox() RETURNS trigger
    LANGUAGE plpgsql
    AS $$ 
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
$$;


ALTER FUNCTION public.hbox() OWNER TO postgres;

--
-- Name: hclient(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.hclient() RETURNS trigger
    LANGUAGE plpgsql
    AS $$ 
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
$$;


ALTER FUNCTION public.hclient() OWNER TO postgres;

--
-- Name: hdetail(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.hdetail() RETURNS trigger
    LANGUAGE plpgsql
    AS $$ 
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
$$;


ALTER FUNCTION public.hdetail() OWNER TO postgres;

--
-- Name: hemployee(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.hemployee() RETURNS trigger
    LANGUAGE plpgsql
    AS $$ 
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
$$;


ALTER FUNCTION public.hemployee() OWNER TO postgres;

--
-- Name: hlist_of_services(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.hlist_of_services() RETURNS trigger
    LANGUAGE plpgsql
    AS $$ 
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
$$;


ALTER FUNCTION public.hlist_of_services() OWNER TO postgres;

--
-- Name: hlocation(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.hlocation() RETURNS trigger
    LANGUAGE plpgsql
    AS $$ 
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
$$;


ALTER FUNCTION public.hlocation() OWNER TO postgres;

--
-- Name: horder_outfit(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.horder_outfit() RETURNS trigger
    LANGUAGE plpgsql
    AS $$ 
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
$$;


ALTER FUNCTION public.horder_outfit() OWNER TO postgres;

--
-- Name: hparts_sheet(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.hparts_sheet() RETURNS trigger
    LANGUAGE plpgsql
    AS $$ 
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
$$;


ALTER FUNCTION public.hparts_sheet() OWNER TO postgres;

--
-- Name: hperson(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.hperson() RETURNS trigger
    LANGUAGE plpgsql
    AS $$ 
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
$$;


ALTER FUNCTION public.hperson() OWNER TO postgres;

--
-- Name: hvehicle(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.hvehicle() RETURNS trigger
    LANGUAGE plpgsql
    AS $$ 
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
$$;


ALTER FUNCTION public.hvehicle() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: box; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.box (
    id integer NOT NULL,
    title character varying(30),
    stat integer
);


ALTER TABLE public.box OWNER TO postgres;

--
-- Name: box_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.box_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.box_id_seq OWNER TO postgres;

--
-- Name: box_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.box_id_seq OWNED BY public.box.id;


--
-- Name: client; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.client (
    id integer NOT NULL,
    id_person integer
);


ALTER TABLE public.client OWNER TO postgres;

--
-- Name: client_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.client_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.client_id_seq OWNER TO postgres;

--
-- Name: client_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.client_id_seq OWNED BY public.client.id;


--
-- Name: detail; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.detail (
    id integer NOT NULL,
    catalogue character varying(30),
    manufacturer character varying(30),
    type character varying(100),
    coast integer
);


ALTER TABLE public.detail OWNER TO postgres;

--
-- Name: detail_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.detail_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.detail_id_seq OWNER TO postgres;

--
-- Name: detail_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.detail_id_seq OWNED BY public.detail.id;


--
-- Name: employee; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employee (
    id integer NOT NULL,
    id_person integer,
    specialty character varying(50)
);


ALTER TABLE public.employee OWNER TO postgres;

--
-- Name: employee_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.employee_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.employee_id_seq OWNER TO postgres;

--
-- Name: employee_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.employee_id_seq OWNED BY public.employee.id;


--
-- Name: hbox; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hbox (
    id_ integer NOT NULL,
    id integer,
    title character varying(30),
    stat integer,
    type_h integer
);


ALTER TABLE public.hbox OWNER TO postgres;

--
-- Name: hbox_id__seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hbox_id__seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hbox_id__seq OWNER TO postgres;

--
-- Name: hbox_id__seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hbox_id__seq OWNED BY public.hbox.id_;


--
-- Name: hclient; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hclient (
    id_ integer NOT NULL,
    id integer,
    id_person integer,
    type_h integer
);


ALTER TABLE public.hclient OWNER TO postgres;

--
-- Name: hclient_id__seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hclient_id__seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hclient_id__seq OWNER TO postgres;

--
-- Name: hclient_id__seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hclient_id__seq OWNED BY public.hclient.id_;


--
-- Name: hdetail; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hdetail (
    id_ integer NOT NULL,
    id integer,
    catalogue character varying(30),
    manufacturer character varying(30),
    type character varying(100),
    coast integer,
    type_h integer
);


ALTER TABLE public.hdetail OWNER TO postgres;

--
-- Name: hdetail_id__seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hdetail_id__seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hdetail_id__seq OWNER TO postgres;

--
-- Name: hdetail_id__seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hdetail_id__seq OWNED BY public.hdetail.id_;


--
-- Name: hemployee; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hemployee (
    id_ integer NOT NULL,
    id integer,
    id_person integer,
    specialty character varying(50),
    type_h integer
);


ALTER TABLE public.hemployee OWNER TO postgres;

--
-- Name: hemployee_id__seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hemployee_id__seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hemployee_id__seq OWNER TO postgres;

--
-- Name: hemployee_id__seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hemployee_id__seq OWNED BY public.hemployee.id_;


--
-- Name: history; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.history (
    id integer NOT NULL,
    table_h character varying(30),
    date timestamp without time zone
);


ALTER TABLE public.history OWNER TO postgres;

--
-- Name: history_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.history_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.history_id_seq OWNER TO postgres;

--
-- Name: history_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.history_id_seq OWNED BY public.history.id;


--
-- Name: hlist_of_services; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hlist_of_services (
    id_ integer NOT NULL,
    id integer,
    name_of_work character varying(50),
    id_order_outfit integer,
    type_h integer
);


ALTER TABLE public.hlist_of_services OWNER TO postgres;

--
-- Name: hlist_of_services_id__seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hlist_of_services_id__seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hlist_of_services_id__seq OWNER TO postgres;

--
-- Name: hlist_of_services_id__seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hlist_of_services_id__seq OWNED BY public.hlist_of_services.id_;


--
-- Name: hlocation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hlocation (
    id_ integer NOT NULL,
    id integer,
    id_employee integer,
    id_vehicle integer,
    work_time integer,
    datestart date,
    type_h integer
);


ALTER TABLE public.hlocation OWNER TO postgres;

--
-- Name: hlocation_id__seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hlocation_id__seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hlocation_id__seq OWNER TO postgres;

--
-- Name: hlocation_id__seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hlocation_id__seq OWNED BY public.hlocation.id_;


--
-- Name: horder_outfit; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.horder_outfit (
    id_ integer NOT NULL,
    id integer,
    datereceipt date,
    dateexpiration date,
    cost integer,
    id_client integer,
    id_vehicle integer,
    type_h integer
);


ALTER TABLE public.horder_outfit OWNER TO postgres;

--
-- Name: horder_outfit_id__seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.horder_outfit_id__seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.horder_outfit_id__seq OWNER TO postgres;

--
-- Name: horder_outfit_id__seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.horder_outfit_id__seq OWNED BY public.horder_outfit.id_;


--
-- Name: hparts_sheet; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hparts_sheet (
    id_ integer NOT NULL,
    id integer,
    id_detail integer,
    id_order_outfit integer,
    type_h integer
);


ALTER TABLE public.hparts_sheet OWNER TO postgres;

--
-- Name: hparts_sheet_id__seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hparts_sheet_id__seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hparts_sheet_id__seq OWNER TO postgres;

--
-- Name: hparts_sheet_id__seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hparts_sheet_id__seq OWNED BY public.hparts_sheet.id_;


--
-- Name: hperson; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hperson (
    id_ integer NOT NULL,
    id integer,
    name character varying(30),
    surname character varying(30),
    patronymic character varying(30),
    gender character varying(10),
    datebirth date,
    telephone character varying(20),
    addres character varying(200),
    type_h integer
);


ALTER TABLE public.hperson OWNER TO postgres;

--
-- Name: hperson_id__seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hperson_id__seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hperson_id__seq OWNER TO postgres;

--
-- Name: hperson_id__seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hperson_id__seq OWNED BY public.hperson.id_;


--
-- Name: hvehicle; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hvehicle (
    id_ integer NOT NULL,
    id integer,
    brand character varying(30),
    model character varying(30),
    year integer,
    vin character varying(20),
    state_number character varying(10),
    id_client integer,
    type_h integer
);


ALTER TABLE public.hvehicle OWNER TO postgres;

--
-- Name: hvehicle_id__seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hvehicle_id__seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hvehicle_id__seq OWNER TO postgres;

--
-- Name: hvehicle_id__seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hvehicle_id__seq OWNED BY public.hvehicle.id_;


--
-- Name: list_of_services; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.list_of_services (
    id integer NOT NULL,
    name_of_work character varying(50),
    id_order_outfit integer
);


ALTER TABLE public.list_of_services OWNER TO postgres;

--
-- Name: list_of_services_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.list_of_services_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.list_of_services_id_seq OWNER TO postgres;

--
-- Name: list_of_services_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.list_of_services_id_seq OWNED BY public.list_of_services.id;


--
-- Name: location; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.location (
    id integer NOT NULL,
    id_employee integer,
    id_vehicle integer,
    work_time integer,
    datestart date
);


ALTER TABLE public.location OWNER TO postgres;

--
-- Name: location_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.location_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.location_id_seq OWNER TO postgres;

--
-- Name: location_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.location_id_seq OWNED BY public.location.id;


--
-- Name: order_outfit; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.order_outfit (
    id integer NOT NULL,
    datereceipt date,
    dateexpiration date,
    cost integer,
    id_client integer,
    id_vehicle integer
);


ALTER TABLE public.order_outfit OWNER TO postgres;

--
-- Name: order_outfit_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.order_outfit_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.order_outfit_id_seq OWNER TO postgres;

--
-- Name: order_outfit_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.order_outfit_id_seq OWNED BY public.order_outfit.id;


--
-- Name: parts_sheet; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.parts_sheet (
    id integer NOT NULL,
    id_detail integer,
    id_order_outfit integer
);


ALTER TABLE public.parts_sheet OWNER TO postgres;

--
-- Name: parts_sheet_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.parts_sheet_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.parts_sheet_id_seq OWNER TO postgres;

--
-- Name: parts_sheet_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.parts_sheet_id_seq OWNED BY public.parts_sheet.id;


--
-- Name: person; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.person (
    id integer NOT NULL,
    name character varying(30),
    surname character varying(30),
    patronymic character varying(30),
    gender character varying(10),
    datebirth date,
    telephone character varying(20),
    addres character varying(200)
);


ALTER TABLE public.person OWNER TO postgres;

--
-- Name: person_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.person_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.person_id_seq OWNER TO postgres;

--
-- Name: person_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.person_id_seq OWNED BY public.person.id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id integer NOT NULL,
    id_employee integer,
    password character varying(50)
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_id_seq OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- Name: vehicle; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.vehicle (
    id integer NOT NULL,
    brand character varying(30),
    model character varying(30),
    year integer,
    vin character varying(20),
    state_number character varying(10),
    id_client integer
);


ALTER TABLE public.vehicle OWNER TO postgres;

--
-- Name: vehicle_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.vehicle_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.vehicle_id_seq OWNER TO postgres;

--
-- Name: vehicle_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.vehicle_id_seq OWNED BY public.vehicle.id;


--
-- Name: box id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.box ALTER COLUMN id SET DEFAULT nextval('public.box_id_seq'::regclass);


--
-- Name: client id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client ALTER COLUMN id SET DEFAULT nextval('public.client_id_seq'::regclass);


--
-- Name: detail id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail ALTER COLUMN id SET DEFAULT nextval('public.detail_id_seq'::regclass);


--
-- Name: employee id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employee ALTER COLUMN id SET DEFAULT nextval('public.employee_id_seq'::regclass);


--
-- Name: hbox id_; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hbox ALTER COLUMN id_ SET DEFAULT nextval('public.hbox_id__seq'::regclass);


--
-- Name: hclient id_; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hclient ALTER COLUMN id_ SET DEFAULT nextval('public.hclient_id__seq'::regclass);


--
-- Name: hdetail id_; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hdetail ALTER COLUMN id_ SET DEFAULT nextval('public.hdetail_id__seq'::regclass);


--
-- Name: hemployee id_; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hemployee ALTER COLUMN id_ SET DEFAULT nextval('public.hemployee_id__seq'::regclass);


--
-- Name: history id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.history ALTER COLUMN id SET DEFAULT nextval('public.history_id_seq'::regclass);


--
-- Name: hlist_of_services id_; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hlist_of_services ALTER COLUMN id_ SET DEFAULT nextval('public.hlist_of_services_id__seq'::regclass);


--
-- Name: hlocation id_; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hlocation ALTER COLUMN id_ SET DEFAULT nextval('public.hlocation_id__seq'::regclass);


--
-- Name: horder_outfit id_; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.horder_outfit ALTER COLUMN id_ SET DEFAULT nextval('public.horder_outfit_id__seq'::regclass);


--
-- Name: hparts_sheet id_; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hparts_sheet ALTER COLUMN id_ SET DEFAULT nextval('public.hparts_sheet_id__seq'::regclass);


--
-- Name: hperson id_; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hperson ALTER COLUMN id_ SET DEFAULT nextval('public.hperson_id__seq'::regclass);


--
-- Name: hvehicle id_; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hvehicle ALTER COLUMN id_ SET DEFAULT nextval('public.hvehicle_id__seq'::regclass);


--
-- Name: list_of_services id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.list_of_services ALTER COLUMN id SET DEFAULT nextval('public.list_of_services_id_seq'::regclass);


--
-- Name: location id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location ALTER COLUMN id SET DEFAULT nextval('public.location_id_seq'::regclass);


--
-- Name: order_outfit id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_outfit ALTER COLUMN id SET DEFAULT nextval('public.order_outfit_id_seq'::regclass);


--
-- Name: parts_sheet id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.parts_sheet ALTER COLUMN id SET DEFAULT nextval('public.parts_sheet_id_seq'::regclass);


--
-- Name: person id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.person ALTER COLUMN id SET DEFAULT nextval('public.person_id_seq'::regclass);


--
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- Name: vehicle id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vehicle ALTER COLUMN id SET DEFAULT nextval('public.vehicle_id_seq'::regclass);


--
-- Data for Name: box; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.box (id, title, stat) FROM stdin;
1	Стоянка 1	\N
2	Стоянка 2	\N
3	Покрасочная	\N
4	Стапель	\N
5	Моторный	\N
6	Стенд сход-развал	\N
7	Подъемник 1	\N
8	Подъемник 2	\N
\.


--
-- Data for Name: client; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.client (id, id_person) FROM stdin;
1	9
2	10
3	11
5	13
4	12
\.


--
-- Data for Name: detail; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.detail (id, catalogue, manufacturer, type, coast) FROM stdin;
1	56059500	AJUSA	Прокладка крышки головки цилиндров	1200
2	8EA012528041	HELLA	Стартер	7800
3	334341	KAYABA	Амортизатор задний	5450
4	DCN02007	DENSO	Радиатор кондиционера	11300
5	TKF3211	SCT	Воздушный фильтр	347
\.


--
-- Data for Name: employee; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employee (id, id_person, specialty) FROM stdin;
1	1	Специалист по ремонту ходовой.
2	2	Диагност-приемщик
3	3	Электрик
4	4	Кузовщик-жестяншик
5	5	Автомаляр
6	6	Моторист
7	7	Зав.склад
8	8	Директор
\.


--
-- Data for Name: hbox; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hbox (id_, id, title, stat, type_h) FROM stdin;
1	1	\N	\N	1
2	2	\N	\N	1
3	3	\N	\N	1
4	4	\N	\N	1
5	5	\N	\N	1
6	6	\N	\N	1
7	7	\N	\N	1
8	8	\N	\N	1
\.


--
-- Data for Name: hclient; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hclient (id_, id, id_person, type_h) FROM stdin;
1	1	\N	1
2	2	\N	1
3	3	\N	1
4	4	\N	1
5	5	\N	1
\.


--
-- Data for Name: hdetail; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hdetail (id_, id, catalogue, manufacturer, type, coast, type_h) FROM stdin;
1	1	\N	\N	\N	\N	1
2	2	\N	\N	\N	\N	1
3	3	\N	\N	\N	\N	1
4	4	\N	\N	\N	\N	1
5	5	\N	\N	\N	\N	1
\.


--
-- Data for Name: hemployee; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hemployee (id_, id, id_person, specialty, type_h) FROM stdin;
1	1	\N	\N	1
2	2	\N	\N	1
3	3	\N	\N	1
4	4	\N	\N	1
5	5	\N	\N	1
6	6	\N	\N	1
7	7	\N	\N	1
8	8	\N	\N	1
\.


--
-- Data for Name: history; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.history (id, table_h, date) FROM stdin;
51	BASE	2020-01-27 00:00:00
\.


--
-- Data for Name: hlist_of_services; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hlist_of_services (id_, id, name_of_work, id_order_outfit, type_h) FROM stdin;
\.


--
-- Data for Name: hlocation; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hlocation (id_, id, id_employee, id_vehicle, work_time, datestart, type_h) FROM stdin;
\.


--
-- Data for Name: horder_outfit; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.horder_outfit (id_, id, datereceipt, dateexpiration, cost, id_client, id_vehicle, type_h) FROM stdin;
1	1	\N	\N	\N	\N	\N	1
2	2	\N	\N	\N	\N	\N	1
3	3	\N	\N	\N	\N	\N	1
4	4	\N	\N	\N	\N	\N	1
5	5	\N	\N	\N	\N	\N	1
\.


--
-- Data for Name: hparts_sheet; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hparts_sheet (id_, id, id_detail, id_order_outfit, type_h) FROM stdin;
\.


--
-- Data for Name: hperson; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hperson (id_, id, name, surname, patronymic, gender, datebirth, telephone, addres, type_h) FROM stdin;
1	1	\N	\N	\N	\N	\N	\N	\N	1
2	2	\N	\N	\N	\N	\N	\N	\N	1
3	3	\N	\N	\N	\N	\N	\N	\N	1
4	4	\N	\N	\N	\N	\N	\N	\N	1
5	5	\N	\N	\N	\N	\N	\N	\N	1
6	6	\N	\N	\N	\N	\N	\N	\N	1
7	7	\N	\N	\N	\N	\N	\N	\N	1
8	8	\N	\N	\N	\N	\N	\N	\N	1
9	9	\N	\N	\N	\N	\N	\N	\N	1
10	10	\N	\N	\N	\N	\N	\N	\N	1
11	11	\N	\N	\N	\N	\N	\N	\N	1
12	12	\N	\N	\N	\N	\N	\N	\N	1
13	13	\N	\N	\N	\N	\N	\N	\N	1
\.


--
-- Data for Name: hvehicle; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hvehicle (id_, id, brand, model, year, vin, state_number, id_client, type_h) FROM stdin;
1	1	\N	\N	\N	\N	\N	\N	1
2	2	\N	\N	\N	\N	\N	\N	1
3	3	\N	\N	\N	\N	\N	\N	1
4	4	\N	\N	\N	\N	\N	\N	1
5	5	\N	\N	\N	\N	\N	\N	1
\.


--
-- Data for Name: list_of_services; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.list_of_services (id, name_of_work, id_order_outfit) FROM stdin;
\.


--
-- Data for Name: location; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.location (id, id_employee, id_vehicle, work_time, datestart) FROM stdin;
\.


--
-- Data for Name: order_outfit; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.order_outfit (id, datereceipt, dateexpiration, cost, id_client, id_vehicle) FROM stdin;
3	2019-09-17	2019-09-17	1000	1	1
1	2019-09-22	2019-09-24	2500	2	2
2	2019-09-19	2019-09-20	2000	3	3
4	2019-09-20	2019-09-21	4500	5	5
5	2019-09-19	2019-09-19	800	4	4
\.


--
-- Data for Name: parts_sheet; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.parts_sheet (id, id_detail, id_order_outfit) FROM stdin;
\.


--
-- Data for Name: person; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.person (id, name, surname, patronymic, gender, datebirth, telephone, addres) FROM stdin;
1	Егор	Симонов	Витальевич	Мужской	1988-10-18	+7(928)-553-13-31	г. Ростов-на-Дону, пер. Университетский 14, кв 17.
2	Вано	Авасян	Арамович	Мужской	1984-01-27	+7(988)-651-99-01	г. Батайск ул. Главная 17 кв.6
3	Александр	Петров	Евгеньевич	Мужской	1993-12-02	+7(989)-543-19-00	г. Ростов-на-Дону ул.Социалистическая 47, кв. 9.
4	Никита	Иванов	Семенович	Мужской	1991-08-13	+7(965)-111-57-16	г.Ростов-на-Дону ул. Шолохова 4,кв.7
5	Андрей	Краевой	Петрович	Мужской	1987-09-22	+7(928)-135-33-55	г. Аксай пр. Октября 94 кв 9
6	Павел	Новацкий	Сергеевич	Мужской	1979-02-13	+7(999)-763-30-87	г. Аксай, пер. Школьный 98
7	Анатолий	Анчинко	Геннадьевич	Мужской	1970-08-15	+7(999)-178-80-16	г. Шахты ул. Ленина 165, кв. 1
8	Роман	Шевченко	Сергеевич	Мужской	1977-01-23	+7(987)-133-89-89	г. Ростов-на-Дону ул. Шаумяна 147, кв 8.
9	Валерий	Киров	Владимирович	Мужской	1997-05-01	+7(987)-190-65-41	\N
10	Анна	Клинова	Александровна	Женский	1981-12-02	+7(999)-165-09-09	\N
11	Евгений	Самаров	Артемович	Мужской	1979-11-08	+7(986)-190-88-88	\N
13	Илья	Стругин	Сергеевич	Мужской	1998-03-08	+7(991)-761-03-00	\N
12	Семен	Маркелов	Олегович	Мужской	1991-09-09	+7(965)-765-32-55	\N
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, id_employee, password) FROM stdin;
1	2	qwerty
2	8	director
3	7	sclad
4	1	qwerty1
5	3	qwerty1
6	4	qwerty1
7	5	qwerty1
8	6	qwerty1
\.


--
-- Data for Name: vehicle; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.vehicle (id, brand, model, year, vin, state_number, id_client) FROM stdin;
1	BMW	180i	2009	Z9873K983PNM331	Е188ЕВ 61	1
2	Toyota	Camry	2001	T898EDKL0981NCD	О881СА 161	2
3	Lada	21124	2007	U763XYW2391MLO	У431ВВ 61	3
5	Volkswagen	Passat	2008	KI3GGD003SNDAPP	С247ЕТ 161	5
4	Volkswagen	Touareg	2012	KI3SAD883SNDAPP	Р763ТЕ 777	4
\.


--
-- Name: box_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.box_id_seq', 8, true);


--
-- Name: client_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.client_id_seq', 5, true);


--
-- Name: detail_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.detail_id_seq', 5, true);


--
-- Name: employee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employee_id_seq', 8, true);


--
-- Name: hbox_id__seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hbox_id__seq', 8, true);


--
-- Name: hclient_id__seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hclient_id__seq', 17, true);


--
-- Name: hdetail_id__seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hdetail_id__seq', 5, true);


--
-- Name: hemployee_id__seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hemployee_id__seq', 8, true);


--
-- Name: history_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.history_id_seq', 99, true);


--
-- Name: hlist_of_services_id__seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hlist_of_services_id__seq', 1, false);


--
-- Name: hlocation_id__seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hlocation_id__seq', 1, false);


--
-- Name: horder_outfit_id__seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.horder_outfit_id__seq', 17, true);


--
-- Name: hparts_sheet_id__seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hparts_sheet_id__seq', 1, false);


--
-- Name: hperson_id__seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hperson_id__seq', 25, true);


--
-- Name: hvehicle_id__seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hvehicle_id__seq', 17, true);


--
-- Name: list_of_services_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.list_of_services_id_seq', 1, false);


--
-- Name: location_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.location_id_seq', 1, false);


--
-- Name: order_outfit_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.order_outfit_id_seq', 5, true);


--
-- Name: parts_sheet_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.parts_sheet_id_seq', 1, false);


--
-- Name: person_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.person_id_seq', 13, true);


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 8, true);


--
-- Name: vehicle_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.vehicle_id_seq', 5, true);


--
-- Name: box box_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.box
    ADD CONSTRAINT box_pkey PRIMARY KEY (id);


--
-- Name: client client_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_pkey PRIMARY KEY (id);


--
-- Name: detail detail_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail
    ADD CONSTRAINT detail_pkey PRIMARY KEY (id);


--
-- Name: employee employee_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_pkey PRIMARY KEY (id);


--
-- Name: hbox hbox_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hbox
    ADD CONSTRAINT hbox_pkey PRIMARY KEY (id_);


--
-- Name: hclient hclient_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hclient
    ADD CONSTRAINT hclient_pkey PRIMARY KEY (id_);


--
-- Name: hdetail hdetail_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hdetail
    ADD CONSTRAINT hdetail_pkey PRIMARY KEY (id_);


--
-- Name: hemployee hemployee_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hemployee
    ADD CONSTRAINT hemployee_pkey PRIMARY KEY (id_);


--
-- Name: history history_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.history
    ADD CONSTRAINT history_pkey PRIMARY KEY (id);


--
-- Name: hlist_of_services hlist_of_services_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hlist_of_services
    ADD CONSTRAINT hlist_of_services_pkey PRIMARY KEY (id_);


--
-- Name: hlocation hlocation_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hlocation
    ADD CONSTRAINT hlocation_pkey PRIMARY KEY (id_);


--
-- Name: horder_outfit horder_outfit_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.horder_outfit
    ADD CONSTRAINT horder_outfit_pkey PRIMARY KEY (id_);


--
-- Name: hparts_sheet hparts_sheet_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hparts_sheet
    ADD CONSTRAINT hparts_sheet_pkey PRIMARY KEY (id_);


--
-- Name: hperson hperson_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hperson
    ADD CONSTRAINT hperson_pkey PRIMARY KEY (id_);


--
-- Name: hvehicle hvehicle_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hvehicle
    ADD CONSTRAINT hvehicle_pkey PRIMARY KEY (id_);


--
-- Name: list_of_services list_of_services_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.list_of_services
    ADD CONSTRAINT list_of_services_pkey PRIMARY KEY (id);


--
-- Name: location location_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location
    ADD CONSTRAINT location_pkey PRIMARY KEY (id);


--
-- Name: order_outfit order_outfit_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_outfit
    ADD CONSTRAINT order_outfit_pkey PRIMARY KEY (id);


--
-- Name: parts_sheet parts_sheet_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.parts_sheet
    ADD CONSTRAINT parts_sheet_pkey PRIMARY KEY (id);


--
-- Name: person person_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.person
    ADD CONSTRAINT person_pkey PRIMARY KEY (id);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- Name: vehicle vehicle_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vehicle
    ADD CONSTRAINT vehicle_pkey PRIMARY KEY (id);


--
-- Name: box hbox; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER hbox BEFORE INSERT OR DELETE OR UPDATE ON public.box FOR EACH ROW EXECUTE FUNCTION public.hbox();


--
-- Name: client hclient; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER hclient BEFORE INSERT OR DELETE OR UPDATE ON public.client FOR EACH ROW EXECUTE FUNCTION public.hclient();


--
-- Name: detail hdetail; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER hdetail BEFORE INSERT OR DELETE OR UPDATE ON public.detail FOR EACH ROW EXECUTE FUNCTION public.hdetail();


--
-- Name: employee hemployee; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER hemployee BEFORE INSERT OR DELETE OR UPDATE ON public.employee FOR EACH ROW EXECUTE FUNCTION public.hemployee();


--
-- Name: list_of_services hlist_of_services; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER hlist_of_services BEFORE INSERT OR DELETE OR UPDATE ON public.list_of_services FOR EACH ROW EXECUTE FUNCTION public.hlist_of_services();


--
-- Name: location hlocation; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER hlocation BEFORE INSERT OR DELETE OR UPDATE ON public.location FOR EACH ROW EXECUTE FUNCTION public.hlocation();


--
-- Name: order_outfit horder_outfit; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER horder_outfit BEFORE INSERT OR DELETE OR UPDATE ON public.order_outfit FOR EACH ROW EXECUTE FUNCTION public.horder_outfit();


--
-- Name: parts_sheet hparts_sheet; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER hparts_sheet BEFORE INSERT OR DELETE OR UPDATE ON public.parts_sheet FOR EACH ROW EXECUTE FUNCTION public.hparts_sheet();


--
-- Name: person hperson; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER hperson BEFORE INSERT OR DELETE OR UPDATE ON public.person FOR EACH ROW EXECUTE FUNCTION public.hperson();


--
-- Name: vehicle hvehicle; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER hvehicle BEFORE INSERT OR DELETE OR UPDATE ON public.vehicle FOR EACH ROW EXECUTE FUNCTION public.hvehicle();


--
-- Name: box box_stat_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.box
    ADD CONSTRAINT box_stat_fkey FOREIGN KEY (stat) REFERENCES public.location(id);


--
-- Name: client client_id_person_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_id_person_fkey FOREIGN KEY (id_person) REFERENCES public.person(id);


--
-- Name: employee employee_id_person_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_id_person_fkey FOREIGN KEY (id_person) REFERENCES public.person(id);


--
-- Name: list_of_services list_of_services_id_order_outfit_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.list_of_services
    ADD CONSTRAINT list_of_services_id_order_outfit_fkey FOREIGN KEY (id_order_outfit) REFERENCES public.order_outfit(id);


--
-- Name: location location_id_employee_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location
    ADD CONSTRAINT location_id_employee_fkey FOREIGN KEY (id_employee) REFERENCES public.employee(id);


--
-- Name: location location_id_vehicle_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location
    ADD CONSTRAINT location_id_vehicle_fkey FOREIGN KEY (id_vehicle) REFERENCES public.vehicle(id);


--
-- Name: order_outfit order_outfit_id_client_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_outfit
    ADD CONSTRAINT order_outfit_id_client_fkey FOREIGN KEY (id_client) REFERENCES public.client(id);


--
-- Name: order_outfit order_outfit_id_vehicle_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_outfit
    ADD CONSTRAINT order_outfit_id_vehicle_fkey FOREIGN KEY (id_vehicle) REFERENCES public.vehicle(id);


--
-- Name: parts_sheet parts_sheet_id_detail_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.parts_sheet
    ADD CONSTRAINT parts_sheet_id_detail_fkey FOREIGN KEY (id_detail) REFERENCES public.detail(id);


--
-- Name: parts_sheet parts_sheet_id_order_outfit_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.parts_sheet
    ADD CONSTRAINT parts_sheet_id_order_outfit_fkey FOREIGN KEY (id_order_outfit) REFERENCES public.order_outfit(id);


--
-- Name: users users_id_employee_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_id_employee_fkey FOREIGN KEY (id_employee) REFERENCES public.employee(id);


--
-- Name: vehicle vehicle_id_client_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vehicle
    ADD CONSTRAINT vehicle_id_client_fkey FOREIGN KEY (id_client) REFERENCES public.client(id);


--
-- PostgreSQL database dump complete
--

