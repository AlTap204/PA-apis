import requests
codigo = int(input("Ingrese codigo postal: "))

url = f"http://localhost/apis/suma.php?codigo={codigo}"

response = requests.get(url)

try:
    responsedata = response.json()
    print(f'El resultado es {responsedata}')
except ValueError:
    print("La respuesta no es un JSON válido.")