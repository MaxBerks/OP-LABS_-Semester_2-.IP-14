import pickle
from datetime import date
from Person import Person

def OutputPeople(people: list, prompt: str):
    print(prompt)

    for person in people:
        print("Person:", person.name, person.birthdate, person.sex)

    print()

def WritePeopleToFile(people: list, path: str, mode: str):
    with open(path, mode) as file:
        for person in people:
            pickle.dump(person, file)

def GetFromFile(path: str):
    people = []

    with open(path, "rb") as file:
        while True:
            try:
                people.append(pickle.load(file))
            except EOFError:
                break

    return people

def InitEntities(path: str):
    people = [
        Person("Ivan36", "1986-04-11", "male"),
        Person("Ivan34-35", "1987-04-05", "male"),
        Person("Nik", "2004-04-04", "male"),
        Person("Max17", "2004-05-17", "male"),
        Person("Den34", "1988-04-11", "male"),
        Person("Lucy22", "2000-04-11", "female")
    ]
    WritePeopleToFile(people, path, "wb")

def Del35(people: list):
    newpeople = []
    for person in people:
        personbirthdate_list = person.birthdate.split('-')
        personbirthdate = date(int(personbirthdate_list[0]), int(personbirthdate_list[1]), int(personbirthdate_list[2]))
        age = (date.today() - personbirthdate) / 365.242199
        age = age.days
        if age < 35:
            newpeople.append(person)

    return newpeople

def Voenkom(people: list):
    newpeople = []
    for person in people:
        personbirthdate_list = person.birthdate.split('-')
        personbirthdate = date(int(personbirthdate_list[0]), int(personbirthdate_list[1]), int(personbirthdate_list[2]))
        age_temp = (date.today() - personbirthdate)
        age_temp = age_temp / 365.2
        age = age_temp.days
        if age > 17 and age < 28 and person.GetSex() == "male":
            newpeople.append(person)
    return newpeople
