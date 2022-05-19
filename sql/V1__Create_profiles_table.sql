--
-- PostgreSQL database dump
--

-- Dumped from database version 14.3 (Debian 14.3-1.pgdg110+1)
-- Dumped by pg_dump version 14.2

-- Started on 2022-05-19 06:50:25 UTC

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 210 (class 1259 OID 16392)
-- Name: Profiles; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public."Profiles" (
    "Id" uuid NOT NULL,
    "UserType" integer NOT NULL,
    "Name" text,
    "Description" text,
    "FacebookURL" text,
    "TwitterURL" text,
    "DiscordURL" text,
    "TwitchURL" text,
    "WebsiteURL" text
);


ALTER TABLE public."Profiles" OWNER TO admin;

--
-- TOC entry 3188 (class 2606 OID 16398)
-- Name: Profiles PK_Profiles; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."Profiles"
    ADD CONSTRAINT "PK_Profiles" PRIMARY KEY ("Id");


--
-- TOC entry 3186 (class 1259 OID 16470)
-- Name: IX_Profiles_Name; Type: INDEX; Schema: public; Owner: admin
--

CREATE UNIQUE INDEX "IX_Profiles_Name" ON public."Profiles" USING btree ("Name");


-- Completed on 2022-05-19 06:50:25 UTC

--
-- PostgreSQL database dump complete
--

