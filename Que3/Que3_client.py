#CLIENT FILE. Give the info of the application to the serverr
import socket
import json

def get_student_input():
    print("------DBS Admission Application-------")
    print("Please enter the following details:")
    
    name = input("Full Name: ").strip()
    address = input("Address: ").strip()
    qualifications = input("Educational Qualifications: ").strip()
    
    course_choice = input("\nEnter course name (exactly as printed below): ").strip()
    print("\nAvailable Courses:")
    print("MSc in Cyber Security")
    print("MSc Information Systems and Computing")
    print("MSc Data Analytics")
    
    start_year = input("Intended Start Year (YYYY): ").strip()
    start_month = input("Intended Start Month: ").strip()
    
    return {
        "name": name,
        "address": address,
        "qualifications": qualifications,
        "course": course_choice,
        "start_date": f"{start_month}/{start_year}"
    }

def admission_application():
    host = '127.0.0.1'
    port = 9999

    data = get_student_input()
    
    #some validations
    if not data['name'] or not data['course']:
        print("Error: Name and Course are mandatory fields.")
        return
    elif not data["course"] == "MSc in Cyber Security" and not data["course"] == "MSc Information Systems and Computing" and not data["course"] == "MSc Data Analytics":
        print("Error: Please enter a valid course")
        return

    try:
        print("\nConnecting to Server.....")
        
        sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        sock.connect((host, port))
        print("Client connected with server.......")
        
        #convert into json
        data = json.dumps(data)
        sock.sendall(data.encode())
        
        #print the ID
        resp = sock.recv(1024)
        print("\nSERVER response:")
        print(resp.decode())

    except ConnectionError:
        print("Error: Could not connect to the server........")
        sock.close()
    except Exception as e:
        print(f"An unexpected error occurred: {e}")
        sock.close()
    finally:
        sock.close()
        print("Connection closed.")

if __name__ == "__main__":
    admission_application()


    