--
-- PostgreSQL database dump
--

-- Dumped from database version 17.5
-- Dumped by pg_dump version 17.5

-- Started on 2025-06-13 01:25:43

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 6 (class 2615 OID 16450)
-- Name: outbox; Type: SCHEMA; Schema: -; Owner: nutritionaladvice_user
--

CREATE SCHEMA outbox;


ALTER SCHEMA outbox OWNER TO nutritionaladvice_user;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 221 (class 1259 OID 16465)
-- Name: outboxMessage; Type: TABLE; Schema: outbox; Owner: nutritionaladvice_user
--

CREATE TABLE outbox."outboxMessage" (
    "outboxId" uuid NOT NULL,
    content text,
    type text NOT NULL,
    created timestamp with time zone NOT NULL,
    processed boolean NOT NULL,
    "processedOn" timestamp with time zone,
    "correlationId" text,
    "traceId" text,
    "spanId" text
);


ALTER TABLE outbox."outboxMessage" OWNER TO nutritionaladvice_user;

--
-- TOC entry 218 (class 1259 OID 16445)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: nutritionaladvice_user
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO nutritionaladvice_user;

--
-- TOC entry 219 (class 1259 OID 16451)
-- Name: ingredient; Type: TABLE; Schema: public; Owner: nutritionaladvice_user
--

CREATE TABLE public.ingredient (
    "Id" uuid NOT NULL,
    "Name" character varying(250) NOT NULL,
    "Variety" character varying(100),
    "Benefits" character varying(500),
    "DishCategory" character varying(100)
);


ALTER TABLE public.ingredient OWNER TO nutritionaladvice_user;

--
-- TOC entry 220 (class 1259 OID 16458)
-- Name: mealplan; Type: TABLE; Schema: public; Owner: nutritionaladvice_user
--

CREATE TABLE public.mealplan (
    "Id" uuid NOT NULL,
    "Name" character varying(100) NOT NULL,
    "Description" character varying(256),
    "Goal" character varying(256),
    "DailyCalories" integer NOT NULL,
    "DailyProtein" double precision NOT NULL,
    "DailyCarbohydrates" double precision NOT NULL,
    "DailyFats" double precision NOT NULL,
    "NutritionistId" uuid NOT NULL,
    "PatientId" uuid NOT NULL
);


ALTER TABLE public.mealplan OWNER TO nutritionaladvice_user;

--
-- TOC entry 223 (class 1259 OID 16479)
-- Name: mealtime; Type: TABLE; Schema: public; Owner: nutritionaladvice_user
--

CREATE TABLE public.mealtime (
    "Id" uuid NOT NULL,
    "Number" integer NOT NULL,
    "Type" character varying(50) NOT NULL,
    "MealPlanId" uuid NOT NULL,
    "RecipeId" uuid NOT NULL,
    "MealPlanStoredModelId" uuid
);


ALTER TABLE public.mealtime OWNER TO nutritionaladvice_user;

--
-- TOC entry 222 (class 1259 OID 16472)
-- Name: recipe; Type: TABLE; Schema: public; Owner: nutritionaladvice_user
--

CREATE TABLE public.recipe (
    "Id" uuid NOT NULL,
    "Name" character varying(250) NOT NULL,
    "Description" character varying(256),
    "PreparationTime" integer NOT NULL,
    "CookingTime" integer NOT NULL,
    "Portions" integer NOT NULL,
    "Instructions" text
);


ALTER TABLE public.recipe OWNER TO nutritionaladvice_user;

--
-- TOC entry 224 (class 1259 OID 16489)
-- Name: recipeingredient; Type: TABLE; Schema: public; Owner: nutritionaladvice_user
--

CREATE TABLE public.recipeingredient (
    "Id" uuid NOT NULL,
    "Quantity" double precision NOT NULL,
    "UnitOfMeasure" character varying(10) NOT NULL,
    "RecipeId" uuid NOT NULL,
    "IngredientId" uuid NOT NULL,
    "RecipeStoredModelId" uuid
);


ALTER TABLE public.recipeingredient OWNER TO nutritionaladvice_user;

--
-- TOC entry 4831 (class 0 OID 16465)
-- Dependencies: 221
-- Data for Name: outboxMessage; Type: TABLE DATA; Schema: outbox; Owner: nutritionaladvice_user
--

