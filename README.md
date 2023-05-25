# Вопрос 2
В задании описана связь между таблица многие ко многим, которая устанавливает через дополнительную таблицу, поэтому имеем следующие таблицы:  
Product (Id, Name)  
Category (Id, Name)  
ProductCategory (ProductId, CategoryId)  


Для выбора всех пар «Имя продукта – Имя категории» нужно выполнить следующий запрос.
``` sql
      SELECT p.Name,
             c.Name
      FROM Products p
           LEFT JOIN ProductCategory pc ON p.Id = pc.ProductId
           LEFT JOIN Category c ON pc.CategoryId = c.Id
```
