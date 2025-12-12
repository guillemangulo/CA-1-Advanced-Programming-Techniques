#SERVER file. Recieve the info of the application
import socket
import json
import sqlite3
import random
import datetime

def setup_database():
    try:
        connection = sqlite3.connect('dbs_admissions.db')
        print("Connected with database....")
        
        cursor = connection.cursor()
        #create table if it doesn't exist
        cursor.execute('''
            CREATE TABLE IF NOT EXISTS applications (
                app_id TEXT PRIMARY KEY,
                name TEXT,
                address TEXT,
                qualifications TEXT,
                course TEXT,
                start_date TEXT,
                submission_time TIMESTAMP
            )
        ''')
        connection.commit()
        
    except sqlite3.DatabaseError:
        print("Database Error....")
        if connection:
            connection.rollback()
    finally:
        if connection:
            connection.close()

def generate_application_id():
    year = datetime.datetime.now().year
    rand_num = random.randint(1000, 9999)       #python library for generating random nums
    return f"DBS-{year}-{rand_num}"

def save_application_to_db(app_id, application_data):
    try:
        connection = sqlite3.connect('dbs_admissions.db')
        cursor = connection.cursor()
        cursor.execute('''
            INSERT INTO applications (app_id, name, address, qualifications, course, start_date, submission_time)
            VALUES (?, ?, ?, ?, ?, ?, ?)
        ''', (
            app_id, 
            application_data['name'], 
            application_data['address'], 
            application_data['qualifications'], 
            application_data['course'], 
            application_data['start_date'],
            datetime.datetime.now()
        ))
        
        print("\nRecords are inserted.....") 
        connection.commit() 
        return True   

    except sqlite3.DatabaseError as e:
        print(f"Database Error: {e}")
        connection.rollback()
    finally:
        if connection:
            cursor.close()
            connection.close()      #always in finally block
            print("Database connection closed.")

def start_server():
    host = '127.0.0.1'
    port = 9999
    
    setup_database()
    
    try:
        sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        sock.bind((host, port))
        sock.listen()
        print(f"Server listening on {host}:{port}...")

        while True:
            conn, addr = sock.accept()
            try:
                data = conn.recv(1024)
                application_data = json.loads(data.decode())
                app_id = generate_application_id()
                
                application_ready = save_application_to_db(app_id, application_data)
                
                if application_ready:
                    response = f"Application done with ref num: {app_id}"
                else:
                    response = "Application Failed....."

                conn.sendall(response.encode())
                
            finally:
                conn.close()
                print(f"Connection with {addr} closed....")
                
    except Exception as e:
        print(f"Error: {e}")
    finally:
        sock.close()

if __name__ == "__main__":
    start_server()

    
