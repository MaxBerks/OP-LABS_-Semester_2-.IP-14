class Person:

    def __init__(self, name, birthdate, sex):
        self.name = name
        self.birthdate = birthdate
        self.sex = sex

    def GetName(self):
        return self.name

    def GetBirthDate(self):
        return self.birthdate

    def GetSex(self):
        return self.sex