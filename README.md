1.此项目是基于.net core 和ef core 开发的，与数据库之间的操作应用的codefirst的开发方式,我采用的 数据库是SQlSERVER。如果用MySql亦可，不过要下载连接MySql相关的包。 2.mysql项目的依赖包 Microsoft.EntityFrameworkCore MySql.Data.EntityFrameworkCore Microsoft.EntityFrameworkCore.Tools 3.SQlSERVER项目的依赖包 Microsoft.EntityFrameworkCore.SqlServer Microsoft.EntityFrameworkCore.Tools 4.引用项目的包可以用命令行，百度上很多可以去搜索。 或者右键项目的依赖项>管理Nuget程序包>点浏览安装这几个包 此项目非常适合初学.net core，efcore人学习。 5.因为采用的是codefirst,需要生成对应的数据库，生成数据库步骤 单击VS菜单工具>Nuget包管理器>程序包管理控制台。打开后在管理器控制台执行如下命令： Add-Migration NoteFirst Update-Database 出现Done表示还原成功，没成功可以查看Startup.cs的连接串是否成功。EFCore默认生成的表名是复数，想改成单数可以在上下操作类中 写一个OnModelCreating(具体做法百度一下)








