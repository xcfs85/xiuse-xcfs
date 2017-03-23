/*
MySQL Data Transfer
Source Host: localhost
Source Database: xiuse
Target Host: localhost
Target Database: xiuse
Date: 2017/3/23 11:33:34
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
  `ConsumptionRecordsId` char(32) NOT NULL,
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
  `AccountsPayable` decimal(12,2) NOT NULL COMMENT '应付款',
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
  `ClassifyTag` varchar(200) DEFAULT NULL,
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
INSERT INTO `order_` VALUES ('00000000000000000000000000000001', '00000000000000000000000000000001', '132.00', '100.00', '0000000000.00', '32', '1', '100.00', '0.00', '0.00', '0.00', '0.00', '0', '2016-12-21 11:22:14', '2016-12-04 14:20:15', '00000000000000000000000000000000', null);
INSERT INTO `order_` VALUES ('00000000000000000000000000000002', '00000000000000000000000000000002', '122.00', '90.00', '0000000000.00', '32', '0', '0.00', '90.00', '0.00', '0.00', '0.00', '0', '2017-01-20 11:25:37', '2017-01-20 12:25:43', '00000000000000000000000000000000', null);
INSERT INTO `order_` VALUES ('00000000000000000000000000000003', '00000000000000000000000000000002', '37.00', '37.00', '0000000000.00', '0', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-01-20 09:34:30', '2017-01-20 09:49:50', '00000000000000000000000000000000', null);
INSERT INTO `order_` VALUES ('00000000000000000000000000000004', '00000000000000000000000000000003', '5.00', '5.00', '0000000000.00', '5', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-01-20 09:36:38', null, '00000000000000000000000000000000', null);
INSERT INTO `ordermenu_` VALUES ('00000000000000000000000000100001', '00000000000000000000000000000001', '饺子', '0.00', null, '1', null, null, '0', null, null, null, '0');
INSERT INTO `ordermenu_` VALUES ('00000000000000000000000000100002', '00000000000000000000000000000001', '饺子', '15.00', '正常', '2', null, '猪肉韭菜馅、猪肉白菜馅、西葫芦鸡蛋陷', '0', null, null, null, '0');
INSERT INTO `ordermenu_` VALUES ('00000000000000000000000000100003', '00000000000000000000000000000001', '鱼香肉丝', '25.00', '正常', '1', null, '猪肉、胡萝卜、木耳，酸甜可口', '0', null, null, null, '0');
INSERT INTO `ordermenu_` VALUES ('00000000000000000000000000100004', '00000000000000000000000000000001', '筒子骨海带汤', '38.00', '正常', '1', null, '猪肉、海带，补钙利器', '0', null, null, null, '0');
INSERT INTO `ordermenu_` VALUES ('00000000000000000000000000100005', '00000000000000000000000000000001', '玉米排骨汤', '28.00', '正常', '1', null, null, '0', null, null, null, '0');
INSERT INTO `ordermenu_` VALUES ('00000000000000000000000000100006', '00000000000000000000000000000001', '西红柿炒鸡蛋', '16.00', '正常', '1', null, '营养专家所评最具营养的菜~~', '0', null, null, null, '0');
INSERT INTO `ordermenu_` VALUES ('00000000000000000000000000100007', '00000000000000000000000000000001', '米饭', '2.00', '正常', '5', null, null, '0', null, null, null, '0');
INSERT INTO `ordermenu_` VALUES ('00000000000000000000000000200001', '00000000000000000000000000000002', '米饭', '2.00', '正常', '3', null, null, '0', null, null, null, '0');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000001', '第一桌', '0', '1', '1', '00000000000000000000000000000001', '2016-12-20 13:58:41');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000002', '第二桌', '0', '1', '1', '00000000000000000000000000000001', '2016-12-20 13:58:58');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000003', '第三桌', '0', '1', '1', '00000000000000000000000000000001', '2016-12-20 13:59:14');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000004', '第四桌', '0', '1', '0', '00000000000000000000000000000001', '2016-12-20 13:59:32');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000005', '第五桌', '0', '1', '0', '00000000000000000000000000000001', '2016-12-20 13:59:48');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000006', '第六桌', '0', '1', '0', '00000000000000000000000000000001', '2016-12-20 14:00:07');
INSERT INTO `xiuse_menuclassify` VALUES ('001', '凉菜', '1', '0', null, '000000000000000000000001', '2016-12-20 11:07:37');
INSERT INTO `xiuse_menuclassify` VALUES ('002', '热菜', '2', '0', null, '000000000000000000000001', '2016-12-20 11:08:27');
INSERT INTO `xiuse_menuclassify` VALUES ('003', '饮料', '3', '0', null, '000000000000000000000001', '2016-12-20 11:14:09');
INSERT INTO `xiuse_menuclassify` VALUES ('004', '主食', '4', '0', null, '000000000000000000000001', '2016-12-20 10:54:48');
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
INSERT INTO `xiuse_restaurant` VALUES ('00000000000000000000000000000000', 'TestRN', '010-88888888', '北京', null, '2016-12-12 13:22:43');
INSERT INTO `xiuse_restaurant` VALUES ('00000000000000000000000000000001', 'TestR1', '010-12345678', '北京', null, '2016-12-20 11:16:58');
INSERT INTO `xiuse_user` VALUES ('00000000000000000000000000000000', 'admin', 'weixin', '15811111111', 'admin@163.com', 'flaskjdflj===', '00000000000000000000000000000000', '0', '-1', '0', null, '2016-12-12 13:20:42');
