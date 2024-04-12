import socket
import threading

def handle_client(connection, address):
    print(f"Connection from {address} has been established.")
    
    while True:
        message = connection.recv(1024).decode('utf-8')
        if not message:
            break
        print(f"Received from {address}: {message}")
        # Echo back the received message
        connection.sendall(message.encode())
    
    connection.close()

def start_server():
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.bind(('0.0.0.0', 5555))  # Listen on all network interfaces, port 5555
    server.listen()
    print("Echo server listening on port 5555...")
    
    while True:
        conn, addr = server.accept()
        thread = threading.Thread(target=handle_client, args=(conn, addr))
        thread.start()
        print(f"[ACTIVE CONNECTIONS] {threading.activeCount() - 1}")

if __name__ == "__main__":
    start_server()
