import requests
numero1 = float(input("Ingresa numero 1: "))
numero2 = float(input("Ingresa numero 2: "))
url = f"http://localhost/apis/suma.php?numero1={numero1}&numero2={numero2}"
response = requests.post(url)
responsedata = response.json()
print (responsedata)
#print (f"El resultado es: {responsedata['result']}")