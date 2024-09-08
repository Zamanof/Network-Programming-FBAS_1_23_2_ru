import socket

buffer_size = 1024
msg = ''

UDP_client_socket = socket.socket(family=socket.AF_INET, type=socket.SOCK_DGRAM)
UDP_client_socket.bind(('127.0.0.1', 27001))

print("UDP client listening")
while True:
    bytes_addressPair = UDP_client_socket.recvfrom(buffer_size)
    msg = bytes_addressPair[0]
    address = bytes_addressPair[1]
    print(msg.decode('utf-8'), end='')
