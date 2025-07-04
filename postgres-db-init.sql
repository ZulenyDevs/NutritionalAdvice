--
-- PostgreSQL database dump
--

-- Dumped from database version 17.5
-- Dumped by pg_dump version 17.5

-- Started on 2025-07-03 22:39:09

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
-- TOC entry 6 (class 2615 OID 33013)
-- Name: outbox; Type: SCHEMA; Schema: -; Owner: nutritionaladvice_user
--

CREATE SCHEMA outbox;


ALTER SCHEMA outbox OWNER TO nutritionaladvice_user;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 221 (class 1259 OID 33028)
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
-- TOC entry 219 (class 1259 OID 33014)
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
-- TOC entry 220 (class 1259 OID 33021)
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
    "PatientId" uuid NOT NULL,
    "DiagnosticId" uuid NOT NULL
);


ALTER TABLE public.mealplan OWNER TO nutritionaladvice_user;

--
-- TOC entry 223 (class 1259 OID 33042)
-- Name: mealtime; Type: TABLE; Schema: public; Owner: nutritionaladvice_user
--

CREATE TABLE public.mealtime (
    "Id" uuid NOT NULL,
    "Number" integer NOT NULL,
    "Type" character varying(50) NOT NULL,
    "Date" timestamp without time zone NOT NULL,
    "MealPlanId" uuid NOT NULL,
    "RecipeId" uuid NOT NULL
);


ALTER TABLE public.mealtime OWNER TO nutritionaladvice_user;

--
-- TOC entry 222 (class 1259 OID 33035)
-- Name: recipe; Type: TABLE; Schema: public; Owner: nutritionaladvice_user
--

CREATE TABLE public.recipe (
    "Id" uuid NOT NULL,
    "Name" character varying(250) NOT NULL,
    "Description" character varying(256),
    "Portions" integer NOT NULL
);


ALTER TABLE public.recipe OWNER TO nutritionaladvice_user;

--
-- TOC entry 224 (class 1259 OID 33057)
-- Name: recipeingredient; Type: TABLE; Schema: public; Owner: nutritionaladvice_user
--

CREATE TABLE public.recipeingredient (
    "Id" uuid NOT NULL,
    "Quantity" double precision NOT NULL,
    "UnitOfMeasure" character varying(10) NOT NULL,
    "RecipeId" uuid NOT NULL,
    "IngredientId" uuid NOT NULL
);


ALTER TABLE public.recipeingredient OWNER TO nutritionaladvice_user;

--
-- TOC entry 4835 (class 0 OID 33028)
-- Dependencies: 221
-- Data for Name: outboxMessage; Type: TABLE DATA; Schema: outbox; Owner: nutritionaladvice_user
--

