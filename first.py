def power(base , exponent):
    if exponent == 0:
        return 1
    elif exponent < 0:
        return 1 / power(base,-exponent)
    else:
        return base*power(base,exponent-1)

base = int(input("Base:"))
exponent = int(input("Exponent:"))

result=power(base , exponent)
print(result)

