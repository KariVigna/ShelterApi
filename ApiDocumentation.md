### Animal Shelter Api Endpoints

### GET /api/pets
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>GET</td>
        <td>/api/pets</td>
        <td>Returns an array containing all pet objects in the database.</td>
        <td>200: Ok</td>
      </tr>
</table>

Expected Response:
```json
[
  {
    "petId": 1,
    "name": "Leonard",
    "species": "Ball Python",
    "age": 2
  },
  {
    "petId": 2,
    "name": "Strawberry",
    "species": "Tarantula",
    "age": 3
  }
]
```

### GET /api/Pets *with optional query parameters
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>Optional URL Parameters</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>GET</td>
        <td>/api/AnimPetsals?[PARAMETER NAME]=[PARAMETER VALUE]</td>
        <td>name (string) <br> species (string) <br> minimumAge (integer)</td>
        <td>Returns an array containing all pet objects in the database that match the included parameters, multiple parameters may be included.</td>
        <td>200: Ok</td>
      </tr>
</table>

Example Request URL: `GET /api/Pets?species=Tarantula&name=Strawberry&minimumAge=1`

Expected Response:

```json
[
 {
    "animalId": 2,
    "name": "Strawberry",
    "species": "Tarantula",
    "age": 3
  }
]
```

### GET /api/Pets/{id}
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>URL Parameter *required</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>GET</td>
        <td>/api/Pets/{id}</td>
        <td>id (int)</td>
        <td>Returns a JSON object representing a pet with a "petId" property that matches the "id" provided as a URL parameter.</td>
        <td>200: Ok</td>
      </tr>
</table>

Example Request URL: `GET /api/Pets/1`

Expected Response: 

```json
  {
    "petId": 1,
    "name": "Leonard",
    "species": "Ball Python",
    "age": 2
  },
```

### POST /api/Pets
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>Request Body *required</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>POST</td>
        <td>/api/Pets</td>
        <td>A JSON object containing key-value pairs for: <br> - name(string), <br> - species(string), <br> - age(int) <br> - petId(int) may be included but regardless of the value provided, it's value will be set by the database when the record is saved.</td>
        <td>Creates a new Pet object in the database.</td>
        <td>201: Created</td>
      </tr>
</table>

Example Request Body *required:

```json
  {
    "name": "Leonard",
    "species": "Ball Python",
    "age": 2
  }
```

Expected Response:

```json
  {
    "animalId": 100,
    "name": "Leonard",
    "species": "Ball Python",
    "age": 2
  }
```

### PUT /api/Pets/{id}
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>URL Parameter *required</th>
        <th>Request Body *required</th>
        <th>Expected Response</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>PUT</td>
        <td>/api/Pets/{id}</td>
        <td>id (int)</td>
        <td>A JSON object containing key-value pairs for: <br> - petId(int) <br> - name(string), <br> - species(string), <br> - age(int) <br> *Note that the "petId" must match the "id" provided as a URL parameter.</td>
        <td>No content</td>
        <td>204: No Content</td>
      </tr>
</table>

Example Request Body *required:

```json
  {
    "animalId": 100,
    "name": "Leonard",
    "species": "Ball Python",
    "age": 2
  }
```

### DELETE /api/Pets/{id}
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>URL Parameter *required</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>DELETE</td>
        <td>/api/Pets/{id}</td>
        <td>id (int)</td>
        <td>Deletes a pet from the database.</td>
        <td>204: No Content</td>
      </tr>
</table>