COPY outbox."outboxMessage" ("outboxId", content, type, created, processed, "processedOn", "correlationId", "traceId", "spanId") FROM stdin;
5f43f2ef-42b4-48b2-81b0-09e6574d2857	{"$type":"NutritionalAdvice.Domain.Recipes.Events.RecipeCreated, NutritionalAdvice.Domain","RecipeId":"f837239f-1323-475c-be7b-e4d7f926e52a","Name":"Espaguetis a la Carbonara","Description":"Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.","Id":"7c3f34b8-f401-43f8-bc82-a45327e961c0","OccuredOn":"2025-07-02T01:45:20.2424229-04:00"}	RecipeCreated	2025-07-02 01:45:23.269444-04	t	2025-07-03 00:42:37.777244-04	\N	\N	\N
b2a827a5-68fe-45f1-b55b-74a38c002b26	{"$type":"NutritionalAdvice.Domain.Recipes.Events.RecipeCreated, NutritionalAdvice.Domain","RecipeId":"65ce4e7a-fad7-406f-b454-dbb79a040641","Name":"Pollo Tikka Masala","Description":"Un sabroso curry con trozos de pollo tierno en una cremosa salsa de tomate.","Id":"4527bbb9-04ab-4c31-b578-99f00071bb24","OccuredOn":"2025-07-02T01:45:50.6043047-04:00"}	RecipeCreated	2025-07-02 01:45:50.912732-04	t	2025-07-03 00:42:45.630911-04	\N	\N	\N
eb219663-0c15-4d67-b72f-070200112bd2	{"$type":"NutritionalAdvice.Domain.MealPlans.Events.MealPlanCreated, NutritionalAdvice.Domain","Name":"Plan de pérdida de peso","Description":"Plan diseñado para reducción de peso saludable","Goal":"Perder 5kg en 2 meses","DailyCalories":1800,"DailyProtein":0.0,"DailyCarbohydrates":0.0,"DailyFats":0.0,"NutritionistId":"3fa85f64-5717-4562-b3fc-2c963f66afa6","PatientId":"4fa85f64-5717-4562-b3fc-2c963f66afb7","DiagnosticId":"5fa85f64-5717-4562-b3fc-2c963f66afc8","MealTimes":{"$type":"System.Collections.Generic.List`1[[NutritionalAdvice.Domain.MealPlans.MealTime, NutritionalAdvice.Domain]], System.Private.CoreLib","$values":[{"$type":"NutritionalAdvice.Domain.MealPlans.MealTime, NutritionalAdvice.Domain","Number":1,"Type":"Desayuno","Date":"2025-07-02T11:00:00+00:00","MealPlanId":"5e437a88-59c5-4e2b-904c-3b795b8fbfee","RecipeId":"f837239f-1323-475c-be7b-e4d7f926e52a","Id":"114715ee-79db-427a-98bc-741d16181115","DomainEvents":{"$type":"System.Collections.Generic.List`1[[NutritionalAdvice.Domain.Abstractions.DomainEvent, NutritionalAdvice.Domain]], System.Private.CoreLib","$values":[]}},{"$type":"NutritionalAdvice.Domain.MealPlans.MealTime, NutritionalAdvice.Domain","Number":2,"Type":"Almuerzo","Date":"2025-07-02T16:00:00+00:00","MealPlanId":"5e437a88-59c5-4e2b-904c-3b795b8fbfee","RecipeId":"65ce4e7a-fad7-406f-b454-dbb79a040641","Id":"1a8fe79a-bba1-4375-83fb-62ecbf6852dc","DomainEvents":{"$type":"System.Collections.Generic.List`1[[NutritionalAdvice.Domain.Abstractions.DomainEvent, NutritionalAdvice.Domain]], System.Private.CoreLib","$values":[]}}]},"Id":"883fa793-48a5-4acf-9834-38d26aa3cd0d","OccuredOn":"2025-07-03T00:59:56.95042-04:00"}	MealPlanCreated	2025-07-03 00:59:57.069449-04	t	2025-07-03 01:00:01.754771-04	\N	\N	\N
2096c84a-1cc3-4007-98af-500cfe490e48	{"$type":"NutritionalAdvice.Domain.MealPlans.Events.MealPlanCreated, NutritionalAdvice.Domain","Name":"Plan de pérdida de peso 3","Description":"Plan diseñado para reducción de peso saludable","Goal":"Perder 5kg en 2 meses","DailyCalories":1800,"DailyProtein":0.0,"DailyCarbohydrates":0.0,"DailyFats":0.0,"NutritionistId":"3fa85f64-5717-4562-b3fc-2c963f66afa6","PatientId":"4fa85f64-5717-4562-b3fc-2c963f66afb7","DiagnosticId":"5fa85f64-5717-4562-b3fc-2c963f66afc8","MealTimes":{"$type":"System.Collections.Generic.List`1[[NutritionalAdvice.Domain.MealPlans.MealTime, NutritionalAdvice.Domain]], System.Private.CoreLib","$values":[{"$type":"NutritionalAdvice.Domain.MealPlans.MealTime, NutritionalAdvice.Domain","Number":1,"Type":"Desayuno 3","Date":"2025-07-03T11:00:00+00:00","MealPlanId":"9644b20c-f13b-4dd3-8df6-624e3a7fc077","RecipeId":"f837239f-1323-475c-be7b-e4d7f926e52a","Id":"8df4cd44-1bdf-4056-b68a-a9849462ffd3","DomainEvents":{"$type":"System.Collections.Generic.List`1[[NutritionalAdvice.Domain.Abstractions.DomainEvent, NutritionalAdvice.Domain]], System.Private.CoreLib","$values":[]}},{"$type":"NutritionalAdvice.Domain.MealPlans.MealTime, NutritionalAdvice.Domain","Number":2,"Type":"Almuerzo 3","Date":"2025-07-03T16:00:00+00:00","MealPlanId":"9644b20c-f13b-4dd3-8df6-624e3a7fc077","RecipeId":"65ce4e7a-fad7-406f-b454-dbb79a040641","Id":"627831ff-9053-43b5-89ce-72afdc5c18cd","DomainEvents":{"$type":"System.Collections.Generic.List`1[[NutritionalAdvice.Domain.Abstractions.DomainEvent, NutritionalAdvice.Domain]], System.Private.CoreLib","$values":[]}}]},"Id":"1ac48c7e-89fb-443a-a59e-fc720f40a9d7","OccuredOn":"2025-07-03T01:07:50.8485404-04:00"}	MealPlanCreated	2025-07-03 01:07:50.970464-04	t	2025-07-03 01:08:04.284086-04	\N	\N	\N
60a75814-ab06-42c3-abc7-79153a35b823	{"$type":"NutritionalAdvice.Domain.Recipes.Events.RecipeCreated, NutritionalAdvice.Domain","RecipeId":"f6ed0fe2-a6c1-4918-b1b6-53c59c2b6219","Name":"Lasaña de Carne","Description":"Una deliciosa lasaña al horno con capas de pasta, carne molida, salsa de tomate y bechamel, gratinada con queso.","Id":"5cec79ec-af75-42f4-bf30-58785e81d43b","OccuredOn":"2025-07-03T22:25:14.2818272-04:00"}	RecipeCreated	2025-07-03 22:25:14.347078-04	t	2025-07-03 22:25:21.04354-04	\N	\N	\N
\.


