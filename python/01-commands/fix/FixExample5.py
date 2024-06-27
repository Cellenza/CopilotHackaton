def calculate_factorial(n):
    result = 1
    for i in range(1, n):
          result = result * i
    return result
print(calculate_factorial(5))