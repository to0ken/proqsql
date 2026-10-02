import pyodbc

def connect():
    connection_string ="DRIVER={ODBC Driver 18 for SQL Server};Server=COMP7A2\\SQLEXPRESS;Database=DataBase_1;Trusted_Connections=yes;TrustServerCertificate=yes"

    connection = pyodbc.connect(connection_string)
    return connection



def main():
    table_name = ["users2", "Table1"]
    conn= connect()
    add_data(conn, table_name[0])
    #print_data(curr)

def select_data(conn, name):
    cursor = conn.corsor()

    sql_command = ("SELECT TOP 10 * "
                   f"FROM dbo.{name}")

    cursor.execute(sql_command)
    return cursor

def add_data(conn,name):
    cursor = conn.corsor()

    sql_command = ("INSERT INTO dbo.{name}(name,balans,credit) VALUES(?,?,?)")
    cursor.execute(sql_command, 'SPATI_XOCHY', 100.0, 50.0)
    cursor.commit()

def print_data(cursor):
    rows = cursor.fetchall()
    for row in rows:
        print(row)

main()
