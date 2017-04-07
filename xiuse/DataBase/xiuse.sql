/*
MySQL Data Transfer
Source Host: localhost
Source Database: xiuse
Target Host: localhost
Target Database: xiuse
Date: 2017/4/5 17:09:21
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for log
-- ----------------------------
CREATE TABLE `log` (
  `LogId` char(32) NOT NULL COMMENT '日志Id',
  `UserId` char(32) NOT NULL COMMENT '用户ID',
  `LogContent` varchar(5000) DEFAULT NULL COMMENT '日志内容',
  `LogType` int(10) unsigned zerofill NOT NULL COMMENT '日志类型',
  `LogTime` datetime DEFAULT NULL COMMENT '日志时间',
  PRIMARY KEY (`LogId`),
  KEY `LogFk` (`UserId`),
  CONSTRAINT `LogFk` FOREIGN KEY (`UserId`) REFERENCES `xiuse_user` (`UserId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for memberconsumption
-- ----------------------------
CREATE TABLE `memberconsumption` (
  `ConsumptionRecordsId` char(32) NOT NULL COMMENT '消费信息',
  `MemberCardNo` char(16) NOT NULL COMMENT '会员卡卡号',
  `MemberId` char(32) NOT NULL COMMENT '会员Id',
  `CRecordsType` smallint(4) NOT NULL COMMENT '消费类型',
  `Amount` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '消费金额',
  `Balance` decimal(12,2) NOT NULL COMMENT '余额',
  `ConsumptionTime` datetime NOT NULL COMMENT '消费日期',
  `OrderId` char(32) NOT NULL COMMENT '订单Id',
  PRIMARY KEY (`ConsumptionRecordsId`),
  KEY `MCon_key` (`MemberId`),
  CONSTRAINT `MCon_key` FOREIGN KEY (`MemberId`) REFERENCES `xiuse_member` (`MemberId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for order_
-- ----------------------------
CREATE TABLE `order_` (
  `OrderId` varchar(32) NOT NULL COMMENT '订单号',
  `DeskId` char(32) NOT NULL COMMENT '餐桌Id',
  `BillAmount` decimal(12,2) NOT NULL COMMENT '账单',
  `AccountsPayable` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '应付款',
  `Refunds` decimal(12,2) unsigned zerofill NOT NULL DEFAULT '0000000000.00' COMMENT '退款',
  `DishCount` int(11) NOT NULL COMMENT '菜品数量',
  `OrderState` smallint(1) NOT NULL DEFAULT '0' COMMENT '订单状态（0，未支付；1，已支付;2,退单）',
  `Cash` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '现金付款',
  `BankCard` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '银行卡付款',
  `WeiXin` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '微信付款',
  `Alipay` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '支付宝付款',
  `MembersCard` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '会员卡付款',
  `ClearDeskState` tinyint(4) NOT NULL DEFAULT '0' COMMENT '0,没有清台；1，已经清台；',
  `OrderbeginTime` datetime NOT NULL COMMENT '下单时间',
  `OrderEndTime` datetime DEFAULT NULL COMMENT '用餐结束时间',
  `ServiceUserId` char(32) NOT NULL COMMENT '服务员的Id',
  `CustomerNum` int(11) DEFAULT NULL COMMENT '顾客数量',
  PRIMARY KEY (`OrderId`),
  KEY `DeskId` (`DeskId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for ordermenu_
-- ----------------------------
CREATE TABLE `ordermenu_` (
  `OrderMenuId` char(32) NOT NULL COMMENT '订单ID',
  `OrderId` char(32) NOT NULL,
  `MenuName` varchar(500) DEFAULT NULL COMMENT '餐品名称',
  `MenuPrice` decimal(12,2) DEFAULT '0.00' COMMENT '菜品价格',
  `MenuTag` varchar(500) DEFAULT NULL COMMENT '菜品标签',
  `MenuNum` int(11) NOT NULL DEFAULT '1' COMMENT '菜品数量',
  `MenuImage` varchar(500) DEFAULT NULL COMMENT '菜品图片',
  `MenuInstruction` varchar(5000) DEFAULT NULL COMMENT '菜品介绍',
  `DiscoutFlag` smallint(1) DEFAULT '0' COMMENT '是否有折扣（0,1）',
  `DiscountName` varchar(500) DEFAULT NULL COMMENT '折扣名称',
  `DiscountContent` decimal(12,2) DEFAULT NULL COMMENT '折扣金额',
  `DiscountType` smallint(1) DEFAULT NULL COMMENT '折扣类型(0:百分比 1：固定金额)',
  `MenuServing` smallint(1) DEFAULT '0' COMMENT '是否上菜（0：没上；1：上菜）',
  PRIMARY KEY (`OrderMenuId`),
  KEY `key-006` (`OrderId`),
  CONSTRAINT `key-006` FOREIGN KEY (`OrderId`) REFERENCES `order_` (`OrderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for xiuse_desk
-- ----------------------------
CREATE TABLE `xiuse_desk` (
  `DeskId` char(32) NOT NULL COMMENT '餐桌主键ID',
  `DeskName` varchar(100) NOT NULL COMMENT '餐桌名称',
  `TakeOut` smallint(1) NOT NULL DEFAULT '0' COMMENT '是否接受外卖（0，不接受外卖。1接受外卖）',
  `DeskDel` smallint(1) NOT NULL DEFAULT '1' COMMENT '0,已删除。1正常',
  `DeskState` smallint(1) NOT NULL DEFAULT '0' COMMENT '餐桌的状态：0，空桌；1，未支付；2，已支付；',
  `RestaurantId` varchar(32) NOT NULL COMMENT '餐厅ID',
  `DeskTime` datetime NOT NULL COMMENT '更新时间',
  PRIMARY KEY (`DeskId`),
  KEY `key_001` (`RestaurantId`),
  CONSTRAINT `key_001` FOREIGN KEY (`RestaurantId`) REFERENCES `xiuse_restaurant` (`RestaurantId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for xiuse_discount
-- ----------------------------
CREATE TABLE `xiuse_discount` (
  `DiscountId` char(32) NOT NULL DEFAULT '' COMMENT '折扣ID',
  `DiscountName` varchar(250) NOT NULL COMMENT '折扣名称',
  `DiscountType` smallint(11) NOT NULL DEFAULT '0' COMMENT '折扣类型(0:百分比 1：固定金额)',
  `DiscountContent` decimal(12,2) NOT NULL COMMENT '折扣金额',
  `DiscountMenus` varchar(1000) DEFAULT '' COMMENT '折扣菜品(-1，全部餐品；（菜品ID,菜品ID,菜品ID,菜品ID,菜品ID）,部门折扣)',
  `DiscountSection` smallint(1) NOT NULL DEFAULT '0' COMMENT '0,整单折扣；1，单品折扣',
  `DiscountState` smallint(1) DEFAULT '0' COMMENT '1,启用；0，禁用;2,删除；',
  `DiscountVerification` smallint(1) DEFAULT '0' COMMENT '0,启用管理员验证；1,禁用管理员验证；',
  `RestaurantId` char(32) NOT NULL,
  `DiscountTime` datetime DEFAULT NULL COMMENT '更新时间',
  PRIMARY KEY (`DiscountId`),
  KEY `key-002` (`RestaurantId`),
  CONSTRAINT `key-002` FOREIGN KEY (`RestaurantId`) REFERENCES `xiuse_restaurant` (`RestaurantId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for xiuse_member
-- ----------------------------
CREATE TABLE `xiuse_member` (
  `MemberId` char(32) NOT NULL COMMENT '会员Id',
  `MemberCardNo` char(16) NOT NULL COMMENT '会员卡号',
  `MemberName` varchar(200) NOT NULL COMMENT '会员名称',
  `MemberAmount` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '卡内余额',
  `MemberClassifyId` char(32) NOT NULL COMMENT '会员类型ID',
  `MemberCell` varchar(15) DEFAULT NULL COMMENT '手机号',
  `MemberReference` varchar(15) DEFAULT NULL COMMENT '推荐人',
  `MemberPassword` varchar(16) NOT NULL,
  `MemberState` smallint(1) NOT NULL DEFAULT '1' COMMENT '会员状态（0，禁用；1，启用；）',
  `MemberTime` datetime NOT NULL COMMENT '会员创建时间',
  `RestaurantId` char(32) NOT NULL,
  PRIMARY KEY (`MemberId`),
  KEY `MemberType_foreign_key` (`MemberClassifyId`),
  CONSTRAINT `MemberType_foreign_key` FOREIGN KEY (`MemberClassifyId`) REFERENCES `xiuse_memberclassify` (`MemberClassifyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for xiuse_memberclassify
-- ----------------------------
CREATE TABLE `xiuse_memberclassify` (
  `MemberClassifyId` char(32) NOT NULL COMMENT '会员类型',
  `DiscountId` char(32) NOT NULL COMMENT '折扣ID',
  `ClassifyName` varchar(250) NOT NULL COMMENT '类型名称',
  `ClassRemark` varchar(500) DEFAULT NULL COMMENT '说明',
  `ClassifyMemberNum` int(11) NOT NULL DEFAULT '0' COMMENT '会员数量',
  `ClassifyTime` datetime NOT NULL COMMENT '修改时间',
  `DelTag` smallint(4) NOT NULL DEFAULT '0' COMMENT '删除标志，(0,启用；1，停用；2，删除。)',
  `RestaurantId` char(32) NOT NULL COMMENT '餐厅Id',
  PRIMARY KEY (`MemberClassifyId`),
  KEY `MemberClassify_Key` (`RestaurantId`),
  CONSTRAINT `MemberClassify_Key` FOREIGN KEY (`RestaurantId`) REFERENCES `xiuse_restaurant` (`RestaurantId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for xiuse_menuclassify
-- ----------------------------
CREATE TABLE `xiuse_menuclassify` (
  `ClassifyId` char(32) NOT NULL COMMENT '菜单分类',
  `ClassifyInstruction` varchar(500) DEFAULT NULL COMMENT '品餐分类介绍',
  `ClassifyNo` int(11) NOT NULL COMMENT '餐品排列顺序',
  `ClassifyNet` smallint(1) unsigned zerofill NOT NULL DEFAULT '0' COMMENT '隐藏分类 (网上点单客户无法使用) 1,隐藏分类。0不隐藏分类。',
  `ClassifyTag` varchar(200) DEFAULT NULL COMMENT '分类名称',
  `RestaurantId` char(32) DEFAULT NULL COMMENT '餐厅的ID',
  `ClassifyTime` datetime NOT NULL COMMENT '分类更新时间',
  PRIMARY KEY (`ClassifyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for xiuse_menus
-- ----------------------------
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
  `SaleState` smallint(1) DEFAULT '0' COMMENT '菜品销售状态（1限量销售，0不限量销售）',
  `MenuState` smallint(1) DEFAULT '0' COMMENT '餐品状态（0，正常。1，停用。2，已删除。）',
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
-- Table structure for xiuse_rebates
-- ----------------------------
CREATE TABLE `xiuse_rebates` (
  `RebatesId` char(32) NOT NULL COMMENT '返现记录Id',
  `MemberCardNo` char(16) NOT NULL COMMENT '会员卡号',
  `MemberId` char(32) NOT NULL COMMENT '会员Id',
  `RebatesType` varchar(500) NOT NULL COMMENT '返现类型',
  `RebatesAmount` decimal(12,2) DEFAULT NULL COMMENT '返现金额',
  `DateTime` datetime DEFAULT NULL COMMENT '日期',
  `Balance` decimal(12,2) NOT NULL COMMENT '可用余额',
  PRIMARY KEY (`RebatesId`),
  KEY `Rebates_key` (`MemberId`),
  CONSTRAINT `Rebates_key` FOREIGN KEY (`MemberId`) REFERENCES `xiuse_member` (`MemberId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for xiuse_recharge
-- ----------------------------
CREATE TABLE `xiuse_recharge` (
  `RechargeId` char(32) NOT NULL COMMENT '充值记录Id',
  `RechargeType` smallint(4) NOT NULL COMMENT '充值类型',
  `RechargeAmount` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '充值金额',
  `Balance` decimal(12,2) NOT NULL COMMENT '可用余额',
  `MemberId` char(32) NOT NULL COMMENT '会员的Id',
  `MemberCardNo` varchar(16) NOT NULL COMMENT '会员的卡号',
  `RechargeTime` datetime NOT NULL,
  `BeforeBalance` decimal(12,0) DEFAULT NULL COMMENT '充值前的可用余额',
  PRIMARY KEY (`RechargeId`),
  KEY `RechargeMember_key` (`MemberId`),
  CONSTRAINT `RechargeMember_key` FOREIGN KEY (`MemberId`) REFERENCES `xiuse_member` (`MemberId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for xiuse_restaurant
-- ----------------------------
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
-- Table structure for xiuse_user
-- ----------------------------
CREATE TABLE `xiuse_user` (
  `UserId` char(32) NOT NULL COMMENT 'Id编号',
  `UserName` varchar(50) NOT NULL COMMENT '姓名',
  `Weixin` varchar(255) DEFAULT NULL COMMENT '微信号',
  `CellPhone` varchar(15) DEFAULT NULL COMMENT '手机号',
  `Email` varchar(255) DEFAULT NULL COMMENT 'Email',
  `Password` varchar(50) NOT NULL COMMENT '密码',
  `RestaurantId` char(32) NOT NULL COMMENT '餐厅ID',
  `UserRole` smallint(1) NOT NULL DEFAULT '0' COMMENT '0,是管理员；1，是员工。',
  `ParentUserId` varchar(32) NOT NULL DEFAULT '-1' COMMENT '上级用户Id，顶级为-1',
  `OwnRestaurant` smallint(1) DEFAULT '0' COMMENT '餐厅所有权（0，无；1，所有；）',
  `DelTag` smallint(4) DEFAULT NULL COMMENT '员工状态（0，正常；1，禁用；2，删除。）',
  `Time` datetime NOT NULL COMMENT '修改时间',
  PRIMARY KEY (`UserId`),
  KEY `key-004` (`RestaurantId`),
  CONSTRAINT `key-004` FOREIGN KEY (`RestaurantId`) REFERENCES `xiuse_restaurant` (`RestaurantId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `memberconsumption` VALUES ('0000000000000000000001', '00003', '000000000000000000000000003', '1', '28.00', '17.00', '2017-04-04 10:26:01', '114ba6d863de46f8b389c5f8266d07fa');
INSERT INTO `memberconsumption` VALUES ('0000000000000000000002', '00004', '000000000000000000000000004', '1', '91.00', '9.00', '2017-04-05 10:28:56', '1e8bf48635b64ac9a7c9ae2668c4b7a0');
INSERT INTO `order_` VALUES ('0016b467769148f6913389b2ebed36d5', '00000000000000000000000000000006', '43.00', '43.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-01 13:03:51', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('03d7a090e83e492c9fd931ebffddd606', '00000000000000000000000000000003', '43.00', '43.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-03-31 17:08:01', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('08718270f187475781a43c0c832ab7c7', '00000000000000000000000000000004', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:45:07', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('08bf855165714fd4a0d864a1beb6ff4d', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:40:18', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('09fe0f4e02da4bfeb957b9c43e98ee43', '00000000000000000000000000000001', '35.00', '35.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:45:50', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('0e292c451a5445e9a549b9dcfc806556', '00000000000000000000000000000006', '238.00', '238.00', '0000000000.00', '17', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:36:30', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('114ba6d863de46f8b389c5f8266d07fa', '00000000000000000000000000000004', '28.00', '0.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-03-31 17:06:13', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('11d1f5456e034fc6a7e77d0dd6d49768', '00000000000000000000000000000002', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:35:05', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('12d1f4327ef449a7b5f3b82c8bfaff89', '00000000000000000000000000000002', '85.00', '85.00', '0000000000.00', '6', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-03-31 16:53:26', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('1ba08e1e4543443d8e646f7ec2e53b0b', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:47:10', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('1e8bf48635b64ac9a7c9ae2668c4b7a0', '00000000000000000000000000000005', '91.00', '91.00', '0000000000.00', '4', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-03-31 17:08:16', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('1fc1f50f22334279962458145df7b7eb', '00000000000000000000000000000006', '43.00', '43.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-01 13:04:55', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('246969aa6a414c08918625617b41f194', '00000000000000000000000000000002', '47.00', '47.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:48:09', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('28dbd50ecf5340279367bbbca2445bc1', '00000000000000000000000000000002', '33.00', '33.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:42:13', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('29c5e392e7a849cfbed2c5b99191e9fd', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 16:24:30', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('2f02d686b954483d9bd9a71db3046038', '00000000000000000000000000000002', '53.00', '53.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:31:48', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('2f2dccf0acf3420ab107414dbaf9e768', '00000000000000000000000000000005', '40.00', '40.00', '0000000000.00', '4', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-03-31 17:08:26', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('35e64af9567949d98d665891e39f0b99', '00000000000000000000000000000005', '38.00', '38.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 13:15:20', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('404ef615914d4570a9b2cea4c49aad71', '00000000000000000000000000000004', '43.00', '43.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 16:34:59', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('4a6080f588e34233b86042b3d270dd33', '00000000000000000000000000000001', '61.00', '61.00', '0000000000.00', '5', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 09:20:15', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('4b5b8e8205a243fe911f4aed53d459ea', '00000000000000000000000000000001', '22.00', '22.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:30:28', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('51d58602dbac4615a4bc4664c5ba6118', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 13:06:45', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('532588b50caa42c88620b1097260d4c0', '00000000000000000000000000000005', '12.00', '12.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 13:12:02', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('5369bdc61e50459eb33ddee09f25eb75', '00000000000000000000000000000002', '22.00', '22.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 13:38:20', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('5567de5f774b41c19bb0ac9ad71b4d55', '00000000000000000000000000000002', '41.00', '41.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 09:21:37', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('56572e67f5a9406285ebdc1a6459b56d', '00000000000000000000000000000001', '25.00', '25.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:17:24', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('5a49ce04af144717a6f1af6133dce7e8', '00000000000000000000000000000004', '28.00', '0.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-03-31 17:06:22', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('659487387a5846d3ac7cf10076c4bdb4', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 11:05:56', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('6e9dcc57e20b4851b2d11362a827fc43', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:35:48', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('6ff3f9809349435aa0de1b05ca063554', '00000000000000000000000000000005', '43.00', '43.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 13:11:44', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('760648013471441591c38cc5f53c8507', '00000000000000000000000000000004', '25.00', '25.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 13:20:24', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('7a1ca92acb2c4a58a51b37a78aefe413', '00000000000000000000000000000004', '31.00', '31.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 13:35:23', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('8012e7ab471f435c9613adbc100ac15b', '00000000000000000000000000000006', '53.00', '53.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-01 13:13:48', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('80612557c3dd461e9cbd68c756d2b44f', '00000000000000000000000000000003', '43.00', '43.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:34:12', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('8ee2c48a2751453d853fbf64378e12dd', '00000000000000000000000000000001', '31.00', '31.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:25:51', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('980f96063aca4d129f818c57f0e999e8', '00000000000000000000000000000001', '63.00', '63.00', '0000000000.00', '4', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-03-31 16:52:45', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('99b79530080343c085b14788e88c49cc', '00000000000000000000000000000003', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 16:01:07', null, '00000000000000000000000000000000', '5');
INSERT INTO `order_` VALUES ('9ed953d876634a0cb3302a4d60e29684', '00000000000000000000000000000001', '40.00', '40.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:13:38', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('9f9aa27c25464907b4c8803b0c96b678', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:50:50', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('a43bdad50e9743a8a5385cb517c21a93', '00000000000000000000000000000001', '43.00', '43.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:29:25', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('a5e8d8e0c32146e9a4d68fcae7738175', '00000000000000000000000000000002', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 13:46:41', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('a6c0a86108da487c90b1de01e5aed5d8', '00000000000000000000000000000001', '31.00', '31.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 09:21:53', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('a710ac4f974d4cbb92edf1ebc867ffb3', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 09:31:07', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('abb2b45cfbe44566a1275c7225a4a1a4', '00000000000000000000000000000001', '31.00', '31.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:38:51', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('b23351381aaa412ba43521a6eac33a7a', '00000000000000000000000000000004', '28.00', '0.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-03-31 17:06:24', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('b2c5672ac938434aa76f5563c97df0c8', '00000000000000000000000000000001', '43.00', '43.00', '0000000000.00', '4', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 10:58:20', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('b92cc1518a774449a1fa749b7f98a44a', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 11:04:31', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('b96a4479f93240c6b49c82f714757900', '00000000000000000000000000000004', '28.00', '0.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-03-31 17:05:59', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('bab58ba7ae064e45aa0143dc595c41a7', '00000000000000000000000000000006', '68.00', '68.00', '0000000000.00', '4', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-01 13:02:53', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('c8fd2b12bee545ab9007809a758b9112', '00000000000000000000000000000004', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-01 13:04:10', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('d220be1ba22549d7a295e5b6ea07df95', '00000000000000000000000000000002', '31.00', '31.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 14:36:05', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('e46937d76d5349ada2785434df953fce', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 13:22:33', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('e678a16fe34e4850a22eada0e0234e39', '00000000000000000000000000000004', '64.00', '64.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 13:37:00', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('f0cd4a7cd0e4420687089ec03de415be', '00000000000000000000000000000004', '66.00', '66.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 13:32:22', null, '00000000000000000000000000000000', '1');
INSERT INTO `order_` VALUES ('fd3c278044cc41f2a89b296f685d312f', '00000000000000000000000000000001', '43.00', '43.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-05 09:25:06', null, '00000000000000000000000000000000', '1');
INSERT INTO `ordermenu_` VALUES ('00641f88493d482588fe3652ea6ebc4c', '5369bdc61e50459eb33ddee09f25eb75', '炝海带丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('026696cac6bd400a9244c2ce3d04810f', '246969aa6a414c08918625617b41f194', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('027ae078beac43aca8bbac59f3cc9973', '12d1f4327ef449a7b5f3b82c8bfaff89', '雪碧', '8.00', '微辣', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('043579e72d8c4376b90c02f8e27df0ff', '03d7a090e83e492c9fd931ebffddd606', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('04f6035da3354cc4babb9a5c41d70b9c', 'bab58ba7ae064e45aa0143dc595c41a7', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('0739f8eef0334689b417d673b5899cdd', '08718270f187475781a43c0c832ab7c7', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('08cdde8a26a64438afbd74b393fccc5b', '0e292c451a5445e9a549b9dcfc806556', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('09761605f8af47a499482a491f9a504e', 'e46937d76d5349ada2785434df953fce', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('09d14a162bcb447c91bd68e25170ae9d', '2f02d686b954483d9bd9a71db3046038', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('0ad3ecf59ca34f9ea4c09bf0051718d0', '0e292c451a5445e9a549b9dcfc806556', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('0b5806b31d9a4909842c8965f9524049', '1fc1f50f22334279962458145df7b7eb', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('0d0599783f03420d8947b94cb4e96e82', '404ef615914d4570a9b2cea4c49aad71', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('0dd4ddf96abb4401a2b0157e27366a1a', '7a1ca92acb2c4a58a51b37a78aefe413', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('10c446ca01a9468c8d02a70eb564fb56', '51d58602dbac4615a4bc4664c5ba6118', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('10cdebb8e8004f9a8c5b4da621056d39', 'd220be1ba22549d7a295e5b6ea07df95', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('11eb68b2c97445188e9391c0c66381f5', '760648013471441591c38cc5f53c8507', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('12cf7ac0a8c1485192d42ebe3d59e91a', 'a5e8d8e0c32146e9a4d68fcae7738175', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('15ea47b25ef343e7a0a0d4a105939403', 'b23351381aaa412ba43521a6eac33a7a', '西红柿炒鸡蛋', '16.00', '', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('171f658c5fb1471791316bd96e5e2b94', '0e292c451a5445e9a549b9dcfc806556', '玉米排骨汤', '28.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('174aa4d5be1149afacf9c9a9df38996e', 'b2c5672ac938434aa76f5563c97df0c8', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('1adc4884228e49f3bc7b82fe8935e90f', '6ff3f9809349435aa0de1b05ca063554', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('1ca6b82fe07a4031a413f4630a82c248', '08718270f187475781a43c0c832ab7c7', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('1d75bdd8c8af438bbcbfddab1dbf169b', '1e8bf48635b64ac9a7c9ae2668c4b7a0', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('1f9bfdfca9eb4a688cacab3dc3303177', '2f2dccf0acf3420ab107414dbaf9e768', '雪碧', '8.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('200436ac71944306bc09e756f0f71609', 'b2c5672ac938434aa76f5563c97df0c8', '米饭', '2.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('20647366570646e39b3c4d26aa8f2904', 'c8fd2b12bee545ab9007809a758b9112', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('21137f91f3f64a83b08b95ea14c27847', 'a6c0a86108da487c90b1de01e5aed5d8', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('257546e6ff42495db1728037e594298d', '8012e7ab471f435c9613adbc100ac15b', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('28b83272c5ae404daa73fb02f3a3cf93', '11d1f5456e034fc6a7e77d0dd6d49768', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '1');
INSERT INTO `ordermenu_` VALUES ('2cb95b1ee4c6412fa53818673ead8dfe', 'e678a16fe34e4850a22eada0e0234e39', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('2cc29c945a024cb49127a6ab0fc5b111', 'e678a16fe34e4850a22eada0e0234e39', '筒子骨海带汤', '38.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('2e618f336b3e4b72925e99c807144e90', 'a710ac4f974d4cbb92edf1ebc867ffb3', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('2fc4b93a38e54e2da128ac5beac9f551', '4a6080f588e34233b86042b3d270dd33', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('3521344fc52e4f4ea8965636652cad87', '1ba08e1e4543443d8e646f7ec2e53b0b', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('369ecdef3b9e4451a1ea6a2cc8ccf4d1', '9f9aa27c25464907b4c8803b0c96b678', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '1');
INSERT INTO `ordermenu_` VALUES ('370f053d128a44cc8fe9081aeb82a092', '56572e67f5a9406285ebdc1a6459b56d', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('37c10101f0934b71aada0499fc13b1e3', '80612557c3dd461e9cbd68c756d2b44f', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('38567d66647e4fe38082648daf0a34a1', 'f0cd4a7cd0e4420687089ec03de415be', '玉米排骨汤', '28.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('38b9efd11b874894a92c064dca88bfd2', '4b5b8e8205a243fe911f4aed53d459ea', '炝海带丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('396914f763bb474898c999e7e7ef51b9', '6ff3f9809349435aa0de1b05ca063554', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('3e543959747644819bdb69b28eeb9f89', '35e64af9567949d98d665891e39f0b99', '烙饼子', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('3ea16343c17b4c01a044a654dd491812', '980f96063aca4d129f818c57f0e999e8', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('3ed5a6cc1918409aba815694f8f6fd41', '6e9dcc57e20b4851b2d11362a827fc43', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('41ef494fc33144779aaa58e2d1c6dea6', '659487387a5846d3ac7cf10076c4bdb4', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('432946c8d2c94277a33b8b33897a31b3', '0e292c451a5445e9a549b9dcfc806556', '米饭', '2.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('433c552c1bc14993a4119085dc996f6f', 'b96a4479f93240c6b49c82f714757900', '西红柿炒鸡蛋', '16.00', '', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('4bf835be8f2145e4beba237dda319e3d', '980f96063aca4d129f818c57f0e999e8', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('4dec41f5395b465d8f74514c40692676', '532588b50caa42c88620b1097260d4c0', '扬州炒饭', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('4e179572441441d6921ebac581bbed53', 'a43bdad50e9743a8a5385cb517c21a93', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('5051a5d3356e48968bc40ecae2a71c09', '0e292c451a5445e9a549b9dcfc806556', '扬州炒饭', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('5630d606a4ac4faa9301c7413e929c62', '0e292c451a5445e9a549b9dcfc806556', '雪碧', '8.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('56dcaea71e1346fbb259c4585ca482a2', '08bf855165714fd4a0d864a1beb6ff4d', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '1');
INSERT INTO `ordermenu_` VALUES ('5a779e66cb774395884c2576ffffa7b1', '1ba08e1e4543443d8e646f7ec2e53b0b', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('5a97f0de5d5c4790a60e59ce4c09098d', '659487387a5846d3ac7cf10076c4bdb4', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('5bbf207aa0834da09aa93b689bc2b1cb', '0e292c451a5445e9a549b9dcfc806556', '糖醋萝卜', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('5d057242f37f471d9dad9b015f9d761d', '4a6080f588e34233b86042b3d270dd33', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('5e36ba9d3af14cce9ca75a2f4eaa935a', 'b92cc1518a774449a1fa749b7f98a44a', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('63105144f3b04ef297069e08739f541c', '09fe0f4e02da4bfeb957b9c43e98ee43', '炝海带丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '1');
INSERT INTO `ordermenu_` VALUES ('6496b7f7087540e6a2285c9ab679224e', 'd220be1ba22549d7a295e5b6ea07df95', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('67b4181f9896499cacf4b19d9eb68148', '5a49ce04af144717a6f1af6133dce7e8', '西红柿炒鸡蛋', '16.00', '', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('6b789bfb6aa64fe68a8282d4bd6483ef', '28dbd50ecf5340279367bbbca2445bc1', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('6e27f1896b354265bf31541021d22c9d', '5369bdc61e50459eb33ddee09f25eb75', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('7170c53a78614d1aae26944e1b9160d4', '6ff3f9809349435aa0de1b05ca063554', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('764c72037fb447fe8ab6a2c83aa92446', '7a1ca92acb2c4a58a51b37a78aefe413', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('7760cf961bf249eda382c3cbc1f37ad0', '8ee2c48a2751453d853fbf64378e12dd', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('78e1030bc20e448bb00622f96da5f7a6', '0e292c451a5445e9a549b9dcfc806556', '烙饼子', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('7b50c12f7c0441e5a2fcea685d8afac9', '80612557c3dd461e9cbd68c756d2b44f', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '1');
INSERT INTO `ordermenu_` VALUES ('7c687b756f6a447381cbe30904b17c6c', '0e292c451a5445e9a549b9dcfc806556', '油炸花生米', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('82dc3e83f852450cad62071dbe8b03fb', '114ba6d863de46f8b389c5f8266d07fa', '西红柿炒鸡蛋', '16.00', '', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('8436f623c938484f9cd250041e0a68ff', '12d1f4327ef449a7b5f3b82c8bfaff89', '红油金针菇', '12.00', '超辣', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('873f693149f64b088fe279d47210cb41', 'fd3c278044cc41f2a89b296f685d312f', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('8e5eff57998b4ad49e63b938d0005cae', 'bab58ba7ae064e45aa0143dc595c41a7', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('8ef2fc41d1634e17a55732df82912d08', 'a5e8d8e0c32146e9a4d68fcae7738175', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('918bb6ceaf00439991c10a371ff39764', 'e678a16fe34e4850a22eada0e0234e39', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('939be2ac2abe46dcba3a9709ac649948', '29c5e392e7a849cfbed2c5b99191e9fd', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('94eddbdd3e2f42fda09e284b6aec071c', '0e292c451a5445e9a549b9dcfc806556', '可乐', '8.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('959cc3716da148c1868a4c5c7c53d98c', '114ba6d863de46f8b389c5f8266d07fa', '红油金针菇', '12.00', '', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('97c887ca1de141e1bef153c8b3c07880', '0e292c451a5445e9a549b9dcfc806556', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('981816841a554e02b9d738a8324a09bc', '51d58602dbac4615a4bc4664c5ba6118', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('98580b70ef484198b3b9155b0b7227c3', '03d7a090e83e492c9fd931ebffddd606', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('9b52147c2b8f48f085acc7ff6f644e3c', '2f02d686b954483d9bd9a71db3046038', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('9be55e6c19294caf89b861be1229d209', '0016b467769148f6913389b2ebed36d5', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('9db7f6e09bcb4f0f9a3dc9a97eaf4259', 'a710ac4f974d4cbb92edf1ebc867ffb3', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('9dc5a8ee2a0c406dad43a600f733d80b', '2f2dccf0acf3420ab107414dbaf9e768', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('9eee235f17fb443692e393abba04246d', '12d1f4327ef449a7b5f3b82c8bfaff89', '鱼香肉丝', '25.00', '较咸', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('9ffdaeaaa365473387624786ff3ac3da', '4a6080f588e34233b86042b3d270dd33', '油焖茄子', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('a0c92e1f4db34662a0fde6a48a20ed53', 'b23351381aaa412ba43521a6eac33a7a', '红油金针菇', '12.00', '', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('a0fd13a2066e49f7bc7d0b2e4e46d34e', 'bab58ba7ae064e45aa0143dc595c41a7', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('a374de47cb7141e89e461949e158070f', '1e8bf48635b64ac9a7c9ae2668c4b7a0', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('a44beb4028b14164bcb57b948d6301e0', '29c5e392e7a849cfbed2c5b99191e9fd', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('a4e7ceeccca641b39881b10734daa778', '12d1f4327ef449a7b5f3b82c8bfaff89', '玉米排骨汤', '28.00', '较咸', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('a5f77306f55b45bebe9984a4146c737a', '0016b467769148f6913389b2ebed36d5', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('a946e812286c4762a3d8a389d8d8c490', 'e46937d76d5349ada2785434df953fce', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('aa71725d92ed415f90b94c15373a989b', '99b79530080343c085b14788e88c49cc', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('ab83728bdd814ca385c2fd12556163e6', '1fc1f50f22334279962458145df7b7eb', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('ac7c3302c72f4a3d9315e97adaa359f2', '9f9aa27c25464907b4c8803b0c96b678', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '1');
INSERT INTO `ordermenu_` VALUES ('ae3c770255bb40b7bcfae1adee2ddc6f', '08bf855165714fd4a0d864a1beb6ff4d', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '1');
INSERT INTO `ordermenu_` VALUES ('b1ad4500b94c478988c1b9d326fb3261', '0e292c451a5445e9a549b9dcfc806556', '油焖茄子', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('b762693ce7ad430fb918f8769131ab82', '4a6080f588e34233b86042b3d270dd33', '雪碧', '8.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('b884a20c968042018db8e7758b083d19', '0016b467769148f6913389b2ebed36d5', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('b8dff4ef1fb347edb20abda41c68835a', '9ed953d876634a0cb3302a4d60e29684', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('badb6bb2df7f4baea273416636391bba', '35e64af9567949d98d665891e39f0b99', '玉米排骨汤', '28.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('bd2f06470d8a4a6297e20306dc44ba86', '80612557c3dd461e9cbd68c756d2b44f', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '1');
INSERT INTO `ordermenu_` VALUES ('bd81e19b06744ec9a512320202b22fe2', 'bab58ba7ae064e45aa0143dc595c41a7', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('bf8263b44cac489ba4c78ad4aa5a3995', 'a43bdad50e9743a8a5385cb517c21a93', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('bfca59e646f04278b3116020cc323c97', '404ef615914d4570a9b2cea4c49aad71', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('c0b94b75de0c4b058ed3aa3911a5fcdf', '0e292c451a5445e9a549b9dcfc806556', '筒子骨海带汤', '38.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('c2fa5dc02b30430d976480b72274bd5f', '99b79530080343c085b14788e88c49cc', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('c38fe9f982cd41829f3b252f1024004d', '9ed953d876634a0cb3302a4d60e29684', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('c3cb1fe9f73942e68b30228424c5d9ca', '12d1f4327ef449a7b5f3b82c8bfaff89', '烙饼子', '10.00', '超辣', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('c5e6f31cc3ef49f1b821b6a35531b11e', '980f96063aca4d129f818c57f0e999e8', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('c75baa1bdb9e485eab23500509a3e982', 'f0cd4a7cd0e4420687089ec03de415be', '筒子骨海带汤', '38.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('c92eec02755e4188afacab9e44fe62c1', '12d1f4327ef449a7b5f3b82c8bfaff89', '米饭', '2.00', '中辣', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('ccea768722364f1a907f6dbe176d9c29', 'a6c0a86108da487c90b1de01e5aed5d8', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('cdf846131a4f4060a8ef134530fdd0dc', '0e292c451a5445e9a549b9dcfc806556', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('ce5d573da63a4b039132906835ad882c', 'a43bdad50e9743a8a5385cb517c21a93', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('cfcca197ffcb485cb060f123eb576754', '246969aa6a414c08918625617b41f194', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('d120103f658f4ae495c768d28c76f05a', '8ee2c48a2751453d853fbf64378e12dd', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('d131ccd7aad64811a89916173b6f60ed', '760648013471441591c38cc5f53c8507', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('d1463c4e3e264519892f16f40b5939cd', '0e292c451a5445e9a549b9dcfc806556', '炝海带丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('d2649c82b7c44bb484f629cb06f812fa', '5a49ce04af144717a6f1af6133dce7e8', '红油金针菇', '12.00', '', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('d2b6f7bcc48b4f9b8cfc442feb1b5562', 'b2c5672ac938434aa76f5563c97df0c8', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('d3a2415db50945e581011fd5ecb089ea', '246969aa6a414c08918625617b41f194', '炝海带丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('d559ed3ec3054d6c88454d52de4b4471', '404ef615914d4570a9b2cea4c49aad71', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('d6ccc92edaf446a8a97595e9b4a792c5', '09fe0f4e02da4bfeb957b9c43e98ee43', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '1');
INSERT INTO `ordermenu_` VALUES ('d796162a908c4ae9946a27e563743e47', 'abb2b45cfbe44566a1275c7225a4a1a4', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('d86a611a8b5f4eb6a5fd6213f5c36953', '0e292c451a5445e9a549b9dcfc806556', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('d8a41c80910d43a194963f31e262cd31', 'abb2b45cfbe44566a1275c7225a4a1a4', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('d98c90d02dcc426bbcfd66e2c34aaa42', '8012e7ab471f435c9613adbc100ac15b', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('dac34d7d36284bcfa0aff3a3eca3ec45', '4b5b8e8205a243fe911f4aed53d459ea', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('dc2801b065e84582aa7984c73b3b098c', '56572e67f5a9406285ebdc1a6459b56d', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('dcff7ae4549a4415b6c114e41f415c67', 'fd3c278044cc41f2a89b296f685d312f', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('dd054cf45c214530a646288950a8a1d3', 'b92cc1518a774449a1fa749b7f98a44a', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('de03911c59a840cc88e7914328e3e57b', '0e292c451a5445e9a549b9dcfc806556', '尖椒土豆丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('de7de114868642e7a026f51c59ef9bc1', '4a6080f588e34233b86042b3d270dd33', '尖椒土豆丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('df2a24f80cb147ea98a336b660071583', '28dbd50ecf5340279367bbbca2445bc1', '雪碧', '8.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('e33d7e74042e410094f0a50603b898e2', '5567de5f774b41c19bb0ac9ad71b4d55', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('e5eccc87fdc74286a34c98c21a277723', 'c8fd2b12bee545ab9007809a758b9112', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('e5fdab671f9e40608f3288e9b01634fb', '2f02d686b954483d9bd9a71db3046038', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('e8cb8987010141839cfaead63c24b59a', 'b96a4479f93240c6b49c82f714757900', '红油金针菇', '12.00', '', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('ebf16094ed65457dbf7c4efc2ca8a6d7', '532588b50caa42c88620b1097260d4c0', '米饭', '2.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('f0c8709951424f9fab2eb1d61cd277a4', '11d1f5456e034fc6a7e77d0dd6d49768', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('f76da4fa878944118849334b18b39711', '5567de5f774b41c19bb0ac9ad71b4d55', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('f7c46ee45c37496a96a170ebb2de2389', 'fd3c278044cc41f2a89b296f685d312f', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('f82fb68ce30a4b7f8e7e5ef765ba77ee', '980f96063aca4d129f818c57f0e999e8', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('f997e8996dbc46fd906cfd76ff0223a3', '03d7a090e83e492c9fd931ebffddd606', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('fb22eb9aab444d59927fb9b8f9232e1a', '6e9dcc57e20b4851b2d11362a827fc43', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('fb641153d580483b975390944e98e0b0', '1fc1f50f22334279962458145df7b7eb', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('fc3b25ac82904059b2db8d81d1c13139', '8012e7ab471f435c9613adbc100ac15b', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `ordermenu_` VALUES ('fd85dfa6586846d08081eabe5ab7dd0d', 'b2c5672ac938434aa76f5563c97df0c8', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000001', '第一桌', '0', '1', '1', '00000000000000000000000000000001', '2016-12-20 13:58:41');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000002', '第二桌', '0', '1', '1', '00000000000000000000000000000001', '2016-12-20 13:58:58');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000003', '第三桌', '0', '1', '1', '00000000000000000000000000000001', '2016-12-20 13:59:14');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000004', '第四桌', '0', '1', '1', '00000000000000000000000000000001', '2016-12-20 13:59:32');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000005', '第五桌', '0', '1', '1', '00000000000000000000000000000001', '2016-12-20 13:59:48');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000006', '第六桌', '0', '1', '1', '00000000000000000000000000000001', '2016-12-20 14:00:07');
INSERT INTO `xiuse_discount` VALUES ('00000000', '九折', '0', '0.00', '-1', '0', '1', '0', '00000000000000000000000000000000', '2017-03-27 14:40:58');
INSERT INTO `xiuse_discount` VALUES ('00000001', '满百减12', '1', '12.00', '-1', '0', '1', '0', '00000000000000000000000000000001', '2017-03-27 14:42:31');
INSERT INTO `xiuse_member` VALUES ('000000000000000000000000001', '00001', '洋洋洋', '1000.00', '1', '15200856922', null, '123456', '1', '2017-04-01 11:13:59', '00000000000000000000000000000000');
INSERT INTO `xiuse_member` VALUES ('000000000000000000000000002', '00002', '彤彤', '100.00', '1', '13200339999', null, '123456', '1', '2017-03-16 11:14:51', '00000000000000000000000000000000');
INSERT INTO `xiuse_member` VALUES ('000000000000000000000000003', '00003', '拉拉', '45.00', '1', '13032343234', '', '654321', '0', '2017-02-15 11:15:34', '00000000000000000000000000000001');
INSERT INTO `xiuse_member` VALUES ('000000000000000000000000004', '00004', 'test1', '100.00', '1', '13522114455', null, '123', '1', '2017-04-04 13:44:28', '00000000000000000000000000000001');
INSERT INTO `xiuse_member` VALUES ('000000000000000000000000005', '00005', 'test2', '88.00', '1', null, null, '321', '1', '2017-04-07 13:45:57', '00000000000000000000000000000001');
INSERT INTO `xiuse_memberclassify` VALUES ('1', '1', '铂金卡', null, '1', '2017-03-23 15:33:38', '0', '00000000000000000000000000000001');
INSERT INTO `xiuse_memberclassify` VALUES ('2', '2', '黄金卡', null, '0', '2017-04-05 15:11:50', '0', '00000000000000000000000000000001');
INSERT INTO `xiuse_memberclassify` VALUES ('3', '3', '银卡', null, '0', '2017-04-05 15:12:34', '0', '00000000000000000000000000000001');
INSERT INTO `xiuse_memberclassify` VALUES ('4', '4', '钻石卡', null, '0', '2017-04-05 15:13:09', '0', '00000000000000000000000000000001');
INSERT INTO `xiuse_menuclassify` VALUES ('001', '凉菜', '1', '0', '凉菜', '000000000000000000000001', '2016-12-20 11:07:37');
INSERT INTO `xiuse_menuclassify` VALUES ('002', '热菜', '2', '0', '热菜', '000000000000000000000001', '2016-12-20 11:08:27');
INSERT INTO `xiuse_menuclassify` VALUES ('003', '饮料', '3', '0', '饮料', '000000000000000000000001', '2016-12-20 11:14:09');
INSERT INTO `xiuse_menuclassify` VALUES ('004', '主食', '4', '0', '主食', '000000000000000000000001', '2016-12-20 10:54:48');
INSERT INTO `xiuse_menus` VALUES ('1001', '红油金针菇', '100', '12.00', null, '', null, '1', null, '0', '0', '00000000000000000000000000000001', '001', '2016-12-20 13:35:48');
INSERT INTO `xiuse_menus` VALUES ('1002', '炝海带丝', '100', '10.00', null, '', null, '2', null, '0', '0', '00000000000000000000000000000001', '001', '2016-12-20 13:36:45');
INSERT INTO `xiuse_menus` VALUES ('1003', '油炸花生米', '100', '10.00', null, '', null, '3', null, '0', '0', '00000000000000000000000000000001', '001', '2016-12-20 13:36:53');
INSERT INTO `xiuse_menus` VALUES ('1004', '糖醋萝卜', '100', '10.00', null, '', null, '4', null, '0', '0', '00000000000000000000000000000001', '001', '2016-12-20 13:37:54');
INSERT INTO `xiuse_menus` VALUES ('2001', '尖椒土豆丝', '100', '10.00', null, '', null, '1', null, '0', '0', '00000000000000000000000000000001', '002', '2016-12-20 13:39:04');
INSERT INTO `xiuse_menus` VALUES ('2002', '油焖茄子', '100', '16.00', null, '', null, '2', null, '0', '0', '00000000000000000000000000000001', '002', '2016-12-20 13:39:46');
INSERT INTO `xiuse_menus` VALUES ('2003', '西红柿炒鸡蛋', '100', '16.00', null, '', null, '3', null, '0', '0', '00000000000000000000000000000001', '002', '2016-12-20 13:40:17');
INSERT INTO `xiuse_menus` VALUES ('2004', '鱼香肉丝', '100', '25.00', null, '', null, '4', null, '0', '0', '00000000000000000000000000000001', '002', '2016-12-20 13:41:18');
INSERT INTO `xiuse_menus` VALUES ('3001', '雪碧', '100', '8.00', null, '', null, '1', null, '0', '0', '00000000000000000000000000000001', '003', '2016-12-20 11:16:09');
INSERT INTO `xiuse_menus` VALUES ('3002', '可乐', '100', '8.00', null, '', null, '2', null, '0', '0', '00000000000000000000000000000001', '003', '2016-12-20 13:28:29');
INSERT INTO `xiuse_menus` VALUES ('3003', '玉米排骨汤', '100', '28.00', null, '', null, '3', null, '0', '0', '00000000000000000000000000000001', '003', '2016-12-20 13:30:47');
INSERT INTO `xiuse_menus` VALUES ('3004', '筒子骨海带汤', '100', '38.00', null, '', null, '4', null, '0', '0', '00000000000000000000000000000001', '003', '2016-12-20 13:31:56');
INSERT INTO `xiuse_menus` VALUES ('4001', '饺子', '100', '15.00', null, '', null, '1', null, '0', '0', '00000000000000000000000000000001', '004', '2016-12-20 13:42:50');
INSERT INTO `xiuse_menus` VALUES ('4002', '龙须面', '100', '10.00', null, '', null, '2', null, '0', '0', '00000000000000000000000000000001', '004', '2016-12-20 13:43:18');
INSERT INTO `xiuse_menus` VALUES ('4003', '扬州炒饭', '100', '10.00', null, '', null, '3', null, '0', '0', '00000000000000000000000000000001', '004', '2016-12-20 13:43:54');
INSERT INTO `xiuse_menus` VALUES ('4004', '米饭', '100', '2.00', null, '', null, '4', null, '0', '0', '00000000000000000000000000000001', '004', '2016-12-20 13:44:35');
INSERT INTO `xiuse_menus` VALUES ('4005', '烙饼子', '100', '10.00', null, '', null, '5', null, '0', '0', '00000000000000000000000000000001', '004', '2016-12-20 13:45:20');
INSERT INTO `xiuse_recharge` VALUES ('0000000000000001', '1', '1000.00', '1000.00', '000000000000000000000000001', '00001', '2017-04-01 11:13:59', null);
INSERT INTO `xiuse_recharge` VALUES ('0000000000000002', '1', '100.00', '100.00', '000000000000000000000000002', '00002', '2017-03-16 11:14:51', null);
INSERT INTO `xiuse_recharge` VALUES ('0000000000000003', '1', '45.00', '17.00', '000000000000000000000000003', '00003', '2017-02-15 11:15:34', null);
INSERT INTO `xiuse_recharge` VALUES ('0000000000000004', '2', '100.00', '9.00', '000000000000000000000000004', '00004', '2017-04-04 13:44:28', null);
INSERT INTO `xiuse_recharge` VALUES ('0000000000000005', '1', '88.00', '88.00', '000000000000000000000000005', '00005', '2017-04-07 13:45:57', null);
INSERT INTO `xiuse_restaurant` VALUES ('00000000000000000000000000000000', 'TestRN', '010-88888888', '北京', null, '2016-12-12 13:22:43');
INSERT INTO `xiuse_restaurant` VALUES ('00000000000000000000000000000001', 'TestR1', '010-12345678', '北京', null, '2016-12-20 11:16:58');
INSERT INTO `xiuse_user` VALUES ('00000000000000000000000000000000', 'admin', 'weixin', '15811111111', 'admin@163.com', '123', '00000000000000000000000000000001', '0', '-1', '0', null, '2016-12-12 13:20:42');
INSERT INTO `xiuse_user` VALUES ('00000000000000000000000000000001', 'test', 'weixin', '15811112222', 'Rita@163.com', '123', '00000000000000000000000000000001', '1', '-1', '0', null, '2017-03-24 16:20:42');

-- ----------------------------
-- Trigger structure for GetBeforeBalance
-- ----------------------------
DELIMITER ;;
CREATE TRIGGER `GetBeforeBalance` BEFORE INSERT ON `xiuse_recharge` FOR EACH ROW set new.BeforeBalance=(select MemberAmount from xiuse_member where xiuse_member.MemberId= MemberId);;
DELIMITER ;

-- ----------------------------
-- Trigger structure for SetAmount
-- ----------------------------
DELIMITER ;;
CREATE TRIGGER `SetAmount` AFTER INSERT ON `xiuse_recharge` FOR EACH ROW update xiuse_member set  MemberAmount=RechargeAmount+BeforeBalance where MemberId=MemberId;;
DELIMITER ;
