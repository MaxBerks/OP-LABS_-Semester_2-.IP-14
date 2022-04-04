from modules import *
#створення назв файлів
input_path = "input.txt"
voenkom_path = "voenkom.txt"
del35_path = "del35.txt"
#  створення файла зі списком абітурієнтів
InitEntities(input_path)
people = GetFromFile(input_path)
OutputPeople(people, "Here are people from input file:")
#видалення зі списку абітурієнтів старших 35 років та занесення до нового файлу
peopleunder35 = Del35(people)
OutputPeople(peopleunder35, "Here are people under 35:")
WritePeopleToFile(peopleunder35, del35_path, "wb")
#створення файлу зі списком абітурієнтів призивного віку
peoplevoenkom = Voenkom(peopleunder35)
OutputPeople(peoplevoenkom, "Here are people who needs to go to voenkom:")
WritePeopleToFile(peoplevoenkom, voenkom_path, "wb")
#перевірка
print("Checking files...\n")
peopleunder35new = GetFromFile(del35_path)
OutputPeople(peopleunder35new, "From file del35:")
peoplevoenkomnew = GetFromFile(voenkom_path)
OutputPeople(peoplevoenkomnew, "From file voenkom:")