COPY outbox."outboxMessage" ("outboxId", content, type, created, processed, "processedOn", "correlationId", "traceId", "spanId") FROM stdin;
b641ed85-c9ff-46ab-9e5c-d02ef064d1b1	{"$type":"NutritionalAdvice.Domain.Recipes.Events.RecipeCreated, NutritionalAdvice.Domain","RecipeId":"50047427-0337-4a1a-b110-28e7ad07ef08","Name":"Espaguetis a la Carbonara","Description":"Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.","Id":"56633e06-54bc-4559-b0c2-31515942a3c2","OccuredOn":"2025-06-11T21:53:02.8469272-04:00"}	RecipeCreated	2025-06-11 21:53:02.88975-04	t	2025-06-12 01:19:33.051658-04	\N	\N	\N
0274e76c-5658-41d7-993b-851572aaaabd	{"$type":"NutritionalAdvice.Domain.Recipes.Events.RecipeCreated, NutritionalAdvice.Domain","RecipeId":"41490200-378e-4a66-8806-f11ace39a18f","Name":"Pollo Tikka Masala","Description":"Un sabroso curry con trozos de pollo tierno en una cremosa salsa de tomate.","Id":"9ae78bc7-4be6-4a44-9a5c-ebf596ef6ab7","OccuredOn":"2025-06-11T22:00:46.193158-04:00"}	RecipeCreated	2025-06-11 22:00:46.197338-04	t	2025-06-12 01:19:40.055255-04	\N	\N	\N
\.


--
-- TOC entry 4828 (class 0 OID 16445)
-- Dependencies: 218
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20250612013835_CreateDatabase	9.0.5
\.


--
-- TOC entry 4829 (class 0 OID 16451)
-- Dependencies: 219
-- Data for Name: ingredient; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public.ingredient ("Id", "Name", "Variety", "Benefits", "DishCategory") FROM stdin;
cd8e87ec-a3b9-4d56-90d3-4df208aaacb3	Tomate	cherry	Posee propiedades diuréticas, antiinflamatorias, antioxidantes, anticancerígenas, digestivas, entre otras	ensaladas
9005b4f9-49bf-4522-a0f1-ffae7d3f1acd	Zanahoria	baby	Rica en beta-caroteno, ayuda a mejorar la visión y fortalece el sistema inmunológico	ensaladas
9ccfe086-d080-45fd-b911-430472397b1a	Espinaca	baby	Alto contenido de hierro, mejora la salud ósea y es rica en antioxidantes	batidos
\.


--
-- TOC entry 4830 (class 0 OID 16458)
-- Dependencies: 220
-- Data for Name: mealplan; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public.mealplan ("Id", "Name", "Description", "Goal", "DailyCalories", "DailyProtein", "DailyCarbohydrates", "DailyFats", "NutritionistId", "PatientId") FROM stdin;
8e4dd179-a4d3-458a-8bba-078148725e70	Plan de Alimentación Balanceado	Un plan diseñado para mantener un equilibrio saludable de nutrientes.	Mantener peso	2000	0	0	0	3fa85f64-5717-4562-b3fc-2c963f66afa6	3fa85f64-5717-4562-b3fc-2c963f66afa6
7ce8494a-8b14-4561-9106-56f73b51c28b	Plan de Ganancia de Masa Muscular	Este plan está diseñado para ayudar a ganar masa muscular de manera efectiva.	Ganar masa muscular	3000	0	0	0	3fa85f64-5717-4562-b3fc-2c963f66afa6	3fa85f64-5717-4562-b3fc-2c963f66afa6
\.


--
-- TOC entry 4833 (class 0 OID 16479)
-- Dependencies: 223
-- Data for Name: mealtime; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public.mealtime ("Id", "Number", "Type", "MealPlanId", "RecipeId", "MealPlanStoredModelId") FROM stdin;
\.


