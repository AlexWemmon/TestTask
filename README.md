# Инструкция
#### Для запуска проекта проверяем два пункта:
##### **1)** В папке **Migrations** проекта **BookAPI** есть нужные миграции (см. скрин ниже).

![image](https://user-images.githubusercontent.com/47531968/198840527-37c81456-be28-4173-b8b1-09a7f32074cd.png)

Если представленных файлов там нет, то в VS Studio переходим по следующему пути: **Меню -> Вид -> Другие окна -> Консоль диспетчера пакетов**:<br>
![image](https://user-images.githubusercontent.com/47531968/198840717-e21e3cbd-13fd-45a0-82c6-3f27d596dd5c.png)

Там прописываем следующие строчки по очереди, вторую команду только после сообщения об успешном применении первой:<br>
**add-migration initial -project BookAPI
update-database -project BookAPI**<br>
##### **2) Проверяем параметры запуска:**
Правой кнопкой мыши нажимаем на **Решение**, выбираем пункт **Свойства**.<br>
![image](https://user-images.githubusercontent.com/47531968/198841113-2ad3bd6e-0cbd-4e83-8543-1aff63495904.png)<br>
Проверяем следующие настройки, если у вас не так, то выставляем:<br>
![image](https://user-images.githubusercontent.com/47531968/198841233-1cbf38a6-4713-49b0-b690-61fd666b1961.png)<br>
Свойства проекта **BookAPI** должны быть следующими:<br>
![image](https://user-images.githubusercontent.com/47531968/198841383-fa27eccd-62a4-4fec-a491-8744bc2d375d.png)<br>
Свойства проекта **StoreApp** должны быть следующими:<br>
![image](https://user-images.githubusercontent.com/47531968/198841448-503b136f-09c1-4699-a0ac-ef4c398fcaf4.png)<br>
##### Можно запускать и пользоваться!