--
-- TOC entry 4832 (class 0 OID 16445)
-- Dependencies: 218
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20250612013835_CreateDatabase	9.0.5
20250622233104_CreateDatabase	9.0.5
20250623024335_CreateDatabase	9.0.5
20250623025032_CreateDatabase	9.0.5
20250623030514_CreateDatabase	9.0.5
20250623042736_CreateDatabase	9.0.5
20250623052840_CreateDatabase	9.0.5
20250625044750_CreateDatabase	9.0.5
20250702032257_CreateDatabase	9.0.5
20250702034300_CreateDatabase	9.0.5
20250702041411_CreateDatabase	9.0.5
\.


--
-- TOC entry 4833 (class 0 OID 33014)
-- Dependencies: 219
-- Data for Name: ingredient; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public.ingredient ("Id", "Name", "Variety", "Benefits", "DishCategory") FROM stdin;
8f5d348d-a464-415a-80eb-2edcb355c04a	Tomate	cherry	Posee propiedades diuréticas, antiinflamatorias, antioxidantes, anticancerígenas, digestivas, entre otras	ensaladas
99dd6a52-e718-4b3a-8e4f-bc391b5e36f0	Zanahoria	baby	Rica en beta-caroteno, ayuda a mejorar la visión y fortalece el sistema inmunológico	ensaladas
76fc505c-8a0e-4abd-94ef-af347c76bf8e	Aguacate	hass	Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón	guacamole
\.


--
-- TOC entry 4834 (class 0 OID 33021)
-- Dependencies: 220
-- Data for Name: mealplan; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public.mealplan ("Id", "Name", "Description", "Goal", "DailyCalories", "DailyProtein", "DailyCarbohydrates", "DailyFats", "NutritionistId", "PatientId", "DiagnosticId") FROM stdin;
a852f6b2-f7c8-4c10-a2e8-912c45841ecf	Plan de pérdida de peso	Plan diseñado para reducción de peso saludable	Perder 5kg en 2 meses	1800	0	0	0	3fa85f64-5717-4562-b3fc-2c963f66afa6	4fa85f64-5717-4562-b3fc-2c963f66afb7	5fa85f64-5717-4562-b3fc-2c963f66afc8
e50d955c-bc0b-470c-b573-5cdd15efd081	Plan de pérdida de peso 2	Plan diseñado para reducción de peso saludable	Perder 5kg en 2 meses	1800	0	0	0	3fa85f64-5717-4562-b3fc-2c963f66afa6	4fa85f64-5717-4562-b3fc-2c963f66afb7	5fa85f64-5717-4562-b3fc-2c963f66afc8
9644b20c-f13b-4dd3-8df6-624e3a7fc077	Plan de pérdida de peso 3	Plan diseñado para reducción de peso saludable	Perder 5kg en 2 meses	1800	0	0	0	3fa85f64-5717-4562-b3fc-2c963f66afa6	4fa85f64-5717-4562-b3fc-2c963f66afb7	5fa85f64-5717-4562-b3fc-2c963f66afc8
5e437a88-59c5-4e2b-904c-3b795b8fbfee	Plan de pérdida de peso 4	Plan diseñado para reducción de peso saludable	Perder 5kg en 2 meses	1800	0	0	0	3fa85f64-5717-4562-b3fc-2c963f66afa6	4fa85f64-5717-4562-b3fc-2c963f66afb7	5fa85f64-5717-4562-b3fc-2c963f66afc8
\.


