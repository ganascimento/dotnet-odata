# Pock .NET 6 with OData8

## About

This project was developed to test OData and the filter possibilities in the query

## OData

### Filter

| Name                  | Example                                 |
| --------------------- | --------------------------------------- |
| LIKE                  | $filter=contains(Name, '1')             |
| EQUAL                 | $filter=Id eq 2                         |
| NOT EQUAL             | $filter=Id ne 1                         |
| GREATER THAN          | $filter=Id gt 1                         |
| GREATER THAN OR EQUAL | $filter=Id ge 2                         |
| LESS THAN             | $filter=Id lt 1                         |
| LESS THAN OR EQUAL    | $filter=Id le 2                         |
| AND                   | $filter=Id eq 1 and contains(Name, '1') |
| OR                    | $filter=Id eq 1 or contains(Name, '2')  |
| IN                    | $filter=Id in (1,3)                     |

### Select

| Name   | Example         |
| ------ | --------------- |
| Simple | $select=Id,Name |

### Expand

| Name        | Example                                                                |
| ----------- | ---------------------------------------------------------------------- |
| Simple      | $select=Id,Name                                                        |
| With Select | $expand=School($select=Name)                                           |
| Multiple    | $expand=ClassRoom($select=Name;$expand=Teachers($select=Name,Subject)) |

### OrderBy

| Name | Example            |
| ---- | ------------------ |
| ASC  | $orderby=Name asc  |
| DESC | $orderby=Name desc |

### Aggregate

| Name    | Example                                                 |
| ------- | ------------------------------------------------------- |
| COUNT   | $apply=aggregate($count as OrderCount)                  |
| SUM     | $apply=aggregate(SchoolYear with sum as TotalYears)     |
| AVERAGE | $apply=aggregate(SchoolYear with average as TotalYears) |

### Count

```
$count=true
```

### Top

```
$top=10
```

### Skip

```
$skip=5
```

## Execute Project

Run in project folder

```
docker build -t pockodata1 .
docker-compose up
```

Go to appsettings.json
Replace

```
server=database;database=DBPockOData;uid=root;pwd=mysql
```

To

```
server=localhost;database=DBPockOData;uid=root;pwd=mysql
```

Run

```
dotnet ef database update -p .\PockOData.Api\
```

Test by clicking [here](http://localhost:5000/Student)
