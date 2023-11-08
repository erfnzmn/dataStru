def hanoi(n,source,middle,target):
    if n==1:
        print(f"Move disk 1 from {source} to {target}")
        return
    hanoi(n-1,source,target,middle)
    print(f"Move disk {n} from {source} to {target}")
    hanoi(n - 1, middle, source, target)
n=int(input("n:"))
hanoi(n,"A","B","C")
