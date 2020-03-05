1. В Package Manager Console выполнить команду Install-Package Microsoft.EntityFrameworkCore.Tools
2. В Package Manager Console выполнить команду Install-Package Microsoft.EntityFrameworkCore.SqlServer
3. В Package Manager Console выполнить команду 
	Scaffold-DbContext "server=192.168.9.159;
						database=SBOX_7142_Shamsutdinov;
						user id=SQLU_QDS_DID56;
						password = Demo123"
	Microsoft.EntityFrameworkCore.SqlServer
	-Tables SysAdminUnit