--
-- TOC entry 4837 (class 0 OID 33042)
-- Dependencies: 223
-- Data for Name: mealtime; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public.mealtime ("Id", "Number", "Type", "Date", "MealPlanId", "RecipeId") FROM stdin;
7c2039dd-8735-41da-a5d5-49bf3fc71e46	1	Desayuno 3	2025-07-03 07:00:00	9644b20c-f13b-4dd3-8df6-624e3a7fc077	f837239f-1323-475c-be7b-e4d7f926e52a
d4f0ccb8-a57e-4d00-ac33-bae6cda26ac5	2	Almuerzo 3	2025-07-03 12:00:00	9644b20c-f13b-4dd3-8df6-624e3a7fc077	65ce4e7a-fad7-406f-b454-dbb79a040641
79442331-1791-4c3d-a6af-e63ed235b4c2	1	Desayuno 2	2025-07-03 07:00:00	e50d955c-bc0b-470c-b573-5cdd15efd081	f837239f-1323-475c-be7b-e4d7f926e52a
da57b3c3-96d2-4252-b0d9-7ccfdd296209	2	Almuerzo 2	2025-07-03 12:00:00	e50d955c-bc0b-470c-b573-5cdd15efd081	65ce4e7a-fad7-406f-b454-dbb79a040641
6f3600b9-ef2a-4475-ba87-7b270fd50dab	1	Desayuno 3	2025-07-02 07:00:00	5e437a88-59c5-4e2b-904c-3b795b8fbfee	f837239f-1323-475c-be7b-e4d7f926e52a
9f669fb6-edb9-4f0f-957a-c90eb628c2dc	2	Almuerzo 3	2025-07-02 12:00:00	5e437a88-59c5-4e2b-904c-3b795b8fbfee	65ce4e7a-fad7-406f-b454-dbb79a040641
74cec0e0-a31d-4a93-bb15-379ea9b59006	1	Desayuno	2025-07-02 07:00:00	a852f6b2-f7c8-4c10-a2e8-912c45841ecf	f837239f-1323-475c-be7b-e4d7f926e52a
f75e0f44-21f5-41a2-b39d-3211501b0b6f	2	Almuerzo	2025-07-02 12:00:00	a852f6b2-f7c8-4c10-a2e8-912c45841ecf	65ce4e7a-fad7-406f-b454-dbb79a040641
\.


--
-- TOC entry 4836 (class 0 OID 33035)
-- Dependencies: 222
-- Data for Name: recipe; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public.recipe ("Id", "Name", "Description", "Portions") FROM stdin;
f837239f-1323-475c-be7b-e4d7f926e52a	Espaguetis a la Carbonara	Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.	4
65ce4e7a-fad7-406f-b454-dbb79a040641	Pollo Tikka Masala	Un sabroso curry con trozos de pollo tierno en una cremosa salsa de tomate.	4
f6ed0fe2-a6c1-4918-b1b6-53c59c2b6219	Lasaña de Carne	Una deliciosa lasaña al horno con capas de pasta, carne molida, salsa de tomate y bechamel, gratinada con queso.	6
\.


--
-- TOC entry 4838 (class 0 OID 33057)
-- Dependencies: 224
-- Data for Name: recipeingredient; Type: TABLE DATA; Schema: public; Owner: nutritionaladvice_user
--

