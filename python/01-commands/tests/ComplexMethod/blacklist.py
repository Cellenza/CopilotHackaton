import socket
import sys

blackListedIP = [
    "12.5.6.7",
    "192.0.5.1"
]

def get_current_ip_address():
    host_name = socket.gethostname()
    print(host_name)

    # Get the IP from gethostbyname method of socket module.
    return socket.gethostbyname(host_name)

def is_blacklisted(key):
    return key in blackListedIP

def is_whitelisted(key):
    return key == get_current_ip_address()