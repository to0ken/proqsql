import mssql_python

str_connect = ("Server=COMP7A2\\SQLEXPRESS;"
               "Database=DataBase_1;"
               "Trusted_Connections=yes;"
               "Encrypt=yes;"
               "TrustServerCertificate=yes")

connection = mssql_python.connect(str_connect)

cursor = connection.cursor()

sql_command = ("SELECT TOP 10 * "
               "FROM dbo.users2")

cursor.execute(sql_command)

rows = cursor.fetchall()

for row in rows:
    print(row)

#.\venv\Scripts\