COPY public.recipeingredient ("Id", "Quantity", "UnitOfMeasure", "RecipeId", "IngredientId") FROM stdin;
\.


--
-- TOC entry 4672 (class 2606 OID 33034)
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
-- TOC entry 4668 (class 2606 OID 33020)
-- Name: ingredient PK_ingredient; Type: CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.ingredient
    ADD CONSTRAINT "PK_ingredient" PRIMARY KEY ("Id");


--
-- TOC entry 4670 (class 2606 OID 33027)
-- Name: mealplan PK_mealplan; Type: CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.mealplan
    ADD CONSTRAINT "PK_mealplan" PRIMARY KEY ("Id");


--
-- TOC entry 4678 (class 2606 OID 33046)
-- Name: mealtime PK_mealtime; Type: CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.mealtime
    ADD CONSTRAINT "PK_mealtime" PRIMARY KEY ("Id");


--
-- TOC entry 4674 (class 2606 OID 33041)
-- Name: recipe PK_recipe; Type: CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.recipe
    ADD CONSTRAINT "PK_recipe" PRIMARY KEY ("Id");


--
-- TOC entry 4682 (class 2606 OID 33061)
-- Name: recipeingredient PK_recipeingredient; Type: CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.recipeingredient
    ADD CONSTRAINT "PK_recipeingredient" PRIMARY KEY ("Id");


--
-- TOC entry 4675 (class 1259 OID 33072)
-- Name: IX_mealtime_MealPlanId; Type: INDEX; Schema: public; Owner: nutritionaladvice_user
--

CREATE INDEX "IX_mealtime_MealPlanId" ON public.mealtime USING btree ("MealPlanId");


--
-- TOC entry 4676 (class 1259 OID 33073)
-- Name: IX_mealtime_RecipeId; Type: INDEX; Schema: public; Owner: nutritionaladvice_user
--

CREATE INDEX "IX_mealtime_RecipeId" ON public.mealtime USING btree ("RecipeId");


--
-- TOC entry 4679 (class 1259 OID 33074)
-- Name: IX_recipeingredient_IngredientId; Type: INDEX; Schema: public; Owner: nutritionaladvice_user
--

CREATE INDEX "IX_recipeingredient_IngredientId" ON public.recipeingredient USING btree ("IngredientId");


--
-- TOC entry 4680 (class 1259 OID 33075)
-- Name: IX_recipeingredient_RecipeId; Type: INDEX; Schema: public; Owner: nutritionaladvice_user
--

CREATE INDEX "IX_recipeingredient_RecipeId" ON public.recipeingredient USING btree ("RecipeId");


--
-- TOC entry 4683 (class 2606 OID 33047)
-- Name: mealtime FK_mealtime_mealplan_MealPlanId; Type: FK CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.mealtime
    ADD CONSTRAINT "FK_mealtime_mealplan_MealPlanId" FOREIGN KEY ("MealPlanId") REFERENCES public.mealplan("Id") ON DELETE CASCADE;


--
-- TOC entry 4684 (class 2606 OID 33052)
-- Name: mealtime FK_mealtime_recipe_RecipeId; Type: FK CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.mealtime
    ADD CONSTRAINT "FK_mealtime_recipe_RecipeId" FOREIGN KEY ("RecipeId") REFERENCES public.recipe("Id") ON DELETE CASCADE;


--
-- TOC entry 4685 (class 2606 OID 33062)
-- Name: recipeingredient FK_recipeingredient_ingredient_IngredientId; Type: FK CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.recipeingredient
    ADD CONSTRAINT "FK_recipeingredient_ingredient_IngredientId" FOREIGN KEY ("IngredientId") REFERENCES public.ingredient("Id") ON DELETE CASCADE;


--
-- TOC entry 4686 (class 2606 OID 33067)
-- Name: recipeingredient FK_recipeingredient_recipe_RecipeId; Type: FK CONSTRAINT; Schema: public; Owner: nutritionaladvice_user
--

ALTER TABLE ONLY public.recipeingredient
    ADD CONSTRAINT "FK_recipeingredient_recipe_RecipeId" FOREIGN KEY ("RecipeId") REFERENCES public.recipe("Id") ON DELETE CASCADE;


-- Completed on 2025-07-03 22:39:09

--
-- PostgreSQL database dump complete
--

