/*
MySQL Data Transfer
Source Host: localhost
Source Database: xiuse
Target Host: localhost
Target Database: xiuse
Date: 2017/4/21 16:49:06
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
  `OrderState` int(1) NOT NULL DEFAULT '0' COMMENT '订单状态（0，未支付；1，已支付;2,退单）',
  `Cash` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '现金付款',
  `BankCard` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '银行卡付款',
  `WeiXin` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '微信付款',
  `Alipay` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '支付宝付款',
  `MembersCard` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '会员卡付款',
  `ClearDeskState` int(1) NOT NULL DEFAULT '0' COMMENT '0,没有清台；1，已经清台；',
  `OrderbeginTime` datetime NOT NULL COMMENT '下单时间',
  `OrderEndTime` datetime DEFAULT NULL COMMENT '用餐结束时间',
  `ServiceUserId` char(32) NOT NULL COMMENT '服务员的Id',
  `CustomerNum` int(11) DEFAULT NULL COMMENT '顾客数量',
  `OrderReMark` varchar(5000) DEFAULT NULL COMMENT '结账的备注',
  `Payment` decimal(12,0) DEFAULT '0' COMMENT '付款金额',
  `ChangePay` decimal(12,0) DEFAULT '0' COMMENT '找零',
  `Tip` decimal(12,0) DEFAULT '0' COMMENT '小费',
  `SameChange` decimal(12,0) DEFAULT '0' COMMENT '抹零',
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
  `DiscountContent` decimal(12,2) DEFAULT '0.00' COMMENT '折扣金额',
  `DiscountType` smallint(1) DEFAULT NULL COMMENT '折扣类型(0:百分比 1：固定金额)',
  `MenuServing` smallint(1) DEFAULT '0' COMMENT '是否上菜（0：没上；1：上菜）',
  `MenuId` char(32) DEFAULT NULL COMMENT '菜品ID',
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
  `DiscountMenus` varchar(20000) DEFAULT '' COMMENT '折扣菜品(-1，全部餐品；（菜品ID,菜品ID,菜品ID,菜品ID,菜品ID）,部门折扣)',
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
  `MemberPassword` varchar(16) NOT NULL COMMENT '会员卡密码',
  `MemberState` int(1) NOT NULL DEFAULT '1' COMMENT '会员状态（0，禁用；1，启用；2,删除）',
  `MemberTime` datetime NOT NULL COMMENT '会员创建时间',
  `RestaurantId` char(32) NOT NULL COMMENT '餐厅Id',
  `MemberEmail` varchar(200) DEFAULT NULL COMMENT '会员的Email',
  `MemberEnabledPassWord` int(1) NOT NULL DEFAULT '0' COMMENT '是否启用密码。（0，不启用；1，启用密码）',
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
  `DelTag` int(2) NOT NULL DEFAULT '0' COMMENT '删除标志，(0,启用；1，停用；2，删除。)',
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
  `SaleState` smallint(1) DEFAULT '0' COMMENT '菜品销售状态（1售完，0未售完）',
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
  `RechargeType` int(1) NOT NULL COMMENT '充值类型(1,现金；2，银行卡；3，微信；4，支付宝；)',
  `RechargeAmount` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '充值金额',
  `Balance` decimal(12,2) NOT NULL DEFAULT '0.00' COMMENT '可用余额',
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
  `UserRole` smallint(1) NOT NULL DEFAULT '1' COMMENT '0,是管理员；1，是员工。',
  `ParentUserId` varchar(32) NOT NULL DEFAULT '-1' COMMENT '上级用户Id，顶级为-1',
  `OwnRestaurant` smallint(1) DEFAULT '0' COMMENT '餐厅所有权（0，无；1，所有；）',
  `DelTag` smallint(4) DEFAULT '0' COMMENT '员工状态（0，正常；1，禁用；2，删除。）',
  `Time` datetime NOT NULL COMMENT '修改时间',
  PRIMARY KEY (`UserId`),
  KEY `key-004` (`RestaurantId`),
  CONSTRAINT `key-004` FOREIGN KEY (`RestaurantId`) REFERENCES `xiuse_restaurant` (`RestaurantId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Procedure structure for updateRecharge
-- ----------------------------
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `updateRecharge`(in rechargeId varchar(50),
in rechargeType int,
in rechargeAmount decimal(8,2),
in memberId varchar(50),
in memberCardNo varchar(50),
in rechargeTime datetime)
begin
Insert Into xiuse_recharge(RechargeId,RechargeType,RechargeAmount,MemberId,MemberCardNo,RechargeTime)
                                        values(rechargeId,rechargeType,rechargeAmount,memberId,memberCardNo,rechargeTime);

update xiuse_recharge set BeforeBalance=(select MemberAmount from xiuse_member where  MemberId=memberId  )where RechargeId=rechargeId;
update xiuse_member set MemberAmount=(MemberAmount+rechargeAmount) where MemberId=memberId;
update xiuse_recharge set Balance=(select MemberAmount from xiuse_member where MemberId=memberId ) where RechargeId=rechargeId;

end;;
DELIMITER ;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `memberconsumption` VALUES ('0000000000000000000001', '00003', '000000000000000000000000003', '1', '28.00', '17.00', '2017-04-04 10:26:01', '114ba6d863de46f8b389c5f8266d07fa');
INSERT INTO `memberconsumption` VALUES ('0000000000000000000002', '00004', '000000000000000000000000004', '1', '91.00', '9.00', '2017-04-05 10:28:56', '1e8bf48635b64ac9a7c9ae2668c4b7a0');
INSERT INTO `order_` VALUES ('004ae67871ef4f139ba6d171596e900c', '00000000000000000000000000000001', '19.00', '19.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-19 10:14:45', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('00797148f89549e8ac4b127c2c0501d9', '00000000000000000000000000000007', '114.00', '114.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-17 09:06:48', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('0ce37c475dc645a4ae0d011ff4f1ee1a', 'b11da6e37f3a4c09ba36bd18b5b7fc07', '27.00', '27.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-20 09:58:03', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('15e601c228ba4cb4a71035d8fb6f4c0c', '00000000000000000000000000000007', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-11 15:20:07', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('1ffee023b59946d395d653f49e20c402', 'b11da6e37f3a4c09ba36bd18b5b7fc07', '41.00', '41.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-20 16:26:54', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('2357aad0158d403ab83eef73c586f15b', '00000000000000000000000000000002', '16.00', '16.00', '0000000000.00', '1', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-14 08:59:20', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('2b9e765d47714ba5955e463798d2dcbf', '00000000000000000000000000000002', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 15:41:10', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('2bdcda192e56469ba4595bcd2fecac99', '00000000000000000000000000000004', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-12 10:21:19', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('34775b3b6f5e4a379cbff8258d27d6ff', '00000000000000000000000000000002', '120.00', '120.00', '0000000000.00', '10', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 15:15:34', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('3789942207bc4a28abedf65017d4fe03', '00000000000000000000000000000003', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-18 17:28:40', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('37909b82a414427dbfada60f301d2f47', '00000000000000000000000000000005', '212.00', '212.00', '0000000000.00', '15', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-11 16:08:36', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('3c258eee738f4b26943bfa23527e6c8e', '00000000000000000000000000000002', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-11 15:19:06', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('3df4ea4042d04c8bb0279a572e313b11', '00000000000000000000000000000005', '20.00', '20.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-12 10:22:30', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('445d50a6d3544d6dad08f6724965730a', 'bdddf27124c24bb9a84e0181c73fa225', '27.00', '27.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-20 09:01:02', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('483b7f817642455c95ee102fb368afa0', '00000000000000000000000000000002', '56.00', '56.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 13:01:21', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('4a93235784e54963a81d34f8becf38ea', '00000000000000000000000000000001', '47.00', '47.00', '0000000000.00', '5', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-20 09:00:04', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('52e51af155b74de3bc1626c042546a0e', '00000000000000000000000000000006', '12.00', '12.00', '0000000000.00', '1', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 15:36:47', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('5a1abe1670d04b88afd1d1db7aa0b054', '00000000000000000000000000000002', '31.00', '31.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 09:16:29', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('633f2db9d13d4e81a6f2d3bc54b0f014', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 15:37:11', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('63df8ddb4a7c4fe193ab4458a11e6b70', '00000000000000000000000000000002', '192.00', '192.00', '0000000000.00', '16', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 15:21:34', null, '00000000000000000000000000000000', '8', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('6a5fd27aaf644745aebf0b5394219de2', 'efd0619ae7d6423694ee3e2d60d726db', '22.00', '22.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-20 08:53:54', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('6a99fb9babf64a9180560e5db6511c81', '00000000000000000000000000000002', '14.00', '14.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-19 16:54:36', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('720462769e8d450a8aef7b538027d6a6', '00000000000000000000000000000001', '22.00', '22.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-11 16:33:14', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('757cd506fe9a470795e9e8549f624234', '00000000000000000000000000000002', '120.00', '120.00', '0000000000.00', '10', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 15:12:28', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('7a0da426141e453fb7411f801b60ac76', '00000000000000000000000000000002', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 15:43:00', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('7fc82ba264f141b188d154904656d931', '00000000000000000000000000000002', '54.00', '54.00', '0000000000.00', '5', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-11 16:23:22', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('82bcb8406188477e869b4a476939467f', '00000000000000000000000000000004', '34.00', '34.00', '0000000000.00', '4', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-21 15:29:10', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('83e6f45be89d444ea8fb10084a5dfcee', '00000000000000000000000000000001', '58.00', '58.00', '0000000000.00', '5', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-12 09:39:10', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('85bff56e44994405ac23125edec2b23e', '00000000000000000000000000000001', '47.00', '47.00', '0000000000.00', '5', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-21 15:25:23', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('861dc2f5b3564b849ba6339e8d616f0b', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-17 09:03:54', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('8753574fc7a54efaa470533b666d9ab9', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 16:17:46', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('8cc9a18580d340719a59260a32154641', '00000000000000000000000000000002', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-18 13:47:17', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('91965c33ae6a49a5bf8119e22fcbfb70', '00000000000000000000000000000006', '26.00', '26.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-12 10:23:49', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('a7bfd275c0364cffa702b6497d1b410d', '00000000000000000000000000000001', '43.00', '43.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 13:03:43', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('b6322984d95046ee93bb3ffd43dbf909', '00000000000000000000000000000001', '26.00', '26.00', '0000000000.00', '4', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-17 09:03:38', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('be370bf0bd44416597fee48690d3b690', '00000000000000000000000000000002', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-19 10:14:53', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('c38e598c7f83499a87a56fd87ef67f19', '00000000000000000000000000000002', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 15:45:38', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('cda5b2db4c2140bc836629193ce337da', '00000000000000000000000000000001', '22.00', '22.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 08:59:47', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('cf1d5569fa014a398210ee65c3543cfe', '00000000000000000000000000000002', '132.00', '132.00', '0000000000.00', '11', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 15:24:20', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('cfc52f2de0c74ebb83e192f091d7c9d2', '1ab6654790c74da8ab3524fcf300b1e3', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-20 08:53:07', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('d26be4e6188b47f29bc37f56d1253a65', '00000000000000000000000000000007', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-14 08:58:01', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('dec2289a8e0d43ac983556e3abedb5bb', '00000000000000000000000000000003', '28.00', '28.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-12 10:04:17', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('e0e78ec04c9e4c8d97ea20ce705d20a0', '00000000000000000000000000000002', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-12 09:33:00', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('e6feee5e8087409b882cd27c6f72f038', '00000000000000000000000000000007', '43.00', '43.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-07 16:58:54', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('e846e30621414d6c9ec7c58f32d7f9c0', '00000000000000000000000000000001', '28.00', '28.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-18 09:01:40', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('ed5e83643fce4135b706c9f479413de3', '353ef11ba2bd462ba11e814efe6ad997', '53.00', '53.00', '0000000000.00', '4', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-21 15:22:29', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('ed710fefa923417086b3b932bcbb34de', '00000000000000000000000000000005', '35.00', '35.00', '0000000000.00', '2', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-07 17:12:46', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('f3dd7b525f3b491fb5582d0d08a23b74', '00000000000000000000000000000002', '12.00', '12.00', '0000000000.00', '1', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-11 17:00:34', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('f42ed1832ef94992ac84e749b1194df8', '00000000000000000000000000000002', '43.00', '43.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-10 15:11:33', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `order_` VALUES ('f769af6d60e1429f84232b97bd7fdadb', '00000000000000000000000000000002', '45.00', '45.00', '0000000000.00', '3', '0', '0.00', '0.00', '0.00', '0.00', '0.00', '0', '2017-04-18 11:36:41', null, '00000000000000000000000000000000', '1', null, '0', '0', '0', '0');
INSERT INTO `ordermenu_` VALUES ('016a322b6a05473394de8d9b681f1529', '483b7f817642455c95ee102fb368afa0', '可乐', '8.00', '正常', '1', '', '', '0', '', '0.00', '0', '1', '3002');
INSERT INTO `ordermenu_` VALUES ('0220ef33feed4a719038ca4dd48b9434', 'e6feee5e8087409b882cd27c6f72f038', '饺子', '15.00', '正常', '2', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('029ea4d1b83049a3b098b99cf2a18542', 'ed5e83643fce4135b706c9f479413de3', '啊啊阿道夫', '10.00', '正常', '1', 'blob:http%3A//127.0.0.1%3A8020/7cf27a85-87e2-48ea-9923-2d6786439978', '', '0', '', '0.00', '0', '0', 'c2a678c49e25452cb1ec2d3c4104a88f');
INSERT INTO `ordermenu_` VALUES ('03b434df4b154353ab2b522368720698', 'dec2289a8e0d43ac983556e3abedb5bb', '米饭', '2.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4004');
INSERT INTO `ordermenu_` VALUES ('07cd4fdc0afa42d19b03835029faa727', '720462769e8d450a8aef7b538027d6a6', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('07cfd996dd374e40b0fa824886d97108', 'cf1d5569fa014a398210ee65c3543cfe', '红油金针菇', '12.00', '正常', '12', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('0812d24778384630be27fe85d3204e18', 'cfc52f2de0c74ebb83e192f091d7c9d2', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '1', '2003');
INSERT INTO `ordermenu_` VALUES ('087cba95fe3848febaecb2f2c16fe017', '6a5fd27aaf644745aebf0b5394219de2', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4002');
INSERT INTO `ordermenu_` VALUES ('09f6f5275aff4150bb11f4ef89742479', '37909b82a414427dbfada60f301d2f47', '尖椒土豆丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2001');
INSERT INTO `ordermenu_` VALUES ('0d6e57dc9c00491fbb07e1b8567c63fd', 'e0e78ec04c9e4c8d97ea20ce705d20a0', '红油金针菇', '12.00', '正常', '10', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('0f451664da6342b5b145241cab7c7b92', 'cfc52f2de0c74ebb83e192f091d7c9d2', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('0ffe1d7173c64c719ee6eab71f59422e', '6a5fd27aaf644745aebf0b5394219de2', '米饭', '2.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4004');
INSERT INTO `ordermenu_` VALUES ('13923b42b5c1421faac2691998483a4e', '00797148f89549e8ac4b127c2c0501d9', '带图片带标签2', '111.00', '正常', '1', 'C:fakepathTulips.jpg', '', '0', '', '0.00', '0', '1', 'a705b736b7b34284bfcb3d9e711e3fe1');
INSERT INTO `ordermenu_` VALUES ('13b9f1139c29488c8bb4d9fdcfa52aab', '483b7f817642455c95ee102fb368afa0', '玉米排骨汤', '28.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '3003');
INSERT INTO `ordermenu_` VALUES ('13f8618498aa4b4e9639d8ab771d1860', '8cc9a18580d340719a59260a32154641', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('173ad6bc435c41409b7f6c762870baf2', 'e846e30621414d6c9ec7c58f32d7f9c0', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('176e123f32214c28a211f1a83f04352c', '7a0da426141e453fb7411f801b60ac76', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('18c076136704471b93cf54ecf73b3377', '37909b82a414427dbfada60f301d2f47', '可乐', '8.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '3002');
INSERT INTO `ordermenu_` VALUES ('1a50533e1b5b4d349de4cbdecceeb53e', '3789942207bc4a28abedf65017d4fe03', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('1b820288b68440bda6bd11172ad4ae59', '6a5fd27aaf644745aebf0b5394219de2', '玉米排骨汤', '28.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '3003');
INSERT INTO `ordermenu_` VALUES ('1ba4e074db5b42e29890d9c0c4fd1a80', '0ce37c475dc645a4ae0d011ff4f1ee1a', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4002');
INSERT INTO `ordermenu_` VALUES ('1bd0032415584309b9b715948c2ec579', '6a5fd27aaf644745aebf0b5394219de2', '大师傅', '4.00', '正常', '1', 'blob:http%3A//127.0.0.1%3A8020/5aed0e31-dee6-431f-b947-37e6b36589e9', '122233344', '0', '', '0.00', '0', '0', 'e4ee2ab18bd445fc820cb7144762664e');
INSERT INTO `ordermenu_` VALUES ('1bf64ecf7ac04b399a5292538bab43b2', '483b7f817642455c95ee102fb368afa0', '油炸花生米', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1003');
INSERT INTO `ordermenu_` VALUES ('1d401728b7dd41d281a759648948b5fa', '7fc82ba264f141b188d154904656d931', '龙须面', '10.00', '微辣', '1', '', '', '0', '', '0.00', '0', '0', '4002');
INSERT INTO `ordermenu_` VALUES ('1edfac400cc248dcb876f73e12755484', '0ce37c475dc645a4ae0d011ff4f1ee1a', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4001');
INSERT INTO `ordermenu_` VALUES ('20f2054ed7104119a122683891da3041', 'ed710fefa923417086b3b932bcbb34de', '炝海带丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('268d0e6aabfe4d6f9d5221707c33acf5', '6a5fd27aaf644745aebf0b5394219de2', '油焖茄子', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2002');
INSERT INTO `ordermenu_` VALUES ('28f49cfa2d88439db9cdaa497cc8b798', '85bff56e44994405ac23125edec2b23e', '扬州炒饭', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4003');
INSERT INTO `ordermenu_` VALUES ('2cc905beeef4495d86c9949d60329c4d', '83e6f45be89d444ea8fb10084a5dfcee', '烙饼子', '10.00', '正常', '3', '', '', '0', '', '0.00', '0', '0', '4005');
INSERT INTO `ordermenu_` VALUES ('2ec679635aa949d59e6980d691970256', '6a5fd27aaf644745aebf0b5394219de2', '雪碧', '8.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '3001');
INSERT INTO `ordermenu_` VALUES ('302f620ce29b413ca3d9ce1a32c13b1f', '37909b82a414427dbfada60f301d2f47', '炝海带丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1002');
INSERT INTO `ordermenu_` VALUES ('3250c475dc3a4917b309ab658fde2889', '445d50a6d3544d6dad08f6724965730a', '米饭', '2.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4004');
INSERT INTO `ordermenu_` VALUES ('3309c9c4957e409ebe77b4111625d4d0', '6a5fd27aaf644745aebf0b5394219de2', '尖椒土豆丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2001');
INSERT INTO `ordermenu_` VALUES ('35541e135ae643b386ab7c8e07879372', 'c38e598c7f83499a87a56fd87ef67f19', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('35f788cd8ae34ac5b0c2cb04e75afa19', 'dec2289a8e0d43ac983556e3abedb5bb', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('369bce373e6c4cb8ba3dcc1916d21526', '3c258eee738f4b26943bfa23527e6c8e', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('36ca217c0f3449cf8cc00f8805735d73', 'f3dd7b525f3b491fb5582d0d08a23b74', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('38577bb6e5f74af2a793daa6266a3ddc', 'd26be4e6188b47f29bc37f56d1253a65', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('3a5936150a6540a2916ff8f557c70add', 'f42ed1832ef94992ac84e749b1194df8', '饺子', '15.00', '正常', '0', '', '', '0', '', '0.00', '0', '0', '4001');
INSERT INTO `ordermenu_` VALUES ('3f2d981ca79243d099d6e3c96f1376aa', '4a93235784e54963a81d34f8becf38ea', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4001');
INSERT INTO `ordermenu_` VALUES ('408c2716c35540228e557e34440f327f', '7a0da426141e453fb7411f801b60ac76', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('4930284ca6744c9e97ddb23be6246b50', '633f2db9d13d4e81a6f2d3bc54b0f014', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('4a38d5eae840434289f8851743436165', '4a93235784e54963a81d34f8becf38ea', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4002');
INSERT INTO `ordermenu_` VALUES ('4b69104aa7cf450580827c64fac2224e', '483b7f817642455c95ee102fb368afa0', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '1', '4001');
INSERT INTO `ordermenu_` VALUES ('4c0b366c90df409ab1ef137ee798032f', '720462769e8d450a8aef7b538027d6a6', '尖椒土豆丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2001');
INSERT INTO `ordermenu_` VALUES ('5081ad6fe55f461c81a3d9384cd47d30', '7fc82ba264f141b188d154904656d931', '尖椒土豆丝', '10.00', '较咸', '1', '', '', '0', '', '0.00', '0', '0', '2001');
INSERT INTO `ordermenu_` VALUES ('550036873ddf4bc195d3c7ef796e0bcf', '483b7f817642455c95ee102fb368afa0', '油焖茄子', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2002');
INSERT INTO `ordermenu_` VALUES ('57bf17fdbb6b4268bcaec8f7d73fd826', '4a93235784e54963a81d34f8becf38ea', '米饭', '2.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4004');
INSERT INTO `ordermenu_` VALUES ('5988ca1eca8645b9b654d01764838133', '37909b82a414427dbfada60f301d2f47', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2004');
INSERT INTO `ordermenu_` VALUES ('5bb2e35a5d094384a5ab73006845c599', '6a5fd27aaf644745aebf0b5394219de2', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('5cbffd615962447797f364290c6d5966', 'e0e78ec04c9e4c8d97ea20ce705d20a0', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('5d5a5d67f009474bb3add2c49529c06d', '483b7f817642455c95ee102fb368afa0', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('5d620c9036c24c7bb7ab014ef51dc4b2', '0ce37c475dc645a4ae0d011ff4f1ee1a', '米饭', '2.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4004');
INSERT INTO `ordermenu_` VALUES ('5dc27e275885457b86d165b7882ab65e', 'ed710fefa923417086b3b932bcbb34de', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('5e7580853d634befaf6b307f64ea0cbf', '004ae67871ef4f139ba6d171596e900c', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('61f7d2b352c24370a1136d1375a8076f', 'ed5e83643fce4135b706c9f479413de3', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4001');
INSERT INTO `ordermenu_` VALUES ('6550b2616b03407287dd7d4e4edfb263', '15e601c228ba4cb4a71035d8fb6f4c0c', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('66c5caa2cc1743d8b349f938aa4c2402', 'd26be4e6188b47f29bc37f56d1253a65', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('66c73b8efe504b9b8ed32ecfb610e621', '82bcb8406188477e869b4a476939467f', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('6bc582e62b7c483da5144475e112fe0d', 'e846e30621414d6c9ec7c58f32d7f9c0', '啊啊阿道夫', '10.00', '正常', '1', 'blob:http%3A//127.0.0.1%3A8020/7cf27a85-87e2-48ea-9923-2d6786439978', '', '0', '', '0.00', '0', '0', 'c2a678c49e25452cb1ec2d3c4104a88f');
INSERT INTO `ordermenu_` VALUES ('6c6dff55329c49aebbe9d9cba2bc7d63', '6a5fd27aaf644745aebf0b5394219de2', '可乐', '8.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '3002');
INSERT INTO `ordermenu_` VALUES ('6e4634d41218454aaa20165c7e7ab52e', '004ae67871ef4f139ba6d171596e900c', '更改', '3.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', 'ab62341ade124f618cec5fdaf18222d0');
INSERT INTO `ordermenu_` VALUES ('6f8cf7d180934e4599f3baf12f52e561', '37909b82a414427dbfada60f301d2f47', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4001');
INSERT INTO `ordermenu_` VALUES ('6ff67bb99fc7487fbe6c5a068e562c78', '6a5fd27aaf644745aebf0b5394219de2', '更改', '3.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', 'ab62341ade124f618cec5fdaf18222d0');
INSERT INTO `ordermenu_` VALUES ('70749dcccd25433da65f618a6ea470e5', '6a99fb9babf64a9180560e5db6511c81', '大师傅', '4.00', '正常', '1', 'blob:http%3A//127.0.0.1%3A8020/5aed0e31-dee6-431f-b947-37e6b36589e9', '122233344', '0', '', '0.00', '0', '0', 'e4ee2ab18bd445fc820cb7144762664e');
INSERT INTO `ordermenu_` VALUES ('70faf2443364405ca993b2a1b8e6bb4f', '2b9e765d47714ba5955e463798d2dcbf', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('7635cd85aaf04fb69134cf6674dc8378', '6a5fd27aaf644745aebf0b5394219de2', '糖醋萝卜', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1004');
INSERT INTO `ordermenu_` VALUES ('77335234d08a410fa080473b7675baae', 'e846e30621414d6c9ec7c58f32d7f9c0', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('77d9e052e2324ee8b66342cb776ef87c', '6a5fd27aaf644745aebf0b5394219de2', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4001');
INSERT INTO `ordermenu_` VALUES ('7850973c88d44baa86943f031271a815', '8753574fc7a54efaa470533b666d9ab9', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('79adf28f6bde4cb9ad8f49e0888cf3fe', 'ed5e83643fce4135b706c9f479413de3', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('7a7ef13a3d674612b8dcfb350066801e', '633f2db9d13d4e81a6f2d3bc54b0f014', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('7bf3b0044b25431a8fd6c467a6e12da3', '37909b82a414427dbfada60f301d2f47', '扬州炒饭', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4003');
INSERT INTO `ordermenu_` VALUES ('7fbb2974d7464b78a07235f811039b5a', '757cd506fe9a470795e9e8549f624234', '红油金针菇', '12.00', '正常', '0', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('82c03fcaa5a448faa44575022f7c0f05', 'e6feee5e8087409b882cd27c6f72f038', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('83747cb2cb79451e98d4cffaabb58f2c', '4a93235784e54963a81d34f8becf38ea', '烙饼子', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4005');
INSERT INTO `ordermenu_` VALUES ('85588660ceaf405ea091052fa0edf085', '6a5fd27aaf644745aebf0b5394219de2', '油炸花生米', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1003');
INSERT INTO `ordermenu_` VALUES ('856453b397984d03b0e40f513b3d33bb', '37909b82a414427dbfada60f301d2f47', '糖醋萝卜', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1004');
INSERT INTO `ordermenu_` VALUES ('860abfd3e3144082b57802a54af1d6dc', '445d50a6d3544d6dad08f6724965730a', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4001');
INSERT INTO `ordermenu_` VALUES ('8876580885f54c5e9e66def07f450d6a', '2bdcda192e56469ba4595bcd2fecac99', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('8d3d047e4bb64a918c2b5c14f490e11e', 'f769af6d60e1429f84232b97bd7fdadb', '啊啊阿道夫', '10.00', '正常', '1', 'blob:http%3A//127.0.0.1%3A8020/7cf27a85-87e2-48ea-9923-2d6786439978', '', '0', '', '0.00', '0', '0', 'c2a678c49e25452cb1ec2d3c4104a88f');
INSERT INTO `ordermenu_` VALUES ('8d45566bdeff4323b6bca1549155ddaa', 'f42ed1832ef94992ac84e749b1194df8', '西红柿炒鸡蛋', '16.00', '正常', '0', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('8de555bf074d46f38f01af8744439a6b', '37909b82a414427dbfada60f301d2f47', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('8e64be5e49be4703b39c82232e942d79', '6a5fd27aaf644745aebf0b5394219de2', '炝海带丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1002');
INSERT INTO `ordermenu_` VALUES ('8eac6427b508416ba582e85570fba25d', '82bcb8406188477e869b4a476939467f', '米饭', '2.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4004');
INSERT INTO `ordermenu_` VALUES ('93d86693e52b4c269daf9a0cf5b46cae', '37909b82a414427dbfada60f301d2f47', '油焖茄子', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2002');
INSERT INTO `ordermenu_` VALUES ('94ead05d8da24120af36b70be0a5fbf2', '37909b82a414427dbfada60f301d2f47', '米饭', '2.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4004');
INSERT INTO `ordermenu_` VALUES ('94ef1cf5d28b42fd964cf56208b6227e', '1ffee023b59946d395d653f49e20c402', '啊啊阿道夫', '10.00', '正常', '1', 'blob:http%3A//127.0.0.1%3A8020/7cf27a85-87e2-48ea-9923-2d6786439978', '', '0', '', '0.00', '0', '0', 'c2a678c49e25452cb1ec2d3c4104a88f');
INSERT INTO `ordermenu_` VALUES ('94f211a09fc54c229f5be186cb65c953', '483b7f817642455c95ee102fb368afa0', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('9804f01d9e7e4d81aac41b16c5cf97e4', '2b9e765d47714ba5955e463798d2dcbf', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('9916f4c47a68432288239b9e2d526d0b', 'cda5b2db4c2140bc836629193ce337da', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('99b4e9e80fba407fbdb72807737618c6', '3c258eee738f4b26943bfa23527e6c8e', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('9bb04d11bead422b9e934eb5aee022c0', 'a7bfd275c0364cffa702b6497d1b410d', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('9cb0745188d9488bb6828ce3e5726c0e', '445d50a6d3544d6dad08f6724965730a', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4002');
INSERT INTO `ordermenu_` VALUES ('9e3602db008b41aa9fe31516bcf31caf', 'a7bfd275c0364cffa702b6497d1b410d', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('9ebbdb4e5493427fb3d5407db5db61aa', '6a5fd27aaf644745aebf0b5394219de2', '带图片带标签2', '111.00', '正常', '1', 'C:fakepathTulips.jpg', '', '0', '', '0.00', '0', '0', 'a705b736b7b34284bfcb3d9e711e3fe1');
INSERT INTO `ordermenu_` VALUES ('a13e5e2c91474f2184c8ec575d295824', '37909b82a414427dbfada60f301d2f47', '玉米排骨汤', '28.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '3003');
INSERT INTO `ordermenu_` VALUES ('a1bbe099bb7d40718f0541a6ca883be7', '37909b82a414427dbfada60f301d2f47', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4002');
INSERT INTO `ordermenu_` VALUES ('a53bced5ddb948678a315c63bbbb1b89', '483b7f817642455c95ee102fb368afa0', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('a7364e340fa840f384541a77a4c040f7', 'e846e30621414d6c9ec7c58f32d7f9c0', '更改', '3.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', 'ab62341ade124f618cec5fdaf18222d0');
INSERT INTO `ordermenu_` VALUES ('a9b20a45809545498d5fddf1bb5a409a', 'c38e598c7f83499a87a56fd87ef67f19', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('aadb19e3a41f41b6a096cbe57ddeaddd', '3df4ea4042d04c8bb0279a572e313b11', '油炸花生米', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1003');
INSERT INTO `ordermenu_` VALUES ('ac759dbcee4345f3a1a64587c5658909', '483b7f817642455c95ee102fb368afa0', '雪碧', '8.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '3001');
INSERT INTO `ordermenu_` VALUES ('acce1ecd318b4ceba46a0e6d4e9f3f88', '37909b82a414427dbfada60f301d2f47', '雪碧', '8.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '3001');
INSERT INTO `ordermenu_` VALUES ('acf466dca4dc49f892c99b25b7b80800', '4a93235784e54963a81d34f8becf38ea', '扬州炒饭', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4003');
INSERT INTO `ordermenu_` VALUES ('ad1798908efb4d69a388344684a815b9', '3789942207bc4a28abedf65017d4fe03', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('ad746d7f156449ad852612066f8c6437', '85bff56e44994405ac23125edec2b23e', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4001');
INSERT INTO `ordermenu_` VALUES ('adfcdd35eaf2477fa7e12b53806987ec', 'f769af6d60e1429f84232b97bd7fdadb', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2004');
INSERT INTO `ordermenu_` VALUES ('af2d78a5485f4b24a92c3ab3b611f5a5', '8cc9a18580d340719a59260a32154641', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('b1138d0e127c4099a575b3d72455ee7e', 'f42ed1832ef94992ac84e749b1194df8', '红油金针菇', '12.00', '正常', '0', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('b35116e635e7422e980e7c90166aeba5', '82bcb8406188477e869b4a476939467f', '扬州炒饭', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4003');
INSERT INTO `ordermenu_` VALUES ('b57a1417e775428580262692f2eddf36', 'a7bfd275c0364cffa702b6497d1b410d', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('b838b43b1e224cb8bdbbbcbfb131d852', '6a5fd27aaf644745aebf0b5394219de2', '烙饼子', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4005');
INSERT INTO `ordermenu_` VALUES ('b83a14f65a6349318ed1d0b20467ce01', '91965c33ae6a49a5bf8119e22fcbfb70', '油焖茄子', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2002');
INSERT INTO `ordermenu_` VALUES ('bab427ffda334c13ac8561b5b99b2246', '6a99fb9babf64a9180560e5db6511c81', '啊啊阿道夫', '10.00', '正常', '1', 'blob:http%3A//127.0.0.1%3A8020/7cf27a85-87e2-48ea-9923-2d6786439978', '', '0', '', '0.00', '0', '0', 'c2a678c49e25452cb1ec2d3c4104a88f');
INSERT INTO `ordermenu_` VALUES ('c13230701e4b4a4586685e5126cbf30b', 'cda5b2db4c2140bc836629193ce337da', '尖椒土豆丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('c2877fcb53f14892ab354b10752159d9', 'dec2289a8e0d43ac983556e3abedb5bb', '烙饼子', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4005');
INSERT INTO `ordermenu_` VALUES ('c3c680c000754d4b9ee8513c9abf7d9a', '7fc82ba264f141b188d154904656d931', '油焖茄子', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2002');
INSERT INTO `ordermenu_` VALUES ('c4029cbea1f54beea86d701c0f689133', '37909b82a414427dbfada60f301d2f47', '烙饼子', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4005');
INSERT INTO `ordermenu_` VALUES ('c524b3622aae46adaaf4533c15296fef', '5a1abe1670d04b88afd1d1db7aa0b054', '鱼香肉丝', '25.00', '正常', '3', '', '', '0', '', '0.00', '0', '0', '2004');
INSERT INTO `ordermenu_` VALUES ('c6d678d4c8724bd698bb8eb772a98008', '7fc82ba264f141b188d154904656d931', '雪碧', '8.00', '超辣', '1', '', '', '0', '', '0.00', '0', '0', '3001');
INSERT INTO `ordermenu_` VALUES ('c8ebf03d24b041d79ce765186a02258e', '004ae67871ef4f139ba6d171596e900c', '大师傅', '4.00', '正常', '1', 'blob:http%3A//127.0.0.1%3A8020/5aed0e31-dee6-431f-b947-37e6b36589e9', '122233344', '0', '', '0.00', '0', '0', 'e4ee2ab18bd445fc820cb7144762664e');
INSERT INTO `ordermenu_` VALUES ('c913c82398524573bd3b6c61a04275c3', 'ed5e83643fce4135b706c9f479413de3', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('c94dd6703bc0414ea69c67d38d3faabb', '00797148f89549e8ac4b127c2c0501d9', '更改', '3.00', '正常', '1', '', '', '0', '', '0.00', '0', '1', 'ab62341ade124f618cec5fdaf18222d0');
INSERT INTO `ordermenu_` VALUES ('caa77d5a0f1841239cbb1a2942ecd77d', '483b7f817642455c95ee102fb368afa0', '尖椒土豆丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2001');
INSERT INTO `ordermenu_` VALUES ('cd9d88d6e6a04d08b91b32b88b1dfdcf', '6a5fd27aaf644745aebf0b5394219de2', '筒子骨海带汤', '38.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '3004');
INSERT INTO `ordermenu_` VALUES ('cf5c5244d05b407db81635e4cdcae6b1', '6a5fd27aaf644745aebf0b5394219de2', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2004');
INSERT INTO `ordermenu_` VALUES ('d2fc6f3eb28540da9f942b3a6ea68c0b', '6a5fd27aaf644745aebf0b5394219de2', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('d42efd1d5663404db8a0369cc5dc1210', '5a1abe1670d04b88afd1d1db7aa0b054', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '1', null);
INSERT INTO `ordermenu_` VALUES ('d7f297743cad4811b6219ac87044ca50', '1ffee023b59946d395d653f49e20c402', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('d9017514d95e46599437c3a0b93cc528', '3df4ea4042d04c8bb0279a572e313b11', '尖椒土豆丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2001');
INSERT INTO `ordermenu_` VALUES ('d954824281974ad78cef7723a846aaaf', '5a1abe1670d04b88afd1d1db7aa0b054', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('d9c0b38642cb43b59194ca8470fdec78', '483b7f817642455c95ee102fb368afa0', '炝海带丝', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1002');
INSERT INTO `ordermenu_` VALUES ('db3a1c0127894ec3beacd89ac8b4ae94', '483b7f817642455c95ee102fb368afa0', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4002');
INSERT INTO `ordermenu_` VALUES ('dbd12993f5bb40bb874f2bd03151760f', 'e6feee5e8087409b882cd27c6f72f038', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('de3188d18a6247269ceab4f893159602', 'f769af6d60e1429f84232b97bd7fdadb', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4002');
INSERT INTO `ordermenu_` VALUES ('dfa9eb692ce0473faf923e6861c11c02', '483b7f817642455c95ee102fb368afa0', '鱼香肉丝', '25.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('e21e7be2bb2d446a827dceb7dc2bbf78', '6a5fd27aaf644745aebf0b5394219de2', '啊啊阿道夫', '10.00', '正常', '1', 'blob:http%3A//127.0.0.1%3A8020/7cf27a85-87e2-48ea-9923-2d6786439978', '', '0', '', '0.00', '0', '0', 'c2a678c49e25452cb1ec2d3c4104a88f');
INSERT INTO `ordermenu_` VALUES ('e241dac3cddb439ab58af20f243c246e', '483b7f817642455c95ee102fb368afa0', '米饭', '2.00', '正常', '3', '', '', '0', '', '0.00', '0', '0', '4004');
INSERT INTO `ordermenu_` VALUES ('e2e129d09f9349d8b8e6b0f7ab346e78', 'e846e30621414d6c9ec7c58f32d7f9c0', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4001');
INSERT INTO `ordermenu_` VALUES ('e493c9f2090f4a3d86b4da2dba074c37', '85bff56e44994405ac23125edec2b23e', '龙须面', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4002');
INSERT INTO `ordermenu_` VALUES ('e6d94e5ca6e64ac883fd35876386db73', '2bdcda192e56469ba4595bcd2fecac99', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('e75c35dc1abf411b9cfadd54a1079560', '1ffee023b59946d395d653f49e20c402', '饺子', '15.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4001');
INSERT INTO `ordermenu_` VALUES ('e947ecba6aeb40208317b02fe4f1b972', '82bcb8406188477e869b4a476939467f', '烙饼子', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4005');
INSERT INTO `ordermenu_` VALUES ('eabf6581b47744bca4ae858eb396df0d', '85bff56e44994405ac23125edec2b23e', '烙饼子', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4005');
INSERT INTO `ordermenu_` VALUES ('ebb470c2a4e1402da210e6613fa880e9', '7fc82ba264f141b188d154904656d931', '炝海带丝', '10.00', '清淡', '1', '', '', '0', '', '0.00', '0', '0', '1002');
INSERT INTO `ordermenu_` VALUES ('ec9fef4ad6874144a727931c489e2a07', '83e6f45be89d444ea8fb10084a5dfcee', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('ed92aade7d1b4bd497654e7f6bcb8226', '52e51af155b74de3bc1626c042546a0e', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('ef5b0110f4df43479bbb583ff6b1e196', '483b7f817642455c95ee102fb368afa0', '筒子骨海带汤', '38.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '3004');
INSERT INTO `ordermenu_` VALUES ('ef774a26a0454c44a6adf3435d4a93d4', 'be370bf0bd44416597fee48690d3b690', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '1', '2003');
INSERT INTO `ordermenu_` VALUES ('f0733b97f34b4cd8ae6071ab558c6bec', '15e601c228ba4cb4a71035d8fb6f4c0c', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('f0936bf3f013465d8b0dcea3763c2c67', '34775b3b6f5e4a379cbff8258d27d6ff', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('f0bf7783d8b0434096b9e8cb708f4fc6', '6a5fd27aaf644745aebf0b5394219de2', '扬州炒饭', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4003');
INSERT INTO `ordermenu_` VALUES ('f1800adbc93049ddb0f8009ab471d1c0', '91965c33ae6a49a5bf8119e22fcbfb70', '糖醋萝卜', '10.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1004');
INSERT INTO `ordermenu_` VALUES ('f462db2abc7942fda79b79699084d772', '83e6f45be89d444ea8fb10084a5dfcee', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '1001');
INSERT INTO `ordermenu_` VALUES ('f5904a7fe55a489596f23663b62bd44e', '37909b82a414427dbfada60f301d2f47', '筒子骨海带汤', '38.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '3004');
INSERT INTO `ordermenu_` VALUES ('f6a3e236f9884af0bea7a7926125854c', '8753574fc7a54efaa470533b666d9ab9', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', null);
INSERT INTO `ordermenu_` VALUES ('fa3a1ae74062441aa4e81aa32b3af64c', '2357aad0158d403ab83eef73c586f15b', '西红柿炒鸡蛋', '16.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '2003');
INSERT INTO `ordermenu_` VALUES ('fc22e444a4f549b9892c89f1df529de2', 'be370bf0bd44416597fee48690d3b690', '红油金针菇', '12.00', '正常', '1', '', '', '0', '', '0.00', '0', '1', '1001');
INSERT INTO `ordermenu_` VALUES ('feff69f5224d42a780c8a101a3e94a12', '85bff56e44994405ac23125edec2b23e', '米饭', '2.00', '正常', '1', '', '', '0', '', '0.00', '0', '0', '4004');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000001', '第一桌', '0', '1', '1', '00000000000000000000000000000001', '2016-12-20 13:58:41');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000002', '第二桌', '0', '1', '0', '00000000000000000000000000000001', '2016-12-20 13:58:58');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000003', '第三桌', '0', '1', '0', '00000000000000000000000000000001', '2016-12-20 13:59:14');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000004', '第四桌', '0', '1', '1', '00000000000000000000000000000001', '2016-12-20 13:59:32');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000005', '第五桌', '0', '1', '0', '00000000000000000000000000000001', '2016-12-20 13:59:48');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000006', '第六桌', '0', '1', '0', '00000000000000000000000000000001', '2016-12-20 14:00:07');
INSERT INTO `xiuse_desk` VALUES ('00000000000000000000000000000007', '六人桌', '0', '1', '0', '00000000000000000000000000000001', '2017-02-03 00:00:00');
INSERT INTO `xiuse_desk` VALUES ('1ab6654790c74da8ab3524fcf300b1e3', '桌子名就要长长长长长长长一些~~~', '1', '1', '0', '00000000000000000000000000000001', '2017-04-19 13:58:07');
INSERT INTO `xiuse_desk` VALUES ('1b6bdb75c252478e9d538dd37e23ae0b', '不接受外卖', '0', '1', '0', '00000000000000000000000000000001', '2017-04-19 11:39:58');
INSERT INTO `xiuse_desk` VALUES ('353ef11ba2bd462ba11e814efe6ad997', '不接受外卖', '0', '1', '1', '00000000000000000000000000000001', '2017-04-19 11:37:36');
INSERT INTO `xiuse_desk` VALUES ('40de6746c20f4d6dba53c529224e952f', '添加餐桌test', '0', '1', '0', '00000000000000000000000000000001', '2017-04-19 11:37:09');
INSERT INTO `xiuse_desk` VALUES ('69b2d29e33b74398b37f11932a6cc36f', '接收外卖', '1', '1', '0', '00000000000000000000000000000001', '2017-04-19 11:39:35');
INSERT INTO `xiuse_desk` VALUES ('71e08ad14546449983cd7202f4738d49', '2333', '1', '1', '0', '00000000000000000000000000000001', '2017-04-19 13:58:09');
INSERT INTO `xiuse_desk` VALUES ('7703fec56c164d80a9cb2e76082a3371', 'wefr', '1', '1', '0', '00000000000000000000000000000001', '2017-04-19 13:36:19');
INSERT INTO `xiuse_desk` VALUES ('8b87415d6549498d8cbdc2de22a084dc', '32333', '1', '0', '0', '00000000000000000000000000000001', '2017-04-19 13:58:12');
INSERT INTO `xiuse_desk` VALUES ('b11da6e37f3a4c09ba36bd18b5b7fc07', '二人桌', '1', '1', '0', '00000000000000000000000000000001', '2017-04-19 13:38:11');
INSERT INTO `xiuse_desk` VALUES ('bdddf27124c24bb9a84e0181c73fa225', '33333', '1', '1', '0', '00000000000000000000000000000001', '2017-04-19 13:58:16');
INSERT INTO `xiuse_desk` VALUES ('eeddecd1f01d4903b7c2f5527acfcef7', '2', '1', '0', '0', '00000000000000000000000000000001', '2017-04-19 13:58:04');
INSERT INTO `xiuse_desk` VALUES ('efd0619ae7d6423694ee3e2d60d726db', '圆桌', '0', '1', '0', '00000000000000000000000000000001', '2017-04-19 13:58:02');
INSERT INTO `xiuse_discount` VALUES ('00000000', '九折', '0', '10.00', '-1', '0', '1', '0', '00000000000000000000000000000001', '2017-03-27 14:40:58');
INSERT INTO `xiuse_discount` VALUES ('00000001', '满百减12', '1', '12.00', '-1', '0', '1', '1', '00000000000000000000000000000001', '2017-03-27 14:42:31');
INSERT INTO `xiuse_discount` VALUES ('0a21c7e1a2424a11ac4b73d0dc6fe31e', '删除删除', '1', '5.00', '-1', '0', '2', '0', '00000000000000000000000000000001', '2017-04-19 13:14:37');
INSERT INTO `xiuse_discount` VALUES ('3f1f1841645f40caa2299886b5879286', '主食折扣', '0', '10.00', '4001,4002,4003,4004', '1', '1', '0', '00000000000000000000000000000001', '2017-04-18 14:51:01');
INSERT INTO `xiuse_discount` VALUES ('4922f544006c48948d140d9db2f4b7fd', 'test111', '0', '90.00', '', '1', '1', '0', '00000000000000000000000000000001', '2017-04-18 17:12:18');
INSERT INTO `xiuse_discount` VALUES ('4ead430b70d54e55a8586479543f889e', '的点点滴滴', '0', '4.00', '-1', '0', '2', '0', '00000000000000000000000000000001', '2017-04-19 13:15:24');
INSERT INTO `xiuse_discount` VALUES ('7cf09848b2c3468eac3797a6d5b590eb', 'test修改的不是新建啊啊啊呜呜呜', '0', '80.00', 'a705b736b7b34284bfcb3d9e711e3fe1,c2a678c49e25452cb1ec2d3c4104a88f,e4ee2ab18bd445fc820cb7144762664e,4001,4002,4003,4004,4005', '1', '2', '0', '00000000000000000000000000000001', '2017-04-18 17:13:55');
INSERT INTO `xiuse_discount` VALUES ('94573be01e1841d2b0e4f5f224968b49', 'dfdf', '0', '111.00', '-1', '0', '1', '0', '00000000000000000000000000000001', '2017-04-18 14:40:47');
INSERT INTO `xiuse_discount` VALUES ('e8542296686d44bf91f4fa82bf873293', 'test11', '1', '22.00', '4001,4002,4003,4004,4005', '1', '2', '0', '00000000000000000000000000000001', '2017-04-18 17:11:25');
INSERT INTO `xiuse_discount` VALUES ('ff682e8ec51f40f1a630ca32f2f3e038', 'test', '1', '22.00', 'a705b736b7b34284bfcb3d9e711e3fe1,ab62341ade124f618cec5fdaf18222d0,c2a678c49e25452cb1ec2d3c4104a88f,e4ee2ab18bd445fc820cb7144762664e', '1', '2', '0', '00000000000000000000000000000001', '2017-04-18 14:41:28');
INSERT INTO `xiuse_member` VALUES ('000000000000000000000000001', '00001', '洋洋洋', '1104.00', '1', '15200856922', null, '123456', '1', '2017-04-01 11:13:59', '00000000000000000000000000000001', null, '0');
INSERT INTO `xiuse_member` VALUES ('000000000000000000000000002', '00002', '彤彤', '241.00', '1', '13200339999', null, '123456', '1', '2017-03-16 11:14:51', '00000000000000000000000000000001', null, '0');
INSERT INTO `xiuse_member` VALUES ('000000000000000000000000003', '00003', '拉拉', '49.00', '1', '13032343234', '', '654321', '1', '2017-02-15 11:15:34', '00000000000000000000000000000001', null, '0');
INSERT INTO `xiuse_member` VALUES ('000000000000000000000000004', '00004', 'test1', '220.00', '1', '13522114455', null, '123', '0', '2017-04-04 13:44:28', '00000000000000000000000000000001', null, '0');
INSERT INTO `xiuse_member` VALUES ('000000000000000000000000005', '00005', 'test2', '92.00', '1', null, null, '321', '0', '2017-04-07 13:45:57', '00000000000000000000000000000001', null, '0');
INSERT INTO `xiuse_member` VALUES ('053a7d875e2a44729a0a7bbe59742597', '1704060120241201', 'sddd', '4.00', '1', 'adf', '', '123', '0', '2017-04-06 13:20:28', '', 'adfdd', '0');
INSERT INTO `xiuse_member` VALUES ('230d0dc60724457586902637c7df7da6', '1704060120241201', 'sddd', '4.00', '1', 'adf', '', '123', '0', '2017-04-06 13:20:50', '', 'adfdd', '0');
INSERT INTO `xiuse_member` VALUES ('38cfd8c9e5a6454ea033e8fe1269594e', '1704071010332344', '阿拉斯加', '4.00', '1', '12312312312', '', '123456', '0', '2017-04-07 10:11:04', '00000000000000000000000000000001', '191919@qq.com', '0');
INSERT INTO `xiuse_member` VALUES ('6c18b3e058004cccab795adb923d72ed', '1704060202287548', '喵喵喵喵', '4.00', '1', '12345678912', '', '12345', '2', '2017-04-06 14:02:37', '00000000000000000000000000000001', 'adf@111.com', '0');
INSERT INTO `xiuse_member` VALUES ('762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '哈士奇', '84.00', '1', '', '', '', '1', '2017-04-06 14:07:20', '00000000000000000000000000000001', '', '0');
INSERT INTO `xiuse_member` VALUES ('8afabc91604b444984f59b07dce15f96', '1704061142177086', '1232', '4.00', '4', '122321343433', '', 'adsfad', '0', '2017-04-06 11:42:23', '', 'adf', '0');
INSERT INTO `xiuse_member` VALUES ('dbaa1a6e54cd4c19ae4f2c03224b3edd', '1704060220052555', '电饭锅的名字就要长长长长超级长啊啊啊啊啊', '210.00', 'c1f05b69b0db4230836795746eb63d06', '23342454554', '', '11111', '1', '2017-04-06 14:20:19', '00000000000000000000000000000001', '11111111', '0');
INSERT INTO `xiuse_member` VALUES ('fa88e78a4f09463c890a8bcdc7d2ba56', '1704060122326765', 'adfadf', '4.00', '4', '151111111111', '', '123456', '2', '2017-04-06 13:22:37', '00000000000000000000000000000001', '111@111.com', '0');
INSERT INTO `xiuse_member` VALUES ('fb80ee53bc324b0ea220038ec060be07', '1704100245442174', '吉娃娃', '31.00', 'c1f05b69b0db4230836795746eb63d06', '12345654321', '', 'mYo+BYIT41M=', '1', '2017-04-10 14:45:51', '00000000000000000000000000000001', '', '0');
INSERT INTO `xiuse_memberclassify` VALUES ('1', '00000000', '铂金卡', '进进进', '5', '2017-03-23 15:33:38', '0', '00000000000000000000000000000001');
INSERT INTO `xiuse_memberclassify` VALUES ('2', '2', '黄金卡', null, '0', '2017-04-05 15:11:50', '0', '00000000000000000000000000000001');
INSERT INTO `xiuse_memberclassify` VALUES ('2ef849be9edb4da7b908906293b47e71', '00000001', 'VVVVip卡卡卡卡', '123456', '0', '2017-04-10 13:52:51', '2', '00000000000000000000000000000001');
INSERT INTO `xiuse_memberclassify` VALUES ('3', '3', '银卡', null, '0', '2017-04-05 15:12:34', '0', '00000000000000000000000000000001');
INSERT INTO `xiuse_memberclassify` VALUES ('4', '4', '钻石卡', null, '0', '2017-04-05 15:13:09', '0', '00000000000000000000000000000001');
INSERT INTO `xiuse_memberclassify` VALUES ('b737a7285f844afab7f8346031350110', '00000001', 'test2222', '123456', '0', '2017-04-10 13:46:22', '0', '00000000000000000000000000000001');
INSERT INTO `xiuse_memberclassify` VALUES ('c1f05b69b0db4230836795746eb63d06', '00000000', '新建会员类型测试机好长好长哦', '坑爹坑爹', '2', '2017-04-10 14:02:58', '0', '00000000000000000000000000000001');
INSERT INTO `xiuse_menuclassify` VALUES ('001', '凉菜', '4', '0', '凉菜', '00000000000000000000000000000001', '2016-12-20 11:07:37');
INSERT INTO `xiuse_menuclassify` VALUES ('002', '热菜', '7', '0', '热菜', '00000000000000000000000000000001', '2016-12-20 11:08:27');
INSERT INTO `xiuse_menuclassify` VALUES ('003', '饮料', '5', '0', '饮料', '00000000000000000000000000000001', '2016-12-20 11:14:09');
INSERT INTO `xiuse_menuclassify` VALUES ('004', '主食', '3', '0', '主食', '00000000000000000000000000000001', '2016-12-20 10:54:48');
INSERT INTO `xiuse_menuclassify` VALUES ('41d5a2c3c980409686072ebfe18d6dbe', '111', '10', '1', '隐藏的分类', '00000000000000000000000000000001', '2017-04-12 15:36:49');
INSERT INTO `xiuse_menuclassify` VALUES ('5c0b05955631494381baf64d8cd37ed4', '隐藏分类yes', '6', '1', '特价菜', '00000000000000000000000000000001', '2017-04-11 16:52:43');
INSERT INTO `xiuse_menuclassify` VALUES ('9d7ce87cd1704cb685dad60e9e7dcebb', '', '9', '1', '新建隐藏test', '00000000000000000000000000000001', '2017-04-12 14:54:21');
INSERT INTO `xiuse_menuclassify` VALUES ('ed2843b3ab6a48b7b6eb4079c38bce0d', '热销top10', '8', '1', '热门菜品', '00000000000000000000000000000001', '2017-04-11 13:23:01');
INSERT INTO `xiuse_menuclassify` VALUES ('f4fce08d37244f479aed3f7d52b2a6d9', 'jieshao1', '2', '0', '我是新建1ssd', '00000000000000000000000000000001', '2017-04-20 09:15:31');
INSERT INTO `xiuse_menuclassify` VALUES ('f75e19bce7c9494e82cb3ab44f6ae771', '撸串撸串4343sfawes', '1', '1', '串串343', '00000000000000000000000000000001', '2017-04-17 17:11:59');
INSERT INTO `xiuse_menus` VALUES ('1001', '红油金针菇', '100', '12.00', null, '', null, '1', null, '0', '0', '00000000000000000000000000000001', '001', '2016-12-20 13:35:48');
INSERT INTO `xiuse_menus` VALUES ('1002', '炝海带丝', '100', '10.00', null, '', null, '2', null, '0', '0', '00000000000000000000000000000001', '001', '2016-12-20 13:36:45');
INSERT INTO `xiuse_menus` VALUES ('1003', '油炸花生米', '100', '10.00', null, '', null, '3', null, '0', '0', '00000000000000000000000000000001', '001', '2016-12-20 13:36:53');
INSERT INTO `xiuse_menus` VALUES ('1004', '糖醋萝卜', '100', '10.00', null, '', null, '4', null, '0', '0', '00000000000000000000000000000001', '001', '2016-12-20 13:37:54');
INSERT INTO `xiuse_menus` VALUES ('19d116d262d240589db4a9d3af96a236', '滴滴滴滴滴滴', '0', '7.00', '', '阿斯蒂芬,阿斯蒂芬阿萨德发的发', 'blob:http%3A//127.0.0.1%3A8020/0cc15fef-0de9-41ab-8b99-0154e0fb95cf', '1', '', '0', '2', '00000000000000000000000000000001', 'f4fce08d37244f479aed3f7d52b2a6d9', '2017-04-14 15:43:04');
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
INSERT INTO `xiuse_menus` VALUES ('4d2137ba3d2d4759bb5f18a7c855cec1', '啥地方', '0', '23.00', '11', '', '', '1', '说的vf', '0', '2', '00000000000000000000000000000001', 'f4fce08d37244f479aed3f7d52b2a6d9', '2017-04-14 15:57:20');
INSERT INTO `xiuse_menus` VALUES ('61b3390a998d41cbbb44b610748bee32', '新建有图有标签', '0', '3.00', '', '阿道夫,阿道夫dd', 'C:fakepathJellyfish.jpg', '2', '', '0', '2', '00000000000000000000000000000001', 'f4fce08d37244f479aed3f7d52b2a6d9', '2017-04-14 14:56:52');
INSERT INTO `xiuse_menus` VALUES ('6242728304d649c6a3cb0cb89f041845', '水水水水', '0', '2.00', '', 'rthyr,rthyrrty', 'blob:http%3A//127.0.0.1%3A8020/b9f42e63-fdd6-40c4-927c-a236644f41ee', '1', 'tvg5r6hy', '0', '2', '00000000000000000000000000000001', 'f4fce08d37244f479aed3f7d52b2a6d9', '2017-04-17 11:19:22');
INSERT INTO `xiuse_menus` VALUES ('7a102c582bb34e869abee70e4fc80de0', '羊肉串11223', '0', '2.00', '12', 'sdf,sdfew,5ryt', 'blob:http%3A//127.0.0.1%3A8020/7ece094d-1227-4e87-8387-3f374d7c2de7', '1', 'sgvwsrg', '0', '2', '00000000000000000000000000000001', 'f75e19bce7c9494e82cb3ab44f6ae771', '2017-04-17 17:11:02');
INSERT INTO `xiuse_menus` VALUES ('a5d385c9158344938139d25946c33a57', '有图有快捷码有介绍3块钱有标签已售完', '0', '3.00', '', '标签1,标签1标签', 'C:fakepathTulips.jpg', '1', '', '1', '2', '00000000000000000000000000000001', 'f4fce08d37244f479aed3f7d52b2a6d9', '2017-04-14 15:24:50');
INSERT INTO `xiuse_menus` VALUES ('a705b736b7b34284bfcb3d9e711e3fe1', '带图片带标签2', '0', '111.00', '', '啧啧啧', 'C:fakepathTulips.jpg', '1', '', '0', '2', '00000000000000000000000000000001', 'f4fce08d37244f479aed3f7d52b2a6d9', '2017-04-14 15:01:12');
INSERT INTO `xiuse_menus` VALUES ('ab62341ade124f618cec5fdaf18222d0', '更改sdfsdf', '0', '3.00', '', '打的费,sdfvwe', '', '3', '', '0', '0', '00000000000000000000000000000001', 'f4fce08d37244f479aed3f7d52b2a6d9', '2017-04-20 09:16:11');
INSERT INTO `xiuse_menus` VALUES ('c2a678c49e25452cb1ec2d3c4104a88f', '啊啊阿道夫', '0', '10.00', '', '滴滴滴,滴滴滴大多数非', 'blob:http%3A//127.0.0.1%3A8020/7cf27a85-87e2-48ea-9923-2d6786439978', '1', '', '1', '0', '00000000000000000000000000000001', 'f4fce08d37244f479aed3f7d52b2a6d9', '2017-04-14 15:37:12');
INSERT INTO `xiuse_menus` VALUES ('e4ee2ab18bd445fc820cb7144762664e', '大师傅', '0', '4.00', '滴滴滴', '大师傅,大师傅大幅萨的说法', 'blob:http%3A//127.0.0.1%3A8020/5aed0e31-dee6-431f-b947-37e6b36589e9', '2', '122233344', '1', '0', '00000000000000000000000000000001', 'f4fce08d37244f479aed3f7d52b2a6d9', '2017-04-14 15:58:59');
INSERT INTO `xiuse_recharge` VALUES ('00000000000000000000000212', '1', '45.00', '1000.00', '000000000000000000000000001', '00001', '2017-04-07 08:48:03', null);
INSERT INTO `xiuse_recharge` VALUES ('0000000000000001', '1', '1000.00', '1000.00', '000000000000000000000000001', '00001', '2017-04-01 11:13:59', null);
INSERT INTO `xiuse_recharge` VALUES ('0000000000000002', '1', '100.00', '100.00', '000000000000000000000000002', '00002', '2017-03-16 11:14:51', null);
INSERT INTO `xiuse_recharge` VALUES ('0000000000000003', '1', '45.00', '17.00', '000000000000000000000000003', '00003', '2017-02-15 11:15:34', null);
INSERT INTO `xiuse_recharge` VALUES ('0000000000000004', '2', '100.00', '9.00', '000000000000000000000000004', '00004', '2017-04-04 13:44:28', null);
INSERT INTO `xiuse_recharge` VALUES ('0000000000000005', '1', '88.00', '88.00', '000000000000000000000000005', '00005', '2017-04-07 13:45:57', null);
INSERT INTO `xiuse_recharge` VALUES ('13ec8f8f7a204883af41961e28ccea63', '1', '123.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-06 17:11:21', '0');
INSERT INTO `xiuse_recharge` VALUES ('3801a6ff6edc4c3db4de0fbee42c3230', '1', '3.00', '210.00', 'dbaa1a6e54cd4c19ae4f2c03224b3edd', '1704060220052555', '2017-04-11 10:16:30', '207');
INSERT INTO `xiuse_recharge` VALUES ('412e2aa6e2d6463093b0db5d51331034', '1', '12.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-11 09:16:27', null);
INSERT INTO `xiuse_recharge` VALUES ('4d20d69ad4294d6bb2d528df81803dcf', '1', '1.00', '206.00', 'dbaa1a6e54cd4c19ae4f2c03224b3edd', '1704060220052555', '2017-04-11 10:08:04', '205');
INSERT INTO `xiuse_recharge` VALUES ('595ba1f0d920492f93a6fc91f9ecbe22', '1', '50.00', '0.00', '000000000000000000000000004', '00004', '2017-04-10 15:26:05', null);
INSERT INTO `xiuse_recharge` VALUES ('6aeadb5fc4a74903a66542dbee2477ca', '1', '50.00', '0.00', '000000000000000000000000004', '00004', '2017-04-10 15:24:00', null);
INSERT INTO `xiuse_recharge` VALUES ('790b4c5ecdab432fb86df11b1058647f', '1', '2.00', '0.00', 'fb80ee53bc324b0ea220038ec060be07', '1704100245442174', '2017-04-10 15:33:32', null);
INSERT INTO `xiuse_recharge` VALUES ('7aa8c7089cc5459bbfaf6cfa60feb278', '1', '1.00', '31.00', 'fb80ee53bc324b0ea220038ec060be07', '1704100245442174', '2017-04-11 10:15:28', '30');
INSERT INTO `xiuse_recharge` VALUES ('82b487680ae245f698616562a5f97715', '1', '2.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:35:30', null);
INSERT INTO `xiuse_recharge` VALUES ('82e2fb5751584adcabc86cfd38fa83bc', '1', '2.00', '0.00', '000000000000000000000000004', '00004', '2017-04-10 15:28:02', null);
INSERT INTO `xiuse_recharge` VALUES ('849c2c6440a64c6caba5ba090d7e0a95', '1', '10.00', '0.00', 'fb80ee53bc324b0ea220038ec060be07', '1704100245442174', '2017-04-10 15:30:06', null);
INSERT INTO `xiuse_recharge` VALUES ('94947086d2244396b91fcaa0b1f70996', '1', '13.00', '0.00', 'fb80ee53bc324b0ea220038ec060be07', '1704100245442174', '2017-04-10 15:34:05', null);
INSERT INTO `xiuse_recharge` VALUES ('9aa016fc3b08460c9e062b909aa60cb5', '2', '1000.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-06 17:24:28', '0');
INSERT INTO `xiuse_recharge` VALUES ('af9e8638759241559056feb06e7b81c7', '1', '1.00', '207.00', 'dbaa1a6e54cd4c19ae4f2c03224b3edd', '1704060220052555', '2017-04-11 10:16:26', '206');
INSERT INTO `xiuse_recharge` VALUES ('b237929a73954688999126033ba07ea5', '1', '12.00', '0.00', '000000000000000000000000002', '00002', '2017-04-10 15:42:50', null);
INSERT INTO `xiuse_recharge` VALUES ('bb5cb4ecc29341a8b4737a23477f8e60', '1', '4.00', '210.00', '000000000000000000000000004', '00004', '2017-04-11 10:18:33', '206');
INSERT INTO `xiuse_recharge` VALUES ('bccde727e6454b3088d89f185695cc7c', '1', '2.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:41:26', null);
INSERT INTO `xiuse_recharge` VALUES ('bdf4dacdee7e4d0fba5e3247c41b6e07', '1', '10.00', '220.00', '000000000000000000000000004', '00004', '2017-04-11 10:21:22', '210');
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625321', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625322', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625333', '1', '4.00', '28.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', '68');
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625334', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625344', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625355', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625356', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', '68');
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625359', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625366', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625411', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625412', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625413', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fbfdea625416', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d7490ab6bb85466a9598fkfdea625356', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d8490ab6bb85466a9598fbfdea625356', '1', '4.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-10 15:56:55', null);
INSERT INTO `xiuse_recharge` VALUES ('d9a048b7c49b42d0a1e393ece00a1d75', '1', '2.00', '84.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-11 10:01:14', '82');
INSERT INTO `xiuse_recharge` VALUES ('eb1b8c6a8cae4e72b1d45c1b289427a3', '1', '111.00', '0.00', '762875ae7e9c49a3b0e97094f6d75888', '1704060207084023', '2017-04-06 17:26:00', '0');
INSERT INTO `xiuse_recharge` VALUES ('efd25af0a15344b6b773c64ddd238a73', '1', '100.00', '204.00', 'dbaa1a6e54cd4c19ae4f2c03224b3edd', '1704060220052555', '2017-04-11 10:03:56', '104');
INSERT INTO `xiuse_recharge` VALUES ('f06670bd9e824ccd9944be04dacbf55b', '1', '1.00', '241.00', '000000000000000000000000002', '00002', '2017-04-11 10:08:45', '240');
INSERT INTO `xiuse_recharge` VALUES ('f944ec9eadba45fb93931713e9162a61', '1', '123.00', '0.00', '000000000000000000000000002', '00002', '2017-04-10 15:45:24', null);
INSERT INTO `xiuse_recharge` VALUES ('fdef935af0b04d52b881ccff79dbd2da', '1', '1.00', '0.00', 'fb80ee53bc324b0ea220038ec060be07', '1704100245442174', '2017-04-11 10:12:18', '30');
INSERT INTO `xiuse_recharge` VALUES ('kl;kl;kl;kl', '1', '100.00', '1100.00', '000000000000000000000000001', '00001', '2017-04-07 09:14:09', '10');
INSERT INTO `xiuse_restaurant` VALUES ('00000000000000000000000000000000', 'TestRN', '010-88888888', '北京', null, '2016-12-12 13:22:43');
INSERT INTO `xiuse_restaurant` VALUES ('00000000000000000000000000000001', 'TestR1', '010-12345678', '北京', null, '2016-12-20 11:16:58');
INSERT INTO `xiuse_user` VALUES ('00000000000000000000000000000000', 'admin', 'weixin', '15811111111', 'admin@163.com', '123', '00000000000000000000000000000001', '0', '-1', '1', '0', '2016-12-12 13:20:42');
INSERT INTO `xiuse_user` VALUES ('00000000000000000000000000000001', 'test', 'weixin', '15811112222', 'Rita@163.com', '123', '00000000000000000000000000000001', '1', '-1', '0', '1', '2017-03-24 16:20:42');
INSERT INTO `xiuse_user` VALUES ('0be7ea512f074a188ae441980c12bf3d', '没有手机邮箱的员工', '', '', '', 'CPBNq1e4luY=', '00000000000000000000000000000001', '1', '', '0', '1', '2017-04-20 10:41:49');
INSERT INTO `xiuse_user` VALUES ('1c5869704dad4e7ea9e55919a08efb18', 'xcf', '', '233223', '', '123', '00000000000000000000000000000001', '0', '', '0', '1', '2017-04-20 11:41:49');
INSERT INTO `xiuse_user` VALUES ('2342325435343dgd', '服务员1', '微信', '15832132326', 'sdfsw', '123', '00000000000000000000000000000001', '1', '-1', '0', '0', '2017-04-12 15:18:22');
INSERT INTO `xiuse_user` VALUES ('2a7ed5caa3be4c35ae63ce206439f44a', '小苹果', '', '11111111111', '111@111.com', 'qpUv6MvpcSs=', '00000000000000000000000000000001', '1', '', '0', '2', '2017-04-20 09:52:16');
INSERT INTO `xiuse_user` VALUES ('53666c3a0e2e4fc1b20e475b901ed64f', '1233', '', '的所发生的', '', 'pS8bAIB6Yfo=', '00000000000000000000000000000001', '1', '', '0', '0', '2017-04-20 10:51:19');
INSERT INTO `xiuse_user` VALUES ('57de25c6f8864e92bdded3de1e879aa8', 'test', '', '1213313', '', 'CigER+rW66M=', '00000000000000000000000000000001', '1', '', '0', '0', '2017-04-20 10:48:10');
INSERT INTO `xiuse_user` VALUES ('66ab5548651246caa9166e94f88c77e0', '阳光灿烂-我选了管理员哟名字长长长长会怎样', '', '12111111111', 'ndn@1111.com', 'UgY8gmreU3N4qLyXPD0eHw==', '00000000000000000000000000000001', '1', '', '0', '0', '2017-04-20 09:58:36');
INSERT INTO `xiuse_user` VALUES ('8db32256011645c2953f78a65aa8d93d', '修改修改', '', '23423111111', '', '123', '00000000000000000000000000000001', '1', '', '0', '0', '2017-04-20 10:50:36');
INSERT INTO `xiuse_user` VALUES ('a9443b906b534dde81ecc33bd521ea1c', '大声道', '', '', '', 'l0kV8AWhMt0=', '00000000000000000000000000000001', '1', '', '0', '2', '2017-04-20 10:42:14');
INSERT INTO `xiuse_user` VALUES ('fd239c85b3b54d268d20718a088354c6', '文身断发', '', '23423', '', 'CigER+rW66M=', '00000000000000000000000000000001', '1', '', '0', '0', '2017-04-20 10:48:55');
