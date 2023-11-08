def combination(n,r):
    if r == 0 or r == n:
        return 1;
    else:
        return combination(n-1,r-1)+combination(n-1,r)

n = int(input("n:"))
r = int(input("r:"))
result= combination(n,r)
print(f"Combination of ({n},{r}) is {result}")