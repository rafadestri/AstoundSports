# Astound Sports

Repository for Astound chalenge

In this project I tried to accomplish all the request for the chalenge.
I made this based on an exercise from a book I'm reading. 
There are some considerations and things I would make different, with more time, such as:

- Move the logic code from controllers to a business layer
- Add unit tests
- Move validation logic from entities to DTOs 
- Add Open API documentation
- Improve the sports with an undetermined duration, like VolleyBall
- Add logic to handle subtypes of sport, like marathon.

On the screenshots below you can check the request/response from postman on all endpoints. 

## Sports

**Create a sport** `curl --location --request POST 'https://localhost:5001/api/sports' \
--header 'Content-Type: application/json' \
--data-raw '{
    "name": "Swimming",
    "caloriesBurntByMinute": 40,
    "duration": 0,
    "numberOfPlayers": 1
}'`
![image](https://user-images.githubusercontent.com/24480945/162099338-8da7de66-49fc-44a7-8c90-90470459c9f9.png)

**Get All Sports** `curl --location --request GET 'https://localhost:5001/api/sports'`
![image](https://user-images.githubusercontent.com/24480945/162097810-b732b1b9-ea41-41a4-a49b-46632bb4d634.png)

**Get a given sport** `curl --location --request GET 'https://localhost:5001/api/sports/{sportId}'`
![image](https://user-images.githubusercontent.com/24480945/162098704-9692ead3-6d17-4e5b-b7d5-ee6334651a13.png)

**Update a whole sport with PUT** `curl --location --request PUT 'https://localhost:5001/api/sports/{sportId}' \
--header 'Content-Type: application/json' \
--data-raw '{
    "name": "Female VoleyBall",
    "caloriesBurntByMinute": 15,
    "duration": 0,
    "numberOfPlayers": 12
}'`
![image](https://user-images.githubusercontent.com/24480945/162098904-814e4f05-e9cb-4647-a6d0-6c9a2870cf49.png)

**Update a single sport property with PATCH** `curl --location --request PATCH 'https://localhost:5001/api/sports/{sportId}' \
--header 'Content-Type: application/json' \
--data-raw '[
    {
        "op" : "replace",
        "path": "/numberOfPlayers",
        "value" : "12"
    }
]'`
![image](https://user-images.githubusercontent.com/24480945/162099096-3c155435-7e6c-4718-8c03-0a8c81601592.png)

**Delete a sport** `curl --location --request DELETE 'https://localhost:5001/api/sports/{sportId}'`
![image](https://user-images.githubusercontent.com/24480945/162099195-32f5f9c7-14e6-4c85-b168-9915d27ab104.png)

## Athletes

**Create an athlete** `curl --location --request POST 'https://localhost:5001/api/athletes' \
--header 'Content-Type: application/json' \
--data-raw '{
    "name": "Rafael",
    "surname": "Destri",
    "maximumCalories": 100,
    "age": 40,
    "country": "BR"
}'`
![image](https://user-images.githubusercontent.com/24480945/162103330-59ac5144-d3f8-45ed-a9be-9ba401dc9ca2.png)

**Get All Athletes** `curl --location --request GET 'https://localhost:5001/api/athletes'`
![image](https://user-images.githubusercontent.com/24480945/162103398-6e2b88d1-1a01-4dac-bbc3-216249cd797d.png)

**Get a given athlete detail** `curl --location --request GET 'https://localhost:5001/api/athletes/{athleteId}'`
![image](https://user-images.githubusercontent.com/24480945/162103500-58a93cde-43d3-4294-ba9e-e0a7287b6f03.png)

**Update a whole sport with PUT** `curl --location --request PUT 'https://localhost:5001/api/athletes/{athleteId}' \
--header 'Content-Type: application/json' \
--data-raw '    {
        "age": 30,
        "burntCalories": 0,
        "country": "BR",
        "name": "Audrey",
        "surname" : "Audrey",
        "id": "f049f5a6-e1f4-4300-8f54-a44b63831a37",
        "maximumCalories": 1000
    }'`
![image](https://user-images.githubusercontent.com/24480945/162103691-50a2049c-f0d8-4b3e-b825-5dd2e7d31dc0.png)

**Update a single athlete property with PATCH** `curl --location --request PATCH 'https://localhost:5001/api/athletes/{athleteId}' \
--header 'Content-Type: application/json' \
--data-raw '[
    {
        "op" : "replace",
        "path": "/maximumCalories",
        "value" : "250"
    }
]'`
![image](https://user-images.githubusercontent.com/24480945/162103788-85507124-f346-4d15-8f0a-a484e524893a.png)

**Delete an athlete** `curl --location --request DELETE 'https://localhost:5001/api/athletes/{athleteId}'`
![image](https://user-images.githubusercontent.com/24480945/162103881-616c8317-0122-42ce-9dc8-57818ae7048d.png)

**Get burnt calories for a given athlete on a given sport** `curl --location --request GET 'https://localhost:5001/api/athletes/{athleteId}/burntCalories/{sportId}'`
![image](https://user-images.githubusercontent.com/24480945/162104375-de7c2cad-84e1-4d98-931b-395b773c7494.png)

**check if a given athlete can practice a given sport** `curl --location --request GET 'https://localhost:5001/api/athletes/{athleteId}/canPractice/{sportId}'`
![image](https://user-images.githubusercontent.com/24480945/162104612-e929541a-a981-44ef-9581-11186d676140.png)
