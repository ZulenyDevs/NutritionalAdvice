-- MariaDB dump 10.19  Distrib 10.4.27-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: nutritionaladvice
-- ------------------------------------------------------
-- Server version	5.7.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20241219054009_CreateDatabase','5.0.17');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredient`
--

DROP TABLE IF EXISTS `ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingredient` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `Name` varchar(250) NOT NULL,
  `Variety` varchar(100) DEFAULT NULL,
  `Benefits` varchar(500) DEFAULT NULL,
  `DishCategory` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient`
--

LOCK TABLES `ingredient` WRITE;
/*!40000 ALTER TABLE `ingredient` DISABLE KEYS */;
INSERT INTO `ingredient` VALUES ('0abdde46-d178-45d6-adcd-e3fc287b53fb','Aguacate C','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('0d1cc226-71e2-4c84-b303-03d2f59dd143','Zanahoria','baby','Rica en beta-caroteno, ayuda a mejorar la visión y fortalece el sistema inmunológico','ensaladas'),('141d3ab0-c1b0-497d-8e7c-c91cf9aa6e31','Aguacate','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('16232b3f-481d-47c4-9d74-ff0c56fa55e3','Aguacate','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('169b30cd-7f6a-49ef-8089-7d32d710c7b5','Aguacate','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('16bed70c-2741-4e77-bd9d-a3cfceb640c2','Pepino3','kirby','Hidratante, bajo en calorías y contiene vitaminas K y C','ensaladas'),('1ef08a47-27a1-4f5e-8df7-ac9a3e478d38','Pepino3','kirby','Hidratante, bajo en calorías y contiene vitaminas K y C','ensaladas'),('275e437e-8fe5-40fe-9923-967d803ca69d','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('2bd23886-d5b8-4901-8c2a-d1c8cfdc8148','Pepino','kirby','Hidratante, bajo en calorías y contiene vitaminas K y C','ensaladas'),('2d4ebf31-75d6-48db-9427-dead749c307d','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('2f68ab14-e72b-4615-8c32-492b66ac0db8','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('3b470801-8196-47f7-96da-02c9cecdaa5a','Pepino2','Kirby','Hidratante, bajo en calorías y contiene vitaminas K y C','ensaladas'),('5341b190-6c88-494d-9381-e1c562b46acb','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('58592275-5067-4007-8397-e5804f3680ef','Aguacate','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('5d5fb0f1-c742-45e9-82f4-6bf07e021442','Aguacate','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('5f324c05-0650-4c18-ac73-4a1ca16a68b7','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('5fdde7a1-3f09-4cf3-ad31-4df3d696ee4a','Aguacate B','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('79b551d4-5747-4833-b912-114bbbaece55','Aguacate','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('84d6065d-38e0-4936-8ee6-94da068fb8e9','Aguacate100','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('8683945d-45c4-4f1a-897b-54916e3102bc','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('8a41ef9f-34c2-49e4-ba8c-e8ccff73e30a','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('8a9ad515-55a7-4a7b-88f2-e12d3ff25d7a','Pepino3','kirby','Hidratante, bajo en calorías y contiene vitaminas K y C','ensaladas'),('a375ce40-910b-474d-88ee-e4d4c61a0119','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('b5fbc9b6-fcf3-4a73-93ae-60e4ef7e890c','Aguacate A','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('b9773a7c-6089-4ad5-9d4c-43e111e7875b','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('bc723527-fc89-4181-b94f-58ed8a7ccea4','Aguacate','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('be3b69fd-0411-41a7-91ea-f26da20ac961','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('c55c5965-6dd6-4adf-8dd5-c57484c03c8a','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('ce462d2c-8079-476c-8e39-d838dd49913a','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('dd783d81-3a4e-4930-a5c1-7228b72cc0bf','Aguacate A','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('ed91b799-d6a2-464f-b10c-e37e470099d6','Espinaca','baby','Alto contenido de hierro, mejora la salud ósea y es rica en antioxidantes','batidos'),('f5bc972d-cc9f-486e-8f7f-a31042c74d3a','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('f895531c-5fdf-49b9-b04a-16808d6c6f5a','Aguacate A','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole'),('fcce8fd0-9cba-4090-b1ac-557e9d835c59','Aguacate2','hass','Fuente de grasas saludables, ayuda a reducir el colesterol y mejora la salud del corazón','guacamole');
/*!40000 ALTER TABLE `ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mealplan`
--

DROP TABLE IF EXISTS `mealplan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mealplan` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` varchar(256) DEFAULT NULL,
  `Goal` varchar(256) DEFAULT NULL,
  `DailyCalories` int(11) NOT NULL,
  `DailyProtein` double NOT NULL,
  `DailyCarbohydrates` double NOT NULL,
  `DailyFats` double NOT NULL,
  `NutritionistId` char(36) CHARACTER SET ascii NOT NULL,
  `PatientId` char(36) CHARACTER SET ascii NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mealplan`
--

LOCK TABLES `mealplan` WRITE;
/*!40000 ALTER TABLE `mealplan` DISABLE KEYS */;
INSERT INTO `mealplan` VALUES ('24d76c2e-668d-42cf-a8bf-0a1420a9e4dd','Plan de Alimentación Balanceado','Un plan diseñado para mantener un equilibrio saludable de nutrientes.','Mantener peso',2000,0,0,0,'3fa85f64-5717-4562-b3fc-2c963f66afa6','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('44d0ff52-37e3-4caf-922f-8276ebddb313','Plan de Alimentación A','Un plan diseñado para mantener un equilibrio saludable de nutrientes.','Mantener peso',2000,0,0,0,'3fa85f64-5717-4562-b3fc-2c963f66afa6','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('4b65dc59-991c-48c4-ba01-6cf8131ee5b3','Plan de Alimentación Balanceado','Un plan diseñado para mantener un equilibrio saludable de nutrientes.','Mantener peso',2000,0,0,0,'3fa85f64-5717-4562-b3fc-2c963f66afa6','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('517aed08-c8b6-420c-9270-fdea89d80108','Plan de Alimentación Balanceado 100','Un plan diseñado para mantener un equilibrio saludable de nutrientes.','Mantener peso',2000,0,0,0,'3fa85f64-5717-4562-b3fc-2c963f66afa6','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('83f3f77e-d7d7-478d-a62b-f9801b90344f','Plan de Alimentación C','Un plan diseñado para mantener un equilibrio saludable de nutrientes.','Mantener peso',2000,0,0,0,'3fa85f64-5717-4562-b3fc-2c963f66afa6','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('9c7ff1dd-046e-4786-aa97-15112a38fe7e','Plan de Alimentación B','Un plan diseñado para mantener un equilibrio saludable de nutrientes.','Mantener peso',2000,0,0,0,'3fa85f64-5717-4562-b3fc-2c963f66afa6','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('a4870607-50f8-4a84-9053-983dca1f6173','Plan de Alimentación A','Un plan diseñado para mantener un equilibrio saludable de nutrientes.','Mantener peso',2000,0,0,0,'3fa85f64-5717-4562-b3fc-2c963f66afa6','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('b17b2aac-c8b7-42e6-a318-a93e1e38708d','Plan de Alimentación A','Un plan diseñado para mantener un equilibrio saludable de nutrientes.','Mantener peso',2000,0,0,0,'3fa85f64-5717-4562-b3fc-2c963f66afa6','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('b2f700eb-471c-46a9-bcf7-bde83297f979','Plan de Alimentación Balanceado','Un plan diseñado para mantener un equilibrio saludable de nutrientes.','Mantener peso',2000,0,0,0,'3fa85f64-5717-4562-b3fc-2c963f66afa6','3fa85f64-5717-4562-b3fc-2c963f66afa6');
/*!40000 ALTER TABLE `mealplan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mealtime`
--

DROP TABLE IF EXISTS `mealtime`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mealtime` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `Number` int(11) NOT NULL,
  `Type` varchar(50) NOT NULL,
  `MealPlanId` char(36) CHARACTER SET ascii NOT NULL,
  `RecipeId` char(36) CHARACTER SET ascii NOT NULL,
  `MealPlanStoredModelId` char(36) CHARACTER SET ascii DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_mealtime_MealPlanStoredModelId` (`MealPlanStoredModelId`),
  CONSTRAINT `FK_mealtime_mealplan_MealPlanStoredModelId` FOREIGN KEY (`MealPlanStoredModelId`) REFERENCES `mealplan` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mealtime`
