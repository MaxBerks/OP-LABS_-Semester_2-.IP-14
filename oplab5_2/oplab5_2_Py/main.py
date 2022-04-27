import random

from classes import TDate, TTime

def Dates(n):
    print("======================================= Dates =======================================")

    for i in range(n):
        date = TDate(random.randint(1, 30), random.randint(1, 12), random.randint(1, 100))
        date.Print()
        if date.num1 <= 23 and date.num2 <= 59 and date.num3 <= 59:
            print("isTime\n")
        else:
            date.DecreaseNum1(5)
            date.Print()
            print("\n")

def Time(m):
    print("======================================= Time =======================================")

    for i in range(m):
        time = TTime(random.randint(0, 23), random.randint(1, 59), random.randint(1, 59))
        time.Print()
        time.IncreaseNum2(15)
        time.Print()
        print("\n")

n = random.randint(3, 7)
m = random.randint(3, 7)

Dates(n)
Time(m)




