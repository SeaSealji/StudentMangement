# Studentmanagement
项目实现了一个管理信息系统，教务系统数据库中数据表的设计，使用商用数据库MySQL实现所设计的数据库，
实现数据存储、查询、更新、删除等，基于所设计的数据库实现一个“学生教务管理系统”。

## 项目工具
Mysql数据库
C#开发语言

## 项目使用流程
安装项目后，需要本地实现创建数据库的工作。
创建数据库
可以用本地数据库，需要修改项目类各个连接语句的值，也可以使用新建项目数据库.

用户：root

密码：123456

database：test2

### 创建学生表

CREATE TABLE Student

(SnO CHAR (9) PRIMARY KEY,
Sname

CHAR (20) UNIQUE,
Ssex CHAR (2)

Sage SMALLINT

Sdept CHAR (20)
);
### 创建SC表

CREATE TABLE SC

(Sno CHAR(9)

Cno CHAR(4)

Grade SMALLINT,

PRIMARY KEY(Sno, Cno)

FOREIGN KEY(Cno)REFERENCES Course (Cno)
);

### 创建Course表

CREATE TABLE Course

(CnO CHAR(4)PRIMARY KEY.

Cname CHAR(40)NOT NULL,

Cpno CHAR(4)

Ccredit SMALLINT

FOREIGN KEY(Cpno)

REFERENCES Course(Cno)
);