--

LOCK TABLES `mealtime` WRITE;
/*!40000 ALTER TABLE `mealtime` DISABLE KEYS */;
/*!40000 ALTER TABLE `mealtime` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe`
--

DROP TABLE IF EXISTS `recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recipe` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `Name` varchar(250) NOT NULL,
  `Description` varchar(256) DEFAULT NULL,
  `PreparationTime` int(11) NOT NULL,
  `CookingTime` int(11) NOT NULL,
  `Portions` int(11) NOT NULL,
  `Instructions` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
INSERT INTO `recipe` VALUES ('11991735-5e93-402b-9931-60c2f5562cc4','Ensalada César','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Marinar el pollo en yogur y especias.\",\"2. Asar o hornear el pollo hasta que est\\u00E9 cocido.\",\"3. Preparar la salsa con tomates, crema y especias.\",\"4. Combinar el pollo con la salsa.\",\"5. Servir con arroz o naan.\"]'),('2b921f59-74a6-4dca-8cc0-35513e4f1e41','Ensalada César 2','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Marinar el pollo en yogur y especias.\",\"2. Asar o hornear el pollo hasta que est\\u00E9 cocido.\",\"3. Preparar la salsa con tomates, crema y especias.\",\"4. Combinar el pollo con la salsa.\",\"5. Servir con arroz o naan.\"]'),('3ae0cd3a-1981-4649-a3c9-01a02cd4bb9c','Ensalada César C','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Cocinar el pollo a la parrilla hasta que est\\u00E9 bien dorado y cocido por dentro.\",\"2. Cortar la lechuga en trozos medianos.\",\"3. Hacer crutones con pan tostado o comprados y colocarlos en un bowl grande.\",\"4. Mezclar el pollo, la lechuga y los crutones en un taz\\u00F3n grande.\",\"5. Agregar el aderezo C\\u00E9sar al gusto y mezclar bien.\",\"6. Servir con un poco de queso parmesano rallado por encima.\"]'),('5489077d-9042-45e0-a611-d93c84e7dc4d','Ensalada César 2','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Marinar el pollo en yogur y especias.\",\"2. Asar o hornear el pollo hasta que est\\u00E9 cocido.\",\"3. Preparar la salsa con tomates, crema y especias.\",\"4. Combinar el pollo con la salsa.\",\"5. Servir con arroz o naan.\"]'),('5f68ceed-6348-4cc9-9b9d-07e4a4be3cc7','Ensalada César','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Marinar el pollo en yogur y especias.\",\"2. Asar o hornear el pollo hasta que est\\u00E9 cocido.\",\"3. Preparar la salsa con tomates, crema y especias.\",\"4. Combinar el pollo con la salsa.\",\"5. Servir con arroz o naan.\"]'),('ad54a561-d9b6-42c0-a4c6-fda55443276f','Ensalada César 100','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Cocinar el pollo a la parrilla hasta que est\\u00E9 bien dorado y cocido por dentro.\",\"2. Cortar la lechuga en trozos medianos.\",\"3. Hacer crutones con pan tostado o comprados y colocarlos en un bowl grande.\",\"4. Mezclar el pollo, la lechuga y los crutones en un taz\\u00F3n grande.\",\"5. Agregar el aderezo C\\u00E9sar al gusto y mezclar bien.\",\"6. Servir con un poco de queso parmesano rallado por encima.\"]'),('c564509b-1099-4bea-849c-af269ef9161d','Ensalada César B','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Cocinar el pollo a la parrilla hasta que est\\u00E9 bien dorado y cocido por dentro.\",\"2. Cortar la lechuga en trozos medianos.\",\"3. Hacer crutones con pan tostado o comprados y colocarlos en un bowl grande.\",\"4. Mezclar el pollo, la lechuga y los crutones en un taz\\u00F3n grande.\",\"5. Agregar el aderezo C\\u00E9sar al gusto y mezclar bien.\",\"6. Servir con un poco de queso parmesano rallado por encima.\"]'),('c8ed6975-659d-45c7-9b4f-a4622c892bd4','Ensalada César','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Marinar el pollo en yogur y especias.\",\"2. Asar o hornear el pollo hasta que est\\u00E9 cocido.\",\"3. Preparar la salsa con tomates, crema y especias.\",\"4. Combinar el pollo con la salsa.\",\"5. Servir con arroz o naan.\"]'),('cc5fff85-bd4b-4ab0-b9e2-5673aabb9420','Ensalada César 2','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Marinar el pollo en yogur y especias.\",\"2. Asar o hornear el pollo hasta que est\\u00E9 cocido.\",\"3. Preparar la salsa con tomates, crema y especias.\",\"4. Combinar el pollo con la salsa.\",\"5. Servir con arroz o naan.\"]'),('cd9c1f2c-0ec1-4498-bb7e-9ee7556d26e5','Ensalada César A','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Cocinar el pollo a la parrilla hasta que est\\u00E9 bien dorado y cocido por dentro.\",\"2. Cortar la lechuga en trozos medianos.\",\"3. Hacer crutones con pan tostado o comprados y colocarlos en un bowl grande.\",\"4. Mezclar el pollo, la lechuga y los crutones en un taz\\u00F3n grande.\",\"5. Agregar el aderezo C\\u00E9sar al gusto y mezclar bien.\",\"6. Servir con un poco de queso parmesano rallado por encima.\"]'),('d3d76d3d-2471-4439-b84f-6decfd46f9ac','Ensalada César A','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Cocinar el pollo a la parrilla hasta que est\\u00E9 bien dorado y cocido por dentro.\",\"2. Cortar la lechuga en trozos medianos.\",\"3. Hacer crutones con pan tostado o comprados y colocarlos en un bowl grande.\",\"4. Mezclar el pollo, la lechuga y los crutones en un taz\\u00F3n grande.\",\"5. Agregar el aderezo C\\u00E9sar al gusto y mezclar bien.\",\"6. Servir con un poco de queso parmesano rallado por encima.\"]'),('d42034d4-d00d-4eb7-843b-0f459c148d71','Ensalada César A','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Cocinar el pollo a la parrilla hasta que est\\u00E9 bien dorado y cocido por dentro.\",\"2. Cortar la lechuga en trozos medianos.\",\"3. Hacer crutones con pan tostado o comprados y colocarlos en un bowl grande.\",\"4. Mezclar el pollo, la lechuga y los crutones en un taz\\u00F3n grande.\",\"5. Agregar el aderezo C\\u00E9sar al gusto y mezclar bien.\",\"6. Servir con un poco de queso parmesano rallado por encima.\"]'),('ddf62355-285f-4841-94a5-b7d545e666f4','Ensalada César 2','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Marinar el pollo en yogur y especias.\",\"2. Asar o hornear el pollo hasta que est\\u00E9 cocido.\",\"3. Preparar la salsa con tomates, crema y especias.\",\"4. Combinar el pollo con la salsa.\",\"5. Servir con arroz o naan.\"]'),('e66a9d9b-0c41-4ea6-b250-31d34f250489','Pollo Tikka Masala','Un sabroso curry con trozos de pollo tierno en una cremosa salsa de tomate.',20,30,4,'[\"1. Marinar el pollo en yogur y especias.\",\"2. Asar o hornear el pollo hasta que est\\u00E9 cocido.\",\"3. Preparar la salsa con tomates, crema y especias.\",\"4. Combinar el pollo con la salsa.\",\"5. Servir con arroz o naan.\"]'),('ec1dcada-1537-4d78-9412-9bb10e4ae723','Ensalada César','Una deliciosa ensalada con pollo a la parrilla, lechuga, crutones y aderezo César cremoso.',15,10,4,'[\"1. Marinar el pollo en yogur y especias.\",\"2. Asar o hornear el pollo hasta que est\\u00E9 cocido.\",\"3. Preparar la salsa con tomates, crema y especias.\",\"4. Combinar el pollo con la salsa.\",\"5. Servir con arroz o naan.\"]');
/*!40000 ALTER TABLE `recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipeingredient`
--

DROP TABLE IF EXISTS `recipeingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recipeingredient` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `Quantity` double NOT NULL,
  `UnitOfMeasure` varchar(10) NOT NULL,
  `RecipeId` char(36) CHARACTER SET ascii NOT NULL,
  `IngredientId` char(36) CHARACTER SET ascii NOT NULL,
  `RecipeStoredModelId` char(36) CHARACTER SET ascii DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_recipeingredient_RecipeStoredModelId` (`RecipeStoredModelId`),
  CONSTRAINT `FK_recipeingredient_recipe_RecipeStoredModelId` FOREIGN KEY (`RecipeStoredModelId`) REFERENCES `recipe` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipeingredient`
--

LOCK TABLES `recipeingredient` WRITE;
/*!40000 ALTER TABLE `recipeingredient` DISABLE KEYS */;
/*!40000 ALTER TABLE `recipeingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'nutritionaladvice'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-21 16:30:37