--
-- TOC entry 4832 (class 0 OID 16472)
-- Dependencies: 222
-- Data for Name: recipe; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public.recipe ("Id", "Name", "Description", "PreparationTime", "CookingTime", "Portions", "Instructions") FROM stdin;
50047427-0337-4a1a-b110-28e7ad07ef08	Espaguetis a la Carbonara	Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.	15	20	4	["1. Hervir los espaguetis.","2. Cocinar la panceta hasta que est\\u00E9 crujiente.","3. Mezclar los huevos y el queso en un bol.","4. Combinar los espaguetis con la panceta y la mezcla de huevo.","5. Servir con una pizca de pimienta."]
41490200-378e-4a66-8806-f11ace39a18f	Pollo Tikka Masala	Un sabroso curry con trozos de pollo tierno en una cremosa salsa de tomate.	20	30	4	["1. Marinar el pollo en yogur y especias.","2. Asar o hornear el pollo hasta que est\\u00E9 cocido.","3. Preparar la salsa con tomates, crema y especias.","4. Combinar el pollo con la salsa.","5. Servir con arroz o naan."]
\.


--
-- TOC entry 4834 (class 0 OID 16489)
-- Dependencies: 224
-- Data for Name: recipeingredient; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public.recipeingredient ("Id", "Quantity", "UnitOfMeasure", "RecipeId", "IngredientId", "RecipeStoredModelId") FROM stdin;
\.


--
-- TOC entry 4672 (class 2606 OID 16471)
-- Name: outboxMessage PK_outboxMessage; Type: CONSTRAINT; Schema: outbox; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY outbox."outboxMessage"
    ADD CONSTRAINT "PK_outboxMessage" PRIMARY KEY ("outboxId");


--
-- TOC entry 4666 (class 2606 OID 16449)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 4668 (class 2606 OID 16457)
-- Name: ingredient PK_ingredient; Type: CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.ingredient
    ADD CONSTRAINT "PK_ingredient" PRIMARY KEY ("Id");


--
-- TOC entry 4670 (class 2606 OID 16464)
-- Name: mealplan PK_mealplan; Type: CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.mealplan
    ADD CONSTRAINT "PK_mealplan" PRIMARY KEY ("Id");


--
-- TOC entry 4677 (class 2606 OID 16483)
-- Name: mealtime PK_mealtime; Type: CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.mealtime
    ADD CONSTRAINT "PK_mealtime" PRIMARY KEY ("Id");


--
-- TOC entry 4674 (class 2606 OID 16478)
-- Name: recipe PK_recipe; Type: CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.recipe
    ADD CONSTRAINT "PK_recipe" PRIMARY KEY ("Id");


--
-- TOC entry 4680 (class 2606 OID 16493)
-- Name: recipeingredient PK_recipeingredient; Type: CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.recipeingredient
    ADD CONSTRAINT "PK_recipeingredient" PRIMARY KEY ("Id");


--
-- TOC entry 4675 (class 1259 OID 16499)
-- Name: IX_mealtime_MealPlanStoredModelId; Type: INDEX; Schema: public; Owner: nutritionaladvice_user
--

CREATE INDEX "IX_mealtime_MealPlanStoredModelId" ON public.mealtime USING btree ("MealPlanStoredModelId");


--
-- TOC entry 4678 (class 1259 OID 16500)
-- Name: IX_recipeingredient_RecipeStoredModelId; Type: INDEX; Schema: public; Owner: nutritionaladvice_user
--

CREATE INDEX "IX_recipeingredient_RecipeStoredModelId" ON public.recipeingredient USING btree ("RecipeStoredModelId");


--
-- TOC entry 4681 (class 2606 OID 16484)
-- Name: mealtime FK_mealtime_mealplan_MealPlanStoredModelId; Type: FK CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.mealtime
    ADD CONSTRAINT "FK_mealtime_mealplan_MealPlanStoredModelId" FOREIGN KEY ("MealPlanStoredModelId") REFERENCES public.mealplan("Id");


--
-- TOC entry 4682 (class 2606 OID 16494)
-- Name: recipeingredient FK_recipeingredient_recipe_RecipeStoredModelId; Type: FK CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.recipeingredient
    ADD CONSTRAINT "FK_recipeingredient_recipe_RecipeStoredModelId" FOREIGN KEY ("RecipeStoredModelId") REFERENCES public.recipe("Id");


-- Completed on 2025-06-13 01:25:43

--
-- PostgreSQL database dump complete
--

