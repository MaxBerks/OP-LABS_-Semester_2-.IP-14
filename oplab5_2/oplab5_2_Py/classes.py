from abc import ABC, abstractmethod


class TTriad(ABC):

    def __init__(self, num1: int, num2: int, num3: int):
        self.num1 = num1
        self.num2 = num2
        self.num3 = num3

    @abstractmethod
    def IncreaseNum1(self, n):
        pass

    @abstractmethod
    def IncreaseNum2(self, n):
        pass

    @abstractmethod
    def IncreaseNum3(self, n):
        pass

    @abstractmethod
    def DecreaseNum1(self, n):
        pass

    @abstractmethod
    def DecreaseNum2(self, n):
        pass

    @abstractmethod
    def DecreaseNum3(self, n):
        pass

class TTime(TTriad):

    def IncreaseNum1(self, n):
        self.num1 += n

    def IncreaseNum2(self, n):
        for i in range(n):
            self.num2 += 1
            if self.num2 == 60:
                self.num2 = 0
                self.IncreaseNum1(1)


    def IncreaseNum3(self, n):
        for i in range(n):
            self.num3 += 1
            if self.num3 == 60:
                self.num3 = 0
                self.IncreaseNum2(1)

    def DecreaseNum1(self, n):
        self.num1 -= n

    def DecreaseNum2(self, n):
        for i in range(n):
            self.num2 -= 1
            if self.num2 == 0:
                self.num2 = 59
                self.DecreaseNum1(1)

    def DecreaseNum3(self, n):
        for i in range(n):
            self.num3 -= 1
            if self.num3 == 0:
                self.num3 = 59
                self.DecreaseNum2(1)

    def Correction(self, num):
        if num < 10:
            number = '0' + str(num)
        else:
            number = str(num)
        return number

    def Print(self):
        print(f"{self.Correction(self.num1)}:{self.Correction(self.num2)}:{self.Correction(self.num3)}")


class TDate(TTriad):

    def IncreaseNum1(self, n):
        for i in range(n):
            self.num1 += 1
            if self.num1 == 30:
                self.num1 = 0
                self.IncreaseNum2(1)

    def IncreaseNum2(self, n):
        for i in range(n):
            self.num2 += 1
            if self.num2 == 12:
                self.num2 = 0
                self.IncreaseNum3(1)

    def IncreaseNum3(self, n):
        self.num3 += n

    def DecreaseNum1(self, n):
        for i in range(n):
            self.num1 -= 1
            if self.num1 == 0:
                self.num1 = 12
                self.DecreaseNum2(1)

    def DecreaseNum2(self, n):
        for i in range(n):
            self.num2 -= 1
            if self.num2 == 0:
                self.num2 = 12
                self.DecreaseNum3(1)

    def DecreaseNum3(self, n):
        self.num3 -= n

    def Correction(self, num):
        if num < 10:
            number = '0' + str(num)
        else:
            number = str(num)
        return number

    def Print(self):
        print(f"{self.Correction(self.num1)}.{self.Correction(self.num2)}.{self.Correction(self.num3)}")