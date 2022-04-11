import os
import hashlib


binary_values = []
for filename in os.listdir('task2'):
    with open('task2/'+filename, 'rb') as frb:
        data = frb.read()
        binary_values.append(hashlib.sha3_256(data).hexdigest())

binary_values.sort()
res = ''.join(binary_values) + 'pavel.takunov@mail.ru'
print(hashlib.sha3_256(str.encode(res)).hexdigest())