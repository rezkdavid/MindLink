import socket

def test_echo_server():
    message = "test message"
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.connect(("localhost", 5555))
        s.sendall(message.encode())
        response = s.recv(1024).decode('utf-8')
        assert response == message, "The server did not echo the message correctly."
        print("Test passed: Server echoed the message correctly.")

if __name__ == "__main__":
    test_echo_server()
