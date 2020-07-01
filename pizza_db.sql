/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : pizza_db

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2020-06-30 22:20:24
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for cajero
-- ----------------------------
DROP TABLE IF EXISTS `cajero`;
CREATE TABLE `cajero` (
  `rut` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL,
  PRIMARY KEY (`rut`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cajero
-- ----------------------------
INSERT INTO `cajero` VALUES ('1', 'CajeroAdm', 'HnmX2020!');

-- ----------------------------
-- Table structure for cliente
-- ----------------------------
DROP TABLE IF EXISTS `cliente`;
CREATE TABLE `cliente` (
  `phone` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL,
  PRIMARY KEY (`phone`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cliente
-- ----------------------------
INSERT INTO `cliente` VALUES ('25153', 'Aquiles Bailo', '');
INSERT INTO `cliente` VALUES ('2342423', 'asfasdasd', '');
INSERT INTO `cliente` VALUES ('3242342', 'sdfsdfsd', '');

-- ----------------------------
-- Table structure for producto
-- ----------------------------
DROP TABLE IF EXISTS `producto`;
CREATE TABLE `producto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `precio` float NOT NULL DEFAULT '0',
  `cantidad` int(11) NOT NULL DEFAULT '0',
  `idVenta` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of producto
-- ----------------------------
INSERT INTO `producto` VALUES ('20', 'Pizza Familiar', '22000', '2', null);
INSERT INTO `producto` VALUES ('21', 'Pizza Familiar', '22000', '3', null);
INSERT INTO `producto` VALUES ('22', 'Pizza Familiar', '22000', '3', null);
INSERT INTO `producto` VALUES ('23', 'Pizza Familiar', '22000', '3', null);
INSERT INTO `producto` VALUES ('24', 'Pizza Familiar', '22000', '1', null);
INSERT INTO `producto` VALUES ('25', 'Bebida Individual', '1500', '1', null);

-- ----------------------------
-- Table structure for venta
-- ----------------------------
DROP TABLE IF EXISTS `venta`;
CREATE TABLE `venta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` int(11) NOT NULL,
  `idCajero` int(11) NOT NULL,
  `idCliente` int(11) NOT NULL,
  `total` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idCajero` (`idCajero`),
  KEY `idCliente` (`idCliente`),
  CONSTRAINT `venta_ibfk_2` FOREIGN KEY (`idCajero`) REFERENCES `cajero` (`rut`),
  CONSTRAINT `venta_ibfk_3` FOREIGN KEY (`idCliente`) REFERENCES `cliente` (`phone`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of venta
-- ----------------------------
INSERT INTO `venta` VALUES ('1', '29', '1', '3242342', '0');
INSERT INTO `venta` VALUES ('2', '30', '1', '25153', '0');
