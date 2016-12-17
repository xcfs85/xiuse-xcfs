/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : xiuse

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2016-12-17 12:07:03
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `memberconsumption`
-- ----------------------------
DROP TABLE IF EXISTS `memberconsumption`;
CREATE TABLE `memberconsumption` (
  `ConsumptionRecordsId` char(32) NOT NULL,
  `MemberCardNo` char(16) NOT NULL COMMENT '会员卡卡号',
  `MemberId` char(32) NOT NULL COMMENT '会员Id',
  `CRecordsType` tinyint(4) NOT NULL COMMENT '消费类型',
  `Amount` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '消费金额',
  `Balance` decimal(12,2) NOT NULL COMMENT '余额',
  `ConsumptionTime` datetime NOT NULL COMMENT '消费日期',
  `OrderId` char(32) NOT NULL COMMENT '订单Id',
  PRIMARY KEY (`ConsumptionRecordsId`),
  KEY `MCon_key` (`MemberId`),
  CONSTRAINT `MCon_key` FOREIGN KEY (`MemberId`) REFERENCES `xiuse_member` (`MemberId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of memberconsumption
-- ----------------------------

-- ----------------------------
-- Table structure for `ordermenu_`
-- ----------------------------
DROP TABLE IF EXISTS `ordermenu_`;
CREATE TABLE `ordermenu_` (
  `OrderMenuId` char(32) NOT NULL COMMENT '订单ID',
  `OrderId` char(32) NOT NULL,
  `MenuName` varchar(500) NOT NULL COMMENT '餐品名称',
  `MenuPrice` decimal(12,2) NOT NULL COMMENT '菜品价格',
  `MenuTag` varchar(500) NOT NULL COMMENT '菜品标签',
  `MenuImage` varchar(500) DEFAULT NULL COMMENT '菜品图片',
  `MenuInstruction` varchar(5000) DEFAULT NULL COMMENT '菜品介绍',
  `DiscoutFlag` int(1) DEFAULT '0' COMMENT '是否有折扣（0,1）',
  `DiscountName` varchar(500) DEFAULT NULL COMMENT '折扣名称',
  `DiscountContent` decimal(12,2) DEFAULT NULL COMMENT '折扣金额',
  `DiscountType` tinyint(1) DEFAULT NULL COMMENT '折扣类型(0:百分比 1：固定金额)',
  `MenuServing` int(1) DEFAULT '0' COMMENT '是否上菜',
  PRIMARY KEY (`OrderMenuId`),
  KEY `key-006` (`OrderId`),
  CONSTRAINT `key-006` FOREIGN KEY (`OrderId`) REFERENCES `order_` (`OrderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of ordermenu_
-- ----------------------------

-- ----------------------------
-- Table structure for `order_`
-- ----------------------------
DROP TABLE IF EXISTS `order_`;
CREATE TABLE `order_` (
  `OrderId` varchar(32) NOT NULL COMMENT '订单号',
  `DeskId` char(32) NOT NULL COMMENT '餐桌Id',
  `BillAmount` decimal(12,2) NOT NULL COMMENT '账单',
  `AccountsPayable` decimal(12,2) NOT NULL COMMENT '应付款',
  `Refunds` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '退款',
  `DishCount` tinyint(1) NOT NULL COMMENT '菜品数量',
  `OrderState` tinyint(1) DEFAULT '0' COMMENT '订单状态（0，未支付；1，已支付）',
  `Cash` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '现金付款',
  `BankCard` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '银行卡付款',
  `WeiXin` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '微信付款',
  `Alipay` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '支付宝付款',
  `MembersCard` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '会员卡付款',
  `OrderbeginTime` datetime NOT NULL COMMENT '下单时间',
  `OrderEndTime` datetime DEFAULT NULL COMMENT '用餐结束时间',
  PRIMARY KEY (`OrderId`),
  KEY `DeskId` (`DeskId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of order_
-- ----------------------------

-- ----------------------------
-- Table structure for `xiuse_desk`
-- ----------------------------
DROP TABLE IF EXISTS `xiuse_desk`;
CREATE TABLE `xiuse_desk` (
  `DeskId` char(32) NOT NULL COMMENT '餐桌主键ID',
  `DeskName` varchar(100) NOT NULL COMMENT '餐桌名称',
  `TakeOut` int(1) NOT NULL DEFAULT '0' COMMENT '是否接受外卖（0，不接受外卖。1接受外卖）',
  `DeskDel` int(1) NOT NULL DEFAULT '1' COMMENT '0,已删除。1正常',
  `DeskState` tinyint(1) NOT NULL DEFAULT '0' COMMENT '餐桌的状态：0，空桌；1，未支付；2，已支付；',
  `RestaurantId` varchar(32) NOT NULL COMMENT '餐厅ID',
  `DeskTime` datetime NOT NULL COMMENT '更新时间',
  PRIMARY KEY (`DeskId`),
  KEY `key_001` (`RestaurantId`),
  CONSTRAINT `key_001` FOREIGN KEY (`RestaurantId`) REFERENCES `xiuse_restaurant` (`RestaurantId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of xiuse_desk
-- ----------------------------

-- ----------------------------
-- Table structure for `xiuse_discount`
-- ----------------------------
DROP TABLE IF EXISTS `xiuse_discount`;
CREATE TABLE `xiuse_discount` (
  `DiscountId` char(32) NOT NULL DEFAULT '' COMMENT '折扣ID',
  `DiscountName` varchar(250) NOT NULL COMMENT '折扣名称',
  `DiscountType` tinyint(11) NOT NULL DEFAULT '0' COMMENT '折扣类型(0:百分比 1：固定金额)',
  `DiscountContent` decimal(12,2) NOT NULL COMMENT '折扣金额',
  `DiscountMenus` varchar(250) DEFAULT '' COMMENT '折扣菜品(-1，全部餐品；（菜品ID,菜品ID,菜品ID,菜品ID,菜品ID）,部门折扣)',
  `DiscountSection` tinyint(1) NOT NULL DEFAULT '0' COMMENT '0,整单折扣；1，单品折扣',
  `DiscountState` int(1) DEFAULT '0' COMMENT '1,启用；0，禁用',
  `DiscountVerification` int(1) DEFAULT '0' COMMENT '0,启用管理员验证；1,禁用管理员验证；',
  `RestaurantId` char(32) NOT NULL,
  `DiscountTime` datetime DEFAULT NULL COMMENT '更新时间',
  PRIMARY KEY (`DiscountId`),
  KEY `key-002` (`RestaurantId`),
  CONSTRAINT `key-002` FOREIGN KEY (`RestaurantId`) REFERENCES `xiuse_restaurant` (`RestaurantId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of xiuse_discount
-- ----------------------------

-- ----------------------------
-- Table structure for `xiuse_member`
-- ----------------------------
DROP TABLE IF EXISTS `xiuse_member`;
CREATE TABLE `xiuse_member` (
  `MemberId` char(32) NOT NULL COMMENT '会员Id',
  `MemberCardNo` char(16) NOT NULL COMMENT '会员卡号',
  `MemberName` varchar(200) NOT NULL COMMENT '会员名称',
  `MemberAmount` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '卡内余额',
  `MemberClassifyId` char(32) NOT NULL COMMENT '会员类型ID',
  `MemberCell` varchar(15) DEFAULT NULL COMMENT '手机号',
  `MemberReference` varchar(15) DEFAULT NULL COMMENT '推荐人',
  `MemberPassword` varchar(16) NOT NULL,
  `MemberState` int(1) NOT NULL DEFAULT '1' COMMENT '会员状态（0，禁用；1，启用；）',
  `MemberTime` datetime NOT NULL COMMENT '会员创建时间',
  `RestaurantId` char(32) NOT NULL,
  PRIMARY KEY (`MemberId`),
  KEY `MemberType_foreign_key` (`MemberClassifyId`),
  CONSTRAINT `MemberType_foreign_key` FOREIGN KEY (`MemberClassifyId`) REFERENCES `xiuse_memberclassify` (`MemberClassifyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of xiuse_member
-- ----------------------------

-- ----------------------------
-- Table structure for `xiuse_memberclassify`
-- ----------------------------
DROP TABLE IF EXISTS `xiuse_memberclassify`;
CREATE TABLE `xiuse_memberclassify` (
  `MemberClassifyId` char(32) NOT NULL COMMENT '会员类型',
  `DiscountId` char(32) NOT NULL COMMENT '折扣ID',
  `ClassifyName` varchar(250) NOT NULL COMMENT '类型名称',
  `ClassRemark` varchar(500) DEFAULT NULL COMMENT '说明',
  `ClassifyMemberNum` int(11) NOT NULL DEFAULT '0' COMMENT '会员数量',
  `ClassifyTime` datetime NOT NULL COMMENT '修改时间',
  `DelTag` tinyint(4) DEFAULT NULL COMMENT '删除标志，(0,启用；1，停用；2，删除。)',
  PRIMARY KEY (`MemberClassifyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of xiuse_memberclassify
-- ----------------------------

-- ----------------------------
-- Table structure for `xiuse_menuclassify`
-- ----------------------------
DROP TABLE IF EXISTS `xiuse_menuclassify`;
CREATE TABLE `xiuse_menuclassify` (
  `ClassifyId` char(32) NOT NULL COMMENT '菜单分类',
  `ClassifyInstruction` varchar(500) DEFAULT NULL COMMENT '品餐分类介绍',
  `ClassifyNo` int(11) NOT NULL COMMENT '餐品排列顺序',
  `ClassifyNet` int(1) unsigned zerofill NOT NULL DEFAULT '0' COMMENT '隐藏分类 (网上点单客户无法使用) 1,隐藏分类。0不隐藏分类。',
  `ClassifyTag` varchar(200) DEFAULT NULL,
  `RestaurantId` char(32) DEFAULT NULL COMMENT '餐厅的ID',
  `ClassifyTime` datetime NOT NULL COMMENT '分类更新时间',
  PRIMARY KEY (`ClassifyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of xiuse_menuclassify
-- ----------------------------

-- ----------------------------
-- Table structure for `xiuse_menus`
-- ----------------------------
DROP TABLE IF EXISTS `xiuse_menus`;
CREATE TABLE `xiuse_menus` (
  `MenuId` char(32) NOT NULL COMMENT '品餐Id',
  `MenuName` varchar(500) NOT NULL COMMENT '餐品名称',
  `MenuQuantity` int(11) NOT NULL DEFAULT '100' COMMENT '(当天)菜品剩余数量',
  `MenuPrice` decimal(12,2) NOT NULL COMMENT '餐品价格',
  `MenuShortcut` varchar(5) DEFAULT NULL COMMENT '快捷码',
  `MenuTag` varchar(500) DEFAULT '' COMMENT '菜品标签（正常,微微辣,微辣,辣,超辣,变态辣,多糖）',
  `MenuImage` varchar(200) DEFAULT NULL COMMENT '餐品图片的路径',
  `MenuNo` int(11) DEFAULT NULL COMMENT '菜品排序',
  `MenuInstruction` varchar(5000) DEFAULT NULL COMMENT '餐品介绍',
  `SaleState` int(1) DEFAULT '0' COMMENT '菜品销售状态（1限量销售，0不限量销售）',
  `MenuState` int(1) DEFAULT '0' COMMENT '餐品状态（0，正常。1，停用。2，已删除。）',
  `RestaurantId` char(32) NOT NULL,
  `ClassifyId` char(32) DEFAULT NULL COMMENT '菜品种类',
  `MenuTime` datetime NOT NULL COMMENT '更新时间',
  PRIMARY KEY (`MenuId`),
  KEY `key-003` (`RestaurantId`),
  KEY `key-008` (`ClassifyId`),
  CONSTRAINT `key-003` FOREIGN KEY (`RestaurantId`) REFERENCES `xiuse_restaurant` (`RestaurantId`),
  CONSTRAINT `key-008` FOREIGN KEY (`ClassifyId`) REFERENCES `xiuse_menuclassify` (`ClassifyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of xiuse_menus
-- ----------------------------

-- ----------------------------
-- Table structure for `xiuse_recharge`
-- ----------------------------
DROP TABLE IF EXISTS `xiuse_recharge`;
CREATE TABLE `xiuse_recharge` (
  `RechargeId` char(32) NOT NULL COMMENT '充值记录Id',
  `RechargeType` tinyint(4) NOT NULL COMMENT '充值类型',
  `RechargeAmount` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '充值金额',
  `Balance` decimal(12,2) NOT NULL COMMENT '可用余额',
  `MemberId` char(32) NOT NULL COMMENT '会员的Id',
  `MemberCardNo` varchar(16) NOT NULL COMMENT '会员的卡号',
  `RechargeTime` datetime NOT NULL,
  PRIMARY KEY (`RechargeId`),
  KEY `RechargeMember_key` (`MemberId`),
  CONSTRAINT `RechargeMember_key` FOREIGN KEY (`MemberId`) REFERENCES `xiuse_member` (`MemberId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of xiuse_recharge
-- ----------------------------

-- ----------------------------
-- Table structure for `xiuse_restaurant`
-- ----------------------------
DROP TABLE IF EXISTS `xiuse_restaurant`;
CREATE TABLE `xiuse_restaurant` (
  `RestaurantId` char(32) NOT NULL COMMENT '餐厅的Id',
  `RestaurantName` varchar(200) DEFAULT NULL COMMENT '餐厅名称',
  `Phone` varchar(20) DEFAULT NULL COMMENT '餐厅的电话',
  `Site` varchar(200) DEFAULT NULL COMMENT '餐厅的地址',
  `Remark` varchar(500) DEFAULT NULL COMMENT '餐厅的说明',
  `Time` datetime NOT NULL COMMENT '更新时间',
  PRIMARY KEY (`RestaurantId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of xiuse_restaurant
-- ----------------------------
INSERT INTO `xiuse_restaurant` VALUES ('00000000000000000000000000000000', 'TestRN', '010-88888888', '北京', null, '2016-12-12 13:22:43');

-- ----------------------------
-- Table structure for `xiuse_user`
-- ----------------------------
DROP TABLE IF EXISTS `xiuse_user`;
CREATE TABLE `xiuse_user` (
  `UserId` char(32) NOT NULL COMMENT 'Id编号',
  `UserName` varchar(50) NOT NULL COMMENT '姓名',
  `Weixin` varchar(255) DEFAULT NULL COMMENT '微信号',
  `CellPhone` decimal(11,0) DEFAULT NULL COMMENT '手机号',
  `Email` varchar(255) DEFAULT NULL COMMENT 'Email',
  `Password` varchar(50) NOT NULL COMMENT '密码',
  `RestaurantId` char(32) NOT NULL COMMENT '餐厅ID',
  `UserRole` int(1) NOT NULL DEFAULT '0' COMMENT '0,是管理员；1，是员工。',
  `ParentUserId` varchar(32) NOT NULL DEFAULT '-1' COMMENT '上级用户Id，顶级为-1',
  `OwnRestaurant` int(1) DEFAULT '0' COMMENT '餐厅所有权（0，无；1，所有；）',
  `Time` datetime NOT NULL COMMENT '修改时间',
  PRIMARY KEY (`UserId`),
  KEY `key-004` (`RestaurantId`),
  CONSTRAINT `key-004` FOREIGN KEY (`RestaurantId`) REFERENCES `xiuse_restaurant` (`RestaurantId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of xiuse_user
-- ----------------------------
INSERT INTO `xiuse_user` VALUES ('00000000000000000000000000000000', 'admin', 'weixin', '15811111111', 'admin@163.com', 'flaskjdflj===', '00000000000000000000000000000000', '0', '-1', '0', '2016-12-12 13:20:42');
