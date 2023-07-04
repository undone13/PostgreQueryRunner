# PostgreQueryRunner

Fisierul de intrare se numeste mereu "input.json" si trebuie sa se afle in folder cu aplicatia 

Model + exemplu json

`{
    "appsettings": {
        "host" : "localhost",
        "port": "5432",
        "dbname": "postgres",
        "username": "postgres",
        "password": "postgres"
    },
    "queries": [
        "DELETE FROM public.\"tabelTest\"",
        "INSERT INTO public.\"tabelTest\"(nume, prenume, adresa, telefon, cnp) VALUES ('Bogdan1', 'Ichim', 'Perisoru Calarasi', '0733463369', '50204013511139')",
        "INSERT INTO public.\"tabelTest\"(nume, prenume, adresa, telefon, cnp) VALUES ('Bogdan2', 'Ichim', 'Perisoru Calarasi', '0733463369', '50204013511139')",
        "DELETE FROM public.\"tabelTest\" WHERE nume = 'Bogdan1'"
    ]
}`
